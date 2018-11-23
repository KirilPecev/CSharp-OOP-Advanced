namespace Logger.Loggers.Contracts
{
    public interface ILogger
    {
        void Error(string dateTime, string errorMessage);

        void Info(string dateTime, string infoMessage);

        void Fatal(string dateTime, string fatalMessage);

        void Critical(string dateTime, string criticalMessage);

        void Warning(string dateTime, string warningMessage);
    }
}
