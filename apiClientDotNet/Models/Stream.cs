using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class Stream
    {
        [JsonProperty("streamId")]
        public string streamId { get; set; }

        [JsonProperty("streamType")]
        public string streamType { get; set; }

        [JsonProperty("roomName")]
        public string roomName { get; set; }

        [JsonProperty("members")]
        public List<User> members { get; set; }

        [JsonProperty("external")]
        public bool external { get; set; }

        [JsonProperty("crossPod")]
        public bool crossPod { get; set; }

    }
}
