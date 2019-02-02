using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class SignalSubscriber
    {
        [JsonProperty("pushed")]
        public Boolean pushed { get; set; }

        [JsonProperty("owner")]
        public Boolean owner { get; set; }

        [JsonProperty("subscriberName")]
        public String subscriberName { get; set; }

        [JsonProperty("userId")]
        public long userId { get; set; }

        [JsonProperty("timestamp")]
        public long timestamp { get; set; }
    }
}
