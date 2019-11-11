using System.IO;
using System.Threading.Tasks;

namespace NetMicro.Routing.Binding
{
    public interface IContentParser
    {
        Task<TContent> Parse<TContent>(Stream stream);
    }
}