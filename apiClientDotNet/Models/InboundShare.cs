using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class InboundShare
    {
        [JsonProperty("id")]
        private String id { get; set; }

        [JsonProperty("timestamp")]
        private long timestamp { get; set; }

        [JsonProperty("v2messageType")]
        private String v2messageType { get; set; }

        [JsonProperty("streamId")]
        private String streamId { get; set; }

        [JsonProperty("message")]
        private String message { get; set; }

        [JsonProperty("userId")]
        private long userId { get; set; }
    }
}
