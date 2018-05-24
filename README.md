# symphony-api-client-dotnet
Symphony API Client for .NET. This client is event based. If you are building a bot that listens to conversations, you will only have to implement an interface of a listener with the functions to handle all events that will come through the Datafeed. 

###Install using Package Manager
Install-Package symphony-apiclient-dotnet -Version 1.0.2	

###Install using dotnet cli
dotnet add package symphony-apiclient-dotnet --version 1.0.2

## Configuration
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
          "proxyURL": "",
          "proxyUsername": "",
          "proxyPassword": "",
          "sessionProxyURL": "",
          "sessionProxyUsername": "",
          "sessionProxyPassword": "",
          "authTokenRefreshPeriod": "30"
        }
        
## Proxy Settings

###One Proxy
If all of the traffic to your instance of Symphony goes through a single proxy to make Pod and Session Auth calls set the folling configuration information. 

          "proxyURL": "",
          "proxyUsername": "",
          "proxyPassword": "",

###Two Proxies 
If the traffic to your instance of Symphony is split between two proxys, one for Pod calls and a second for SessionAuth calls set the following configuration information. 

  Pod call proxy info:
          "proxyURL": "",
          "proxyUsername": "",
          "proxyPassword": "",
  SesssionAuth proxy info:
          "sessionProxyURL": "",
          "sessionProxyUsername": "",
          "sessionProxyPassword": "",
