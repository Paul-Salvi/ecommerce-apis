using Ecommerce.Connector.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Ecommerce.Connector.Host.WebApis
{
    public abstract class ErrorHandlerMiddlewareBase
    {
        
        public ErrorHandlerMiddlewareBase(RequestDelegate next)
        {
            _next = next;
        }
        private readonly RequestDelegate _next;

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {              
                    await _next(httpContext);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(exception, httpContext);
            }
        }

        public async Task HandleExceptionAsync(Exception exception, HttpContext context)
        {
            // Translate to generic error for exception shielding
            var appEx = exception as BaseApplicationException;
            ErrorInfo  errorInfo= null;
            if (appEx != null)
            {
                errorInfo = ToErrorInfo(appEx);
                context.Response.StatusCode =(int) appEx.HttpStatusCode;
                if(IsCriticalException(appEx) == true)
                    await LogException(exception, context);
            }
            else
            {
                await LogException(exception, context);
                errorInfo = GetInternalServerError(context);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorInfo, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), Converters = new List<JsonConverter> { new ErrorInfoTranslator(), new InfoTranslator() } }));

        }

        private bool IsCriticalException(BaseApplicationException appEx)
        {
            var errorCode = (int)appEx.HttpStatusCode;
            return errorCode >= 500;
        }

        private async Task LogException(Exception exception, HttpContext context)
        {
            var log = await GetExceptionLogAsync(exception, context, CancellationToken.None);
            await Logger.WriteLogAsync(log);
        }

        private string GetContent(ErrorInfo errorInfo)
        {
            return JsonConvert.SerializeObject(errorInfo, new ErrorInfoTranslator(), new InfoTranslator());
        }

        private ErrorInfo GetInternalServerError(HttpContext context)
        {
            return new ErrorInfo(FaultCodes.UnexpectedSystemException, ErrorMessages.UnexpectedSystemException());
        }

        public abstract Task<ILog> GetExceptionLogAsync(Exception exception, HttpContext context, CancellationToken token);

        private static ErrorInfo ToErrorInfo(BaseApplicationException exception)
        {
            var errorInfo = new ErrorInfo(exception.ErrorCode, exception.ErrorMessage, exception.HttpStatusCode);
            if (exception.Info != null && exception.Info.Count > 0)
                errorInfo.Info.AddRange(exception.Info);
            return errorInfo;
        }
    }
}