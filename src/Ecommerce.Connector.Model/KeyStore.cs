namespace Ecommerce.Connector.Model
{
    public static class KeyStore
    {
        public const string ApplicationName = "ecommerce-engine";

        public static class Api
        {
            public const string HealthCheck = "health_check";
        }
        public static class Verb
        {
            public static readonly string HealthCheck = "healthy";
        }
        public static class HeaderName
        {           
            public static readonly string ApiKey = "apiKey";
            public static readonly string SessionId = "sessionId";
            public static readonly string CorrelationId = "correlationId";
            public static readonly string IpAddress = "userIp";
            public static readonly string AcceptLanguage = "accept-language";
            public static readonly string UserId = "userId";
         
        }
        public static class LogType
        {
            public const string Api = "api";
            public const string Exception = "exception";
            public const string Trace = "trace";
        }
    }
}
