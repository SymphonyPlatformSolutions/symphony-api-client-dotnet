using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class StreamListItem
    {
        [JsonProperty("id")]
        public String id { get; set; }

        [JsonProperty("crossPod")]
        public Boolean crossPod { get; set; }

        [JsonProperty("active")]
        public Boolean active { get; set; }

        [JsonProperty("streamType")]
        public TypeObject streamType { get; set; }

        [JsonProperty("streamAttributes")]
        public StreamAttributes streamAttributes { get; set; }

        [JsonProperty("roomAttributes")]
        public RoomName roomAttributes { get; set; }

    }
}
