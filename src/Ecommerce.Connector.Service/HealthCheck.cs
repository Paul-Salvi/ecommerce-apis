using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Connector.Service
{
    public class HealthCheck : IHealthCheck
    {
        public async Task<HealthStatus> GetApplicationStatusAsync()
        {
            var status = new HealthStatus();
            try
            {
                status.Status.Add(new AppStatus() { Name = "Configuration Provider", Status = "Success" });
                status.Status.Add(new AppStatus() { Name = "Cassandra", Status = "Success" });
                status.Status.Add(new AppStatus() { Name = "MS SQL", Status = "Success" });
                status.Status.Add(new AppStatus() { Name = "RabbitMQ", Status = "Failure" });
                status.Status.Add(new AppStatus() { Name = "Consul", Status = "Success" });

                if (!status.Status.Any(z => z.Status != "Success"))
                    status.IsHealthy = true;

            }
            catch (Exception ex)
            {
                status.IsHealthy = false;
            }
            return status;
        }
    }
}
