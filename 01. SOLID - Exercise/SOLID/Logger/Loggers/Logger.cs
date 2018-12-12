namespace Logger.Loggers
{
    using System;
    using Contracts;
    using global::Logger.Appenders;
    using global::Logger.Appenders.Contracts;
    using global::Logger.Loggers.Enums;

    public class Logger : ILogger
    {
        private readonly IAppender appender;
        private readonly FileAppender fileAppender;

        public Logger(IAppender appender)
        {
            this.appender = appender;
        }

        public Logger(IAppender appender, FileAppender fileAppender) :
            this(appender)
        {
            this.fileAppender = fileAppender;
        }

        public void Warning(string dateTime, string warningMessage)
        {
            AppendMessage(dateTime, ReportLevel.WARNING, warningMessage);
        }

        public void Error(string dateTime, string errorMessage)
        {
            AppendMessage(dateTime, ReportLevel.ERROR, errorMessage);
        }

        public void Info(string dateTime, string infoMessage)
        {
            AppendMessage(dateTime, ReportLevel.INFO, infoMessage);
        }

        public void Fatal(string dateTime, string fatalMessage)
        {
            AppendMessage(dateTime, ReportLevel.FATAL, fatalMessage);
        }

        public void Critical(string dateTime, string criticalMessage)
        {
            AppendMessage(dateTime, ReportLevel.CRITICAL, criticalMessage);
        }

        private void AppendMessage(string dateTime, ReportLevel reportLevel, string message)
        {
            this.appender?.Append(dateTime, reportLevel, message);
            this.fileAppender?.Append(dateTime, reportLevel, message);
        }
    }
}
