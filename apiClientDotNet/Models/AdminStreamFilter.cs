using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class AdminStreamFilter
    {
        [JsonProperty("streamTypes")]
        public List<String> streamTypes { get; set; }

        [JsonProperty("scope")]
        public String scope { get; set; }

        [JsonProperty("origin")]
        public String origin { get; set; }

        [JsonProperty("status")]
        public String status { get; set; }

        [JsonProperty("privacy")]
        public String privacy { get; set; }

        [JsonProperty("startDate")]
        public long startDate { get; set; }

        [JsonProperty("endDate")]
        public long endDate { get; set; }
    }
}
