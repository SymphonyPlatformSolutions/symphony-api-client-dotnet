using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models.Events
{
    public class SharedPost
    {
        [JsonProperty("message")]
        public Message message { get; set; }

        [JsonProperty("sharedMessage")]
        public Message sharedMessage { get; set; }
    }
}
