using Ecommerce.Connector.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.IO;
using System;
using System.IO;
using System.Threading.Tasks;


namespace Ecommerce.Connector.Host.WebApis
{
    public class LoggingMiddleware : ServiceRootLogMiddlewareBase
    {

        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;

        public LoggingMiddleware(RequestDelegate next) : base(next)
        {
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
        }

        protected async override Task<ApiLog> GetLog(HttpContext httpContext)
        {
            var apiLog = new EcomApiLog();
            //apiLog.PopulateContextData();
            apiLog.IsSuccessful = httpContext.Response?.StatusCode == 200 || httpContext.Response?.StatusCode == 204;
            apiLog.Request = System.Text.Encoding.UTF8.GetString(GetRequestPayloadBytes(httpContext));
            apiLog.Response = System.Text.Encoding.UTF8.GetString(GetResponsePayloadBytes(httpContext));
            apiLog.Url = GetRequestUri(httpContext.Request);

            if (httpContext.Response != null)
                apiLog.SetValue("http_status_code", httpContext.Response.StatusCode);

            if (httpContext.Response?.Headers != null)
                apiLog.ResponseHeaders = httpContext.Response.Headers.ToString();

            if (httpContext.Request?.Headers != null)
                apiLog.RequestHeaders = httpContext.Request.Headers.ToString();


            return apiLog;
        }

        private string GetRequestUri(HttpRequest request)
        {
            return new UriBuilder(request.Scheme, request.Host.Host, request.Host.Port ?? 0,
                request.Path, request.QueryString.Value).Uri.ToString();
        }

        private byte[] GetRequestPayloadBytes(HttpContext httpContext)
        {
            if (httpContext.Request.ContentLength == null || httpContext.Request.ContentLength.Value == 0)
            {
                return Array.Empty<byte>();
            }
            var originalBody = httpContext.Request.Body;
            httpContext.Request.EnableBuffering();
            //Use _recyclableMemoryStreamManager for better memory management.
            using (var responseStream = _recyclableMemoryStreamManager.GetStream())
            {
                httpContext.Request.Body = responseStream;
                responseStream.CopyToAsync(originalBody);
                return responseStream.ToArray();
            }
        }

        private byte[] GetResponsePayloadBytes(HttpContext httpContext)
        {
            var originalBody = httpContext.Response.Body;
            //Use _recyclableMemoryStreamManager for better memory management.
            using (var responseStream = _recyclableMemoryStreamManager.GetStream())
            {
                httpContext.Response.Body = responseStream;
                responseStream.CopyToAsync(originalBody);
                return responseStream.ToArray();
            }

          
        }
    }
}
