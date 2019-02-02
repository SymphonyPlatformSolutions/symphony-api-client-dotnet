using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class AdminStreamFilter
    {
        [JsonProperty("streamTypes")]
        private List<String> streamTypes { get; set; }

        [JsonProperty("scope")]
        private String scope { get; set; }

        [JsonProperty("origin")]
        private String origin { get; set; }

        [JsonProperty("status")]
        private String status { get; set; }

        [JsonProperty("privacy")]
        private String privacy { get; set; }

        [JsonProperty("startDate")]
        private long startDate { get; set; }

        [JsonProperty("endDate")]
        private long endDate { get; set; }
    }
}
