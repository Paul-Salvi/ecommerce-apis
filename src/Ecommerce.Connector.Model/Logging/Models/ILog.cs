using System;
using System.Collections.Generic;

namespace Ecommerce.Connector.Model
{
    public interface ILog
    {
        string Id { get; }

        DateTime LogTime { get; }

        string Type { get; }

        string Message { get; }

        IEnumerable<KeyValuePair<string, object>> GetFields();
    }
}
