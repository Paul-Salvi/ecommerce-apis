using Microsoft.AspNetCore.Builder;

namespace Ecommerce.Connector.Host.WebApis
{
    public static class ContextInjectorMiddlewareExtension
    {
        public static IApplicationBuilder UseContextInjector(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ContextInjectorMiddleware>();
        }
    }
}
