using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class StreamListItem
    {
        [JsonProperty("id")]
        private String id { get; set; }

        [JsonProperty("crossPod")]
        private Boolean crossPod { get; set; }

        [JsonProperty("active")]
        private Boolean active { get; set; }

        [JsonProperty("streamType")]
        private TypeObject streamType { get; set; }

        [JsonProperty("streamAttributes")]
        private StreamAttributes streamAttributes { get; set; }

        [JsonProperty("roomAttributes")]
        private RoomName roomAttributes { get; set; }

    }
}
