using System;
using System.Collections.Generic;
using System.Text;
using apiClientDotNet.Models;
using apiClientDotNet.Clients.Constants;
using apiClientDotNet.Utils;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Newtonsoft.Json;


namespace apiClientDotNet.Clients
{
    public class UserClient
    {
        static HttpClient client = new HttpClient();

        private ISymClient botClient;

        public UserClient(ISymClient client)
        {
            botClient = client;

        }
        public UserInfo getUserFromUsername(String username) {

            SymConfig symConfig = botClient.getConfig();
            UserInfo info = null;
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.GETUSERV2 + "?username=" + username + "&local=true";
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Get, symConfig, false);
            if (resp.StatusCode == HttpStatusCode.NoContent)
            {
                throw new Exception("No user found.");
            }
            else if (resp.StatusCode == HttpStatusCode.OK)
            {
                string body = restRequestHandler.ReadResponse(resp);
                info = JsonConvert.DeserializeObject<UserInfo>(body);
            }
          
            return info;
        }

        public UserInfo getUserFromEmail(String email, Boolean local) {

            SymConfig symConfig = botClient.getConfig();
            UserInfo info = null;
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.GETUSERSV3 + "?email=" + email + "&local=" + local;
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Get, symConfig, true);
            if (resp.StatusCode == HttpStatusCode.NoContent)
            {
                throw new Exception("No user found.");
            }
            else if (resp.StatusCode == HttpStatusCode.OK)
            {
                string body = restRequestHandler.ReadResponse(resp);
                info = JsonConvert.DeserializeObject<UserInfo>(body);
            }

            return info;
        }

        public UserInfo getUserFromId(long id, Boolean local) {

            SymConfig symConfig = botClient.getConfig();
            UserInfo info = null;
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.GETUSERSV3 + "?uid=" + id + "&local=" + local;

            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Get, symConfig, true);
            if (resp.StatusCode == HttpStatusCode.NoContent)
            {
                throw new Exception("No user found.");
            }
            else if (resp.StatusCode == HttpStatusCode.OK)
            {
                string body = restRequestHandler.ReadResponse(resp);
                info = JsonConvert.DeserializeObject<UserInfo>(body);
            }

            return info;
        }

        public List<UserInfo> getUsersFromIdList(List<long> idList, Boolean local) {
            return getUsersV3(null, idList, local);
        }

        public List<UserInfo> getUsersFromEmailList(List<String> emailList, Boolean local) {
            return getUsersV3(emailList, null, local);
        }



    public List<UserInfo> getUsersV3(List<String> emailList, List<long> idList, Boolean local) { 

        SymConfig symConfig = botClient.getConfig();
        List<UserInfo> infoList = new List<UserInfo>();
        Boolean emailBased = false;
        StringBuilder lookUpListString = new StringBuilder();
            if (emailList != null)
            {
                if (emailList.Count == 0)
                {
                    throw new Exception("No user sent for lookup");
                }
                emailBased = true;
                lookUpListString.Append(emailList[0]);
                for (int i = 1; i < emailList.Count; i++)
                {
                    lookUpListString.Append("," + emailList[i]);
                }
            }

            else if (idList != null)
            {
                if (idList.Count == 0)
                {
                    throw new Exception("No user sent for lookup");
                }
                lookUpListString.Append(idList[0]);
                for (int i = 1; i < idList.Count; i++)
                {
                    lookUpListString.Append("," + idList[i]);
                }
            }
            else
            {
                throw new Exception("No user sent for lookup");
            }

            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.GETUSERSV3;
            if(emailBased)
            {
                url = url + "?email=" + lookUpListString.ToString();

            } else
            {
                url = url + "?uid=" + lookUpListString.ToString();

            }
            url = url + "&local=" + local;
         HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Get, symConfig, true);
            if (resp.StatusCode == HttpStatusCode.NoContent)
            {
                throw new Exception("No user found.");
            }
            else if (resp.StatusCode == HttpStatusCode.OK)
            {
                string body = restRequestHandler.ReadResponse(resp);
                infoList = JsonConvert.DeserializeObject<List<UserInfo>>(body);
            }
       
        return infoList;
        }

        public UserSearchResult searchUsers(String query, Boolean local, int skip, int limit, UserFilter filter) {

            UserSearchResult result = null;
            SymConfig symConfig = botClient.getConfig();

            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.SEARCHUSERS;


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
            if (local){
                if (url.Contains("?"))
                {
                    url = url + "&local=" + local;
                }
                else
                {
                    url = url + "?local=" + local;
                }
            }
            Dictionary<String, Object> body = new Dictionary<String, Object>();
            body.Add("query", query);
            body.Add("filters", filter);

            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Post, symConfig, true);
            if (resp.StatusCode == HttpStatusCode.NoContent)
            {
                throw new Exception("No user found.");
            }
            else if (resp.StatusCode == HttpStatusCode.OK)
            {
                string resbody = restRequestHandler.ReadResponse(resp);
                result = JsonConvert.DeserializeObject<UserSearchResult>(resbody);
            }
        
            return result;
        }

    }
}
