namespace NetMicro
{
    public interface IDevelopmentConfiguration
    {
        bool DisableSecurity { get; }
        bool ErrorHandling { get; }
    }
}