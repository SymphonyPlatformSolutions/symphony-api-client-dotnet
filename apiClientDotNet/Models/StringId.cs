using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class StringId
    {
        [JsonProperty("id")]
        public string id { get; set; }
    }
}
