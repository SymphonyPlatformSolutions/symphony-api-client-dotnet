using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class Status
    {
        [JsonProperty("status")]
        public String status { get; set; }
    }
}
