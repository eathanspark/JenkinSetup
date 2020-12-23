using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinServiceDemo.Interfaces;

namespace WinServiceDemo
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
            this._commonSchedular.Start();
        }
        public void Stop()
        {
            this._commonSchedular.Shutdown();
        }
    }
}