using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class OutboundShare
    {

        [JsonProperty("articleId")]
        private String articleId { get; set; }

        [JsonProperty("title")]
        private String title { get; set; }

        [JsonProperty("subTitle")]
        private String subTitle { get; set; }

        [JsonProperty("message")]
        private String message { get; set; }

        [JsonProperty("publisher")]
        private String publisher { get; set; }

        [JsonProperty("publishDate")]
        private long publishDate { get; set; }

        [JsonProperty("thumbnailUrl")]
        private String thumbnailUrl { get; set; }

        [JsonProperty("author")]
        private String author { get; set; }

        [JsonProperty("articleUrl")]
        private String articleUrl { get; set; }

        [JsonProperty("summary")]
        private String summary { get; set; }

        [JsonProperty("appId")]
        private String appId { get; set; }

        [JsonProperty("appName")]
        private String appName { get; set; }

        [JsonProperty("appIconUrl")]
        private String appIconUrl { get; set; }
    }
}
