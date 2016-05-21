using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempatureMonitorLibs
{
    public interface ITempatureMonitorSubject
    {
        void RegisterObserver(ITempatureMonitorObserver observer);

        void UnregisterObserver(ITempatureMonitorObserver observer);

        void NotifyTempature();
    }
}