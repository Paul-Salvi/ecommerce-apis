using Ecommerce.Connector.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;


namespace Skeleton.Host.Controllers
{
    [Route("ecom/v1.0/health")]
    public class HealthCheckController : Controller
    {
        readonly IHealthCheck _healthCheck;

        public HealthCheckController(IHealthCheck healthCheck)
        {
            _healthCheck = healthCheck;
        }

        /// <summary>
        /// Health status of service
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetHealthCheckAsync()
        {
           
            var consulStatus = await _healthCheck.GetApplicationStatusAsync();           
            if (consulStatus.IsHealthy)
            {
                return Ok(consulStatus);
            }
            return StatusCode((int)HttpStatusCode.InternalServerError, consulStatus);

        }


    }
}
