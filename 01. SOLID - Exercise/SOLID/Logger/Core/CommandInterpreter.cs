namespace Logger.Core
{
    using Contracts;
    using Logger.Appenders.Contracts;
    using Logger.Appenders.Factory;
    using Logger.Appenders.Factory.Contracts;
    using Logger.Layouts.Factory;
    using Logger.Layouts.Factory.Contracts;
    using Logger.Loggers.Enums;
    using System;
    using System.Collections.Generic;

    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<IAppender> collection;
        private IAppenderFactory appenderFactory;
        private ILayoutFactory layoutFactory;

        public CommandInterpreter()
        {
            this.collection = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
            this.layoutFactory = new LayoutFactory();
        }

        public void AddAppender(string[] args)
        {
            string appenderType = args[0];
            string layoutType = args[1];
            ReportLevel reportLevel = ReportLevel.INFO;

            if (args.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(args[2]);
            }

            var layout = this.layoutFactory.CreateLayout(layoutType);

            var appender = this.appenderFactory.CreateAppender(appenderType, layout);

            appender.ReportLevel = reportLevel;

            this.collection.Add(appender);
        }

        public void AddMessage(string[] args)
        {
            ReportLevel messageType = Enum.Parse<ReportLevel>(args[0]);
            string dateTime = args[1];
            string message = args[2];

            foreach (var appender in this.collection)
            {
                appender.Append(dateTime, messageType, message);
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine("Logger info");
            foreach (var item in this.collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
