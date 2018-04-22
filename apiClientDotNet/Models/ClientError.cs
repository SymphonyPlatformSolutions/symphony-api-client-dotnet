using System;
using System.Collections.Generic;
using System.Text;

namespace apiClientDotNet.Models
{
    public class ClientError
    {
        public int code { get; set; }
        public string message { get; set; }
        public Object details { get; set; }

    }
}
