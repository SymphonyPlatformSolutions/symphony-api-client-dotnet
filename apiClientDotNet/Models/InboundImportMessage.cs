using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class InboundImportMessage
    {
        [JsonProperty("messageId")]
        public String messageId { get; set; }

        [JsonProperty("originatingSystemId")]
        public String originatingSystemId { get; set; }

        [JsonProperty("originalMessageId")]
        public String originalMessageId { get; set; }

        [JsonProperty("diagnostic")]
        public String diagnostic { get; set; }
    }
}
