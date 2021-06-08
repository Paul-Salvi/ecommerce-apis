using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Net;

namespace Ecommerce.Connector.Model
{
    public class EcomCallContext : CallContextBase
    {
        public string SessionId { get; set; }
        public string UserId { get; set; }
        public DateTime? StartTime { get; protected internal set; }
        public string Api { get; set; }
        public string Verb { get; set; }
        public new static EcomCallContext Current => EcomCallContext.Current;


        public EcomCallContext(string api, string verb, CultureInfo culture, string sessionId, string correlationId, IPAddress ipAddress, string applicationName, NameValueCollection reqHeaders, DateTime? startTime = null,
         string userId = null)
        {
            Culture = culture;
            if (!string.IsNullOrWhiteSpace(correlationId))
                CorrelationId = correlationId;
            UserId = userId;
            SessionId = sessionId;
            ApplicationName = applicationName;

            Api = api;
            Verb = verb;
            ApplicationName = KeyStore.ApplicationName;
            Culture = culture;
            CorrelationId = correlationId;
            IpAddress = ipAddress;
            StartTime = startTime;
            if (reqHeaders != null)
                Headers.Add(reqHeaders);
        }
    
    }



}
