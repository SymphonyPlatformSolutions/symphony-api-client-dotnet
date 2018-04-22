using System;
using System.Collections.Generic;
using System.Text;
using apiClientDotNet.Models;
using apiClientDotNet.Models.Events;
using apiClientDotNet.Listeners;
using apiClientDotNet.Utils;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;



namespace apiClientDotNet.Services
{
    public class DatafeedEventsService
    {
        private List<RoomListener> roomListeners;
        private List<IMListener> IMListeners;
        private List<ConnectionListener> connectionListeners;
        private DatafeedClient datafeedClient;

        public DatafeedClient init(SymConfig symConfig)
        {
            roomListeners = new List<RoomListener>();
            IMListeners = new List<IMListener>();
            connectionListeners = new List<ConnectionListener>();
            datafeedClient = new DatafeedClient();

            return datafeedClient;
        }

        public Datafeed createDatafeed(SymConfig symConfig, DatafeedClient datafeedClient)
        {
            Datafeed datafeed = datafeedClient.createDatafeed(symConfig);
            return datafeed;
        }

        static bool stopLoop = false;

        public void getEventsFromDatafeed(SymConfig symConfig, Datafeed datafeed, DatafeedClient datafeedClient)
        {
            List<DatafeedEvent> events = new List<DatafeedEvent>();
            while (!stopLoop)
            {
                events = RunAsync(symConfig, datafeed, datafeedClient).GetAwaiter().GetResult();
                if (events != null)
                {
                    handleEvents(events);
                }
                getEventsFromDatafeed(symConfig, datafeed, datafeedClient);
            }

        }

        static async Task<List<DatafeedEvent>> RunAsync(SymConfig symConfig, Datafeed datafeed, DatafeedClient datafeedClient)
        {
            
            List<DatafeedEvent> events = new List<DatafeedEvent>();
            try
            {
                events = await GetEventAsync(symConfig, datafeed, datafeedClient);
                return events;     
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return events;
            }
            
        }

        static async Task<List<DatafeedEvent>> GetEventAsync(SymConfig symConfig, Datafeed datafeed, DatafeedClient datafeedClient)
        {
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            HttpWebResponse response = datafeedClient.getEventsFromDatafeed(symConfig, datafeed);
            if (response.StatusCode.Equals(HttpStatusCode.OK) || response.StatusCode.Equals(HttpStatusCode.Accepted))
            {
                try
                {
                    string body = restRequestHandler.ReadResponse(response);
                    List<DatafeedEvent> events = JsonConvert.DeserializeObject<List<DatafeedEvent>>(body);
                    return events;
                }
                catch (JsonSerializationException e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
            }
            else if (response.StatusCode.Equals(HttpStatusCode.NoContent))
            {
                return null;
            }
            else if (response.StatusCode.Equals(HttpStatusCode.Forbidden) || response.StatusCode.Equals(HttpStatusCode.Unauthorized))
            {
                SymBotAuth symBotAuth = new SymBotAuth();
                symConfig.authTokens = symBotAuth.authenticate(symConfig);
                stopLoop = true;
                return null;
            }
            else if (response.StatusCode.Equals(HttpStatusCode.BadRequest))
            {
                stopLoop = true;
            }
            return null;
        }



        private void handleEvents(List<DatafeedEvent> datafeedEvents)
        {
            foreach (DatafeedEvent eventv4 in datafeedEvents)
            {
                switch (eventv4.type)
                {
                    case "MESSAGESENT":

                        MessageSent messageSent = eventv4.payload.messageSent;
                        if (messageSent.message.stream.streamType.Equals("ROOM"))
                        {
                            foreach (RoomListener listener in roomListeners)
                            {
                                listener.onRoomMessage(messageSent.message);
                            }
                        }
                        else
                        {
                            foreach (IMListener listener in IMListeners)
                            {
                                listener.onIMMessage(messageSent.message);
                            }
                        }
                        break;
                    case "INSTANTMESSAGECREATED":

                        foreach (IMListener listeners in IMListeners)
                        {
                            listeners.onIMCreated(eventv4.payload.instantMessageCreated.stream);
                        }
                        break;

                    case "ROOMCREATED":

                        foreach (RoomListener listener in roomListeners)
                        {
                            listener.onRoomCreated(eventv4.payload.roomCreated);
                        }
                        break;

                    case "ROOMUPDATED":

                        foreach (RoomListener listener in roomListeners)
                        {
                            listener.onRoomUpdated(eventv4.payload.roomUpdated);
                        }
                        break;

                    case "ROOMDEACTIVATED":

                        foreach (RoomListener listener in roomListeners)
                        {
                            listener.onRoomDeactivated(eventv4.payload.roomDeactivated);
                        }
                        break;

                    case "ROOMREACTIVATED":

                        foreach (RoomListener listener in roomListeners)
                        {
                            listener.onRoomReactivated(eventv4.payload.roomReactivated.stream);
                        }
                        break;

                    case "USERJOINEDROOM":

                        foreach (RoomListener listener in roomListeners)
                        {
                            listener.onUserJoinedRoom(eventv4.payload.userJoinedRoom);
                        }
                        break;

                    case "USERLEFTROOM":

                        foreach (RoomListener listener in roomListeners)
                        {
                            listener.onUserLeftRoom(eventv4.payload.userLeftRoom);
                        }
                        break;

                    case "ROOMMEMBERPROMOTEDTOOWNER":

                        foreach (RoomListener listener in roomListeners)
                        {
                            listener.onRoomMemberPromotedToOwner(eventv4.payload.roomMemberPromotedToOwner);
                        }
                        break;

                    case "ROOMMEMBERDEMOTEDFROMOWNER":

                        foreach (RoomListener listener in roomListeners)
                        {
                            listener.onRoomMemberDemotedFromOwner(eventv4.payload.roomMemberDemotedFromOwner);
                        }
                        break;

                    case "CONNECTIONACCEPTED":

                        foreach (ConnectionListener listener in connectionListeners)
                        {
                            listener.onConnectionAccepted(eventv4.payload.connectionAccepted.fromUser);
                        }
                        break;

                    case "CONNECTIONREQUESTED":

                        foreach (ConnectionListener listener in connectionListeners)
                        {
                            listener.onConnectionRequested(eventv4.payload.connectionRequested.toUser);
                        }
                        break;

                    default:
                        break;

                }
            }
        }

        public void addRoomListener(RoomListener listener)
        {
            roomListeners.Add(listener);
        }

        public void removeRoomListener(RoomListener listener)
        {
            roomListeners.Remove(listener);
        }

        public void addIMListener(IMListener listener)
        {
            IMListeners.Add(listener);
        }

        public void removeIMListener(IMListener listener)
        {
            IMListeners.Remove(listener);
        }

        public void addConnectionsListener(ConnectionListener listener)
        {
            connectionListeners.Add(listener);
        }

        public void removeConnectionsListener(ConnectionListener listener)
        {
            connectionListeners.Remove(listener);
        }
    }
}
