using System.Collections.Generic;

namespace Ecommerce.Connector.Service
{
    public class HealthStatus
    {
        public bool IsHealthy { get; set; } = false;
        public List<AppStatus> Status { get; } = new List<AppStatus>();
    }
    public class AppStatus
    {
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
