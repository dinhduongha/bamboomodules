using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using Bamboo.Core.Models;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Application
{

    public class ModelTypeRegistry : IModelTypeRegistry
    {
        private readonly Dictionary<string, Type> _modelTypes = new Dictionary<string, Type>();

        public Type GetType(string modelName)
        {
            if (_modelTypes.TryGetValue(modelName, out var type))
                return type;
            return null;
            //throw new UserFriendlyException($"Model {modelName} not found");
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
                    _modelTypes[type.Name] = type;
                }
            }
        }
    }
}