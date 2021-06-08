using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Connector.Model
{
    
    [Serializable]
    public class ExceptionLog : LogBase
    {
        public ExceptionLog()
        {
        }

        public ExceptionLog(Exception ex)
        {
            ExceptionType = ex.GetType().Name;
            Message = ex.Message;
            Source = ex.Source;
            StackTrace = ex.StackTrace;
            InnerException = ex.InnerException?.ToString();
            SetData(ex.Data);
        }

        private void SetData(IDictionary data)
        {
            foreach(var key in data.Keys.OfType<string>())
            {
                var value = data[key];
                if (value != null)
                    this.TrySetValue(key, value);
            }
        }

        public override string Type { get; } = KeyStore.LogType.Exception;

        public string ExceptionType { get; set; }

        public string StackTrace { get; set; }


        public string Source { get; set; }

        public string InnerException { get; set; }

        protected override List<KeyValuePair<string, object>> GetLogFields()
        {
            return new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object> ("ex_type", ExceptionType),
                new KeyValuePair<string, object> ("stack_trace", StackTrace),
                new KeyValuePair<string, object> ("source", Source),
                new KeyValuePair<string, object> ("inner_exception", InnerException)
            };
        }

    }
    
}
