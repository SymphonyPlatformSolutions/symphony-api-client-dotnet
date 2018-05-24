using System;
using System.Collections.Generic;
using System.Text;
using apiClientDotNet.Models;
using apiClientDotNet.Utils;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace apiClientDotNet
{
    public class MessageClient
    {
        public HttpWebResponse sendMessage(SymConfig symConfig, Message message, Stream stream)
        {
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = "https://" + symConfig.agentHost + ":" + symConfig.agentPort + "/agent/v4/stream/" + stream.streamId + "/message/create";
            HttpWebResponse resp = restRequestHandler.executeRequest(message, url, false, WebRequestMethods.Http.Post, symConfig, true);

            return resp;
        }

        public void getMessagesFromStream()
        {

        }

    }
}
