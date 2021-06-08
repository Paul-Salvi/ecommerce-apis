using System.Threading.Tasks;

namespace Ecommerce.Connector.Service
{
    public interface IHealthCheck
    {
        Task<HealthStatus> GetApplicationStatusAsync();
    }
}
