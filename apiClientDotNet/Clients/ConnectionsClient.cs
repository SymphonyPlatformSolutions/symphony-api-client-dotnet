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
    public class ConnectionsClient
    {
        private ISymClient botClient;

        public ConnectionsClient(ISymClient client)
        {
            botClient = client;
        }

        public List<InboundConnectionRequest> getPendingConnections()
        {
            return getConnections(null, null);
        }

        public List<InboundConnectionRequest> getInboundPendingConnections()
        {
            return getConnections("PENDING_INCOMING", null);
        }

        public List<InboundConnectionRequest> getAllConnections()
        {
            return getConnections("ALL", null);
        }

        public List<InboundConnectionRequest> getAcceptedConnections()
        {
            return getConnections("ACCEPTED", null);
        }

        public List<InboundConnectionRequest> getRejectedConnections()
        {
            return getConnections("REJECTED", null);
        }

        public List<InboundConnectionRequest> getConnections(String status, List<long> userIds)
        {
            Boolean userList = false;
            StringBuilder userIdList = new StringBuilder();
            if (userIds != null)
            {
                if (userIds.Count != 0)
                {
                    userList = true;
                    userIdList.Append(userIds[0]);
                    for (int i = 1; i < userIds.Count; i++)
                    {
                        userIdList.Append("," + userIds[i]);
                    }
                }
            }

            SymConfig symConfig = botClient.getConfig();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.GETCONNECTIONS;


            if (status != null)
            {
                if (url.Contains("?"))
                {
                    url = url + "&status=" + status;
                }
                else
                {
                    url = url + "?status=" + status;
                }
            }
            if (userList)
            {
                if (url.Contains("?"))
                {
                    url = url + "&userIds=" + userIdList.ToString();
                }
                else
                {
                    url = url + "?userIds=" + userIdList.ToString();
                }
            }
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Get, symConfig, true);
            string body = restRequestHandler.ReadResponse(resp);
            resp.Close();
            return JsonConvert.DeserializeObject<InboundConnectionRequestList>(body);

        }

        public InboundConnectionRequest acceptConnectionRequest(long userId)
        {
            UserId userIdObject = new UserId();
            userIdObject.setUserId(userId);
            SymConfig symConfig = botClient.getConfig();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.ACCEPTCONNECTION;
            HttpWebResponse resp = restRequestHandler.executeRequest(userId, url, false, WebRequestMethods.Http.Post, symConfig, true);
            string body = restRequestHandler.ReadResponse(resp);
            resp.Close();
            return JsonConvert.DeserializeObject<InboundConnectionRequest>(body);
           
        }

        public InboundConnectionRequest rejectConnectionRequest(long userId)
        {
            UserId userIdObject = new UserId();
            userIdObject.setUserId(userId);
            SymConfig symConfig = botClient.getConfig();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.REJECTCONNECTION;
            HttpWebResponse resp = restRequestHandler.executeRequest(userId, url, false, WebRequestMethods.Http.Post, symConfig, true);
            string body = restRequestHandler.ReadResponse(resp);
            resp.Close();
            return JsonConvert.DeserializeObject<InboundConnectionRequest>(body);
            
        }

        public InboundConnectionRequest sendConnectionRequest(long userId)
        {
            UserId userIdObject = new UserId();
            userIdObject.setUserId(userId);
            SymConfig symConfig = botClient.getConfig();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.SENDCONNECTIONREQUEST;
            HttpWebResponse resp = restRequestHandler.executeRequest(userId, url, false, WebRequestMethods.Http.Post, symConfig, true);
            string body = restRequestHandler.ReadResponse(resp);
            resp.Close();
            return JsonConvert.DeserializeObject<InboundConnectionRequest>(body);

        }

        public InboundConnectionRequest getConnectionRequestStatus(long userId)
        {
            SymConfig symConfig = botClient.getConfig();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.GETCONNECTIONSTATUS.Replace("{userId}", userId.ToString());
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Get, symConfig, true);
            string body = restRequestHandler.ReadResponse(resp);
            resp.Close();
            return JsonConvert.DeserializeObject<InboundConnectionRequest>(body);
        }

        public void removeConnection(long userId)
        {
            SymConfig symConfig = botClient.getConfig();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.REMOVECONNECTION.Replace("{userId}", userId.ToString());
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Post, symConfig, true);
            //string body = restRequestHandler.ReadResponse(resp);
            resp.Close();
         }


        private class UserId
        {
            long userId;

            public long getUserId()
            {
                return userId;
            }

            public void setUserId(long userId)
            {
                this.userId = userId;
            }
        }
            }

}

