using System;
using System.Collections.Generic;
using System.Text;
using apiClientDotNet.Models;
using apiClientDotNet.Utils;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using apiClientDotNet.Clients.Constants;
using apiClientDotNet.Clients;

namespace apiClientDotNet.Clients
{
    public class SignalsClient
    {
        private ISymClient botClient;

        public SignalsClient(ISymClient client)
        {
            botClient = client;

        }

        public List<Signal> listSignals(int skip, int limit)
        {
            List<Signal> result = new List<Signal>();
            SymConfig symConfig = botClient.getConfig();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.agentHost + ":" + symConfig.agentPort + AgentConstants.LISTSIGNALS;


            if (skip > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&skip=" + skip;
                }
                else
                {
                    url = url + "?skip=" + skip;
                }
            }
            if (limit > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&limit=" + limit;
                }
                else
                {
                    url = url + "?limit=" + limit;
                }
            }
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Get, symConfig, true);
            string body = restRequestHandler.ReadResponse(resp);
            result = JsonConvert.DeserializeObject<List<Signal>>(body);
        
        return result;

        }

        public Signal getSignal(String id)
        {
            Signal result = new Signal();
            SymConfig symConfig = botClient.getConfig();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.agentHost + ":" + symConfig.agentPort + AgentConstants.GETSIGNAL.Replace("{id}", id);
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Get, symConfig, true);
            string body = restRequestHandler.ReadResponse(resp);
            result = JsonConvert.DeserializeObject<Signal>(body);

            return result;
        }

        public Signal createSignal(Signal signal)
        {
            Signal result = new Signal();
            SymConfig symConfig = botClient.getConfig();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.agentHost + ":" + symConfig.agentPort + AgentConstants.CREATESIGNAL;
            HttpWebResponse resp = restRequestHandler.executeRequest(signal, url, false, WebRequestMethods.Http.Post, symConfig, true);
            string body = restRequestHandler.ReadResponse(resp);
            result = JsonConvert.DeserializeObject<Signal>(body);

            return result;
        }

        public Signal updateSignal(Signal signal)
        {
            Signal result = new Signal();
            SymConfig symConfig = botClient.getConfig();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.agentHost + ":" + symConfig.agentPort + AgentConstants.UPDATESIGNAL.Replace("{id}", signal.id);
            HttpWebResponse resp = restRequestHandler.executeRequest(signal, url, false, WebRequestMethods.Http.Post, symConfig, true);
            string body = restRequestHandler.ReadResponse(resp);
            result = JsonConvert.DeserializeObject<Signal>(body);

            return result;

        }

        public void deleteSignal(String id)
        {
            SymConfig symConfig = botClient.getConfig();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.agentHost + ":" + symConfig.agentPort + AgentConstants.DELETESIGNAL.Replace("{id}", id);
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Post, symConfig, true);
            string body = restRequestHandler.ReadResponse(resp);
            
        }

        public SignalSubscriptionResult subscribeSignal(String id, Boolean self, List<long> uids, Boolean pushed)
        {

            SymConfig symConfig = botClient.getConfig();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            HttpWebResponse resp;
            if (self) {
                string url = CommonConstants.HTTPSPREFIX + symConfig.agentHost + ":" + symConfig.agentPort + AgentConstants.SUBSCRIBESIGNAL.Replace("{id}", id);
                resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Post, symConfig, true);
                
             } else {

                string url = CommonConstants.HTTPSPREFIX + symConfig.agentHost + ":" + symConfig.agentPort + AgentConstants.SUBSCRIBESIGNAL.Replace("{id}", id) + "?pushed=" + pushed;
                resp = restRequestHandler.executeRequest(uids, url, false, WebRequestMethods.Http.Post, symConfig, true);
                
            }

            string body = restRequestHandler.ReadResponse(resp);
            return JsonConvert.DeserializeObject<SignalSubscriptionResult>(body);
        }

        public SignalSubscriptionResult unsubscribeSignal(String id, Boolean self, List<long> uids) 
        {

            SymConfig symConfig = botClient.getConfig();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            HttpWebResponse resp;
            if (self)
            {
                string url = CommonConstants.HTTPSPREFIX + symConfig.agentHost + ":" + symConfig.agentPort + AgentConstants.UNSUBSCRIBESIGNAL.Replace("{id}", id);
                resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Post, symConfig, true);

            }
            else
            {

                string url = CommonConstants.HTTPSPREFIX + symConfig.agentHost + ":" + symConfig.agentPort + AgentConstants.UNSUBSCRIBESIGNAL.Replace("{id}", id);
                resp = restRequestHandler.executeRequest(uids, url, false, WebRequestMethods.Http.Post, symConfig, true);

            }

            string body = restRequestHandler.ReadResponse(resp);
            return JsonConvert.DeserializeObject<SignalSubscriptionResult>(body);
        }

        public SignalSubscriberList getSignalSubscribers(String id, int skip, int limit) 
        {


            SymConfig symConfig = botClient.getConfig();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.agentHost + ":" + symConfig.agentPort + AgentConstants.GETSUBSCRIBERS.Replace("{id}", id);
            if (skip > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&skip=" + skip;
                }
                else
                {
                    url = url + "?skip=" + skip;
                }
            }
            if (limit > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&limit=" + limit;
                }
                else
                {
                    url = url + "?limit=" + limit;
                }
            }


            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Get, symConfig, true);
            string body = restRequestHandler.ReadResponse(resp);
            return JsonConvert.DeserializeObject<SignalSubscriberList>(body);
        }
    }
}
