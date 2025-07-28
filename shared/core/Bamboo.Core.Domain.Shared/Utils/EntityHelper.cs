using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

class EntityHelper
{
    public static void InitCollections(object entity)
    {
        var props = entity.GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p =>
                p.PropertyType.IsGenericType &&
                typeof(ICollection<>).IsAssignableFrom(p.PropertyType.GetGenericTypeDefinition()) == false &&
                typeof(IEnumerable<>).IsAssignableFrom(p.PropertyType));

        foreach (var prop in props)
        {
            if (prop.GetValue(entity) == null)
            {
                var listType = typeof(List<>).MakeGenericType(prop.PropertyType.GenericTypeArguments[0]);
                prop.SetValue(entity, Activator.CreateInstance(listType));
            }
        }
    }
}