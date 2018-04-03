using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models.Events
{
    public class ConnectionRequested
    {
        [JsonProperty("toUser")]
        public User toUser { get; set; }
    }
}
