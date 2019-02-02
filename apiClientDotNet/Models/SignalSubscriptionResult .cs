using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class SignalSubscriptionResult
    {
        [JsonProperty("requestedSubscription")]
        public int requestedSubscription { get; set; }

        [JsonProperty("successfulSubscription")]
        public int successfulSubscription { get; set; }

        [JsonProperty("failedSubscription")]
        public int failedSubscription { get; set; }

        [JsonProperty("subscriptionErrors")]
        public List<long> subscriptionErrors { get; set; }
    }
}
