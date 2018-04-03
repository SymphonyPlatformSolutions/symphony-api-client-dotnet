using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models.Events
{
    public class ConnectionAccepted
    {
        [JsonProperty("fromUser")]
        public User fromUser { get; set; }
    }
}
