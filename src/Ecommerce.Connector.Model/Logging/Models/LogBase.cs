using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Reflection;

namespace Ecommerce.Connector.Model
{
    [Serializable]
    public abstract class LogBase : ILog
    {

        protected LogBase()
        {
            Id = Guid.NewGuid().ToString();
            LogTime = DateTime.UtcNow;
            ProcessId = Process.GetCurrentProcess().Id;
            MachineName = Environment.MachineName;
        }

        public virtual IEnumerable<KeyValuePair<string, object>> GetFields()
        {
           
            var map = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
            {
                { "id", Id },
                { "log_time", LogTime },
                { "pid", ProcessId },
                { "machine", MachineName },
                { "app_domain", AppDomain },
                { "type", Type },
                { "msg", Message },
                { "app_name", ApplicationName },               
                { "cid", CorrelationId }                              
               
            };
            
            var fields = GetLogFields();
            fields?.ForEach(f => map[f.Key] = f.Value);

           
            foreach (var key in _attributes.Keys)
            {
                if (map.ContainsKey(key) == true && map[key] != null)
                    map["attr_" + key] = _attributes[key];
                else
                    map[key] = _attributes[key];
            }
            return map.ToList();
        }

      

        protected abstract List<KeyValuePair<string, object>> GetLogFields();

      

        public abstract string Type { get; }
        
        public string Message { get; set; }

        public string Id { get; set; }

        public string AppDomain { get; set; }

        public DateTime LogTime { get; set; }

        public int ProcessId { get; set; }

        public string MachineName { get; set; }

        public string ApplicationName { get; set; }     

        public string CorrelationId { get; set; }  
     

        private readonly IDictionary<string, object> _attributes = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

       

        public bool TrySetValue(string name, object value)
        {  
            _attributes[name] = value;
            return true;
        }

        public void SetValue(string name, string value)
        {
            _attributes[name] = value;
        }

      

        public void SetValue(string name, DateTime value)
        {
            _attributes[name] = value;
        }

        public void SetValue(string name, long value)
        {
            _attributes[name] = value;
        }

        public void SetValue(string name, int value)
        {
            _attributes[name] = value;
        }

        public void SetValue(string name, ulong value)
        {
            _attributes[name] = value;
        }

        public void SetValue(string name, uint value)
        {
            _attributes[name] = value;
        }

        public void SetValue(string name, float value)
        {
            _attributes[name] = value;
        }

        public void SetValue(string name, double value)
        {
            _attributes[name] = value;
        }

        public void SetValue(string name, decimal value)
        {
            _attributes[name] = value;
        }

        public void SetValue(string name, bool value)
        {
            _attributes[name] = value;
        }


        public void SetValue(string name, IPAddress ip)
        {
            _attributes[name] = ip;
        }
    }

}
