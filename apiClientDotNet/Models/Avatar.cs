using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class Avatar
    {
        [JsonProperty("size")]
        public string size{ get; set; }

        [JsonProperty("url")]
        public string url { get; set; }
    }
}
