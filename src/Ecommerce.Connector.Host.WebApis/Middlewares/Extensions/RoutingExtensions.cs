using Ecommerce.Connector.Model;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Ecommerce.Connector.Host.WebApis
{
    public class RoutingExtensions
    {
        internal static (string api, string verb) GetRouteMapping(HttpRequest request)
        {
            var route = request.Path.Value;

            foreach (var callType in RouteMap)
                if (route.Contains(callType.Key))
                    return callType.Value;

            return (api: route, verb: route);
        }

        static readonly Dictionary<string, (string api, string verb)> RouteMap = new Dictionary<string, (string api, string verb)>
        {
                {"health", (KeyStore.Api.HealthCheck, KeyStore.Verb.HealthCheck)},

        };
    }
}
