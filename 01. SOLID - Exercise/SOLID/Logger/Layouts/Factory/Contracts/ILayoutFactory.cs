namespace Logger.Layouts.Factory.Contracts
{
    using Logger.Layouts.Contracts;

    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
