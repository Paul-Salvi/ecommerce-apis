using Ecommerce.Connector.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Ecommerce.Connector.Host.WebApis
{
    public abstract class ServiceRootLogMiddlewareBase
    {
        public ServiceRootLogMiddlewareBase(RequestDelegate next)
        {
            _next = next;
        }

        private readonly RequestDelegate _next;

        public async Task Invoke(HttpContext httpContext)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {


                await _next.Invoke(httpContext);
            }
            catch (BaseApplicationException exception) when (exception.HttpStatusCode.Equals(HttpStatusCode.BadRequest))
            {
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(ToErrorInfo(exception), new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), Converters = new List<JsonConverter> { new ErrorInfoTranslator(), new InfoTranslator() } }));
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            finally
            {
                Log(httpContext, stopWatch);
            }
        }

        private static ErrorInfo ToErrorInfo(BaseApplicationException exception)
        {
            var errorInfo = new ErrorInfo(exception.ErrorCode, exception.ErrorMessage, exception.HttpStatusCode);
            if (exception.Info != null && exception.Info.Count > 0)
                errorInfo.Info.AddRange(exception.Info);
            return errorInfo;
        }

        async Task Log(HttpContext httpContext, Stopwatch stopWatch)
        {
            if (stopWatch.IsRunning)
                stopWatch.Stop();

            var apiLogEntry = await GetLog(httpContext);
            apiLogEntry.LogTime = DateTime.UtcNow;
            apiLogEntry.TimeTakenInMs = stopWatch.ElapsedMilliseconds;

            await Logger.WriteLogAsync(apiLogEntry);
        }

        protected abstract Task<ApiLog> GetLog(HttpContext httpContext);


        protected internal virtual async Task<Func<byte[]>> GetRequestPayload(HttpContext httpContext)
        {
            if (httpContext.Request.ContentLength == null || httpContext.Request.ContentLength.Value == 0)
            {
                return null;
            }

            httpContext.Request.Body.Seek(0, SeekOrigin.Begin);
            string requestBodyText = new StreamReader(httpContext.Request.Body).ReadToEnd();
            httpContext.Request.Body.Seek(0, SeekOrigin.Begin);
            Func<byte[]> requestData = () => string.IsNullOrWhiteSpace(requestBodyText) ? new byte[0] : Encoding.UTF8.GetBytes(requestBodyText);
            return requestData;
        }
        protected internal virtual async Task<Func<byte[]>> GetResponsePayload(HttpContext httpContext)
        {
            httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseBodyText = new StreamReader(httpContext.Response.Body).ReadToEnd();
            httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
            Func<byte[]> responseData = () => string.IsNullOrWhiteSpace(responseBodyText) ? new byte[0] : Encoding.UTF8.GetBytes(responseBodyText);
            return responseData;
        }
    }
}
