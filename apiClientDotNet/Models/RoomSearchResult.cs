using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class RoomSearchResult
    {
        [JsonProperty("count")]
        public int count { get; set; }

        [JsonProperty("skip")]
        public int skip { get; set; }

        [JsonProperty("limit")]
        public int limit { get; set; }

        [JsonProperty("query")]
        public RoomSearchQuery query { get; set; }

        [JsonProperty("rooms")]
        public List<RoomInfo> rooms { get; set; }

    }
}
