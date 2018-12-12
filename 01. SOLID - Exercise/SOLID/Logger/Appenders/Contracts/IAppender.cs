namespace Logger.Appenders.Contracts
{
    using Logger.Layouts.Contracts;
    using Logger.Loggers.Enums;

    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }

        int MessageCount { get; }

        ILayout Layout { get; }

        void Append(string dateTime, ReportLevel reportLevel, string message);
    }
}
