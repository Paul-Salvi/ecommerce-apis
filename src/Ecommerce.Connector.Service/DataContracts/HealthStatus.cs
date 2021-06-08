using System.Collections.Generic;

namespace Ecommerce.Connector.Service
{
    public class HealthStatus
    {
        public bool IsHealthy { get; set; }
        public List<string> Messages { get; } = new List<string>();
    }
}
