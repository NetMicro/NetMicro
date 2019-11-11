using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NetMicro.Routing.Binding
{
    public class JsonContentParser : IContentParser
    {
        public async Task<TContent> Parse<TContent>(Stream stream)
        {
            try
            {
                using var sr = new StreamReader(stream);
                return JsonConvert.DeserializeObject<TContent>(await sr.ReadToEndAsync());
            }
            catch (JsonSerializationException e)
            {
                throw new ValidationException("Error during parsing JSON data.", e);
            }
        }
    }
}