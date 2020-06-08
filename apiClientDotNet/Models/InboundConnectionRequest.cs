using Newtonsoft.Json;
using System;

namespace apiClientDotNet.Models
{
    public class InboundConnectionRequest
    {
        [JsonProperty("userId")]
        public long userId { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonIgnore]
        [Obsolete("Please instead of firstRequestedAt use FirstRequestedAt")]
        public long firstRequestedAt
        {
            get { return FirstRequestedAt.HasValue ? FirstRequestedAt.Value : default(long); }
            set { FirstRequestedAt = value; }
        }

        [JsonProperty("firstRequestedAt")]
        public long? FirstRequestedAt { get; set; }

        [JsonIgnore]
        [Obsolete("Please instead of updatedAt use UpdatedAt")]
        public long updatedAt
        {
            get { return UpdatedAt.HasValue ? UpdatedAt.Value : default(long); }
            set { UpdatedAt = value; }
        }

        [JsonProperty("updatedAt")]
        public long? UpdatedAt { get; set; }

        [JsonIgnore]
        [Obsolete("Please instead of requestCounter use RequestCounter")]
        public int requestCounter
        {
            get { return RequestCounter.HasValue ? RequestCounter.Value : default(int); }
            set { RequestCounter = value; }
        }

        [JsonProperty("requestCounter")]
        public int? RequestCounter { get; set; }
    }
}
