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

namespace apiClientDotNet
{
    public class MessageClient
    {
        private ISymClient botClient;

        public MessageClient(ISymClient client)
        {
            botClient = client;

        }

        public InboundMessage sendMessage(String streamId, OutboundMessage message, Boolean appendTags)
        {
            SymConfig symConfig = botClient.getConfig();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = "https://" + symConfig.agentHost + ":" + symConfig.agentPort + "/agent/v4/stream/" + streamId + "/message/create";
            if(botClient is SymOBOClient)
            {
                symConfig.authTokens.sessionToken = botClient.getSymAuth().getSessionToken();
            }
            if (appendTags && message.message != null) {
                message.message = "<messageML>" + message.message + "</messageML>";
            }
            HttpResponseMessage resp = restRequestHandler.executePostFormRequest(message, url, symConfig);
            InboundMessage inboundMessage = JsonConvert.DeserializeObject<InboundMessage>(resp.Content.ReadAsStringAsync().Result);
            return inboundMessage;
        }

        public InboundMessage forwardMessage(String streamId, InboundMessage message)
        {
            OutboundMessage outboundMessage = new OutboundMessage();
            outboundMessage.message = message.message;
            outboundMessage.data = message.data;
            //outboundMessage.setAttachment(message.getAttachments());

            return sendMessage(streamId, outboundMessage, false);

        }

        public List<InboundMessage> getMessagesFromStream(String streamId, int since, int skip, int limit)
        {
            List<InboundMessage> inboundMessages = null;
            SymConfig symConfig = botClient.getConfig();

            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string getMessageUrl = AgentConstants.GETMESSAGES.Replace("{sid}", streamId);
            string url = CommonConstants.HTTPSPREFIX + symConfig.agentHost + ":" + symConfig.agentPort + getMessageUrl + "?since=" + since.ToString();


            if (skip > 0)
            {
                url = url + "&skip=" + skip;
            }
            if (limit > 0)
            {
                url = url + "&limit=" + limit;
            }
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Get, symConfig, true);
            string body = restRequestHandler.ReadResponse(resp);
            resp.Close();
            inboundMessages = JsonConvert.DeserializeObject<List<InboundMessage>>(body);

            return inboundMessages;
        }

        public byte[] getAttachment(String streamId, String attachmentId, String messageId)
        {

            SymConfig symConfig = botClient.getConfig();

            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.agentHost + ":" + symConfig.agentPort + AgentConstants.GETATTACHMENT.Replace("{sid}", streamId) + "?fieldId=" + attachmentId + "&messageId=" + messageId;

            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Get, symConfig, true);
            string body = restRequestHandler.ReadResponse(resp);
            resp.Close();
            var base64EncodedBytes = System.Convert.FromBase64String(body);

            return base64EncodedBytes;

        }

        public List<FileAttachment> getMessageAttachments(InboundMessage message)
        {
            List<FileAttachment> result = new List<FileAttachment>();
            List<Attachment> messageAttachments = message.attachments;
            foreach (Attachment attachment in messageAttachments)
            {
                FileAttachment fileAttachment = new FileAttachment();
                fileAttachment.fileName = attachment.name;
                fileAttachment.size = attachment.size;
                fileAttachment.fileContent = getAttachment(message.stream.streamId, attachment.id, message.messageId);
                result.Add(fileAttachment);
            }
            return result;
        }

        public MessageStatus getMessageStatus(String messageId)
        {

            SymConfig symConfig = botClient.getConfig();

            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.agentHost + ":" + symConfig.agentPort + PodConstants.GETMESSAGESTATUS.Replace("{mid}", messageId);

            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Get, symConfig, true);
            string body = restRequestHandler.ReadResponse(resp);
            resp.Close();
            MessageStatus messageStatus = JsonConvert.DeserializeObject<MessageStatus>(body);
            return messageStatus;

        }

        //////////////////////
       /* public InboundMessageList messageSearch(Dictionary<String, String> query, int skip, int limit, Boolean orderAscending)
            {

            InboundMessageList result = null;
            SymConfig symConfig = botClient.getConfig();

            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.agentHost + ":" + symConfig.agentPort + AgentConstants.SEARCHMESSAGES;


            if (skip > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&skip=" + skip;
                } else
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
            if (orderAscending)
            {
                if (url.Contains("?"))
                {
                    url = url + "&sortDir=ASC";
                }
                else
                {
                    url = url + "?sortDir=ASC";
                }
            }
            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Get, symConfig, true);
            string body = restRequestHandler.ReadResponse(resp);
            InboundMessageList inboundMessages = JsonConvert.DeserializeObject<InboundMessageList>(body);

            return inboundMessages;
        }

   /* public InboundImportMessageList importMessages(OutboundImportMessageList messageList) 
    {
            SymConfig symConfig = botClient.getConfig();

            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.agentHost + ":" + symConfig.agentPort + AgentConstants.MESSAGEIMPORT;

            Response response
                    = botClient.getAgentClient().target(CommonConstants.HTTPSPREFIX + botClient.getConfig().getAgentHost() + ":" + botClient.getConfig().getAgentPort())
                    .path(AgentConstants.MESSAGEIMPORT)
                    .request(MediaType.APPLICATION_JSON)
                    .header("sessionToken",botClient.getSymAuth().getSessionToken())
                    .header("keyManagerToken", botClient.getSymAuth().getKmToken())
                    .post(Entity.entity(messageList,MediaType.APPLICATION_JSON));
            if (response.getStatusInfo().getFamily() != Response.Status.Family.SUCCESSFUL) {
            try
            {
                handleError(response, botClient);
            }
            catch (UnauthorizedException ex)
            {
                return importMessages(messageList);
            }
            return null;
        } else {
            return response.readEntity(InboundImportMessageList.class);
            }
        }

    public SuppressionResult suppressMessage(String id) throws SymClientException
{
    Response response
                = botClient.getAgentClient().target(CommonConstants.HTTPSPREFIX + botClient.getConfig().getPodHost() + ":" + botClient.getConfig().getPodPort())
                .path(PodConstants.MESSAGESUPPRESS.replace("{id}",id))
                .request(MediaType.APPLICATION_JSON)
                .header("sessionToken",botClient.getSymAuth().getSessionToken())
                .post(null);
        if (response.getStatusInfo().getFamily() != Response.Status.Family.SUCCESSFUL) {
        try
        {
            handleError(response, botClient);
        }
        catch (UnauthorizedException ex)
        {
            return suppressMessage(id);
        }
        return null;
    } else {
        return response.readEntity(SuppressionResult.class);
        }
    }

    public InboundShare shareContent(String streamId, OutboundShare shareContent) throws SymClientException
{
    Map<String,Object> map = new HashMap<>();
        map.put("content",shareContent);
        Response response
                = botClient.getAgentClient().target(CommonConstants.HTTPSPREFIX + botClient.getConfig().getAgentHost() + ":" + botClient.getConfig().getAgentPort())
                .path(AgentConstants.SHARE.replace("{sid}", streamId))
                .request(MediaType.APPLICATION_JSON)
                .header("sessionToken", botClient.getSymAuth().getSessionToken())
                .header("keyManagerToken", botClient.getSymAuth().getKmToken())
                .post(Entity.entity(map, MediaType.APPLICATION_JSON));
        if (response.getStatusInfo().getFamily() != Response.Status.Family.SUCCESSFUL) {
            try {
                handleError(response, botClient);
            } catch (UnauthorizedException ex){
                return shareContent(streamId, shareContent);
            }
            return null;
        }
            return response.readEntity(InboundShare.class);
    }*/

    }
}
