using System;
using System.Threading.Tasks;

namespace Ecommerce.Connector.Model
{
    public static class Logger
    {
        //Add Logger Factory
        public static Task WriteLogAsync(ILog log)
        {

            try
            {
                switch (log.Type)
                {
                    case KeyStore.LogType.Api:
                        Console.WriteLine($"API Log : {log.Id}");
                        break;
                    case KeyStore.LogType.Exception:
                        Console.WriteLine($"Exception Log : {log.Id}");
                        break;
                    case KeyStore.LogType.Trace:
                        Console.WriteLine($"Trace Log : {log.Id}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Invalid log type: {log.Type} Class type : {log.GetType()}");
                }
            }
            catch
            {
                // ignored
            }
            return Task.CompletedTask;
        }
    }
}
