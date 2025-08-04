using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using Bamboo.Core.Models;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Application
{

    public class ModelTypeRegistry : IModelTypeRegistry
    {
        private readonly Dictionary<string, Type> _modelTypes = new Dictionary<string, Type>();
        private readonly Dictionary<string, Type> _serviceInterface = new Dictionary<string, Type>();

        public Type GetType(string modelName)
        {
            if (_modelTypes.TryGetValue(modelName, out var type))
                return type;
            return null;
        }

        public Type GetServiceInterfaceType(string modelName)
        {
            if (_serviceInterface.TryGetValue(modelName, out var serviceType))
                return serviceType;
            return null;
        }
        public void RegisterType(string modelName, Type type)
        {
            _modelTypes[modelName] = type;
        }

        public void RegisterType<T>()
        {
            var type = typeof(T);
            _modelTypes[type.Name] = type;
        }

        public void RegisterTypes(Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
            {
                if (type.IsClass && !type.IsAbstract && typeof(IEntity).IsAssignableFrom(type))
                {
                    _modelTypes[type.Name] = type;
                    var _modelAttr = type.GetCustomAttribute<ModelAttribute>(true);
                    if (_modelAttr != null)
                    {
                        _modelTypes[_modelAttr.Name] = type;
                    }
                    var _tableAttr = type.GetCustomAttribute<TableAttribute>(true);
                    if (_tableAttr != null)
                    {
                        _modelTypes[_tableAttr.Name] = type;
                        _modelTypes[_tableAttr.Name.Replace("_", ".")] = type;
                    }
                }
            }
        }
        // public void RegisterServiceTypes(Assembly assembly)
        // {
        //     var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        //     // 2. Quét và đăng ký các Service Interface cụ thể
        //     var appServiceInterfaceTypes = assembly.GetTypes()
        //         //.SelectMany(assembly => assembly.GetTypes())
        //         .Where(type => type.IsInterface && typeof(IApplicationService).IsAssignableFrom(type) && type.Name.EndsWith("AppService"));

        //     foreach (var interfaceType in appServiceInterfaceTypes)
        //     {
        //         // Tìm class triển khai interface này để đọc attribute
        //         var implementationType = assemblies
        //             .SelectMany(a => a.GetTypes())
        //             .FirstOrDefault(t => t.IsClass && !t.IsAbstract && interfaceType.IsAssignableFrom(t));

        //         if (implementationType != null)
        //         {
        //             var modelAttr = implementationType.GetCustomAttribute<ModelAttribute>();
        //             if (modelAttr != null && !_serviceInterface.ContainsKey(modelAttr.Name))
        //             {
        //                 _serviceInterface[modelAttr.Name] = interfaceType;
        //             }
        //         }
        //     }
        // }

        public void RegisterServiceTypes(IEnumerable<Assembly> assemblies)
        {
            var appServiceInterfaceTypes = assemblies
                .SelectMany(a => a.GetTypes())
                .Where(type => type.IsInterface && typeof(IApplicationService).IsAssignableFrom(type) && type.Name.EndsWith("AppService"));

            foreach (var interfaceType in appServiceInterfaceTypes)
            {
                var implementationType = assemblies
                    .SelectMany(a => a.GetTypes())
                    .FirstOrDefault(t => t.IsClass && !t.IsAbstract && interfaceType.IsAssignableFrom(t));

                if (implementationType != null)
                {
                    var modelAttr = implementationType.GetCustomAttribute<ModelAttribute>();
                    if (modelAttr == null) continue;

                    // THAY ĐỔI: Tìm TEntity từ lớp cha GenericApplicationService<TEntity>
                    Type entityType = FindEntityTypeFromGenericBase(implementationType);

                    if (entityType != null)
                    {
                        // Đăng ký service interface với cả hai key: tên Odoo và tên Entity C#
                        _serviceInterface[modelAttr.Name] = interfaceType;
                        _serviceInterface[entityType.Name] = interfaceType;
                    }
                }
            }
        }

        private Type FindEntityTypeFromGenericBase(Type implementationType)
        {
            var currentType = implementationType;
            while (currentType != null && currentType != typeof(object))
            {
                // Kiểm tra xem lớp hiện tại có phải là một generic type không
                if (currentType.IsGenericType && currentType.GetGenericTypeDefinition() == typeof(GenericApplicationService<>))
                {
                    // Nếu đúng, lấy generic argument đầu tiên (chính là TEntity)
                    return currentType.GetGenericArguments()[0];
                }
                // Nếu không, đi lên lớp cha để kiểm tra tiếp
                currentType = currentType.BaseType;
            }
            return null; // Không tìm thấy lớp cha GenericApplicationService<>
        }
    }
}