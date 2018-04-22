using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class Token
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("token")]
        public string token { get; set; }
    }
}
