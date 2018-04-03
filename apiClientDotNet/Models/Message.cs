using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class Message
    {

        [JsonProperty("messageId")]
        public string messageId { get; set; }

        [JsonProperty("timestamp")]
        public long timestamp { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }

        [JsonProperty("data")]
        public string data { get; set; }

        [JsonProperty("attachments")]
        public List<Attachment> attachments { get; set; }

        [JsonProperty("user")]
        public User user { get; set; }

        [JsonProperty("stream")]
        public Stream stream { get; set; }

        [JsonProperty("externalRecipients")]
        public bool externalRecipients { get; set; }

        [JsonProperty("diagnostic")]
        public string diagnostic { get; set; }

        [JsonProperty("userAgent")]
        public string userAgent { get; set; }

        [JsonProperty("originalFormat")]
        public string originalFormat { get; set; }
    }
}
