using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class OutboundImportMessage
    {
        [JsonProperty("message")]
        private String message { get; set; }

        [JsonProperty("data")]
        private String data { get; set; }

        [JsonProperty("intendedMessageTimestamp")]
        private long intendedMessageTimestamp { get; set; }

        [JsonProperty("intendedMessageFromUserId")]
        private long intendedMessageFromUserId { get; set; }

        [JsonProperty("originatingSystemId")]
        private String originatingSystemId { get; set; }

        [JsonProperty("originalMessageId")]
        private String originalMessageId { get; set; }

        [JsonProperty("streamId")]
        private String streamId { get; set; }
    }
}
