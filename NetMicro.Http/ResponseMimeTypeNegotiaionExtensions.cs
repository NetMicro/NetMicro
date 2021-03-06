using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;

namespace NetMicro.Http
{
    public static class ResponseMimeTypeNegotiationExtensions
    {
        public static IEnumerable<string> GetResponseMimeTypesPriority(this Request request, string[] supported = null)
        {
            var mimeTypes = new List<string>();
            if (request.Headers.ContainsKey("Accept") && request.Headers["Accept"].Any(IsNotAllowAll))
                foreach (var accept in request.Headers["Accept"].Where(IsNotAllowAll))
                    mimeTypes.AddRange(accept.Split(","));
            else if (request.Headers.ContainsKey("Content-Type"))
                mimeTypes.AddRange(request.GetMimeTypes());

            return supported != null
                ? mimeTypes.Where(supported.Contains).ToArray()
                : mimeTypes.ToArray();
        }

        private static bool IsNotAllowAll(string contentType)
        {
            return contentType != "*/*";
        }

        public static IEnumerable<string> GetMimeTypes(this Request request)
        {
            return request.Headers["Content-Type"].Select(GetMimeType);
        }

        private static string GetMimeType(string contentType)
        {
            return new ContentType(contentType).MediaType;
        }
    }
}