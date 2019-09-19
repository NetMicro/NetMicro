using System;
using System.Linq;
using System.Text.RegularExpressions;
using NetMicro.Http;

namespace NetMicro.Routing
{
    public class Route : IRoute, IMiddleware
    {
        private static readonly Regex ParamRegex = new Regex(@":(?<name>[A-Za-z0-9_]*)", RegexOptions.Compiled);
        private readonly RouteFuncAsync _handlerFunc;
        private readonly string _method;
        private readonly MiddlewareManager _middlewareManager;
        private readonly string _name;
        private readonly Regex _regex;
        private readonly string _route;


        internal Route(string method, string name, string route, RouteFuncAsync handlerFunc)
        {
            _middlewareManager = new MiddlewareManager();

            _method = method;
            _name = name;
            _route = route;
            _handlerFunc = handlerFunc;

            _regex = RouteToRegex(route);
        }

        public void Use(RouteFuncAsyncMiddleware middlewareFunc)
        {
            _middlewareManager.Use(middlewareFunc);
        }

        public IRequestHandler GetRequestHandler(Request request, IResponse response)
        {
            return Match(request)
                ? new MiddlewareRequestHandler(_middlewareManager.GetRuntime(_handlerFunc),
                    GetContext(request, response))
                : null;
        }

        private Context GetContext(Request request, IResponse response)
        {
            var path = GetPath(request);

            var groups = _regex.Match(path).Groups;
            var uriParams = _regex.GetGroupNames()
                .ToDictionary(groupName => groupName, groupName => groups[groupName].Value);

            return new Context(new SelectedRoute(_name, _route, uriParams), request, response);
        }

        private bool Match(Request request)
        {
            var path = GetPath(request);

            return _method == request.Method && _regex.IsMatch(path);
        }

        private static Regex RouteToRegex(string route)
        {
            var parts = route.Split(new[] {"/"}, StringSplitOptions.RemoveEmptyEntries);

            parts = parts.Select(part => !ParamRegex.IsMatch(part)
                ? part
                : string.Join("",
                    ParamRegex.Matches(part)
                        .Where(match => match.Success)
                        .Select(match => $"(?<{match.Groups["name"].Value.Replace(".", @"\.")}>.+?)"
                        )
                )
            ).ToArray();

            var pattern = parts.Any()
                ? "^/" + string.Join("/", parts) + "$"
                : "^$";

            return new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        private static string GetPath(Request context)
        {
            var path = context.Path;
            if (path.EndsWith("/"))
                path = path.TrimEnd('/');
            return path;
        }
    }
}