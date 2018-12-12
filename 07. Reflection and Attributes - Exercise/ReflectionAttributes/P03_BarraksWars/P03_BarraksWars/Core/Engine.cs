namespace _03BarracksFactory.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Attributes;
    using Contracts;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;
        private Assembly assembly;
        private Type[] types;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
            this.assembly = Assembly.GetExecutingAssembly();
            this.types = this.assembly.GetExportedTypes().Where(x => x.Name.EndsWith("Command")).ToArray();
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private string InterpredCommand(string[] data, string commandName)
        {
            Type type = this.types.FirstOrDefault(c => c.Name.ToString().ToLower().StartsWith(commandName));

            if (type == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            Object instance = Activator.CreateInstance(type, new object[] { data });

            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.GetCustomAttributes(false)
               .Any(x => x.GetType() == typeof(InjectAttribute))).ToArray();

            foreach (var field in fields)
            {
                Object engineClassFieldValue = typeof(Engine)
                    .GetField(field.Name, BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(this);

                field.SetValue(instance, engineClassFieldValue);
            }

            MethodInfo method = type.GetMethod("Execute");

            Object returnedValue = method.Invoke(instance, new object[] { });

            return returnedValue.ToString();
        }
    }
}
