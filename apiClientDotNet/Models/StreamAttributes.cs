using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class StreamAttributes
    {
        [JsonProperty("members")]
        public List<long> members { get; set; }

    }
}
