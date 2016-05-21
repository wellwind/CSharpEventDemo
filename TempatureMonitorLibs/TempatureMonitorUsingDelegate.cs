using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TempatureMonitorLibs
{
    public partial class TempatureMonitorUsingDelegate
    {
        public delegate void TempatureChangedHandler(double tempature);

        public TempatureChangedHandler OnTempatureChanged;

        private double tempature;

        public double Tempature
        {
            get { return tempature; }
            set
            {
                var oldTempature = tempature;
                if (oldTempature != value)
                {
                    tempature = value;
                    OnTempatureChanged.Invoke(value);
                }
            }
        }

        public TempatureMonitorUsingDelegate()
        {
            // 使用delegate必須給定一個初始的委派方法
            OnTempatureChanged = tempatureChanged;
        }

        private void tempatureChanged(double tempature)
        {
            Console.WriteLine($"溫度發生變化了...{tempature}");
        }
    }
}