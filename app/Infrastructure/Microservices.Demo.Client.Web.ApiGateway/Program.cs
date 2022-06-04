using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using Steeltoe.Extensions.Configuration.ConfigServer;

namespace Microservices.Demo.Client.Web.ApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //.ConfigureAppConfiguration((hostingContext, config) =>
                //{
                //    config
                //        .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                //        .AddJsonFile("appsettings.json", true, true)
                //        .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true,
                //            true)
                //        .AddJsonFile("ocelot.json", false, false)
                //        .AddEnvironmentVariables();
                //})
                .ConfigureLogging(loggign =>
                {
                    loggign.SetMinimumLevel(LogLevel.Information);
                    loggign.AddConsole();                    
                })
                .ConfigureAppConfiguration((webHostBuilderContext, configurationBuilder) =>
                {                    
                    var config = new ColoredConsoleLoggerConfiguration
                    {
                        LogLevel = LogLevel.Information,
                        Color = ConsoleColor.Red
                    };
                    ILoggerFactory factory = new LoggerFactory();                    
                    var provider = new DebugLoggerProvider();
                    var providerConsole = new ColoredConsoleLoggerProvider(config);

                    //new ConsoleLoggerProvider((category, logLevel) => logLevel >= LogLevel.Debug, false)
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
