using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models.Events
{
    public class MessageSent
    {
        [JsonProperty("message")]
        public Message message { get; set; }
    }
}
