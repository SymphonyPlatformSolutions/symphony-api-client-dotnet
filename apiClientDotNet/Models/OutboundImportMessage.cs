using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class OutboundImportMessage
    {
        [JsonProperty("message")]
        public String message { get; set; }

        [JsonProperty("data")]
        public String data { get; set; }

        [JsonProperty("intendedMessageTimestamp")]
        public long intendedMessageTimestamp { get; set; }

        [JsonProperty("intendedMessageFromUserId")]
        public long intendedMessageFromUserId { get; set; }

        [JsonProperty("originatingSystemId")]
        public String originatingSystemId { get; set; }

        [JsonProperty("originalMessageId")]
        public String originalMessageId { get; set; }

        [JsonProperty("streamId")]
        public String streamId { get; set; }
    }
}
