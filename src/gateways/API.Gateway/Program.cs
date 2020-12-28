using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;

namespace API.Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                new WebHostBuilder()
                       .UseKestrel()
                       .UseContentRoot(Directory.GetCurrentDirectory())
                       .ConfigureAppConfiguration((context, config) =>
                       {
                           config
                           .SetBasePath(context.HostingEnvironment.ContentRootPath)
                               //.AddJsonFile("appsettings.json", true, true)
                               //.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", true, true)
                               .AddJsonFile("ocelot.json")
                               .AddEnvironmentVariables();
                       })
                       .ConfigureServices(s =>
                       {
                           s.AddOcelot().AddConsul();
                       })
                       .ConfigureLogging((hostingContext, logging) =>
                       {
                           logging.AddConsole();
                       })
                       .UseIISIntegration()
                       .Configure(app =>
                       {
                           app.UseOcelot().Wait();
                       })
                       .Build()
                       .Run();
            }
            catch (System.Exception exx)
            {
            }
        }
    }
}
