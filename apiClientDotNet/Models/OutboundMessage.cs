using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace apiClientDotNet.Models
{
    public class OutboundMessage
    {
        [JsonProperty("message")]
        public string message { get; set; }

        [JsonProperty("data")]
        public string data { get; set; }

        [JsonProperty("attachments")]
        public List<FileStream> attachments { get; set; }

    }
}
