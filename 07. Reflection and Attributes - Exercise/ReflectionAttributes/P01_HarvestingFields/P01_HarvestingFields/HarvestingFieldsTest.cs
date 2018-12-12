namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = typeof(HarvestingFields);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            string input = Console.ReadLine();
            while (input != "HARVEST")
            {
               var currentFields = GetFieldsByModifier(type, fields, input);

                foreach (var field in currentFields)
                {
                    string modifier = field.Attributes.ToString().ToLower();
                    if (modifier == "family")
                    {
                        modifier = "protected";
                    }

                    Console.WriteLine($"{modifier} {field.FieldType.Name} {field.Name}");
                }


                input = Console.ReadLine();
            }
        }

        private static FieldInfo[] GetFieldsByModifier(Type type, FieldInfo[] fields, string command)
        {
            switch (command)
            {
                case "private":
                    return fields.Where(f => f.IsPrivate).ToArray();
                case "protected":
                    return fields.Where(f => f.IsFamily).ToArray();
                case "public":
                    return fields.Where(f => f.IsPublic).ToArray();
                case "all":
                    return fields.ToArray();
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
