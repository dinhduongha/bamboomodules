using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Reflection;

using Microsoft.Extensions.Logging;

using Volo.Abp;
using Volo.Abp.DependencyInjection;

using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Dtos;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Text;
namespace Bamboo.Core.Application;

public class RpcDispatcherAppService : IRpcDispatcherAppService
{

    protected readonly IServiceProvider _serviceProvider;
    protected readonly ILogger<RpcDispatcherAppService> _logger;
    protected readonly IModelTypeRegistry _modelTypeRegistry;
    protected readonly IAuthorizationService _authorizationService;
    //private readonly ConcurrentDictionary<(string model, string method), (Type ServiceType, MethodInfo Method)> _methodCache = new();

    private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        ReferenceHandler = ReferenceHandler.IgnoreCycles,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = false
    };

    protected static string[] _commonMethods = [
            "read", "search", "search_read", "search_count", "create", "write", "update_json", "unlink", "copy",
            "default_get", "fields_get", "name_get", "name_search", "name_create", "onchange",
            "web_read", "web_save", "web_search_read", "web_read_group"];

    public RpcDispatcherAppService(
        IServiceProvider serviceProvider,
        ILogger<RpcDispatcherAppService> logger,
        IAuthorizationService authorizationService,
        IModelTypeRegistry modelTypeRegistry)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
        _modelTypeRegistry = modelTypeRegistry;
        _authorizationService = authorizationService;
    }


    public async Task<List<JsonElement>> ReadAsync(string modelName, ReadRequestDto input)
    {
        var service = GetGenericService(modelName);
        var results = await CallServiceMethodAsync<List<object>>(service, "ReadAsync", input);
        List<JsonElement> jsonElementList = results
            .Select(item => JsonSerializer.SerializeToElement(item, _jsonSerializerOptions))
            .ToList();
        return jsonElementList;
    }

    public async Task<List<Guid>> SearchAsync(string modelName, SearchRequestDto input)
    {
        var service = GetGenericService(modelName);
        return await CallServiceMethodAsync<List<Guid>>(service, "SearchAsync", input);
    }

    public async Task<List<JsonElement>> SearchReadAsync(string modelName, SearchReadRequestDto input)
    {
        var service = GetGenericService(modelName);
        var results = await CallServiceMethodAsync<List<object>>(service, "SearchReadAsync", input);
        List<JsonElement> jsonElementList = results
            .Select(item => JsonSerializer.SerializeToElement(item, _jsonSerializerOptions))
            .ToList();
        return jsonElementList;
    }

    public async Task<object> SearchCountAsync(string modelName, SearchCountRequestDto input)
    {
        var service = GetGenericService(modelName);
        var results = await CallServiceMethodAsync<object>(service, "SearchCountAsync", input);
        return results;
        // List<JsonElement> jsonElementList = results
        //     .Select(item => JsonSerializer.SerializeToElement(item, _jsonSerializerOptions))
        //     .ToList();
        // return jsonElementList;
    }

    public async Task<JsonElement> CreateAsync(string modelName, CreateRequestDto input)
    {
        var service = GetGenericService(modelName);
        var entityType = _modelTypeRegistry.GetEntityType(modelName);
        var typedDtoType = typeof(CreateRequestDto<>).MakeGenericType(entityType);

        var typedDto = Activator.CreateInstance(typedDtoType)!;
        object? entityObj = null;
        if (input.Entity.ValueKind != JsonValueKind.Null && input.Entity.ValueKind != JsonValueKind.Undefined)
        {
            entityObj = input.Entity.Deserialize(entityType, _jsonSerializerOptions);
        }

        typedDtoType.GetProperty(nameof(CreateRequestDto<>.Fields))!
            .SetValue(typedDto, input.Fields);

        typedDtoType.GetProperty(nameof(CreateRequestDto<>.Context))!
            .SetValue(typedDto, input.Context);

        typedDtoType.GetProperty(nameof(CreateRequestDto<>.Entity))!
            .SetValue(typedDto, entityObj);
        var typedEntity = typedDto;

        //var jsonElement = JsonSerializer.SerializeToElement(input);
        //var typedEntity = JsonSerializer.Deserialize(jsonElement, typedDtoType);

        var result = await CallServiceMethodAsync<object>(service, "CreateAsync", typedEntity);
        return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
    }

    public async Task<List<JsonElement>> WriteAsync(string modelName, UpdateRequestDto input)
    {
        var service = GetGenericService(modelName);
        var entityType = _modelTypeRegistry.GetEntityType(modelName);
        var typedDtoType = typeof(UpdateRequestDto<>).MakeGenericType(entityType);

        var typedDto = Activator.CreateInstance(typedDtoType)!;
        object? entityObj = null;
        if (input.Entity.ValueKind != JsonValueKind.Null && input.Entity.ValueKind != JsonValueKind.Undefined)
        {
            entityObj = input.Entity.Deserialize(entityType, _jsonSerializerOptions);
        }
        typedDtoType.GetProperty(nameof(UpdateRequestDto<>.Ids))!
            .SetValue(typedDto, input.Ids);

        typedDtoType.GetProperty(nameof(UpdateRequestDto<>.Fields))!
            .SetValue(typedDto, input.Fields);

        typedDtoType.GetProperty(nameof(UpdateRequestDto<>.Context))!
            .SetValue(typedDto, input.Context);

        typedDtoType.GetProperty(nameof(UpdateRequestDto<>.Entity))!
            .SetValue(typedDto, entityObj);
        var typedEntity = typedDto;

        //var jsonElement = JsonSerializer.SerializeToElement(input);
        //var typedEntity = JsonSerializer.Deserialize(jsonElement, typedDtoType);

        var results = await CallServiceMethodAsync<List<object>>(service, "WriteAsync", typedEntity);
        List<JsonElement> jsonElementList = results
            .Select(item => JsonSerializer.SerializeToElement(item, _jsonSerializerOptions))
            .ToList();
        return jsonElementList;

    }

    public async Task<List<JsonElement>> UpdateJsonAsync(string modelName, UpdateJsonRequestDto input)
    {
        var service = GetGenericService(modelName);
        var entityType = _modelTypeRegistry.GetEntityType(modelName);
        var results = await CallServiceMethodAsync<List<object>>(service, "UpdateJsonAsync", input);
        List<JsonElement> jsonElementList = results
            .Select(item => JsonSerializer.SerializeToElement(item, _jsonSerializerOptions))
            .ToList();
        return jsonElementList;

    }

    public async Task DeleteAsync(string modelName, List<Guid> ids)
    {
        var service = GetGenericService(modelName);
        await CallServiceMethodAsync<object>(service, "DeleteAsync", ids);
    }

    public async Task<JsonElement> CopyAsync(string modelName, CopyRequestDto input)
    {
        var service = GetGenericService(modelName);
        var entityType = _modelTypeRegistry.GetEntityType(modelName);
        var typedDtoType = typeof(CopyRequestDto<>).MakeGenericType(entityType);

        var typedDto = Activator.CreateInstance(typedDtoType)!;
        object? entityObj = null;
        if (input.DefaultValues.ValueKind != JsonValueKind.Null && input.DefaultValues.ValueKind != JsonValueKind.Undefined)
        {
            entityObj = input.DefaultValues.Deserialize(entityType, _jsonSerializerOptions);
        }
        typedDtoType.GetProperty(nameof(CopyRequestDto<>.Ids))!
            .SetValue(typedDto, input.Ids);

        typedDtoType.GetProperty(nameof(CopyRequestDto<>.Fields))!
            .SetValue(typedDto, input.Fields);

        typedDtoType.GetProperty(nameof(CopyRequestDto<>.Context))!
            .SetValue(typedDto, input.Context);

        typedDtoType.GetProperty(nameof(CopyRequestDto<>.DefaultValues))!
            .SetValue(typedDto, entityObj);
        var typedEntity = typedDto;

        //var jsonElement = JsonSerializer.SerializeToElement(input);
        //var typedEntity = JsonSerializer.Deserialize(jsonElement, typedDtoType);

        var result = await CallServiceMethodAsync<object>(service, "CopyAsync", typedEntity);
        return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
    }

    public async Task<JsonElement> DefaultGetAsync(string modelName, DefaultGetRequestDto input)
    {
        var service = GetGenericService(modelName);
        var result = await CallServiceMethodAsync<Dictionary<string, object>>(service, "DefaultGetAsync", input);
        return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
    }

    public async Task<JsonElement> OnChangeAsync(string modelName, OnChangeRequestDto input)
    {
        var service = GetGenericService(modelName);
        var entityType = _modelTypeRegistry.GetEntityType(modelName);
        //var typedValues = Convert.ChangeType(values, entityType);
        return await CallServiceMethodAsync<JsonElement>(service, "OnChangeAsync", input);
    }


    public async Task<JsonElement> NameCreateAsync(string modelName, NameCreateRequestDto input)
    {
        var service = GetGenericService(modelName);
        var result = await CallServiceMethodAsync<object>(service, "NameCreateAsync", modelName, input);
        return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
    }

    public async Task<List<(Guid Id, string Name)>> NameGetAsync(string modelName, NameGetRequestDto input)
    {
        var service = GetGenericService(modelName);
        return await CallServiceMethodAsync<List<(Guid Id, string Name)>>(service, "NameGetAsync", input);
    }

    public async Task<List<(Guid Id, string Name)>> NameSearchAsync(string modelName, NameSearchRequestDto input)
    {
        var service = GetGenericService(modelName);
        return await CallServiceMethodAsync<List<(Guid Id, string Name)>>(service, "NameSearchAsync", input);
    }

    public async Task<Dictionary<string, Dictionary<string, object>>> FieldsGetAsync(string modelName, FieldsGetRequestDto input)
    {
        var service = GetGenericService(modelName);
        return await CallServiceMethodAsync<Dictionary<string, Dictionary<string, object>>>(service, "FieldsGetAsync", input);
    }

    public async Task<JsonElement> WebReadAsync(string modelName, WebReadRequestDto input)
    {
        var service = GetGenericService(modelName);
        var result = await CallServiceMethodAsync<object>(service, "WebReadAsync", modelName, input);
        return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
    }

    public async Task<JsonElement> WebSearchReadAsync(string modelName, WebSearchReadRequestDto input)
    {
        var service = GetGenericService(modelName);
        var result = await CallServiceMethodAsync<object>(service, "WebSearchReadAsync", modelName, input);
        return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
    }

    public async Task<JsonElement> WebReadGroupAsync(string modelName, WebReadGroupRequestDto input)
    {
        var service = GetGenericService(modelName);
        var result = await CallServiceMethodAsync<object>(service, "WebReadGroupAsync", modelName, input);
        return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
    }

    public async Task<JsonElement> WebSaveAsync(string modelName, WebSaveRequestDto input)
    {
        var service = GetGenericService(modelName);
        var result = await CallServiceMethodAsync<object>(service, "WebSaveAsync", modelName, input);
        return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
    }

    public async Task<object> CallServiceAsync(string modelName, string methodName, params object[] args)
    {
        var service = GetGenericService(modelName);
        return await CallServiceMethodAsync<object>(service, methodName, args);
    }

    private object GetGenericService(string modelName)
    {
        var entityType = _modelTypeRegistry.GetEntityType(modelName);
        var serviceType = _modelTypeRegistry.GetAppServiceType(modelName);
        if (serviceType == null)
        {
            serviceType = typeof(IGenericAppService<>).MakeGenericType(entityType);
        }
        return _serviceProvider.GetService(serviceType)
            ?? throw new UserFriendlyException($"{modelName}AppService not found");
    }

    private async Task<TResult> CallServiceMethodAsync<TResult>(object service, string methodName, params object[] args)
    {
        var method = service.GetType().GetMethod(methodName);
        if (method == null)
            throw new UserFriendlyException($"Method {service.GetType().Name}.{methodName} not found");

        if (!method.IsPublic)
            throw new UserFriendlyException($"Method {service.GetType().Name}.{methodName} is not public");

        //if (method.GetCustomAttribute<JsonRpcMethodAttribute>() == null)
        //    throw new UserFriendlyException($"Method {service.GetType().Name}.{methodName} is not public");

        var result = method.Invoke(service, args);
        if (result is Task<TResult> task)
            return await task;
        return (TResult)result;
    }

    // ──────────────────────────────────────────────
    // JSON-2 API (Odoo 19+ style: /json/2/<model>/<method>)
    // ──────────────────────────────────────────────
    public async Task<JsonElement> DispatchJson2Async(
        string model,
        string rpcMethod,
        JsonElement body)
    {
        // Nếu cần UserContext → lấy từ HttpContext.User trong Controller và truyền vào nếu cần

        var (serviceType, method) = GetCachedMethod(model, rpcMethod);
        if (method == null)
            throw new JsonRpcException(-32601, $"Method '{rpcMethod}' not found on model '{model}'");

        //var service = _serviceProvider.GetRequiredService(serviceType);
        var service = _serviceProvider.GetService(serviceType);

        var boundArgs = BindJson2Parameters(method, body);

        return await InvokeAndSerializeAsync(service, method, boundArgs);
    }

    // ──────────────────────────────────────────────
    // Legacy JSON-RPC (execute_kw style: /jsonrpc)
    // ──────────────────────────────────────────────
    public async Task<JsonElement> DispatchLegacyJsonRpcAsync(JsonRpcParams rpcParams)
    {
        if (rpcParams == null)
            throw new JsonRpcException(-32602, "Params is null");

        if (string.IsNullOrEmpty(rpcParams.Model))
            throw new JsonRpcException(-32602, "Missing model");

        if (string.IsNullOrEmpty(rpcParams.Method))
            throw new JsonRpcException(-32602, "Missing method");

        string model = rpcParams.Model;
        string rpcMethod = rpcParams.Method;

        // var modelName = request.Params?.Model ?? throw new UserFriendlyException("Model is required");
        // var method = request.Params?.Method ?? throw new UserFriendlyException("Method is required");
        var args = rpcParams?.Args ?? new List<object>();
        // var kwargs = request.Params?.Kwargs ?? new Dictionary<string, object>();

        // Dùng thẳng, không xử lý gì thêm
        var positional = rpcParams?.Args?.ToArray() ?? Array.Empty<object?>();
        var kwargs = rpcParams?.Kwargs ?? new Dictionary<string, object>();

        // Optional: log để debug format client gửi
        _logger?.LogDebug("Legacy RPC call: model={Model}, method={Method}, positional count={PosCount}, has kwargs={HasKwargs}",
            model, rpcMethod, positional.Length, kwargs != null && kwargs.Count > 0);

        if (_commonMethods.Contains(rpcMethod))
        {
            var result = await ProcessCommonMethodAsync(model, rpcMethod, args, kwargs);
            return JsonSerializer.SerializeToElement(result, new JsonSerializerOptions { WriteIndented = false });
        }

        // Resolve service và method
        var (serviceType, methodInfo) = GetCachedMethod(model, rpcMethod);
        if (methodInfo == null)
            throw new JsonRpcException(-32601, $"Method '{rpcMethod}' not found on model '{model}'");

        var service = _serviceProvider.GetService(serviceType);

        // Bind tham số (positional trước, kwargs override sau)
        var boundArgs = BindLegacyParameters(methodInfo, positional, kwargs);

        // Thực thi và trả kết quả
        return await InvokeAndSerializeAsync(service, methodInfo, boundArgs);
    }

    // ──────────────────────────────────────────────
    // Method resolution: snake_case → PascalCaseAsync + [JsonRpcMethod] support
    // ──────────────────────────────────────────────
    private (Type ServiceType, MethodInfo? Method) GetCachedMethod(string model, string rpcMethod)
    {
        var serviceType = _modelTypeRegistry.GetAppServiceType(model);
        var method = _modelTypeRegistry.GetMethodInfo(model, rpcMethod);
        return (serviceType, method);
        //var key = (model, rpcMethod);
        // return _methodCache.GetOrAdd(key, k =>
        // {
        //     //var serviceType = ModelToServiceMapper.Resolve(k.model);
        //     var serviceType = GetGenericService(k.model).GetType();
        //     if (serviceType == null)
        //         return (null!, null!);

        //     string normalized = NormalizeRpcMethodName(k.method);

        //     var methods = serviceType.GetMethods(BindingFlags.Public | BindingFlags.Instance);

        //     // 1. Ưu tiên [JsonRpcMethod] attribute
        //     foreach (var m in methods)
        //     {
        //         var attr = m.GetCustomAttribute<JsonRpcMethodAttribute>();
        //         if (attr != null &&
        //             string.Equals(k.method, attr.RpcName ?? m.Name, StringComparison.OrdinalIgnoreCase))
        //         {
        //             return (serviceType, m);
        //         }
        //     }

        //     // 2. Fallback: tìm theo tên normalized
        //     var method = serviceType.GetMethod(normalized,
        //         BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

        //     if (method == null && normalized.EndsWith("Async"))
        //     {
        //         var fallback = normalized[..^5];
        //         method = serviceType.GetMethod(fallback,
        //             BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
        //     }

        //     return (serviceType, method);
        // });
    }

    // private static string NormalizeRpcMethodName(string rpcMethod)
    // {
    //     if (string.IsNullOrEmpty(rpcMethod)) return rpcMethod;

    //     if (rpcMethod.EndsWith("Async", StringComparison.Ordinal) && char.IsUpper(rpcMethod[0]))
    //         return rpcMethod;

    //     if (rpcMethod.Contains('_'))
    //     {
    //         var parts = rpcMethod.Split('_', StringSplitOptions.RemoveEmptyEntries);
    //         var sb = new StringBuilder();
    //         foreach (var part in parts)
    //         {
    //             if (part.Length == 0) continue;
    //             sb.Append(char.ToUpperInvariant(part[0]));
    //             sb.Append(part.AsSpan(1));
    //         }
    //         return sb.ToString() + "Async";
    //     }

    //     if (char.IsUpper(rpcMethod[0]))
    //         return rpcMethod + "Async";

    //     return rpcMethod + "Async";
    // }

    // ──────────────────────────────────────────────
    // Binding cho JSON-2 (named params + ids + context)
    // ──────────────────────────────────────────────
    private object?[] BindJson2Parameters(MethodInfo method, JsonElement body)
    {
        var parameters = method.GetParameters();
        var bound = new object?[parameters.Length];
        // Trường hợp 0 tham số
        if (parameters.Length == 0)
            return Array.Empty<object?>();

        var param = parameters[0];
        var paramType = param.ParameterType;

        // ids array
        Guid[]? ids = null;
        if (body.TryGetProperty("ids", out var idsEl) && idsEl.ValueKind == JsonValueKind.Array)
        {
            ids = idsEl.EnumerateArray()
                .Select(e => e.GetGuidSafe())
                .Where(g => g != Guid.Empty)
                .ToArray();
        }

        // context
        IDictionary<string, object?>? context = null;
        if (body.TryGetProperty("context", out var ctxEl) && ctxEl.ValueKind == JsonValueKind.Object)
        {
            context = JsonSerializer.Deserialize<Dictionary<string, object?>>(ctxEl.GetRawText());
        }

        // kwargs: các field khác ngoài ids/context
        var kwargs = new Dictionary<string, JsonElement>(StringComparer.OrdinalIgnoreCase);
        foreach (var prop in body.EnumerateObject())
        {
            if (prop.NameEquals("ids") || prop.NameEquals("context")) continue;
            kwargs[prop.Name] = prop.Value;
        }

        for (int i = 0; i < parameters.Length; i++)
        {
            var p = parameters[i];
            string nameLower = p.Name!.ToLowerInvariant();

            if (nameLower == "ids" || nameLower == "id")
            {
                if (p.ParameterType == typeof(Guid[]))
                    bound[i] = ids ?? Array.Empty<Guid>();
                else if (p.ParameterType == typeof(Guid))
                    bound[i] = ids?.Length == 1 ? ids[0] : throw new JsonRpcException(-32602, "Expected single ID");
                else
                    bound[i] = null;
            }
            else if (nameLower == "context")
            {
                bound[i] = context;
            }
            else if (kwargs.TryGetValue(p.Name, out var val) || kwargs.TryGetValue(p.Name.ToLowerInvariant(), out val))
            {
                bound[i] = ConvertJsonElement(val, p.ParameterType, p.Name);
                kwargs.Remove(p.Name);
            }
            else
            {
                bound[i] = p.HasDefaultValue ? p.DefaultValue :
                           (!p.ParameterType.IsValueType || Nullable.GetUnderlyingType(p.ParameterType) != null
                               ? null
                               : throw new JsonRpcException(-32602, $"Missing required parameter: {p.Name}"));
            }
        }

        if (kwargs.Count > 0)
        {
            _logger.LogWarning("Unused parameters in JSON-2 call: {Params}", string.Join(", ", kwargs.Keys));
        }

        return bound;
    }

    // ──────────────────────────────────────────────
    // Binding cho legacy (positional + kwargs)
    // ──────────────────────────────────────────────
    private object?[] BindLegacyParameters(MethodInfo method, object?[] positional, Dictionary<string, object?>? kwargs = null)
    {
        var parameters = method.GetParameters();
        var bound = new object?[parameters.Length];

        int posIndex = 0;
        for (int i = 0; i < parameters.Length; i++)
        {
            var p = parameters[i];

            if (posIndex < positional.Length)
            {
                bound[i] = positional[posIndex++];
            }
            else if (kwargs?.TryGetValue(p.Name!, out var val) == true ||
                     kwargs?.TryGetValue(p.Name!.ToLowerInvariant(), out val) == true)
            {
                bound[i] = val;
                kwargs.Remove(p.Name!);
            }
            else
            {
                bound[i] = p.HasDefaultValue ? p.DefaultValue : null;
            }
        }

        if (kwargs?.Count > 0)
        {
            _logger.LogWarning("Unused kwargs in legacy call: {Params}", string.Join(", ", kwargs.Keys));
        }

        return bound;
    }

    // ──────────────────────────────────────────────
    // Convert JsonElement sang object theo target type
    // ──────────────────────────────────────────────
    private object? ConvertJsonElement(JsonElement element, Type targetType, string paramName)
    {
        if (element.ValueKind == JsonValueKind.Null || element.ValueKind == JsonValueKind.Undefined)
        {
            return targetType.IsValueType && Nullable.GetUnderlyingType(targetType) == null
                ? throw new JsonRpcException(-32602, $"Parameter '{paramName}' cannot be null")
                : null;
        }

        var actualType = Nullable.GetUnderlyingType(targetType) ?? targetType;

        try
        {
            if (actualType == typeof(string)) return element.GetString();
            if (actualType == typeof(int)) return element.GetInt32();
            if (actualType == typeof(long)) return element.GetInt64();
            if (actualType == typeof(double)) return element.GetDouble();
            if (actualType == typeof(bool)) return element.GetBoolean();
            if (actualType == typeof(DateTime)) return element.GetDateTime();
            if (actualType == typeof(decimal)) return element.GetDecimal();
            if (actualType == typeof(Guid)) return element.GetGuidSafe();

            if (actualType.IsEnum)
            {
                var str = element.GetString();
                return str != null && Enum.TryParse(actualType, str, true, out var ev) ? ev : throw new JsonRpcException(-32602, $"Invalid enum for '{paramName}': {str}");
            }

            // List<T> hoặc array
            if (typeof(System.Collections.IEnumerable).IsAssignableFrom(actualType) && actualType != typeof(string))
            {
                if (element.ValueKind != JsonValueKind.Array)
                    throw new JsonRpcException(-32602, $"Expected array for '{paramName}'");

                var elemType = actualType.IsGenericType ? actualType.GetGenericArguments()[0] : typeof(object);
                var listType = typeof(List<>).MakeGenericType(elemType);
                var list = Activator.CreateInstance(listType) as System.Collections.IList;

                foreach (var item in element.EnumerateArray())
                {
                    list?.Add(ConvertJsonElement(item, elemType, $"{paramName}[]"));
                }

                return actualType.IsArray ? list?.Cast<object?>().ToArray() : list;
            }

            // Dictionary<string, object?>
            if (actualType == typeof(Dictionary<string, object?>) || actualType == typeof(IDictionary<string, object?>))
            {
                if (element.ValueKind != JsonValueKind.Object)
                    throw new JsonRpcException(-32602, $"Expected object for '{paramName}'");

                var dict = new Dictionary<string, object?>();
                foreach (var prop in element.EnumerateObject())
                {
                    dict[prop.Name] = ConvertJsonElement(prop.Value, typeof(object), $"{paramName}.{prop.Name}");
                }
                return dict;
            }

            // Fallback: deserialize full
            return JsonSerializer.Deserialize(element.GetRawText(), actualType);
        }
        catch (Exception ex)
        {
            throw new JsonRpcException(-32602, $"Invalid value for '{paramName}' (expected {actualType.Name})", ex);
        }
    }

    // ──────────────────────────────────────────────
    // Helpers cho legacy
    // ──────────────────────────────────────────────
    private object?[] ExtractPositionalArgs(JsonElement[] argsArray)
    {
        // args[0..4] là db, uid, password, model, method → bỏ qua
        return argsArray.Skip(5).Select(e => ConvertJsonElement(e, typeof(object), "positional")).ToArray();
    }

    private static Dictionary<string, object?>? ExtractKwargsFromLegacyArgs(JsonElement[] argsArray)
    {
        if (argsArray.Length > 5 && argsArray[^1].ValueKind == JsonValueKind.Object)
        {
            return JsonSerializer.Deserialize<Dictionary<string, object?>>(argsArray[^1].GetRawText());
        }
        return null;
    }

    // ──────────────────────────────────────────────
    // Invoke & Serialize
    // ──────────────────────────────────────────────
    private async Task<JsonElement> InvokeAndSerializeAsync(object service, MethodInfo method, object?[] args)
    {
        try
        {
            var result = method.Invoke(service, args);

            if (result is Task task)
            {
                await task.ConfigureAwait(false);
                result = task.GetType().GetProperty("Result")?.GetValue(task);
            }

            return JsonSerializer.SerializeToElement(result, new JsonSerializerOptions { WriteIndented = false });
        }
        catch (TargetInvocationException tie)
        {
            throw new JsonRpcException(-32000, "Execution failed: " + tie.InnerException?.Message, tie.InnerException);
        }
        catch (Exception ex)
        {
            throw new JsonRpcException(-32000, "Server error: " + ex.Message, ex);
        }
    }

    protected async Task<object> ProcessCommonMethodAsync(string modelName, string method, List<object> args, Dictionary<string, object>? kwargs)
    {

        var jsonOptions = new JsonSerializerOptions
        {
            Converters = { new ObjectToInferredTypeConverter() }
        };

        switch (method)
        {
            case "read":
                {
                    var ids = args.Count > 0 ? JsonSerializer.Deserialize<List<Guid>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : new List<Guid>();
                    var fields = kwargs.ContainsKey("fields") ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(kwargs["fields"], jsonOptions), jsonOptions) : args.Count > 1 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[1], jsonOptions), jsonOptions) : null;
                    JsonElement? context = kwargs.ContainsKey("context") ? JsonSerializer.SerializeToElement(kwargs["context"], jsonOptions) : args.Count > 0 ? JsonSerializer.SerializeToElement(args[0], jsonOptions) : null;

                    ReadRequestDto requestDto = new ReadRequestDto
                    {
                        Ids = ids ?? [],
                        Fields = fields ?? [],
                        Context = context,
                    };
                    return await ReadAsync(modelName, requestDto);
                }
            case "search":
                {
                    var ids = args.Count > 0 ? JsonSerializer.Deserialize<List<Guid>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : new List<Guid>();
                    var fields = kwargs.ContainsKey("fields") ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(kwargs["fields"], jsonOptions), jsonOptions) : args.Count > 1 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[1], jsonOptions), jsonOptions) : null;
                    JsonElement? context = kwargs.ContainsKey("context") ? JsonSerializer.SerializeToElement(kwargs["context"], jsonOptions) : args.Count > 0 ? JsonSerializer.SerializeToElement(args[0], jsonOptions) : null;
                    JsonElement? domain = kwargs.ContainsKey("domain") ? JsonSerializer.SerializeToElement(kwargs["domain"], jsonOptions) : args.Count > 0 ? JsonSerializer.SerializeToElement(args[0], jsonOptions) : null;
                    SearchRequestDto requestDto = new SearchRequestDto
                    {
                        //Ids = ids ?? [],
                        Fields = fields ?? [],
                        Domain = domain,
                        Context = context,
                    };
                    return await SearchAsync(modelName, requestDto);
                }
            case "search_read":
                {
                    var ids = args.Count > 0 ? JsonSerializer.Deserialize<List<Guid>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : new List<Guid>();
                    var fields = kwargs.ContainsKey("fields") ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(kwargs["fields"], jsonOptions), jsonOptions) : args.Count > 1 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[1], jsonOptions), jsonOptions) : null;
                    JsonElement? context = kwargs.ContainsKey("context") ? JsonSerializer.SerializeToElement(kwargs["context"], jsonOptions) : args.Count > 0 ? JsonSerializer.SerializeToElement(args[0], jsonOptions) : null;
                    JsonElement? domain = kwargs.ContainsKey("domain") ? JsonSerializer.SerializeToElement(kwargs["domain"], jsonOptions) : args.Count > 0 ? JsonSerializer.SerializeToElement(args[0], jsonOptions) : null;
                    SearchReadRequestDto requestDto = new SearchReadRequestDto
                    {
                        //Ids = ids ?? [],
                        Domain = domain,
                        Fields = fields ?? [],
                        Context = context,
                    };
                    //JsonElement? domain = kwargs.ContainsKey("domain") ? JsonSerializer.SerializeToElement(kwargs["domain"], jsonOptions) : args.Count > 0 ? JsonSerializer.SerializeToElement(args[0], jsonOptions) : null;
                    //var fields = kwargs.ContainsKey("fields") ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(kwargs["fields"], jsonOptions), jsonOptions) : args.Count > 1 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[1], jsonOptions), jsonOptions) : null;
                    return await SearchReadAsync(modelName, requestDto);
                }
            case "search_count":
                {
                    var ids = args.Count > 0 ? JsonSerializer.Deserialize<List<Guid>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : new List<Guid>();
                    var fields = kwargs.ContainsKey("fields") ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(kwargs["fields"], jsonOptions), jsonOptions) : args.Count > 1 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[1], jsonOptions), jsonOptions) : null;
                    JsonElement? context = kwargs.ContainsKey("context") ? JsonSerializer.SerializeToElement(kwargs["context"], jsonOptions) : args.Count > 0 ? JsonSerializer.SerializeToElement(args[0], jsonOptions) : null;
                    JsonElement? domain = kwargs.ContainsKey("domain") ? JsonSerializer.SerializeToElement(kwargs["domain"], jsonOptions) : args.Count > 0 ? JsonSerializer.SerializeToElement(args[0], jsonOptions) : null;
                    SearchCountRequestDto requestDto = new SearchCountRequestDto
                    {
                        //Ids = ids ?? [],
                        //Fields = fields ?? [],
                        Domain = domain,
                        Context = context,
                    };
                    //JsonElement? domain = kwargs.ContainsKey("domain") ? JsonSerializer.SerializeToElement(kwargs["domain"], jsonOptions) : args.Count > 0 ? JsonSerializer.SerializeToElement(args[0], jsonOptions) : null;
                    //var fields = kwargs.ContainsKey("fields") ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(kwargs["fields"], jsonOptions), jsonOptions) : args.Count > 1 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[1], jsonOptions), jsonOptions) : null;
                    return await SearchCountAsync(modelName, requestDto);
                }
            case "create":
                {
                    if (args.Count == 0)
                        throw new UserFriendlyException("Entity is required");

                    JsonElement entity = args[0] switch
                    {
                        JsonElement je => je,
                        null => throw new UserFriendlyException("Entity is required"),
                        _ => JsonSerializer.SerializeToElement(args[0], jsonOptions)
                    };
                    var fields = kwargs.ContainsKey("fields") ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(kwargs["fields"], jsonOptions), jsonOptions) : args.Count > 1 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[1], jsonOptions), jsonOptions) : null;
                    JsonElement? context = kwargs.ContainsKey("context") ? JsonSerializer.SerializeToElement(kwargs["context"], jsonOptions) : args.Count > 0 ? JsonSerializer.SerializeToElement(args[0], jsonOptions) : null;
                    CreateRequestDto requestDto = new CreateRequestDto
                    {
                        Entity = entity,
                        Fields = fields ?? [],
                        Context = context,
                    };
                    return await CreateAsync(modelName, requestDto);
                }
            case "write":
                {
                    if (args.Count <= 2)
                        throw new UserFriendlyException("Missing params");
                    var ids = args.Count > 0 ? JsonSerializer.Deserialize<List<Guid>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : throw new UserFriendlyException("IDs are required");
                    //var entity = args.Count > 1 ? args[1] : throw new UserFriendlyException("Values are required");
                    JsonElement entity = args[1] switch
                    {
                        JsonElement je => je,
                        null => throw new UserFriendlyException("Entity is required"),
                        _ => JsonSerializer.SerializeToElement(args[1], jsonOptions)
                    };
                    var fields = kwargs.ContainsKey("fields") ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(kwargs["fields"], jsonOptions), jsonOptions) : args.Count > 2 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[2], jsonOptions), jsonOptions) : null;
                    JsonElement? context = kwargs.ContainsKey("context") ? JsonSerializer.SerializeToElement(kwargs["context"], jsonOptions) : args.Count > 0 ? JsonSerializer.SerializeToElement(args[0], jsonOptions) : null;

                    UpdateRequestDto requestDto = new UpdateRequestDto
                    {
                        Ids = ids,
                        Entity = entity,
                        Fields = fields ?? [],
                        Context = context,
                    };
                    return await WriteAsync(modelName, requestDto);
                }
            case "unlink":
                {
                    var ids = args.Count > 0 ? JsonSerializer.Deserialize<List<Guid>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : throw new UserFriendlyException("IDs are required");
                    await DeleteAsync(modelName, ids);
                    // foreach (var id in ids)
                    // {
                    //     await _rpcDispatcher.DeleteAsync(modelName, id);
                    // }
                    return true;
                }
            case "copy":
                {
                    var ids = args.Count > 0 ? JsonSerializer.Deserialize<List<Guid>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : throw new UserFriendlyException("IDs are required");

                    //var id = args.Count > 0 ? JsonSerializer.Deserialize<Guid>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : throw new UserFriendlyException("ID is required");
                    //var entity = kwargs.ContainsKey("default") ? kwargs["default"] : args.Count > 1 ? args[1] : null;
                    JsonElement entity = args[1] switch
                    {
                        JsonElement je => je,
                        null => throw new UserFriendlyException("Entity is required"),
                        _ => JsonSerializer.SerializeToElement(args[1], jsonOptions)
                    };
                    var fields = kwargs.ContainsKey("fields") ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(kwargs["fields"], jsonOptions), jsonOptions) : args.Count > 2 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[2], jsonOptions), jsonOptions) : null;
                    JsonElement? context = kwargs.ContainsKey("context") ? JsonSerializer.SerializeToElement(kwargs["context"], jsonOptions) : args.Count > 0 ? JsonSerializer.SerializeToElement(args[0], jsonOptions) : null;

                    CopyRequestDto requestDto = new CopyRequestDto
                    {
                        Ids = ids,
                        DefaultValues = entity,
                        Fields = fields ?? [],
                        Context = context,
                    };
                    return await CopyAsync(modelName, requestDto);
                }
            case "default_get":
                {
                    var fields = kwargs.ContainsKey("fields") ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(kwargs["fields"], jsonOptions), jsonOptions) : args.Count > 0 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : null;
                    JsonElement? context = kwargs.ContainsKey("context") ? JsonSerializer.SerializeToElement(kwargs["context"], jsonOptions) : args.Count > 0 ? JsonSerializer.SerializeToElement(args[0], jsonOptions) : null;

                    DefaultGetRequestDto requestDto = new DefaultGetRequestDto
                    {
                        Fields = fields ?? [],
                        Context = context,
                    };
                    return await DefaultGetAsync(modelName, requestDto);
                }
            case "onchange":
                {
                    var ids = args.Count > 0 ? JsonSerializer.Deserialize<List<Guid>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : throw new UserFriendlyException("IDs are required");

                    var changedFields = args.Count > 0 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : throw new UserFriendlyException("Changed fields are required");
                    var values = args.Count > 1 ? args[1] : throw new UserFriendlyException("Values are required");
                    var fieldInfos = args.Count > 2 ? JsonSerializer.Deserialize<Dictionary<string, object>>(JsonSerializer.Serialize(args[2], jsonOptions), jsonOptions) : new Dictionary<string, object>();
                    JsonElement? context = kwargs.ContainsKey("context") ? JsonSerializer.SerializeToElement(kwargs["context"], jsonOptions) : args.Count > 0 ? JsonSerializer.SerializeToElement(args[0], jsonOptions) : null;

                    OnChangeRequestDto requestDto = new OnChangeRequestDto
                    {
                        Ids = ids,
                        ChangedFields = changedFields,
                        FieldInfos = fieldInfos ?? [],
                        Context = context,
                    };
                    return await OnChangeAsync(modelName, requestDto);
                }
            case "name_create":
                {
                    //var ids = args.Count > 0 ? JsonSerializer.Deserialize<List<Guid>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : new List<Guid>();
                    //var result = await _rpcDispatcher.NameGetAsync(modelName, ids);
                    //return result.Select(x => new object[] { x.Id, x.Name }).ToList();
                    JsonElement? context = kwargs.ContainsKey("context") ? JsonSerializer.SerializeToElement(kwargs["context"], jsonOptions) : args.Count > 0 ? JsonSerializer.SerializeToElement(args[0], jsonOptions) : null;
                    NameCreateRequestDto requestDto = new NameCreateRequestDto
                    {
                        Context = context,
                    };
                    return await NameCreateAsync(modelName, requestDto);
                }
            case "name_get":
                {
                    var ids = args.Count > 0 ? JsonSerializer.Deserialize<List<Guid>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : new List<Guid>();
                    JsonElement? context = kwargs.ContainsKey("context") ? JsonSerializer.SerializeToElement(kwargs["context"], jsonOptions) : args.Count > 0 ? JsonSerializer.SerializeToElement(args[0], jsonOptions) : null;
                    NameGetRequestDto requestDto = new NameGetRequestDto
                    {
                        Ids = ids,
                        Context = context,
                    };
                    var result = await NameGetAsync(modelName, requestDto);
                    return result.Select(x => new object[] { x.Id, x.Name }).ToList();
                }
            case "name_search":
                {
                    var name = kwargs.ContainsKey("name") ? kwargs["name"]?.ToString() : args.Count > 0 ? args[0]?.ToString() : "";
                    JsonElement? domain = kwargs.ContainsKey("domain") ? JsonSerializer.SerializeToElement(kwargs["domain"], jsonOptions) : args.Count > 1 ? JsonSerializer.SerializeToElement(args[1], jsonOptions) : null;
                    var @operator = kwargs.ContainsKey("operator") ? kwargs["operator"]?.ToString() : args.Count > 2 ? args[2]?.ToString() : "ilike";
                    var limit = kwargs.ContainsKey("limit") ? JsonSerializer.Deserialize<int>(JsonSerializer.Serialize(kwargs["limit"], jsonOptions), jsonOptions) : args.Count > 3 ? JsonSerializer.Deserialize<int>(JsonSerializer.Serialize(args[3], jsonOptions), jsonOptions) : 100;
                    JsonElement? context = kwargs.ContainsKey("context") ? JsonSerializer.SerializeToElement(kwargs["context"], jsonOptions) : args.Count > 0 ? JsonSerializer.SerializeToElement(args[0], jsonOptions) : null;

                    NameSearchRequestDto requestDto = new NameSearchRequestDto
                    {
                        Name = name,
                        Domain = domain,
                        Operator = @operator,
                        Limit = limit,
                        Context = context,
                    };
                    var result = await NameSearchAsync(modelName, requestDto);
                    return result.Select(x => new object[] { x.Id, x.Name }).ToList();
                }
            case "fields_get":
                {
                    var fields = kwargs.ContainsKey("fields") ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(kwargs["fields"], jsonOptions), jsonOptions) : args.Count > 0 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : null;
                    var attributes = kwargs.ContainsKey("attributes") ? JsonSerializer.Deserialize<Dictionary<string, List<string>>>(JsonSerializer.Serialize(kwargs["attributes"], jsonOptions), jsonOptions) : args.Count > 1 ? JsonSerializer.Deserialize<Dictionary<string, List<string>>>(JsonSerializer.Serialize(args[1], jsonOptions), jsonOptions) : null;
                    FieldsGetRequestDto requestDto = new FieldsGetRequestDto
                    {
                        Fields = fields,
                        Attributes = attributes,
                    };
                    return await FieldsGetAsync(modelName, requestDto);
                }
            default:
                {
                    throw new UserFriendlyException($"Method {method} not supported");
                }
        }
    }
}

// ──────────────────────────────────────────────
// Custom Exception
// ──────────────────────────────────────────────
public class JsonRpcException : Exception
{
    public int Code { get; }
    public JsonRpcException(int code, string message, Exception? inner = null)
        : base(message, inner)
    {
        Code = code;
    }
}

// ──────────────────────────────────────────────
// Extension: GetGuidSafe
// ──────────────────────────────────────────────
public static class JsonElementExtensions
{
    public static Guid GetGuidSafe(this JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.String &&
            Guid.TryParse(element.GetString(), out var guid))
            return guid;

        throw new JsonRpcException(-32602, "Invalid GUID format");
    }
}