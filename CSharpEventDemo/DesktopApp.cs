using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempatureMonitorLibs;

namespace CSharpEventDemo
{
    public class DesktopApp : ITempatureMonitorObserver, ITempatureMonitorEvent
    {
        public void OnTempatureChanged(double tempature)
        {
            Console.WriteLine($"Desktop App被通知溫度變化了: {tempature}");
        }

        public void OnTempatureChangedEvent(object sender, double e)
        {
            Console.WriteLine($"Desktop App使用事件委派方法得知溫度變化了: {e}");
        }
    }
}