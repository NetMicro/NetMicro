using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace NetMicro.Queues.Kafka
{
    public class Consumer<TMessage> : IConsumer<TMessage>, IDisposable
    {
        private readonly Collection<CancellationTokenSource> _cancellationTokenSources =
            new Collection<CancellationTokenSource>();

        private readonly ConsumerConfig _config;

        public Consumer(ConsumerConfig config)
        {
            _config = config;
        }

        public async Task Register(string topic, MessageReceived<TMessage> messageReceived)
        {
            await Task.Run(() =>
            {
                using (var c = new ConsumerBuilder<Ignore, TMessage>(_config).Build())
                {
                    c.Subscribe(topic);

                    var cts = new CancellationTokenSource();
                    _cancellationTokenSources.Add(cts);

                    try
                    {
                        while (true)
                        {
                            try
                            {
                                var cr = c.Consume(cts.Token);
                                messageReceived(cr.Value);
                            }
                            catch (ConsumeException e)
                            {
                                throw new ConsumerQueueException(e);
                            }
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        c.Close();
                    }
                }
            });
        }

        public void Dispose()
        {
            foreach (var cancellationTokenSource in _cancellationTokenSources)
                cancellationTokenSource.Cancel();
        }
    }
}