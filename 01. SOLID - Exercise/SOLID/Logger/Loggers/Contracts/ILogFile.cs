namespace Logger.Loggers.Contracts
{
    using Layouts.Contracts;

    public interface ILogFile
    {
        int Size { get; }

        void Write(string message);
    }
}
