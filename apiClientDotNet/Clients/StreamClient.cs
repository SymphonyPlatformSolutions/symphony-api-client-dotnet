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
using apiClientDotNet.Clients;

namespace apiClientDotNet
{
    public class StreamClient
    {
        private ISymClient botClient;

        public StreamClient(ISymClient client)
        {
            botClient = client;

        }
        static HttpClient client = new HttpClient();

        public String getUserIMStreamId(long userId)
        {
            List<long> userIdList = new List<long>();
            userIdList.Add(userId);
            return getUserListIM(userIdList);
        }

        public String getUserListIM(List<long> userIdList)
        {

            SymConfig symConfig = botClient.getConfig();
            StringId id = new StringId();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.GETIM;
            HttpWebResponse resp = restRequestHandler.executeRequest(userIdList, url, false, WebRequestMethods.Http.Post, symConfig, true);
            if (resp.StatusCode == HttpStatusCode.NoContent)
            {
                resp.Close();
                throw new Exception("No user found.");
            }
            else if (resp.StatusCode == HttpStatusCode.OK)
            {
                string body = restRequestHandler.ReadResponse(resp);
                id = JsonConvert.DeserializeObject<StringId>(body);
            }
            resp.Close();
            return id.id;
        }

        public RoomInfo createRoom(Room room)
        {

            SymConfig symConfig = botClient.getConfig();
            RoomInfo roomInfo = new RoomInfo();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.CREATEROOM;
            HttpWebResponse resp = restRequestHandler.executeRequest(room, url, false, WebRequestMethods.Http.Post, symConfig, true);
            if (resp.StatusCode == HttpStatusCode.NoContent)
            {
                resp.Close();
                throw new Exception("No user found.");
            }
            else if (resp.StatusCode == HttpStatusCode.OK)
            {
                string body = restRequestHandler.ReadResponse(resp);
                roomInfo = JsonConvert.DeserializeObject<RoomInfo>(body);
            }
            resp.Close();
            return roomInfo;
        }

        public void addMemberToRoom(String streamId, long userId)
        {

            SymConfig symConfig = botClient.getConfig();
            NumericId id = new NumericId();
            id.id = userId;
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.ADDMEMBER.Replace("{id}", streamId);
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Post, symConfig, true);
            if (resp.StatusCode == HttpStatusCode.NoContent)
            {
                resp.Close();
                throw new Exception("No user found.");
            }
            else if (resp.StatusCode == HttpStatusCode.OK)
            {
                string body = restRequestHandler.ReadResponse(resp);
            }
            resp.Close();
        }

        public void removeMemberFromRoom(String streamId, long userId)
        {

            SymConfig symConfig = botClient.getConfig();
            NumericId id = new NumericId();
            id.id = userId;
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.REMOVEMEMBER.Replace("{id}", streamId);
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Post, symConfig, true);
            if (resp.StatusCode == HttpStatusCode.NoContent)
            {
                resp.Close();
                throw new Exception("No user found.");
            }
            else if (resp.StatusCode == HttpStatusCode.OK)
            {
                string body = restRequestHandler.ReadResponse(resp);
            }
            resp.Close();
        }

        public RoomInfo getRoomInfo(String streamId)
        {

            SymConfig symConfig = botClient.getConfig();
            RoomInfo roomInfo = new RoomInfo();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.GETROOMINFO.Replace("{id}", streamId);
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Get, symConfig, true);
            if (resp.StatusCode == HttpStatusCode.NoContent)
            {
                resp.Close();
                throw new Exception("No user found.");
            }
            else if (resp.StatusCode == HttpStatusCode.OK)
            {
                string body = restRequestHandler.ReadResponse(resp);
                roomInfo = JsonConvert.DeserializeObject<RoomInfo>(body);
            }
            resp.Close();
            return roomInfo;
        }

        public RoomInfo updateRoom(String streamId, Room room) 
        {

            SymConfig symConfig = botClient.getConfig();
            RoomInfo roomInfo = new RoomInfo();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.UPDATEROOMINFO.Replace("{id}", streamId);
            HttpWebResponse resp = restRequestHandler.executeRequest(room, url, false, WebRequestMethods.Http.Post, symConfig, true);
            //.post(Entity.entity(room, MediaType.APPLICATION_JSON));
            if (resp.StatusCode == HttpStatusCode.NoContent)
            {
                resp.Close();
                throw new Exception("No user found.");
            }
            else if (resp.StatusCode == HttpStatusCode.OK)
            {
                string body = restRequestHandler.ReadResponse(resp);
                roomInfo = JsonConvert.DeserializeObject<RoomInfo>(body);
            }
            resp.Close();
            return roomInfo;
         }

    //TODO: CHECK WHY 404
        public StreamInfo getStreamInfo(String streamId) 
        {

            SymConfig symConfig = botClient.getConfig();
            StreamInfo streamInfo = new StreamInfo();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.GETSTREAMINFO.Replace("{id}", streamId);
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Get, symConfig, true);
            if (resp.StatusCode == HttpStatusCode.NoContent)
            {
                resp.Close();
                throw new Exception("No stream found.");
            }
            else if (resp.StatusCode == HttpStatusCode.OK)
            {
                string body = restRequestHandler.ReadResponse(resp);
                streamInfo = JsonConvert.DeserializeObject<StreamInfo>(body);
            }
            resp.Close();
            return streamInfo;
        }

        public List<RoomMember> getRoomMembers(String streamId)
        {

            SymConfig symConfig = botClient.getConfig();
            List<RoomMember> roomMembers = new List<RoomMember>();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.GETROOMMEMBERS.Replace("{id}", streamId);
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Get, symConfig, true);
            if (resp.StatusCode == HttpStatusCode.NoContent)
            {
                resp.Close();
                throw new Exception("No stream found.");
            }
            else if (resp.StatusCode == HttpStatusCode.OK)
            {
                string body = restRequestHandler.ReadResponse(resp);
                roomMembers = JsonConvert.DeserializeObject<List<RoomMember>>(body);
            }
            resp.Close();
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

            SymConfig symConfig = botClient.getConfig();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.SETACTIVE.Replace("{id}", streamId);
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Post, symConfig, true);
            if (resp.StatusCode == HttpStatusCode.OK)
            {
                string body = restRequestHandler.ReadResponse(resp);
            }
            resp.Close();
        }

        public void promoteUserToOwner(String streamId, long userId) 
        {

            SymConfig symConfig = botClient.getConfig();
            NumericId id = new NumericId();
            id.id = userId;
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.PROMOTEOWNER.Replace("{id}", streamId);
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Post, symConfig, true);
            resp.Close();
         }

        public void demoteUserFromOwner(String streamId, long userId)
        {
            SymConfig symConfig = botClient.getConfig();
            NumericId id = new NumericId();
            id.id = userId;
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.DEMOTEOWNER.Replace("{id}", streamId);
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Post, symConfig, true);
            resp.Close();
        }

        //TODO: CHECK WHY 500
        public RoomSearchResult searchRooms(RoomSearchQuery query, int skip, int limit)
        {
            RoomSearchResult result = null;
            SymConfig symConfig = botClient.getConfig();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.SEARCHROOMS;


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
            if (query.labels == null)
            {
                query.labels = new List<String>();
            }
            HttpWebResponse resp = restRequestHandler.executeRequest(query, url, false, WebRequestMethods.Http.Post, symConfig, true);
            string body = restRequestHandler.ReadResponse(resp);
            result = JsonConvert.DeserializeObject<RoomSearchResult>(body);
            resp.Close();
            return result;
    }

    public List<StreamListItem> getUserStreams(List<String> streamTypes, Boolean includeInactiveStreams) 
    {
            List<Dictionary<String, String>> inputStreamTypes = new List<Dictionary<String, String>>();
            if (streamTypes != null)
            {
                foreach (String type in streamTypes)
                {
                    Dictionary<String, String> streamTypesMap = new Dictionary<string, string>();
                    streamTypesMap.Add("type", type);
                    inputStreamTypes.Add(streamTypesMap);
                }
            }

            Dictionary<String, Object> input = new Dictionary<String, Object>();
            input.Add("streamTypes", inputStreamTypes);
            input.Add("includeInactiveStreams", includeInactiveStreams);

            SymConfig symConfig = botClient.getConfig();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.podHost + ":" + symConfig.podPort + PodConstants.LISTUSERSTREAMS;
            HttpWebResponse resp = restRequestHandler.executeRequest(input, url, false, WebRequestMethods.Http.Post, symConfig, true);
            string body = restRequestHandler.ReadResponse(resp);
            resp.Close();
            return JsonConvert.DeserializeObject<StreamInfoList>(body);
        }

        public StreamListItem getUserWallStream() 
        {
            List<String> streamTypes = new List<String>();
                streamTypes.Add("POST");
                return getUserStreams(streamTypes, false)[0];
         }

     }
}
