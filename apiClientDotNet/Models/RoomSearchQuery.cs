using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel;

namespace apiClientDotNet.Models
{
    public class RoomSearchQuery
    {
        [JsonProperty("query")]
        public String query { get; set; }

        [JsonProperty("labels")]
        public List<String> labels { get; set; }

        [JsonProperty("active")]
        public Boolean? active { get; set; }

        [JsonProperty("private")]
        public Boolean? isPrivate { get; set; }

        [JsonProperty("creator")]
        public NumericId creator { get; set; }

        [JsonProperty("owner")]
        public NumericId owner { get; set; }

        [JsonProperty("member")]
        public NumericId member { get; set; }
    }
}
