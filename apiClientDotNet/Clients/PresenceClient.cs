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
    public class PresenceClient
    {
        private ISymClient botClient;

        public PresenceClient(ISymClient client)
        {
            botClient = client;

        }

        public UserPresence getUserPresence(long userId, Boolean local)
        {
            SymConfig symConfig = botClient.getConfig();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.GETUSERPRESENCE.Replace("{uid}", userId.ToString()) + "?local=" + local;
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Get, symConfig, true);
            string body = restRequestHandler.ReadResponse(resp);
            return JsonConvert.DeserializeObject<UserPresence>(body);
        }

        public UserPresence setPresence(String status)
        {
            Category category = new Category();
            category.setCategory(status);
            SymConfig symConfig = botClient.getConfig();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.SETPRESENCE;
            HttpWebResponse resp = restRequestHandler.executeRequest(category, url, false, WebRequestMethods.Http.Post, symConfig, true);
            string body = restRequestHandler.ReadResponse(resp);
            return JsonConvert.DeserializeObject<UserPresence>(body);

        }

        public void registerInterestExtUser(List<long> userIds) 
        {
            SymConfig symConfig = botClient.getConfig();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.REGISTERPRESENCEINTEREST;
            HttpWebResponse resp = restRequestHandler.executeRequest(userIds, url, false, WebRequestMethods.Http.Post, symConfig, true);
            string body = restRequestHandler.ReadResponse(resp);
        }

        private class Category
        {
            private String category;

            public String getCategory()
            {
                return category;
            }

            public void setCategory(String category)
            {
                this.category = category;
            }
        }
    }
}
