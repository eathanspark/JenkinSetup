namespace WinServiceDemo.Interfaces
{
    public interface IJobScheduler
    {
        string Name { get; }

        void Start();

        void Pause();

        void Shutdown();

        void Resume();
    }
}