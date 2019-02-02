using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class SuppressionResult
    {
        [JsonProperty("messageId")]
        private String messageId { get; set; }

        [JsonProperty("suppressed")]
        private Boolean suppressed { get; set; }

        [JsonProperty("suppressionDate")]
        private long suppressionDate { get; set; }
    }
}
