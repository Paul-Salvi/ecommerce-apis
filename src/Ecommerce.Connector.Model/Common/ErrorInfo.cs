using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Ecommerce.Connector.Model
{
    public  class ErrorInfo
    {
        public ErrorInfo(string code, string message, HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError)
        {
            Code = code;
            Message = message;
            HttpStatusCode = httpStatusCode;
        }

        public string Code { get; }
        public string Message { get; }
        public HttpStatusCode HttpStatusCode { get; }
        public List<Info> Info { get; } = new List<Info>();
    }

    public sealed class Info
    {
        public Info(string code, string message)
        {
            Code = code;
            Message = message;
        }
        public string Code { get; }
        public string Message { get; set; }
    }
}
