using System;
using Newtonsoft.Json;

namespace NetMicro.ErrorHandling
{
    public class ErrorResponse
    {
        [JsonProperty("status", Required = Required.Always)]
        public int Status;

        [JsonProperty("error", Required = Required.Always)]
        public string Error;

        [JsonProperty("parameters", Required = Required.Always)]
        public string[] Parameters = new string[0];

        [JsonProperty("exception")] public Exception Exception;
    }
}