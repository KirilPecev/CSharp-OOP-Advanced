namespace CustomClassAttribute
{
    using CustomClassAttribute.CustomAttributes;
    using CustomClassAttribute.Entities;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                InfoAttribute info = (InfoAttribute)Attribute.GetCustomAttribute(typeof(Weapon), typeof(InfoAttribute));

                if (input == "Author")
                {
                    Console.WriteLine($"Author: {info.Author}");
                }
                else if (input == "Revision")
                {
                    Console.WriteLine($"Revision: {info.Revision}");
                }
                else if (input == "Description")
                {
                    Console.WriteLine($"Class description: {info.Description}");
                }
                else if (input == "Reviewers")
                {
                    Console.WriteLine($"Reviewers: {String.Join(", ", info.Reviewers)}");
                }

                input = Console.ReadLine();
            }
        }
    }
}

