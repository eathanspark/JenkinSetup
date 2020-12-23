using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WinServiceDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //static void Main()
        //{
        //    ServiceBase[] ServicesToRun;
        //    ServicesToRun = new ServiceBase[]
        //    {
        //        new Service1()
        //    };
        //    ServiceBase.Run(ServicesToRun);
        //}

        static void Main(string[] args)
        {
            Console.WriteLine($"Program started with args {args}");

            //var application = new Bootstrap();
            //application.Start<Startable>();

            //application.Resolver.Resolve<Startable>().Start();
            //GenerateXML();
        }
    }
}
