using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinServiceDemo.Interfaces;
using WinServiceDemo.Jobs;

namespace WinServiceDemo.Jobs
{
    public class JobTrigger
    {
        public IJobDetail Job { get; set; }
        public ITrigger Trigger { get; set; }
    }
    public class CommonScheduler : ICommonScheduler
    {
        private IScheduler scheduler;
        private JobKey ReportProcessorJobKey { get; set; }
        IJobFactory _commonJobFactory;
        public string Name => "TestingCommonScheduler";
        ISchedulerFactory _schedulerFactory;

        public CommonScheduler(IJobFactory commonJobFactory, ISchedulerFactory schedulerFactory)
        {
            this._commonJobFactory = commonJobFactory;
            this._schedulerFactory = schedulerFactory;

        }
        public void Pause()
        {
            if (scheduler != null)
                scheduler.PauseJob(ReportProcessorJobKey);
        }

        public void Resume()
        {
            if (scheduler != null)
                scheduler.ResumeJob(ReportProcessorJobKey);
        }

        public void Shutdown()
        {
            if (scheduler != null)
                scheduler.Shutdown();
        }

        public JobTrigger GetCommonJob()
        {

            ReportProcessorJobKey = JobKey.Create("CommonJob", "CommonJob");

            var job = JobBuilder.Create<CommonJob>().WithIdentity("CommonJob", "CommonJob").Build();
            int ConfigFrequency;
            int frequency = int.TryParse(ConfigurationManager.AppSettings["CommonJobFrequencyInSecond"], out ConfigFrequency) ? ConfigFrequency : 5;
            var jobTrigger = TriggerBuilder.Create()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(frequency).RepeatForever())
                .Build();

            return new JobTrigger { Job = job, Trigger = jobTrigger };
        }


        public async void Start()
        {
            Console.WriteLine("Common Schedular started..");
            var factory = this._schedulerFactory;
            scheduler = await factory.GetScheduler();
            scheduler.JobFactory = this._commonJobFactory;

            var commonJob = this.GetCommonJob();

            if (commonJob != null)
                await scheduler.ScheduleJob(commonJob.Job, commonJob.Trigger);
            await scheduler.Start();

            //Console.ReadKey();
            //await scheduler.Shutdown();
        }
    }
}
