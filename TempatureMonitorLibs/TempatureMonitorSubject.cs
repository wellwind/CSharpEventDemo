using System;
using System.Collections.Generic;

namespace TempatureMonitorLibs
{
    public class TempatureMonitorSubject : ITempatureMonitorSubject
    {
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
                    NotifyTempature();
                }
            }
        }

        private List<ITempatureMonitorObserver> observers;

        public TempatureMonitorSubject()
        {
            observers = new List<ITempatureMonitorObserver>();
            Console.WriteLine("¶}©l°»´ú·Å«×");
        }

        public void RegisterObserver(ITempatureMonitorObserver observer)
        {
            observers.Add(observer);
        }

        public void UnregisterObserver(ITempatureMonitorObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyTempature()
        {
            foreach (var observer in observers)
            {
                observer.OnTempatureChanged(tempature);
            }
        }
    }
}
