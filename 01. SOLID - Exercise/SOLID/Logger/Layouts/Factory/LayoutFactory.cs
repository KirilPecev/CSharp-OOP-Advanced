namespace Logger.Layouts.Factory
{
    using Logger.Layouts.Contracts;
    using Logger.Layouts.Factory.Contracts;
    using System;

    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            switch (type)
            {
                case nameof(SimpleLayout):
                    return new SimpleLayout();
                case nameof(XmlLayout):
                    return new XmlLayout();
                default:
                    throw new ArgumentException("Invalid layout type!");
            }
        }
    }
}
