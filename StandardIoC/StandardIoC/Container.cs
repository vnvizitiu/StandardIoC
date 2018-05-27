namespace StandardIoC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    
    public class Container
    {
        private readonly Dictionary<Type, Type> _mapping = new Dictionary<Type, Type>();
        private readonly Dictionary<Type, object> _instances = new Dictionary<Type, object>();

        public void Register<TConcrete>()
        {
            _mapping.Add(typeof(TConcrete), typeof(TConcrete));
        }

        public void Register<T>(object exisitingInstance)
        {
            _mapping.Add(typeof(T), exisitingInstance.GetType());
            _instances.Add(exisitingInstance.GetType(), exisitingInstance);
        }

        public void Register<TAbstract,TConcrete>() where TConcrete : TAbstract
        {
            _mapping.Add(typeof(TAbstract), typeof(TConcrete));
        }

        public T Resolve<T>()
        {
            return (T) CreateInternal(typeof(T));
        }

        private object CreateInternal(Type type)
        {
            Type typeToInstantiate = type;
            object instance;
            

            if (_mapping.TryGetValue(type, out Type concreteType))
            {
                typeToInstantiate = concreteType;
            }

            if (_instances.TryGetValue(typeToInstantiate, out object existingInstance))
            {
                return existingInstance;
            }

            ConstructorInfo constructor = typeToInstantiate.GetConstructors().Single();
            ParameterInfo[] parameters = constructor.GetParameters();
            
            List<object> parameterInstances = new List<object>();

            foreach (ParameterInfo parameterInfo in parameters)
            {
                parameterInstances.Add(CreateInternal(parameterInfo.ParameterType));
            }

            if (parameterInstances.Any())
            {
                instance = constructor.Invoke(parameterInstances.ToArray());
            }
            else
            {
                instance = Activator.CreateInstance(typeToInstantiate);
            }

            return instance;
        }
    }
}