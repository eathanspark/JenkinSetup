using System;
using WinServiceDemo.Interfaces;

namespace WinServiceDemo.Bootstarp
{
    public class Startable : IStartable
    {
        private ICommonScheduler _commonSchedular;
        public Startable(ICommonScheduler commonSchedular)
        {
            this._commonSchedular = commonSchedular;
        }
        public void Start()
        {
            int exitCode = 0;
            this._commonSchedular.Start();
            Environment.ExitCode = exitCode;
        }
        public void Stop()
        {
            this._commonSchedular.Shutdown();
        }
    }
}