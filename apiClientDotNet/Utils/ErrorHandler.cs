using System;
using System.Collections.Generic;
using System.Text;
using apiClientDotNet.Models;
using apiClientDotNet.Models.Events;
using apiClientDotNet.Utils;
using apiClientDotNet.Listeners;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace apiClientDotNet.Utils
{
    public class ErrorHandler
    {
        public void handleError(HttpWebResponse response)
        {
            try {
                if (response.StatusCode == HttpStatusCode.BadRequest){
                    //logger.error("Client error occurred", error);
                    throw new Exception("Bad Request Error");
                 } else if (response.StatusCode == HttpStatusCode.Unauthorized){
                    //logger.error("User unauthorized, refreshing tokens");
                    //botClient.getSymBotAuth().authenticate();
                    throw new Exception("Bad Tokens");
                } else if (response.StatusCode == HttpStatusCode.Forbidden){
                    //logger.error("Forbidden: Caller lacks necessary entitlement.");
                    throw new Exception("Forbidden Error");
                } else if (response.StatusCode == HttpStatusCode.InternalServerError) {
                    //logger.error(error.getMessage());
                    throw new Exception("Bad 500");
                }
            } catch (Exception e){
                //Print
            }

        }
    }
}
