using System.ComponentModel.DataAnnotations;
using System.IO;
using Newtonsoft.Json;

namespace NetMicro.Routing.Binding
{
    public class JsonContentParser : IContentParser
    {
        public TContent Parse<TContent>(Stream stream)
        {
            try
            {
                using (var sr = new StreamReader(stream))
                {
                    return JsonConvert.DeserializeObject<TContent>(sr.ReadToEnd());
                }
            }
            catch (JsonSerializationException e)
            {
                throw new ValidationException("Error during parsing JSON data.", e);
            }
        }
    }
}