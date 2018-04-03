using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class AuthTokens
    {
        [JsonProperty("sessionToken")]
        public string sessionToken { get; set; }

        [JsonProperty("keyManagerToken")]
        public string keyManagerToken { get; set; }
    }
}
