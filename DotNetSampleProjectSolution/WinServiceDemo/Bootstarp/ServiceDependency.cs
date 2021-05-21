using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System.IO;
using WinServiceDemo.Interfaces;
using WinServiceDemo.Jobs;

namespace WinServiceDemo.Bootstarp
{
    public class ServiceDependency
    {

        public static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            var config = LoadConfiguration();
            services.AddSingleton(config);
            services.AddLogging(loggingBuilder =>
            {
                // configure Logging with NLog
                loggingBuilder.ClearProviders();
                loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                loggingBuilder.AddNLog(config);
            });
            services.AddSingleton<IJobFactory, SingaltonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddSingleton<ICommonScheduler, CommonScheduler>();
            services.AddTransient<CommonJob>();
            services.AddSingleton<Startable>();

           
            return services;
        }

        private static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }

    }
}
