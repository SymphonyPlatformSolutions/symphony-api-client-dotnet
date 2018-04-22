using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class MessageStatus
    {
        [JsonProperty("read")]
        public List<MessageStatusUser> read { get; set; }

        [JsonProperty("delivered")]
        public List<MessageStatusUser> delivered { get; set; }

        [JsonProperty("sent")]
        public List<MessageStatusUser> sent { get; set; }
    }
}
