namespace NetMicro
{
    public interface IStartupAction
    {
        void Execute();

        /// <summary>
        /// Startup actions are run in priority order. Lowest priority value is run first.
        /// </summary>
        int Priority { get; }
    }
}