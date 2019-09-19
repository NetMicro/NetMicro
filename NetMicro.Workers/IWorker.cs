namespace NetMicro.Workers
{
    public interface IWorker
    {
        void Start();
        void Stop();
        bool IsEnabled { get; }
    }
}