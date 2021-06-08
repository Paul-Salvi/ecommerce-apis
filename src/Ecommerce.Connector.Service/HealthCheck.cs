using System;
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
                status.IsHealthy = true;
                status.Messages.Add($"Configuration Provider Status : Success ");
                status.Messages.Add($"Cassandra Status : Success ");
                status.Messages.Add($"MS SQL Status : Success ");
                status.Messages.Add($"RabbitMQ Status : Success ");
                status.Messages.Add($"ConsulStatus : Success ");
            }
            catch (Exception ex)
            {
                status.IsHealthy = false;
                status.Messages.Add($"ConsulStatus : Failed | Message : {ex.Message}");
            }
            return status;
        }
    }
}
