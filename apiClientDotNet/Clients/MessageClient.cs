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

namespace apiClientDotNet
{
    public class MessageClient
    {
        private SymBotClient botClient;

        public MessageClient(SymBotClient client)
        {
            botClient = client;

        }

        public InboundMessage sendMessage(String streamId, OutboundMessage message, Boolean appendTags)
        {
            SymConfig symConfig = botClient.getConfig();
            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = "https://" + symConfig.agentHost + ":" + symConfig.agentPort + "/agent/v4/stream/" + streamId + "/message/create";
            HttpWebResponse resp = restRequestHandler.executeRequest(message, url, false, WebRequestMethods.Http.Post, symConfig, true);
            string body = restRequestHandler.ReadResponse(resp);
            InboundMessage inboundMessage = JsonConvert.DeserializeObject<InboundMessage>(body);
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
            List<InboundMessage> result = null;
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
            List<InboundMessage> inboundMessages = JsonConvert.DeserializeObject<List<InboundMessage>>(body);

            return inboundMessages;
        }

        public byte[] getAttachment(String streamId, String attachmentId, String messageId)
        {

            SymConfig symConfig = botClient.getConfig();

            RestRequestHandler restRequestHandler = new RestRequestHandler();
            string url = CommonConstants.HTTPSPREFIX + symConfig.agentHost + ":" + symConfig.agentPort + AgentConstants.GETATTACHMENT.Replace("{sid}", streamId) + "?fieldId=" + attachmentId + "&messageId=" + messageId;

            HttpWebResponse resp = restRequestHandler.executeRequest(null, url, false, WebRequestMethods.Http.Get, symConfig, true);
            string body = restRequestHandler.ReadResponse(resp);
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
            MessageStatus messageStatus = JsonConvert.DeserializeObject<MessageStatus>(body);
            return messageStatus;

        }

       
    }
}
