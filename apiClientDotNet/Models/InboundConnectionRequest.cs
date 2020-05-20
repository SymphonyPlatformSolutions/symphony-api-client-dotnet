using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class InboundConnectionRequest
    {
        [JsonProperty("userId")]
        public long userId { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("firstRequestedAt")]
        public long? firstRequestedAt { get; set; }

        [JsonProperty("updatedAt")]
        public long? updatedAt { get; set; }

        [JsonProperty("requestCounter")]
        public int? requestCounter { get; set; }
    }
}
