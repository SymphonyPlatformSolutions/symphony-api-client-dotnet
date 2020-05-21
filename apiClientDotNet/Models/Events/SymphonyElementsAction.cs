using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace apiClientDotNet.Models.Events
{
    public class SymphonyElementsAction
    {
        [JsonProperty("formStream")]
        public Stream formStream
        {
            get { return stream; }
            set { stream = value;}
        }

        [JsonProperty("stream")]
        public Stream stream { get; set; }

        [JsonProperty("formMessageId")]
        public string formMessageId { get; set; }

        [JsonProperty("formId")]
        public string formId { get; set; }

        [JsonProperty("formValues")]
        public Dictionary<string, object> formValues { get; set; }

        [OnDeserialized]
        internal void FixIds(StreamingContext context)
        {
            stream.streamId = stream.streamId.Replace('/', '_').Replace('+', '-').Replace("=","");
            formMessageId = formMessageId.Replace('/', '_').Replace('+', '-').Replace("=","");
        }
    }
}
