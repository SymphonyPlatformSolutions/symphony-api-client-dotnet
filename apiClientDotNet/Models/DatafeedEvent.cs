using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using apiClientDotNet.Models.Events;

namespace apiClientDotNet.Models
{
    public class DatafeedEvent
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("timestamp")]
        public long timestamp { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("initiator")]
        public Initiator initiator { get; set; }

        [JsonProperty("diagnostic")]
        public string diagnostic { get; set; }

        [JsonProperty("payload")]
        public EventPayload payload { get; set; }

    }
}
