# symphony-api-client-dotnet
Symphony API Client for .NET. This client is event based. If you are building a bot that listens to conversations, you will only have to implement an interface of a listener with the functions to handle all events that will come through the Datafeed. 

#### Install using Package Manager
    Install-Package symphony-apiclient-dotnet -Version 1.0.17	

#### Install using dotnet cli
    dotnet add package symphony-apiclient-dotnet --version 1.0.17

#### Support for Symphony Elements
Elements support is added in 1.0.18, however this version of the SDK requires some code change. An example of a Program.cs is provided at the end of the README.

## Configuration RSA

        {
            "sessionAuthHost": "<podname>.symphony.com",
            "sessionAuthPort": 443,
            "keyAuthHost": "<podname>.symphony.com",
            "keyAuthPort": 443,
            "podHost": "<podname>.symphony.com",
            "podPort": 443,
            "agentHost": "<podname>.symphony.com",
            "agentPort": 443,
            "botCertPath": "",
            "botCertName": "",
            "botCertPassword": "",
            "botPrivateKeyPath": "./rsa/",
            "botPrivateKeyName": "rsa-private-dotnetDemo.pem",
            "botUsername": "dotnetDemo",
            "botEmailAddress": "dotnet@demo.com",
            "appCertPath": "",
            "appCertName": "",
            "appCertPassword": "",
			// Optional, global proxy
            "proxyURL": "",
            "proxyUsername": "",
            "proxyPassword": "",
			// Optional, session host proxy
            "sessionProxyURL": "",
            "sessionProxyUsername":"",
            "sessionProxyPassword": "",
			// Optional, key manager host proxy
            "keyProxyURL": "",
            "keyProxyUsername":"",
            "keyProxyPassword": "",
			// Optional, pod host proxy
            "podProxyURL": "",
            "podProxyUsername":"",
            "podProxyPassword": "",
			// Optional, agent host proxy
            "agentProxyURL": "",
            "agentProxyUsername":"",
            "agentProxyPassword": "",
            "authTokenRefreshPeriod": "30",
            "truststorePath": ""
        }

## Configuration certificate
Create a config.json file in your project which includes the following properties

        {
			"sessionAuthHost": "COMPANYNAME-api.symphony.com",
			"sessionAuthPort": 8444,
			"keyAuthHost": "COMPANYNAME-api.symphony.com",
			"keyAuthPort": 8444,
			"podHost": "COMPANYNAME.symphony.com",
			"podPort": 443,
			"agentHost": "COMAPNYNAME.symphony.com",
			"agentPort": 443,
			"botCertPath": "PATH",
			"botCertName": "BOT-CERT-NAME",
			"botCertPassword": "BOT-PASSWORD",
			"botEmailAddress": "BOT-EMAIL-ADDRESS",
			"appCertPath": "",
			"appCertName": "",
			"appCertPassword": "",
			// Optional, global proxy
			"proxyURL": "",
			"proxyUsername": "",
			"proxyPassword": "",
			// Optional, session host proxy
			"sessionProxyURL": "",
			"sessionProxyUsername":"",
			"sessionProxyPassword": "",
			// Optional, key manager host proxy
			"keyProxyURL": "",
			"keyProxyUsername":"",
			"keyProxyPassword": "",
			// Optional, pod host proxy
			"podProxyURL": "",
			"podProxyUsername":"",
			"podProxyPassword": "",
			// Optional, agent host proxy
			"agentProxyURL": "",
			"agentProxyUsername":"",
			"agentProxyPassword": "",
			"authTokenRefreshPeriod": "30"
        }
        
## Proxy Settings

### One Proxy
If all of the traffic to your instance of Symphony goes through a single proxy to make Pod and Session Auth calls set the folling configuration information. 

          "proxyURL": "",
          "proxyUsername": "",
          "proxyPassword": "",

### Two Proxies 
If the traffic to your instance of Symphony is split between two proxys, one for Pod calls and a second for SessionAuth calls set the following configuration information. 

  Pod call proxy info:
  
          "proxyURL": "",
          "proxyUsername": "",
          "proxyPassword": "",
          
  SesssionAuth proxy info:
  
          "sessionProxyURL": "",
          "sessionProxyUsername": "",
          "sessionProxyPassword": "",
          
 # Example Elements Program.cs
        using System;
        using System.IO;
        using System.Net;
        using System.Net.Http;
        using apiClientDotNet;
        using apiClientDotNet.Models;
        using apiClientDotNet.Authentication;
        using apiClientDotNet.Services;
        using apiClientDotNet.Listeners;
        using apiClientDotNet.Models.Events;
        using apiClientDotNet.Clients.Constants;
        using System.Collections.Generic;
        using apiClientDotNet.Utils;

        public class MyIMListener : IMListener
        {
            private SymConfig symConfig;


            public void init(SymConfig symConfig)
            {
                this.symConfig = symConfig;
            }

            override public void onIMMessage(Message message)
            {
                string FirstCommand = "";
                string SearchTerm = null;
                string SearchStatus = null;

                if (message.message.Contains("/form"))
                {
                        string fresponse = "";
                        fresponse += "<form id=\"form_id\">";
                        fresponse += "<text-field name=\"Question_Subject\" required=\"true\" placeholder=\"Ask a Question\" />";
                        fresponse += "<textarea name=\"comment\" placeholder=\"Add details (optional)\" required=\"false\"></textarea>";
                        fresponse += "<button type=\"reset\">Reset</button>";
                        fresponse += "<button name=\"submit_button\" type=\"action\">Submit</button>";
                        fresponse += "</form>";
                        sendMessage(message.stream.streamId, fresponse);
                }
            }

            private void sendMessage(String streamId, String messageText)
            {
                Console.WriteLine("streamId:" + streamId);
                OutboundMessage message = new OutboundMessage();
                message.message = "<messageML>"+messageText+"</messageML>";                
                RestRequestHandler restRequestHandler = new RestRequestHandler();
                string url = "https://" + this.symConfig.agentHost + "/agent/v4/stream/" + streamId + "/message/create";
                HttpWebResponse resp = restRequestHandler.executeRequest(message, url, false, WebRequestMethods.Http.Post, symConfig, true);

            }
        }

        public class MyElementsActionListener : ElementsActionListener
        {
                private SymConfig symConfig;

                public void init(SymConfig symConfig)
                {
                        this.symConfig = symConfig;
                }

            override public void onFormMessage(User initiator, String fstreamid, SymphonyElementsAction fform)
            {
                string Question = "";
                string comment = "";

                foreach (var item in fform.formValues)
                {
                    if(item.Key == "Question_Subject"){ Question = item.Value.ToString();}
                    if(item.Key == "comment") {comment = item.Value.ToString();}
                }
                        Console.WriteLine("ACTION-- Question: " + Question + " , Comment: " + comment);
            }
        }


        namespace symphony_dotnet_bot_test
        {
            class Program
            {
                private static readonly String CURRENT_DIR = Directory.GetCurrentDirectory();
                private static readonly String CONFIGFILE = CURRENT_DIR + @"/config.json";

                static void Main(string[] args)
                {
                    try {
                        SymConfigLoader symConfigLoader = new SymConfigLoader();
                        SymConfig symConfig = symConfigLoader.loadFromFile(CONFIGFILE);

                        SymBotRSAAuth symAuth = new SymBotRSAAuth(symConfig);
                        symAuth.authenticate();

                        SymBotClient botClient = SymBotClient.initBot(symConfig,symAuth);

                        MyIMListener myIMListener = new MyIMListener();
                        myIMListener.init(symConfig);

                        MyElementsActionListener myElementsActionListener = new MyElementsActionListener();
                        myElementsActionListener.init(symConfig);

                        // start listening for messages
                        DatafeedEventsService dataFeedService = botClient.getDatafeedEventsService();
                        dataFeedService.addIMListener(myIMListener);
                        dataFeedService.addElementsActionListener(myElementsActionListener);
                        dataFeedService.getEventsFromDatafeed();
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex);
                    }
                }
            }
        }

          
