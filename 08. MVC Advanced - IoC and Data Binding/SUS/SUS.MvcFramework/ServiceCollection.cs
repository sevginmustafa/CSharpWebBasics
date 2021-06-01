using System;
using System.Collections.Generic;
using System.Linq;

namespace SUS.MvcFramework
{
    public class ServiceCollection : IServiceCollection
    {
        private Dictionary<Type, Type> dependancyContainer = new Dictionary<Type, Type>();

        public void Add<TSourse, TDestination>()
        {
            this.dependancyContainer[typeof(TSourse)] = typeof(TDestination);
        }

        public object CreateInstance(Type type)
        {
            if (this.dependancyContainer.ContainsKey(type))
            {
                type = this.dependancyContainer[type];
            }

            var constructor = type.GetConstructors()
                .OrderBy(x=>x.GetParameters().Count()).FirstOrDefault();

            var parameters = constructor.GetParameters();
            var parametersValue = new List<object>();
            foreach (var parameter in parameters)
            {
                var parameterValue = CreateInstance(parameter.ParameterType);
                parametersValue.Add(parameterValue);
            }

            var obj = constructor.Invoke(parametersValue.ToArray());

            return obj;
        }
    }
}
