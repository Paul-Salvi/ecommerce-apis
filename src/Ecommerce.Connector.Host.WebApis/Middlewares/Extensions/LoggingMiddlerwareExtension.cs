using Microsoft.AspNetCore.Builder;

namespace Ecommerce.Connector.Host.WebApis
{
    public static class LoggingMiddlerwareExtension
    {
        public static IApplicationBuilder UseLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
