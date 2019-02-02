using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class NumericId
    {
    
        [JsonProperty("NumericId")]
        public long id { get; set; }
    }
}
