using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class SuppressionResult
    {
        [JsonProperty("messageId")]
        public String messageId { get; set; }

        [JsonProperty("suppressed")]
        public Boolean suppressed { get; set; }

        [JsonProperty("suppressionDate")]
        public long suppressionDate { get; set; }
    }
}
