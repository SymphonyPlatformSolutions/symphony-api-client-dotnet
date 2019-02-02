using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models
{
    public class OutboundShare
    {

        [JsonProperty("articleId")]
        public String articleId { get; set; }

        [JsonProperty("title")]
        public String title { get; set; }

        [JsonProperty("subTitle")]
        public String subTitle { get; set; }

        [JsonProperty("message")]
        public String message { get; set; }

        [JsonProperty("publisher")]
        public String publisher { get; set; }

        [JsonProperty("publishDate")]
        public long publishDate { get; set; }

        [JsonProperty("thumbnailUrl")]
        public String thumbnailUrl { get; set; }

        [JsonProperty("author")]
        public String author { get; set; }

        [JsonProperty("articleUrl")]
        public String articleUrl { get; set; }

        [JsonProperty("summary")]
        public String summary { get; set; }

        [JsonProperty("appId")]
        public String appId { get; set; }

        [JsonProperty("appName")]
        public String appName { get; set; }

        [JsonProperty("appIconUrl")]
        public String appIconUrl { get; set; }
    }
}
