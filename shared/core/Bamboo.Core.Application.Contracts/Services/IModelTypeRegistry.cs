using System;
using System.Collections.Generic;
using System.Reflection;
using Volo.Abp.DependencyInjection;

namespace Bamboo.Core.Application
{
    public interface IModelTypeRegistry : ITransientDependency
    {
        Type GetType(string modelName);
        Type GetServiceInterfaceType(string modelName);

        void RegisterType(string modelName, Type type);
        void RegisterTypes(Assembly assembly);
        void RegisterServiceTypes(IEnumerable<Assembly> assemblies);
    }
}