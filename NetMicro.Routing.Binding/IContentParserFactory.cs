namespace NetMicro.Routing.Binding
{
    public interface IContentParserFactory
    {
        string ContentType { get; }
        IContentParser GetParser();
    }
}