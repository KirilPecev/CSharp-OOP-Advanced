namespace Logger.Appenders.Factory
{
    using Logger.Appenders.Contracts;
    using Logger.Appenders.Factory.Contracts;
    using Logger.Layouts.Contracts;
    using Logger.Loggers;
    using System;

    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            switch (type)
            {
                case nameof(ConsoleAppender):
                    return new ConsoleAppender(layout);
                case nameof(FileAppender):
                    return new FileAppender(layout, new LogFile());
                default:
                    throw new ArgumentException("Invalid appender type!");
            }
        }
    }
}
