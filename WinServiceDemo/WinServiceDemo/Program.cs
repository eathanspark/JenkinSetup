using Microsoft.Extensions.DependencyInjection;
using System;
using Topshelf;
using WinServiceDemo.Bootstarp;

namespace WinServiceDemo
{
    static class Program
    {

        static void Main(string[] args)
        {
            var services = ServiceDependency.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            var rc = HostFactory.Run(x =>
            {
                x.Service<Startable>(s =>
                {
                    s.ConstructUsing(name => serviceProvider.GetService<Startable>());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("Windows Service Demo");
                x.SetDisplayName("WinServiceDemo");
                x.SetServiceName("WinServiceDemo");
            });

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;
        }
    }
}
