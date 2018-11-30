namespace CustomClassAttribute.CustomAttributes
{
    using System;
    using System.Collections.Generic;

    [AttributeUsage(AttributeTargets.Class)]
    public class InfoAttribute : Attribute
    {
        public InfoAttribute(string author, string description, int revision, params string[] reviewers)
        {
            this.Author = author;
            this.Description = description;
            this.Revision = revision;
            this.Reviewers = new List<string>(reviewers);
        }

        public string Author { get; set; }

        public int Revision { get; set; }

        public string Description { get; set; }

        public List<string> Reviewers { get; set; }
    }
}
