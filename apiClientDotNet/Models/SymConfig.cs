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

        [JsonProperty("authTokenRefreshPeriod")]
        public string authTokenRefreshPeriod { get; set; }

        [JsonProperty("botPrivateKeyPath")]
        public string botPrivateKeyPath { get; set; }

        [JsonProperty("botPrivateKeyName")]
        public string botPrivateKeyName { get; set; }

        [JsonProperty("botUsername")]
        public string botUsername { get; set; }

        public AuthTokens authTokens { get; set; }

        #region Global PRoxy

        [JsonProperty("proxyURL")]
        public string proxyURL { get; set; }

        [JsonProperty("proxyUsername")]
        public string proxyUsername { get; set; }

        [JsonProperty("proxyPassword")]
        public string proxyPassword { get; set; }

        #endregion

        #region Session proxy

        [JsonProperty("sessionProxyURL")]
        public string sessionProxyURL { get; set; }

        [JsonProperty("sessionProxyUsername")]
        public string sessionProxyUsername { get; set; }

        [JsonProperty("sessionProxyPassword")]
        public string sessionProxyPassword { get; set; }

        #endregion

        #region Key Manager proxy

        [JsonProperty("keyProxyURL")]
        public string keyProxyURL { get; set; }

        [JsonProperty("keyProxyUsername")]
        public string keyProxyUsername { get; set; }

        [JsonProperty("keyProxyPassword")]
        public string keyProxyPassword { get; set; }

        #endregion

        #region Pod proxy

        [JsonProperty("podProxyURL")]
        public string podProxyURL { get; set; }

        [JsonProperty("podProxyUsername")]
        public string podProxyUsername { get; set; }

        [JsonProperty("podProxyPassword")]
        public string podProxyPassword { get; set; }

        #endregion

        #region Agent proxy

        [JsonProperty("agentProxyURL")]
        public string agentProxyURL { get; set; }

        [JsonProperty("agentProxyUsername")]
        public string agentProxyUsername { get; set; }

        [JsonProperty("agentProxyPassword")]
        public string agentProxyPassword { get; set; }

        #endregion
    }
}