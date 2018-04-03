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
    public class DatafeedClient
    {
        List<RoomListener> listeners = new List<RoomListener>();
        static HttpClient client = new HttpClient();

        public Datafeed createDatafeed(SymConfig symConfig)
        {
            Datafeed datafeed = new Datafeed();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = "https://" + symConfig.agentHost + ":" + symConfig.agentPort + "/agent/v4/datafeed/create";
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Post, symConfig, true);
            string body = restRequestHandler.ReadResponse(resp);
            JObject o = JObject.Parse(body);
            datafeed.datafeedID = (string)o["id"];
            return datafeed;
        }


        public HttpWebResponse getEventsFromDatafeed(SymConfig symConfig, Datafeed datafeed)
        {
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            DatafeedEvent eventv4 = new DatafeedEvent();
            string url = "https://" + symConfig.agentHost + ":" + symConfig.agentPort + "/agent/v4/datafeed/" + datafeed.datafeedID + "/read";
            HttpWebResponse response = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Get, symConfig, true);
            return response;
        }
       
    }

}
