namespace Logger.Appenders
{
    using Layouts.Contracts;
    using Logger.Loggers.Contracts;
    using Logger.Loggers.Enums;
    using System;
    using System.IO;

    public class FileAppender : Appender
    {
        private const string path = "log.txt";
        private readonly ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile) : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                this.MessageCount++;
                var currentString = string.Format(this.Layout.Format, dateTime, reportLevel, message) + Environment.NewLine;
                this.logFile.Write(currentString);
                File.AppendAllText(path, currentString);
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.MessageCount}, File size: {this.logFile.Size}";
        }
    }
}
