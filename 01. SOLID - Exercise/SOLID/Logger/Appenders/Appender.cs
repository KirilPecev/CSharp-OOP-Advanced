namespace Logger.Appenders
{
    using Logger.Appenders.Contracts;
    using Logger.Layouts.Contracts;
    using Logger.Loggers.Enums;

    public abstract class Appender : IAppender
    {
        private readonly ILayout layout;

        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }

        public int MessageCount { get; protected set; }

        public ILayout Layout => this.layout;

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);
    }
}
