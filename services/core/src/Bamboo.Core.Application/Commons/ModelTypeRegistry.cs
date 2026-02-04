using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;

using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;

using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;

namespace Bamboo.Core.Application
{

    public class ModelTypeRegistry : IModelTypeRegistry
    {
        private readonly ConcurrentDictionary<string, Type> _modelTypes = new ConcurrentDictionary<string, Type>();
        private readonly ConcurrentDictionary<string, Type> _appServiceTypes = new ConcurrentDictionary<string, Type>();
        //private readonly ConcurrentDictionary<(string Model, string Method), (Type ServiceType, MethodInfo? Method)> _methodCache = new();
        private readonly ConcurrentDictionary<(string Model, string Method), MethodInfo?> _methodCache = new();
        // Cache field mapping: (model, odooFieldName) → PropertyInfo trong Entity
        private readonly ConcurrentDictionary<(string Model, string Field), PropertyInfo?> _propertyCache = new();
        private const BindingFlags MethodFlags = BindingFlags.Public | BindingFlags.Instance;
        private const BindingFlags PropertyFlags = BindingFlags.Public | BindingFlags.Instance;


        public Type GetEntityType(string modelName)
        {
            if (_modelTypes.TryGetValue(modelName, out var type))
                return type;
            return null;
        }

        /// <summary>
        /// Lấy AppService Type cho modelName (strict: dùng đúng tên được truyền vào).
        /// - Nếu đã register custom AppService → trả về custom.
        /// - Nếu chưa có → tạo GenericAppService<TEntity> và cache lại.
        /// - Cache on-demand giống GetMethodInfo.
        /// </summary>
        public Type GetAppServiceType(string modelName)
        {
            // Dùng chính _appServiceTypes làm cache (ConcurrentDictionary<string, Type>)
            // Nếu đã có (custom hoặc generic đã tạo) → trả về ngay
            if (_appServiceTypes.TryGetValue(modelName, out var cachedType))
            {
                return cachedType;
            }

            // Nếu chưa có trong cache → tạo fallback GenericAppService<TEntity>
            var entityType = GetEntityType(modelName);
            if (entityType == null)
            {
                return null;
            }

            var genericType = typeof(GenericAppService<>).MakeGenericType(entityType);

            // Lưu vào cache để lần sau dùng luôn (thread-safe nhờ ConcurrentDictionary)
            _appServiceTypes[modelName] = genericType;

            return genericType;
        }

        /// <summary>
        /// Lookup MethodInfo từ model và method name (Odoo style, snake_case hoặc PascalCaseAsync).
        /// Sử dụng cache, hỗ trợ normalize tên method.
        /// </summary>
        public MethodInfo? GetMethodInfo(string modelName, string methodName)
        {
            var key = (modelName, methodName);

            return _methodCache.GetOrAdd(key, k =>
            {
                var serviceType = GetAppServiceType(k.Model);
                if (serviceType == null) return null;

                string normalized = NormalizeMethodName(k.Method);

                // 1. Tìm method chính xác theo normalized name
                var method = serviceType.GetMethod(normalized, MethodFlags);

                // 2. Fallback nếu không có Async suffix
                if (method == null && normalized.EndsWith("Async"))
                {
                    var fallbackName = normalized[..^5]; // bỏ "Async"
                    method = serviceType.GetMethod(fallbackName, MethodFlags);
                }

                // 3. Optional: kiểm tra [JsonRpcMethod] attribute nếu bạn dùng
                // if (method != null && method.GetCustomAttribute<JsonRpcMethodAttribute>() == null) method = null;

                return method;
            });
        }

        /// <summary>
        /// Tìm PropertyInfo trong Entity tương ứng với tên trường.
        /// Strict case-sensitive.
        /// Thứ tự ưu tiên:
        /// 1. Tên property C# khớp chính xác (case-sensitive)
        /// 2. Tên theo [Column("...")] hoặc [JsonPropertyName("...")] khớp chính xác
        /// 3. Tên property C# dưới dạng snake_case chuyển thành PascalCase chính xác
        /// </summary>
        public PropertyInfo? GetEntityProperty(string modelName, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(fieldName)) return null;

            // Key cache: dùng nguyên tên fieldName (strict case)
            var key = (modelName, fieldName);

            return _propertyCache.GetOrAdd(key, k =>
            {
                var entityType = GetEntityType(k.Model);
                if (entityType == null) return null;

                var searchName = k.Field;

                var allProps = entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                // Ưu tiên 1: Tên property C# khớp chính xác (case-sensitive)
                var byCSharpName = allProps.FirstOrDefault(p => p.Name == searchName);
                if (byCSharpName != null) return byCSharpName;

                // Ưu tiên 2: Tìm theo [Column] hoặc [JsonPropertyName] khớp chính xác
                var byAttribute = allProps.FirstOrDefault(p =>
                {
                    var col = p.GetCustomAttribute<ColumnAttribute>();
                    if (col?.Name == searchName) return true;

                    var json = p.GetCustomAttribute<System.Text.Json.Serialization.JsonPropertyNameAttribute>();
                    if (json?.Name == searchName) return true;

                    return false;
                });

                if (byAttribute != null) return byAttribute;

                // Ưu tiên 3: Chuyển fieldName snake_case thành PascalCase rồi so khớp chính xác
                // Ví dụ: client gửi "last_modify_time" → tìm property "LastModifyTime"
                var snakeToPascal = NormalizeSnakeToPascal(searchName);
                var bySnakePascal = allProps.FirstOrDefault(p => p.Name == snakeToPascal);

                return bySnakePascal;
            });
        }

        /// <summary>
        /// Lấy tất cả các navigation properties (relation) của Entity
        /// </summary>
        public IEnumerable<PropertyInfo> GetRelationProperties(string modelName)
        {
            var entityType = GetEntityType(modelName);
            if (entityType == null) return Enumerable.Empty<PropertyInfo>();

            return entityType.GetProperties(PropertyFlags)
                .Where(p => p.PropertyType.IsClass &&
                            !p.PropertyType.IsPrimitive &&
                            !p.PropertyType.IsValueType &&
                            p.PropertyType != typeof(string) &&
                            (p.GetCustomAttribute<ForeignKeyAttribute>() != null ||
                             p.GetCustomAttribute<RelationFieldAttribute>() != null ||
                             p.GetCustomAttribute<Many2oneAttribute>() != null ||
                             p.GetCustomAttribute<One2manyAttribute>() != null ||
                             p.GetCustomAttribute<Many2manyAttribute>() != null ||
                             typeof(IEntity).IsAssignableFrom(p.PropertyType)));
        }

        /// <summary>
        /// Normalize tên method từ snake_case sang ABP PascalCaseAsync.
        /// </summary>
        private static string NormalizeMethodName(string rpcMethodName)
        {
            if (string.IsNullOrEmpty(rpcMethodName)) return rpcMethodName;

            // Đã là PascalCaseAsync → giữ nguyên
            if (rpcMethodName.EndsWith("Async") && char.IsUpper(rpcMethodName[0]))
                return rpcMethodName;

            // snake_case → PascalCase + Async
            if (rpcMethodName.Contains('_'))
            {
                var parts = rpcMethodName.Split('_', StringSplitOptions.RemoveEmptyEntries);
                var sb = new StringBuilder();
                foreach (var part in parts)
                {
                    if (part.Length > 0)
                    {
                        sb.Append(char.ToUpperInvariant(part[0]));
                        sb.Append(part[1..]);
                    }
                }
                return sb.ToString() + "Async";
            }

            // PascalCase không Async → thêm Async
            if (char.IsUpper(rpcMethodName[0]))
                return rpcMethodName + "Async";

            // Fallback: thêm Async
            return rpcMethodName + "Async";
        }

        /// <summary>
        /// Chuyển snake_case thành PascalCase chính xác (không thêm hậu tố)
        /// Ví dụ: write_date → WriteDate, tenant_id → TenantId
        /// </summary>
        private static string NormalizeSnakeToPascal(string snake)
        {
            if (string.IsNullOrEmpty(snake)) return snake;

            var parts = snake.Split('_', StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder();
            foreach (var part in parts)
            {
                if (part.Length > 0)
                {
                    sb.Append(char.ToUpperInvariant(part[0]));
                    sb.Append(part[1..]);
                }
            }
            return sb.ToString();
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

        /// <summary>
        /// Đăng ký một model name với Entity và AppService (hỗ trợ nhiều model → cùng entity/service)
        /// </summary>
        public void RegisterModel(string modelName, Type entityType, Type? appServiceType = null)
        {
            if (!typeof(IEntity).IsAssignableFrom(entityType))
                throw new ArgumentException($"Entity phải implement IEntity: {entityType.Name}");

            _modelTypes[modelName] = entityType;

            if (appServiceType == null)
            {
                appServiceType = typeof(GenericAppService<>).MakeGenericType(entityType);
            }
            if (!typeof(IApplicationService).IsAssignableFrom(appServiceType))
            {
                throw new ArgumentException($"AppService phải implement IApplicationService: {appServiceType.Name}");
            }
            _appServiceTypes[modelName] = appServiceType;
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

        public void RegisterServiceTypes(IEnumerable<Assembly> assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var appServiceTypes = assembly.GetTypes()
                                .Where(t => t.IsClass && !t.IsAbstract &&
                                            typeof(IApplicationService).IsAssignableFrom(t) &&
                                            t.Name.EndsWith("AppService"));

                foreach (var implType in appServiceTypes)
                {
                    var implementationType = implType;
                    // var implementationType = assemblies
                    //     .SelectMany(a => a.GetTypes())
                    //     .FirstOrDefault(t => t.IsClass && !t.IsAbstract && interfaceType.IsAssignableFrom(t));

                    if (implementationType != null)
                    {
                        var modelAttr = implementationType.GetCustomAttribute<ModelAttribute>();
                        //if (modelAttr == null) continue;

                        // THAY ĐỔI: Tìm TEntity từ lớp cha GenericApplicationService<TEntity>
                        Type entityType = FindEntityTypeFromGenericBase(implementationType);

                        if (entityType != null)
                        {
                            var _modelAttr = entityType.GetCustomAttribute<ModelAttribute>(true);

                            if (entityType.IsClass && !entityType.IsAbstract && typeof(IEntity).IsAssignableFrom(entityType))
                            {
                                if (_modelAttr != null)
                                {
                                    _appServiceTypes[_modelAttr.Name] = implementationType;
                                }
                                var _tableAttr = entityType.GetCustomAttribute<TableAttribute>(true);
                                if (_tableAttr != null)
                                {
                                    _appServiceTypes[_tableAttr.Name] = implementationType;
                                    _appServiceTypes[_tableAttr.Name.Replace("_", ".")] = implementationType;
                                }
                            }
                            // Đăng ký service interface với cả hai key: tên Odoo và tên Entity C#
                            if (modelAttr != null)
                            {
                                _appServiceTypes[modelAttr.Name] = implementationType;
                            }
                            _appServiceTypes[entityType.Name] = implementationType;
                        }
                    }
                }
            }
            if (_appServiceTypes.Count > 0)
            {

            }
        }

        private Type FindEntityTypeFromGenericBase(Type implementationType)
        {
            var currentType = implementationType;
            while (currentType != null && currentType != typeof(object))
            {
                // Kiểm tra xem lớp hiện tại có phải là một generic type không
                if (currentType.IsGenericType && currentType.GetGenericTypeDefinition() == typeof(GenericAppService<>))
                {
                    // Nếu đúng, lấy generic argument đầu tiên (chính là TEntity)
                    return currentType.GetGenericArguments()[0];
                }
                // Nếu không, đi lên lớp cha để kiểm tra tiếp
                currentType = currentType.BaseType;
            }
            return null; // Không tìm thấy lớp cha GenericAppService<>
        }
    }
}