using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinServiceDemo.Jobs.Interfaces;

namespace WinServiceDemo.Jobs
{
    [DisallowConcurrentExecution]
    public class CommonJob : ICommonJob
    {
        private readonly ILogger<CommonJob> _logger;
        public CommonJob(ILogger<CommonJob> logger)
        {
            this._logger = logger;
           
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {             

                _logger.LogDebug("Logging started.. ");

                await Task.Run(() =>
                {
                    Console.WriteLine(DateTime.Now);

                });
                _logger.LogInformation("Logging started.. ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
           
        }
    }
}
