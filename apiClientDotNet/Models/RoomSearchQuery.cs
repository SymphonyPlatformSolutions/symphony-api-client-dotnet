using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class RoomSearchQuery
    {
        [JsonProperty("query")]
        private String query { get; set; }

        [JsonProperty("labels")]
        private List<String> labels { get; set; }

        [JsonProperty("active")]
        private Boolean active { get; set; }

        [JsonProperty("isPrivate")]
        private Boolean isPrivate { get; set; }

        [JsonProperty("creator")]
        private NumericId creator { get; set; }

        [JsonProperty("owner")]
        private NumericId owner { get; set; }

        [JsonProperty("member")]
        private NumericId member { get; set; }
    }
}
