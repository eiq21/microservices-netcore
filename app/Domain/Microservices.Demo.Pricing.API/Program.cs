using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using Steeltoe.Extensions.Configuration.ConfigServer;

namespace Microservices.Demo.Pricing.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(loggign =>
                {
                    loggign.SetMinimumLevel(LogLevel.Information);
                    loggign.AddConsole();                    
                })
                .ConfigureAppConfiguration((webHostBuilderContext, configurationBuilder) =>
                {
                    ILoggerFactory factory = new LoggerFactory();
                    var provider = new DebugLoggerProvider();
                    factory.AddProvider(provider);

                    var hostingEnvironment = webHostBuilderContext.HostingEnvironment;
                    configurationBuilder.AddConfigServer(hostingEnvironment.EnvironmentName, factory);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
