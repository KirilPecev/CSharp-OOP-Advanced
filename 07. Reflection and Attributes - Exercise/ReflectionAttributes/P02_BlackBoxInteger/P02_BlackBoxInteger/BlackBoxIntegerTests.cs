namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);
            Object instance = Activator.CreateInstance(type, true);
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            FieldInfo field = type.GetField("innerValue",BindingFlags.Instance | BindingFlags.NonPublic);

            string input = Console.ReadLine();
            while (input!="END")
            {
                string[] inputArgs = input.Split("_");
                string command = inputArgs[0];
                int number = int.Parse(inputArgs[1]);

                MethodInfo method = methods.FirstOrDefault(x => x.Name == command);
                method.Invoke(instance, new object[] { number });

                Console.WriteLine(field.GetValue(instance));

                input = Console.ReadLine();
            }
        }
    }
}
