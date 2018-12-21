namespace SoftUniDIFramework.Modules
{
    using Attributes;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class AbstractModule : IModule
    {
        private IDictionary<Type, Dictionary<string, Type>> implementations;
        private IDictionary<Type, object> instances;

        public AbstractModule()
        {
            this.implementations = new Dictionary<Type, Dictionary<string, Type>>();
            this.instances = new Dictionary<Type, object>();
        }

        public abstract void Configure();

        public object GetInstance(Type type)
        {
            return this.instances[type];
        }

        public Type GetMapping(Type currentInterface, object attribute)
        {
            var currentImplementation = this.implementations[currentInterface];

            Type type = null;

            if (attribute is InjectAttribute)
            {
                if (currentImplementation.Count == 1)
                {
                    type = currentImplementation.Values.First();
                }
                else
                {
                    throw new ArgumentException($"No available mapping for class: {currentInterface.Name}");
                }
            }
            else if(attribute is NamedAttribute)
            {
                NamedAttribute named = attribute as NamedAttribute;

                string dependecyName = named.Name;
                type = currentImplementation[dependecyName];
            }

            return type;
        }

        public void SetInstance(Type implementation, object instance)
        {
            if (!this.instances.ContainsKey(implementation))
            {
                this.instances.Add(implementation, instance);
            }
        }

        protected void CreateMapping<TInter, TImpl>()
        {
            if (!this.implementations.ContainsKey(typeof(TInter)))
            {
                this.implementations[typeof(TInter)] = new Dictionary<string, Type>();
            }

            this.implementations[typeof(TInter)].Add(typeof(TImpl).Name, typeof(TImpl));
        }
    }
}
