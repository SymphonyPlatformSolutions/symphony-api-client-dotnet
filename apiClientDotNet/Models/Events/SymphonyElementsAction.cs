using apiClientDotNet.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace apiClientDotNet.Models.Events
{
    public class SymphonyElementsAction
    {

        [JsonIgnore]
        [Obsolete("actionStream is not used since Symphony 1.57+")]
        public ActionStream actionStream { get; set; }

        [JsonProperty("formStream")]
        [Obsolete("formStream is not used since Symphony 1.57+")]
        public Stream formStream
        {
            get
            {
                return stream;
            }
            set
            {
                stream = value;
            }
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
            if (stream != null)
            {
                stream.streamId = StreamUtils.FixId(stream.streamId);
            }
            formMessageId = StreamUtils.FixId(formMessageId);
        }


        [Obsolete("ActionStream is not used since Symphony 1.57+")]
        public class ActionStream
        {
            [JsonProperty("streamId", NullValueHandling = NullValueHandling.Ignore)]
            public string streamId { get; set; }
        }
    }
}
