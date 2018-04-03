using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using apiClientDotNet.Models;
using apiClientDotNet;
using apiClientDotNet.Listeners;
using apiClientDotNet.Services;
using apiClientDotNet.Models.Events;

namespace apiClientDotNetTest
{
    [TestClass]
    public class MessageTest
    {
        [TestMethod]
        public void MessageRoomTest()
        {
            SymBotClient symBotClient = new SymBotClient();
            SymConfig symConfig = symBotClient.initBot("C:/Users/Michael/Documents/Visual Studio 2017/Projects/apiClientDotNet/apiClientDotNetTest/Resources/testConfig.json");
            Message message = new Message();
            message.message = "<messageML>Hello world!</messageML>";

            Stream stream = new Stream();
            stream.streamId = "YuijXsC6SIKg7rbExqJ7dX___p15TcofdA";

            MessageClient messageClient = new apiClientDotNet.MessageClient();
            messageClient.sendMessage(symConfig, message, stream);

            Assert.IsTrue(true);
        }
    }
}
