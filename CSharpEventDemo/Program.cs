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
        private static DesktopApp desktopApp = new DesktopApp();
        private static MobileApp mobileApp = new MobileApp();

        private static void Main(string[] args)
        {
            obsverPatternDemo();

            delegateDemo();

            eventDemo();
        }

        private static void obsverPatternDemo()
        {
            // 使用一般Observer pattern
            Console.WriteLine("Observer Pattern Demo");
            var tempatureMonitor = new TempatureMonitorSubject();

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
        }

        private static void delegateDemo()
        {
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

            Console.WriteLine("mobileApp不再想觀察了");
            tempatureMonitorDelegate.OnTempatureChanged -= mobileApp.OnTempatureChanged;

            Console.WriteLine("溫度變化了，現在是27.6度");
            tempatureMonitorDelegate.Tempature = 27.6;
            Console.WriteLine();
        }

        private static void eventDemo()
        {
            // 使用Event事件委派
            Console.WriteLine("Event Demo");
            var tempatureMonitorEvent = new TempatureMonitorUsingEvent();

            tempatureMonitorEvent.OnTempatureChanged += desktopApp.OnTempatureChangedEvent;
            tempatureMonitorEvent.OnTempatureChanged += mobileApp.OnTempatureChangedEvent;
            // 額外自訂事件委派方法, 由於是宣告成事件委派, 輸入到+=時可以直接用TAB產生基本的程式碼
            tempatureMonitorEvent.OnTempatureChanged += TempatureMonitorEvent_OnTempatureChanged;

            Console.WriteLine("溫度變化了，現在是30.5度");
            tempatureMonitorEvent.Tempature = 30.5;

            Console.WriteLine("溫度沒變化，現在依然是30.5度");
            tempatureMonitorEvent.Tempature = 30.5;

            Console.WriteLine("溫度變化了，現在是28.6度");
            tempatureMonitorEvent.Tempature = 28.6;

            Console.WriteLine("mobileApp不再想觀察了");
            tempatureMonitorEvent.OnTempatureChanged -= mobileApp.OnTempatureChangedEvent;

            Console.WriteLine("溫度變化了，現在是27.6度");
            tempatureMonitorEvent.Tempature = 27.6;
            Console.WriteLine();
        }

        private static void TempatureMonitorEvent_OnTempatureChanged(object sender, double e)
        {
            Console.WriteLine($"自訂的委派方法得知溫度變化了: {e}");
        }
    }
}