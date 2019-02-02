using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class RoomSearchResult
    {
        [JsonProperty("count")]
        private int count { get; set; }

        [JsonProperty("skip")]
        private int skip { get; set; }

        [JsonProperty("limit")]
        private int limit { get; set; }

        [JsonProperty("query")]
        private RoomSearchQuery query { get; set; }

        [JsonProperty("rooms")]
        private List<RoomInfo> rooms { get; set; }

    }
}
