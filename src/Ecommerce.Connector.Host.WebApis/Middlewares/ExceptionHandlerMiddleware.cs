using Ecommerce.Connector.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace Ecommerce.Connector.Host.WebApis
{
    public class ExceptionHandlerMiddleware : ErrorHandlerMiddlewareBase
    {
        public ExceptionHandlerMiddleware(RequestDelegate next) : base(next) { }
        public override Task<ILog> GetExceptionLogAsync(Exception exception, HttpContext context, CancellationToken token)
        {
            var urlRouteMap = RoutingExtensions.GetRouteMapping(context.Request);

            var exceptionLog = new EcomExceptionLog(exception)
            {               
                CorrelationId = context.Request.Headers[KeyStore.HeaderName.CorrelationId],               
                ApplicationName = KeyStore.ApplicationName,
                Api = urlRouteMap.api,
                Verb = urlRouteMap.verb,
            };
            return Task.FromResult<ILog>(exceptionLog);
        }
    }
}
