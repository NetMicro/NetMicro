using System.IO;

namespace NetMicro.Routing.Binding
{
    public interface IContentParser
    {
        TContent Parse<TContent>(Stream stream);
    }
}