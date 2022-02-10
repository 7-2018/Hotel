using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class ActionResponse
    {

        public int StatusCode { get; set; }

        public String ResponseStatus { get; set; }

        public string ResponseMessage { get; set; }

        public ActionResponse(int statusCode, string responseStatus, string responseMessage)
        {
            StatusCode = statusCode;
            ResponseStatus = responseStatus;
            ResponseMessage = responseMessage;
        }

    }
}
