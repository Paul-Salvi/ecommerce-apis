using Ecommerce.Connector.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Net;


namespace Ecommerce.Connector.Host.WebApis
{
    public static class EcomCallContextCreator
    {
        const string DefaultCulture = "en-us";
        public static EcomCallContext CreateCallContext(HttpRequest httpRequest, DateTime? startTime, out List<string> missingHeaders, out List<string> invalidHeaders)
        {
            missingHeaders = new List<string>();
            invalidHeaders = new List<string>();
            var queryCollections = httpRequest?.Query;
            var headerDictionary = httpRequest?.Headers;
            var headers = new NameValueCollection();
            foreach (var kvp in headerDictionary)
                headers.Add(kvp.Key.ToString(), kvp.Value.ToString());           

            var correlationId = GetHeaderValue(headerDictionary, KeyStore.HeaderName.CorrelationId, false, ref missingHeaders);
            var sessionId = GetHeaderValue(headerDictionary, KeyStore.HeaderName.CorrelationId, false, ref missingHeaders);

            if (string.IsNullOrEmpty(correlationId))
                correlationId = Guid.NewGuid().ToString();
            if (string.IsNullOrEmpty(sessionId))
                sessionId = Guid.NewGuid().ToString();

            var culture = GetLanguagesInPreferenceOrder(GetHeaderValue(headerDictionary, KeyStore.HeaderName.AcceptLanguage, false, ref missingHeaders));
            var ipAddressString = GetHeaderValue(headerDictionary, KeyStore.HeaderName.IpAddress, false, ref missingHeaders);

            IPAddress ipAddress;
            if (!IPAddress.TryParse(ipAddressString, out ipAddress))
                ipAddress = null;

            var userId = GetHeaderValue(headerDictionary, KeyStore.HeaderName.UserId, false, ref missingHeaders);
            var urlMapping = RoutingExtensions.GetRouteMapping(httpRequest);

            var ecomCallContext = new EcomCallContext(urlMapping.api, urlMapping.verb, culture, sessionId, correlationId, ipAddress, KeyStore.ApplicationName, headers, startTime, userId);

            return ecomCallContext;
        }



        private static string GetHeaderValue(IHeaderDictionary requestHeaders, string headerName, bool isMandatory, ref List<string> missingHeaders)
        {
            if (requestHeaders != null && requestHeaders.TryGetValue(headerName, out var values) && !string.IsNullOrWhiteSpace(values))
            {
                return values;
            }
            if (isMandatory)
                missingHeaders.Add(headerName);
            return null;
        }

        private static CultureInfo GetLanguagesInPreferenceOrder(string cultureInfo)
        {
            if (cultureInfo == null)
                return new CultureInfo(DefaultCulture);

            try
            {
                return CultureInfo.CreateSpecificCulture(cultureInfo);
            }
            catch
            {
                cultureInfo = DefaultCulture;
            }


            return new CultureInfo(cultureInfo);
        }


    }
}
