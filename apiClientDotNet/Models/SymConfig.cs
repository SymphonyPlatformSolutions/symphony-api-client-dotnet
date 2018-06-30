using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class SymConfig
    {
        [JsonProperty("sessionAuthHost")]
        public string sessionAuthHost { get; set; }

        [JsonProperty("sessionAuthPort")]
        public int sessionAuthPort { get; set; }

        [JsonProperty("keyAuthHost")]
        public string keyAuthHost { get; set; }

        [JsonProperty("keyAuthPort")]
        public int keyAuthPort { get; set; }

        [JsonProperty("podHost")]
        public string podHost { get; set; }

        [JsonProperty("podPort")]
        public int podPort { get; set; }

        [JsonProperty("agentHost")]
        public string agentHost { get; set; }

        [JsonProperty("agentPort")]
        public int agentPort { get; set; }

        [JsonProperty("botCertPath")]
        public string botCertPath { get; set; }

        [JsonProperty("botCertName")]
        public string botCertName { get; set; }

        [JsonProperty("botCertPassword")]
        public string botCertPassword { get; set; }

        [JsonProperty("botEmailAddress")]
        public string botEmailAddress { get; set; }

        [JsonProperty("appCertPath")]
        public string appCertPath { get; set; }

        [JsonProperty("appCertName")]
        public string appCertName { get; set; }

        [JsonProperty("appCertPassword")]
        public string appCertPassword { get; set; }

        [JsonProperty("proxyURL")]
        public string proxyURL { get; set; }

        [JsonProperty("proxyUsername")]
        public string proxyUsername { get; set; }

        [JsonProperty("proxyPassword")]
        public string proxyPassword { get; set; }

        [JsonProperty("sessionProxyURL")]
        public string sessionProxyURL { get; set; }

        [JsonProperty("sessionProxyUsername")]
        public string sessionProxyUsername { get; set; }

        [JsonProperty("sessionProxyPassword")]
        public string sessionProxyPassword { get; set; }

        [JsonProperty("authTokenRefreshPeriod")]
        public string authTokenRefreshPeriod { get; set; }

        [JsonProperty("botPrivateKeyPath")]
        public string botPrivateKeyPath { get; set; }

        [JsonProperty("botPrivateKeyName")]
        public string botPrivateKeyName { get; set; }

        [JsonProperty("botUsername")]
        public string botUsername { get; set; }

        public AuthTokens authTokens { get; set; }
 
    }
}
