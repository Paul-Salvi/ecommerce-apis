using System;
using System.Collections.Generic;

namespace Ecommerce.Connector.Model
{
    [Serializable]
    public class TraceLog : LogBase
    {
        public string Category { get; set; }

        public override string Type { get; } = KeyStore.LogType.Trace;

        protected override List<KeyValuePair<string, object>> GetLogFields()
        {
            return new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object> ("category", Category)
            };
        }

        public static TraceLog GenerateTraceLog(string message)
        {
            TraceLog trace = new TraceLog();
            EcomCallContext context = EcomCallContext.Current;

            if (context != null)
            {
                trace.ApplicationName = context.ApplicationName;                
                trace.CorrelationId = context.CorrelationId;
                trace.Message = message;
            }

            return trace;
        }
    }
}
