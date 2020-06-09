using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class StreamType
    {
        [JsonProperty("type")]
        public String type { get; set; }
    }
}
