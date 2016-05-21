namespace TempatureMonitorLibs
{
    public interface ITempatureMonitorObserver
    {
        void OnTempatureChanged(double tempature);
    }
}