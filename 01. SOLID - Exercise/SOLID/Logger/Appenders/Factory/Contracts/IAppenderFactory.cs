namespace Logger.Appenders.Factory.Contracts
{
    using Logger.Appenders.Contracts;
    using Logger.Layouts.Contracts;

    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}