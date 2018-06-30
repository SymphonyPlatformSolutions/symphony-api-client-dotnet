using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class InboundImportMessage
    {
        [JsonProperty("messageId")]
        private String messageId { get; set; }

        [JsonProperty("originatingSystemId")]
        private String originatingSystemId { get; set; }

        [JsonProperty("originalMessageId")]
        private String originalMessageId { get; set; }

        [JsonProperty("diagnostic")]
        private String diagnostic { get; set; }
    }
}
