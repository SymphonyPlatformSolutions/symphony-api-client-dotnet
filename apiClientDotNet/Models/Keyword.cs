using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class keyword
    {
        [JsonProperty("key")]
        public string key { get; set; }

        [JsonProperty("value")]
        public long value { get; set; }
    }
}
