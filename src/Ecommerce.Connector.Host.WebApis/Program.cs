using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using WH = Microsoft.Extensions.Hosting;

namespace Ecommerce.Connector.Host.WebApis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
          
        public static WH.IHostBuilder CreateHostBuilder(string[] args)
        {
            return WH.Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
        }
    }
}
