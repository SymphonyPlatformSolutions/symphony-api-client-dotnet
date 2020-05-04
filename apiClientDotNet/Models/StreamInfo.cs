using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class StreamInfo
    {

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("crossPod")]
        public Boolean crossPod { get; set; }

        [JsonProperty("origin")]
        public string origin { get; set; }
        
        [JsonProperty("active")]
        public Boolean active { get; set; }

        [JsonProperty("lastMessageDate")]
        public long lastMessageDate { get; set; }

        [JsonProperty("streamType")]
        public StreamType streamType { get; set; }

        [JsonProperty("streamAttributes")]
        public StreamAttributes streamAttributes { get; set; }

        [JsonProperty("roomAttributes")]
        public RoomName roomAttributes { get; set; }
    }
}
