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
        private SymConfig symConfig;
        static HttpClient client = new HttpClient();
        public UserClient(SymConfig config)
        {
            symConfig = config;
        }

        public UserInfo getUserFromUsername(String username) {
            UserInfo info = null;
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.GETUSERV2;
               // .queryParam("username", username)
                //    .queryParam("local", true)
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Post, symConfig, true);
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
            UserInfo info = null;
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.GETUSERSV3;
            // .queryParam("email", email)
            //.queryParam("local", local)
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Post, symConfig, true);
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
            UserInfo info = null;
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.GETUSERSV3;
            // .queryParam("uid", id)
            //.queryParam("local", local)
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Post, symConfig, true);
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
        // .queryParam("uid", id)
        //.queryParam("local", local)
         HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Post, symConfig, true);
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

    }
}
