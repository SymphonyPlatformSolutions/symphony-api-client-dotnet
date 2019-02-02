using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class InboundShare
    {
        [JsonProperty("id")]
        public String id { get; set; }

        [JsonProperty("timestamp")]
        public long timestamp { get; set; }

        [JsonProperty("v2messageType")]
        public String v2messageType { get; set; }

        [JsonProperty("streamId")]
        public String streamId { get; set; }

        [JsonProperty("message")]
        public String message { get; set; }

        [JsonProperty("userId")]
        public long userId { get; set; }
    }
}
