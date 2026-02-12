using System;
using System.Collections.Generic;
using System.Reflection;
using Volo.Abp.DependencyInjection;

namespace Bamboo.Core.Application
{
    public interface IModelTypeRegistry : ITransientDependency
    {
        Type GetEntityType(string modelName);
        Type GetAppServiceType(string modelName);
        MethodInfo? GetMethodInfo(string modelName, string rpcMethodName);
        PropertyInfo? GetEntityProperty(string modelName, string odooFieldName);
        IEnumerable<PropertyInfo> GetRelationProperties(string modelName);
        void RegisterModel(string modelName, Type entityType, Type? appServiceType = null);
        void RegisterType(string modelName, Type type);
        void RegisterTypes(Assembly assembly);
        void RegisterServiceTypes(IEnumerable<Assembly> assemblies);
    }
}