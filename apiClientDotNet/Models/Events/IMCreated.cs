using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models.Events
{
    public class IMCreated
    {
        [JsonProperty("stream")]
        public Stream stream { get; set; }
    }
}
