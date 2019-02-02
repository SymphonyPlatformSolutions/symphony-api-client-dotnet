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


namespace apiClientDotNet
{
    class StreamClient
    {
        private SymConfig symConfig;
        static HttpClient client = new HttpClient();
        public StreamClient(SymConfig config)
        {
            symConfig = config;
        }

        public String getUserIMStreamId(long userId)
        {
            List<long> userIdList = new List<long>();
            userIdList.Add(userId);
            return getUserListIM(userIdList);
        }

        public String getUserListIM(List<long> userIdList)
        {
            StringId id = new StringId();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.GETIM;
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Get, symConfig, true);
            if (resp.StatusCode == HttpStatusCode.NoContent)
            {
                throw new Exception("No user found.");
            }
            else if (resp.StatusCode == HttpStatusCode.OK)
            {
                string body = restRequestHandler.ReadResponse(resp);
                id = JsonConvert.DeserializeObject<StringId>(body);
            }
            
            return id.id;
        }

        public RoomInfo createRoom(Room room)
        {
            RoomInfo roomInfo = new RoomInfo();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.CREATEROOM;
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Post, symConfig, true);
            if (resp.StatusCode == HttpStatusCode.NoContent)
            {
                throw new Exception("No user found.");
            }
            else if (resp.StatusCode == HttpStatusCode.OK)
            {
                string body = restRequestHandler.ReadResponse(resp);
                roomInfo = JsonConvert.DeserializeObject<RoomInfo>(body);
            }

            return roomInfo;
        }

        public void addMemberToRoom(String streamId, long userId)
        {
            NumericId id = new NumericId();
            id.id = userId;
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.ADDMEMBER.Replace("{id}", streamId);
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Post, symConfig, true);
            if (resp.StatusCode == HttpStatusCode.NoContent)
            {
                throw new Exception("No user found.");
            }
            else if (resp.StatusCode == HttpStatusCode.OK)
            {
                string body = restRequestHandler.ReadResponse(resp);
            }
        }

        public void removeMemberFromRoom(String streamId, long userId)
        {
            NumericId id = new NumericId();
            id.id = userId;
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.REMOVEMEMBER.Replace("{id}", streamId);
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Post, symConfig, true);
            if (resp.StatusCode == HttpStatusCode.NoContent)
            {
                throw new Exception("No user found.");
            }
            else if (resp.StatusCode == HttpStatusCode.OK)
            {
                string body = restRequestHandler.ReadResponse(resp);
            }
        }

        public RoomInfo getRoomInfo(String streamId)
        {
            RoomInfo roomInfo = new RoomInfo();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.GETROOMINFO.Replace("{id}", streamId);
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Get, symConfig, true);
            if (resp.StatusCode == HttpStatusCode.NoContent)
            {
                throw new Exception("No user found.");
            }
            else if (resp.StatusCode == HttpStatusCode.OK)
            {
                string body = restRequestHandler.ReadResponse(resp);
            
                roomInfo = JsonConvert.DeserializeObject<RoomInfo>(body);
            }
            return roomInfo;
        }

        public RoomInfo updateRoom(String streamId, Room room) 
        {
            RoomInfo roomInfo = new RoomInfo();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.UPDATEROOMINFO.Replace("{id}", streamId);
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Post, symConfig, true);
            //.post(Entity.entity(room, MediaType.APPLICATION_JSON));
            if (resp.StatusCode == HttpStatusCode.NoContent)
            {
                throw new Exception("No user found.");
            }
            else if (resp.StatusCode == HttpStatusCode.OK)
            {
                string body = restRequestHandler.ReadResponse(resp);

                roomInfo = JsonConvert.DeserializeObject<RoomInfo>(body);
            }
            return roomInfo;
         }

    //TODO: CHECK WHY 404
        public StreamInfo getStreamInfo(String streamId) 
        {
            StreamInfo streamInfo = new StreamInfo();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.GETSTREAMINFO.Replace("{id}", streamId);
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Get, symConfig, true);
            if (resp.StatusCode == HttpStatusCode.NoContent)
            {
                throw new Exception("No stream found.");
            }
            else if (resp.StatusCode == HttpStatusCode.OK)
            {
                string body = restRequestHandler.ReadResponse(resp);

                streamInfo = JsonConvert.DeserializeObject<StreamInfo>(body);
            }
            return streamInfo;

        }

        public List<RoomMember> getRoomMembers(String streamId)
        {
            List<RoomMember> roomMembers = new List<RoomMember>();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.GETROOMMEMBERS.Replace("{id}", streamId);
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Get, symConfig, true);
            if (resp.StatusCode == HttpStatusCode.NoContent)
            {
                throw new Exception("No stream found.");
            }
            else if (resp.StatusCode == HttpStatusCode.OK)
            {
                string body = restRequestHandler.ReadResponse(resp);

                roomMembers = JsonConvert.DeserializeObject<List<RoomMember>>(body);
            }

            return roomMembers;

          }

        public void activateRoom(String streamId)
        {
            setActiveRoom(streamId,true);
        }

        public void deactivateRoom(String streamId)
        {
            setActiveRoom(streamId,false);
        }

        //TODO: CHECK WHY 403
        private void setActiveRoom(String streamId, Boolean active)
        {
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.SETACTIVE.Replace("{id}", streamId);
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Post, symConfig, true);
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                string body = restRequestHandler.ReadResponse(resp);
               
            }
        }

        public void promoteUserToOwner(String streamId, long userId) 
        {
            NumericId id = new NumericId();
            id.id = userId;
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.PROMOTEOWNER.Replace("{id}", streamId);
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Post, symConfig, true);
           
           
         }

        public void demoteUserFromOwner(String streamId, long userId)
        {
            NumericId id = new NumericId();
            id.id = userId;
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.DEMOTEOWNER.Replace("{id}", streamId);
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Post, symConfig, true);
        }
    }
}
