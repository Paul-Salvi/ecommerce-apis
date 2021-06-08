using Ecommerce.Connector.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Ecommerce.Connector.Host.WebApis
{
    public class Startup
    {
        private readonly string _environmentName;
        private bool _isCompressionEnabled;
        public IConfiguration Configuration { get; }


        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                   .SetBasePath(env.ContentRootPath)
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                   .AddEnvironmentVariables();
            Configuration = builder.Build();
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", env.EnvironmentName);
            _environmentName = env.EnvironmentName;
            Console.WriteLine("Processor count for Web Application: {0}", Environment.ProcessorCount);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
                options.JsonSerializerOptions.IgnoreNullValues = true;
            }).AddMvcOptions(options =>
            {
                options.EnableEndpointRouting = false;
            });
            services.AddSingleton<IConfiguration>(Configuration);
            SetupServices(services);
         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCustomExceptionHandler();
            app.UseContextInjector();
            app.UseLogging();          
            app.UseRouting();
            app.UseMvc();
        }

        public void SetupServices(IServiceCollection services)
        {
            services.AddScoped<IHealthCheck,HealthCheck>();
            services.AddSingleton<IConfiguration>(Configuration);
        }

    }
}
