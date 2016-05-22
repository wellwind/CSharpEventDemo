using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempatureMonitorLibs;

namespace CSharpEventDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // 使用一般Observer pattern
            Console.WriteLine("Observer Pattern Demo");
            var tempatureMonitor = new TempatureMonitorSubject();

            var desktopApp = new DesktopApp();
            var mobileApp = new MobileApp();

            tempatureMonitor.RegisterObserver(desktopApp);
            tempatureMonitor.RegisterObserver(mobileApp);

            Console.WriteLine("溫度變化了，現在是30.5度");
            tempatureMonitor.Tempature = 30.5;

            Console.WriteLine("溫度沒變化，現在依然是30.5度");
            tempatureMonitor.Tempature = 30.5;

            Console.WriteLine("溫度變化了，現在是28.6度");
            tempatureMonitor.Tempature = 28.6;

            Console.WriteLine("mobileApp不再想觀察了");
            tempatureMonitor.UnregisterObserver(mobileApp);

            Console.WriteLine("溫度變化了，現在是27.6度");
            tempatureMonitor.Tempature = 27.6;
            Console.WriteLine();

            // 使用Delegate完成Observer pattern
            Console.WriteLine("Delegate Demo");
            var tempatureMonitorDelegate = new TempatureMonitorUsingDelegate();

            tempatureMonitorDelegate.OnTempatureChanged += desktopApp.OnTempatureChanged;
            tempatureMonitorDelegate.OnTempatureChanged += mobileApp.OnTempatureChanged;

            Console.WriteLine("溫度變化了，現在是30.5度");
            tempatureMonitorDelegate.Tempature = 30.5;

            Console.WriteLine("溫度沒變化，現在依然是30.5度");
            tempatureMonitorDelegate.Tempature = 30.5;

            Console.WriteLine("溫度變化了，現在是28.6度");
            tempatureMonitorDelegate.Tempature = 28.6;
            Console.WriteLine();

            // 使用Event事件委派
            Console.WriteLine("Event Demo");
            var tempatureMonitorEvent = new TempatureMonitorUsingEvent();

            desktopApp = new DesktopApp(tempatureMonitorEvent);
            mobileApp = new MobileApp(tempatureMonitorEvent);

            Console.WriteLine("溫度變化了，現在是30.5度");
            tempatureMonitorEvent.Tempature = 30.5;

            Console.WriteLine("溫度沒變化，現在依然是30.5度");
            tempatureMonitorEvent.Tempature = 30.5;

            Console.WriteLine("溫度變化了，現在是28.6度");
            tempatureMonitorEvent.Tempature = 28.6;
        }
    }
}