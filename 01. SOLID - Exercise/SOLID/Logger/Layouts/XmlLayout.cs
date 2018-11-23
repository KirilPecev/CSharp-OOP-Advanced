namespace Logger.Layouts
{
    using Logger.Layouts.Contracts;
    using System;

    public class XmlLayout : ILayout
    {
        public string Format => "<log>" + Environment.NewLine +
                                "   <date>{0}</date>\n" + Environment.NewLine +
                                "   <level>{1}</level>\n" + Environment.NewLine +
                                "   <message>{2}</message>\n" + Environment.NewLine +
                                "</log>";
    }
}
