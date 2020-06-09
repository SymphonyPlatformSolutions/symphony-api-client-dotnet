using System;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class Signal
    {
        [JsonProperty("id")]
        public String id { get; set; }

        [JsonProperty("name")]
        public String name { get; set; }

        [JsonProperty("query")]
        public String query { get; set; }

        [JsonProperty("timestamp")]
        public long timestamp { get; set; }

        [JsonProperty("companyWide")]
        public Boolean companyWide { get; set; }

        [JsonProperty("visibleOnProfile")]
        public Boolean visibleOnProfile { get; set; }
    }
}
