using System;
using System.Collections.Generic;
using System.Net;

namespace Ecommerce.Connector.Model
{
    [Serializable]
    public class ApiLog : LogBase
    {
        public string Url { get; set; }

        public string Api { get; set; }

        public string Verb { get; set; }

        public IPAddress ClientIp { get; set; }

        public string RequestHeaders { get; set; }

        public string ResponseHeaders { get; set; }

        public string Request { get; set; }

        public string Response { get; set; }

        public bool IsSuccessful { get; set; }

        public double TimeTakenInMs { get; set; }

        public string TransactionId { get; set; }

        public override string Type { get; } = KeyStore.LogType.Api;

        protected override List<KeyValuePair<string, object>> GetLogFields()
        {
            return new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object> ("url", Url),
                new KeyValuePair<string, object> ("api", Api),
                new KeyValuePair<string, object> ("verb", Verb),
                new KeyValuePair<string, object> ("status", IsSuccessful ? "success" : "failure"),
                new KeyValuePair<string, object> ("time_taken_ms", Math.Round(TimeTakenInMs,3)),              
                new KeyValuePair<string, object> ("request", Request),
                new KeyValuePair<string, object> ("response", Response),
                new KeyValuePair<string, object> ("client_ip", ClientIp),
                new KeyValuePair<string, object> ("rq_headers", RequestHeaders),
                new KeyValuePair<string, object> ("rs_headers", ResponseHeaders)
            };
        }
    }
    
}
