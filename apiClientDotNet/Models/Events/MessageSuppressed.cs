using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models.Events
{
    public class MessageSuppressed
    {
        [JsonProperty("messageId")]
        public string messageId { get; set; }

        [JsonProperty("stream")]
        public Stream stream { get; set; }
    }
}
