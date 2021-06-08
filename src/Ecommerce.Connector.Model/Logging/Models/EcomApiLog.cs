using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Connector.Model
{
    [Serializable]
    public  class EcomApiLog : ApiLog
    {       
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public string SessionId { get; set; }

        public override IEnumerable<KeyValuePair<string, object>> GetFields()
        {
            var extraFields = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object> ("className", ClassName),
                new KeyValuePair<string, object> ("methodName", MethodName),
                new KeyValuePair<string, object>("sessionId", SessionId)

            };
            extraFields.AddRange(base.GetFields());

            return extraFields;
        }

    }
}
