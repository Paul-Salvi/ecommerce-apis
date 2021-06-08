using System.Collections.Specialized;
using System.Globalization;
using System.Net;

namespace Ecommerce.Connector.Model
{
    public class CallContextBase : AmbientContextBase
    {
        public new static CallContextBase Current => (CallContextBase)AmbientContextBase.Current;
        public NameValueCollection Headers { get; } = new NameValueCollection();
        public string ApplicationName { get; protected internal set; }
        public CultureInfo Culture { get; protected internal set; }
        public string CorrelationId { get; protected internal set; }
        public IPAddress IpAddress { get; protected internal set; }

    }
}
