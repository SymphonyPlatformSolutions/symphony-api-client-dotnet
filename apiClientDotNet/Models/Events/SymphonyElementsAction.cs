using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace apiClientDotNet.Models.Events
{

public class SymphonyElementsAction
{

    //TODO futureproof this by checking for streamId or formStream.streamId
    //TODO add get StreamType checker like Java has
    [JsonProperty("actionStream")]
    public ActionStream actionStream { get; set; }
    
    [JsonProperty("formStream")]
    public Stream formStream { get; set; }

    [JsonProperty("formMessageId")]
    public string formMessageId { get; set; }

    [JsonProperty("formId")]
    public string formId { get; set; }

    [JsonProperty("formValues")]
    public Dictionary<string, object> formValues { get; set; } 
    // public FormValues formValues { get; set; }
}


public class ActionStream
{
    [JsonProperty("streamId")]
    public string streamId { get; set; }
}

}
