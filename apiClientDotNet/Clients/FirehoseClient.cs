using System;
using System.Collections.Generic;
using System.Text;
using apiClientDotNet.Models;
using apiClientDotNet.Models.Events;
using apiClientDotNet.Utils;
using apiClientDotNet.Listeners;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace apiClientDotNet
{
    public class FirehoseClient
    {
        List<IRoomListener> listeners = new List<IRoomListener>();
        static HttpClient client = new HttpClient();

        public Firehose createFirehose(SymConfig symConfig)
        {
            Firehose firehose = new Firehose();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = "https://" + symConfig.agentHost + ":" + symConfig.agentPort + "/agent/v4/firehose/create";
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Post, symConfig, true);
            string body = restRequestHandler.ReadResponse(resp);
            resp.Close();
            JObject o = JObject.Parse(body);
            firehose.firehoseId = (string)o["id"];
            return firehose;
        }


        public HttpWebResponse getEventsFromFirehose(SymConfig symConfig, Firehose firehose)
        {
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            DatafeedEvent eventv4 = new DatafeedEvent();
            string url = "https://" + symConfig.agentHost + ":" + symConfig.agentPort + "/agent/v4/firehose/" + firehose.firehoseId + "/read";
            HttpWebResponse response = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Get, symConfig, true);
            return response;
        }
       
    }

}
