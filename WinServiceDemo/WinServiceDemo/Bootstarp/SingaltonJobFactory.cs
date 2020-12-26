using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;
using System;

namespace WinServiceDemo.Bootstarp
{
    public class SingaltonJobFactory : IJobFactory
    {

        private readonly IServiceProvider _serviceProvider;
        public SingaltonJobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            var job = _serviceProvider.GetRequiredService(bundle.JobDetail.JobType);
            return job as IJob;
        }

        public void ReturnJob(IJob job)
        {

        }

        public object GetInstance(string strNamesapace)
        {
            Type t = Type.GetType(strNamesapace);
            return Activator.CreateInstance(t);
        }
    }
}
