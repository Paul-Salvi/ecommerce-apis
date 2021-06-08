using System;

namespace Ecommerce.Connector.Model
{
    [Serializable]
    public class EcomExceptionLog : ExceptionLog
    {
        public string Api { get; set; }
        public string Verb { get; set; }
      
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public string SessionId { get; set; }

        public EcomExceptionLog(Exception exception) : base(exception)
        {
        }
    }
}
