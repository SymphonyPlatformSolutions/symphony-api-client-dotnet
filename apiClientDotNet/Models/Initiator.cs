using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class Initiator
    {

        [JsonProperty("user")]
        public User user { get; set; }
    }
}
