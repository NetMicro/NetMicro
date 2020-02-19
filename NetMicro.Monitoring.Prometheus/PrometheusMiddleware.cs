using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using NetMicro.Routing;
using Prometheus;

namespace NetMicro.Monitoring.Prometheus
{
    public static class PrometheusMiddleware
    {
        private static readonly Dictionary<string, Gauge> Gauges = new Dictionary<string, Gauge>();
        private static readonly Dictionary<string, Counter> Counters = new Dictionary<string, Counter>();
        private static readonly Dictionary<string, Histogram> Histograms = new Dictionary<string, Histogram>();

        private static readonly object GaugesMutex = new object();
        private static readonly object CountersMutex = new object();
        private static readonly object HistogramsMutex = new object();

        private static Counter GetCounter(string name)
        {
            lock (CountersMutex)
            {
                if (Counters.ContainsKey(name))
                    return Counters[name];

                return Counters[name] = Metrics.CreateCounter(
                    name,
                    name + " routing request count",
                    new CounterConfiguration
                    {
                        LabelNames = new[] {"endpoint"}
                    }
                );
            }
        }

        private static Gauge GetGauge(string name)
        {
            lock (GaugesMutex)
            {
                if (Gauges.ContainsKey(name))
                    return Gauges[name];

                return Gauges[name] = Metrics.CreateGauge(
                    name,
                    name + " routing pending requests",
                    new GaugeConfiguration
                    {
                        LabelNames = new[] {"endpoint"}
                    }
                );
            }
        }

        public static void EnablePrometheusMonitoring(this IRouter router,
            IPrometheusMonitoringConfiguration prometheusMonitoringConfiguration)
        {
            if (!prometheusMonitoringConfiguration.Enabled)
                return;

            router.Use(async (context, next) =>
            {
                try
                {
                    GetCounter(GetMetricName(context, "count")).Inc();
                    var pending = GetGauge(GetMetricName(context, "pending"));
                    pending.Inc();

                    await next(context);

                    pending.Dec();
                    GetCounter(GetMetricName(context, context.Response.StatusCode + "_count")).Inc();
                }
                catch (Exception)
                {
                    GetCounter(GetMetricName(context, "error_count")).Inc();
                    throw;
                }
            });
        }

        private static string GetMetricName(Context context, string type)
        {
            return (string.IsNullOrEmpty(context.SelectedRoute.RouteName)
                       ? "hash_" + GetMd5Hash(context.SelectedRoute.RoutePath)
                       : context.SelectedRoute.RouteName) + "_" + type;
        }

        private static string GetMd5Hash(string input)
        {
            using (var md5Hash = MD5.Create())
            {
                var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                var sBuilder = new StringBuilder();

                foreach (var dataPart in data)
                    sBuilder.Append(dataPart.ToString("x2"));

                return sBuilder.ToString();
            }
        }
    }
}