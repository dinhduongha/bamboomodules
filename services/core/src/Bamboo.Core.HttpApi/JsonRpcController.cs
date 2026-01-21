using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

using Bamboo.Core;
using Bamboo.Core.Application;

namespace Bamboo.Core.HttpApi
{
    [Route("/api/jsonrpc")]
    public class JsonRpcController : AbpController
    {
        private readonly IGenericModelService _genericModelService;

        public JsonRpcController(IGenericModelService genericModelService)
        {
            _genericModelService = genericModelService;
        }

        [HttpPost]
        [Route("/json/2/{model}/{method}")]
        public async Task<object> HandleJsonRpcV2Async(string model, string method, [FromBody] JsonV2Params request)
        {

            try
            {
                var result = await ProcessV2RequestAsync(model, method, request);
                return new JsonRpcResponse
                {
                    Jsonrpc = "2.0",
                    //Id = request.Id,
                    Result = result
                };
            }
            catch (UserFriendlyException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<object> HandleJsonRpcAsync([FromBody] JsonRpcRequest request)
        {
            if (request.Jsonrpc != "2.0" || request.Method != "call")
                return CreateErrorResponse(request.Id, -32600, "Invalid JSON-RPC version or method. Expected 'call'.");

            try
            {
                var result = await ProcessRequestAsync(request);
                return new JsonRpcResponse
                {
                    Jsonrpc = "2.0",
                    Id = request.Id,
                    Result = result
                };
            }
            catch (UserFriendlyException ex)
            {
                return CreateErrorResponse(request.Id, -32000, ex.Message);
            }
            catch (Exception ex)
            {
                return CreateErrorResponse(request.Id, -32603, "Internal error: " + ex.Message);
            }
        }

        private async Task<object> ProcessRequestAsync(JsonRpcRequest request)
        {
            var modelName = request.Params?.Model ?? throw new UserFriendlyException("Model is required");
            var method = request.Params?.Method ?? throw new UserFriendlyException("Method is required");
            var args = request.Params?.Args ?? new List<object>();
            var kwargs = request.Params?.Kwargs ?? new Dictionary<string, object>();

            var jsonOptions = new JsonSerializerOptions
            {
                Converters = { new ObjectToInferredTypeConverter() }
            };

            switch (method)
            {
                case "search":
                    {
                        JsonElement? domain = kwargs.ContainsKey("domain") ? JsonSerializer.SerializeToElement(kwargs["domain"], jsonOptions) : args.Count > 0 ? JsonSerializer.SerializeToElement(args[0], jsonOptions) : null;
                        return await _genericModelService.SearchAsync(modelName, domain);
                    }
                case "read":
                    {
                        var ids = args.Count > 0 ? JsonSerializer.Deserialize<List<Guid>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : new List<Guid>();
                        var fields = kwargs.ContainsKey("fields") ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(kwargs["fields"], jsonOptions), jsonOptions) : args.Count > 1 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[1], jsonOptions), jsonOptions) : null;
                        return await _genericModelService.ReadAsync(modelName, ids, fields);
                    }
                case "search_read":
                    {
                        JsonElement? domain = kwargs.ContainsKey("domain") ? JsonSerializer.SerializeToElement(kwargs["domain"], jsonOptions) : args.Count > 0 ? JsonSerializer.SerializeToElement(args[0], jsonOptions) : null;
                        var fields = kwargs.ContainsKey("fields") ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(kwargs["fields"], jsonOptions), jsonOptions) : args.Count > 1 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[1], jsonOptions), jsonOptions) : null;
                        return await _genericModelService.SearchReadAsync(modelName, domain, fields);
                    }
                case "create":
                    {
                        var entity = args.Count > 0 ? args[0] : throw new UserFriendlyException("Entity is required");
                        var fields = kwargs.ContainsKey("fields") ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(kwargs["fields"], jsonOptions), jsonOptions) : args.Count > 1 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[1], jsonOptions), jsonOptions) : null;
                        return await _genericModelService.CreateAsync(modelName, entity, fields);
                    }
                case "write":
                    {
                        var ids = args.Count > 0 ? JsonSerializer.Deserialize<List<Guid>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : throw new UserFriendlyException("IDs are required");
                        var values = args.Count > 1 ? args[1] : throw new UserFriendlyException("Values are required");
                        var fields = kwargs.ContainsKey("fields") ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(kwargs["fields"], jsonOptions), jsonOptions) : args.Count > 2 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[2], jsonOptions), jsonOptions) : null;
                        return await _genericModelService.WriteAsync(modelName, ids, values, fields);
                    }
                case "unlink":
                    {
                        var ids = args.Count > 0 ? JsonSerializer.Deserialize<List<Guid>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : throw new UserFriendlyException("IDs are required");
                        await _genericModelService.DeleteAsync(modelName, ids);
                        // foreach (var id in ids)
                        // {
                        //     await _genericModelService.DeleteAsync(modelName, id);
                        // }
                        return true;
                    }
                case "name_get":
                    {
                        var ids = args.Count > 0 ? JsonSerializer.Deserialize<List<Guid>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : new List<Guid>();
                        var result = await _genericModelService.NameGetAsync(modelName, ids);
                        return result.Select(x => new object[] { x.Id, x.Name }).ToList();
                    }
                case "name_search":
                    {
                        var name = kwargs.ContainsKey("name") ? kwargs["name"]?.ToString() : args.Count > 0 ? args[0]?.ToString() : "";
                        JsonElement? domain = kwargs.ContainsKey("domain") ? JsonSerializer.SerializeToElement(kwargs["domain"], jsonOptions) : args.Count > 1 ? JsonSerializer.SerializeToElement(args[1], jsonOptions) : null;
                        var @operator = kwargs.ContainsKey("operator") ? kwargs["operator"]?.ToString() : args.Count > 2 ? args[2]?.ToString() : "ilike";
                        var limit = kwargs.ContainsKey("limit") ? JsonSerializer.Deserialize<int>(JsonSerializer.Serialize(kwargs["limit"], jsonOptions), jsonOptions) : args.Count > 3 ? JsonSerializer.Deserialize<int>(JsonSerializer.Serialize(args[3], jsonOptions), jsonOptions) : 100;
                        var result = await _genericModelService.NameSearchAsync(modelName, name, domain, @operator, limit);
                        return result.Select(x => new object[] { x.Id, x.Name }).ToList();
                    }
                case "copy":
                    {
                        var id = args.Count > 0 ? JsonSerializer.Deserialize<Guid>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : throw new UserFriendlyException("ID is required");
                        var defaultValues = kwargs.ContainsKey("default") ? kwargs["default"] : args.Count > 1 ? args[1] : null;
                        var fields = kwargs.ContainsKey("fields") ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(kwargs["fields"], jsonOptions), jsonOptions) : args.Count > 2 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[2], jsonOptions), jsonOptions) : null;
                        return await _genericModelService.CopyAsync(modelName, id, fields, defaultValues);
                    }
                case "onchange":
                    {
                        var changedFields = args.Count > 0 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : throw new UserFriendlyException("Changed fields are required");
                        var values = args.Count > 1 ? args[1] : throw new UserFriendlyException("Values are required");
                        var fieldInfo = args.Count > 2 ? JsonSerializer.Deserialize<Dictionary<string, object>>(JsonSerializer.Serialize(args[2], jsonOptions), jsonOptions) : new Dictionary<string, object>();
                        return await _genericModelService.OnchangeAsync(modelName, changedFields, values, fieldInfo);
                    }
                case "default_get":
                    {
                        var fields = kwargs.ContainsKey("fields") ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(kwargs["fields"], jsonOptions), jsonOptions) : args.Count > 0 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : null;
                        return await _genericModelService.DefaultGetAsync(modelName, fields);
                    }
                case "fields_get":
                    {
                        var fields = kwargs.ContainsKey("fields") ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(kwargs["fields"], jsonOptions), jsonOptions) : args.Count > 0 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : null;
                        var attributes = kwargs.ContainsKey("attributes") ? JsonSerializer.Deserialize<Dictionary<string, List<string>>>(JsonSerializer.Serialize(kwargs["attributes"], jsonOptions), jsonOptions) : args.Count > 1 ? JsonSerializer.Deserialize<Dictionary<string, List<string>>>(JsonSerializer.Serialize(args[1], jsonOptions), jsonOptions) : null;
                        return await _genericModelService.FieldsGetAsync(modelName, fields, attributes);
                    }
                default:
                    throw new UserFriendlyException($"Method {method} not supported");
            }
        }

        private async Task<object> ProcessV2RequestAsync(string modelName, string method, JsonV2Params request)
        {
            var args = request.Args ?? new List<object>();
            var kwargs = request.Kwargs ?? new Dictionary<string, object>();

            var jsonOptions = new JsonSerializerOptions
            {
                Converters = { new ObjectToInferredTypeConverter() }
            };

            switch (method)
            {
                case "search":
                    {
                        JsonElement? domain = kwargs.ContainsKey("domain") ? JsonSerializer.SerializeToElement(kwargs["domain"], jsonOptions) : args.Count > 0 ? JsonSerializer.SerializeToElement(args[0], jsonOptions) : null;
                        return await _genericModelService.SearchAsync(modelName, domain);
                    }
                case "read":
                    {
                        var ids = args.Count > 0 ? JsonSerializer.Deserialize<List<Guid>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : new List<Guid>();
                        var fields = kwargs.ContainsKey("fields") ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(kwargs["fields"], jsonOptions), jsonOptions) : args.Count > 1 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[1], jsonOptions), jsonOptions) : null;
                        return await _genericModelService.ReadAsync(modelName, ids, fields);
                    }
                case "search_read":
                    {
                        JsonElement? domain = kwargs.ContainsKey("domain") ? JsonSerializer.SerializeToElement(kwargs["domain"], jsonOptions) : args.Count > 0 ? JsonSerializer.SerializeToElement(args[0], jsonOptions) : null;
                        var fields = kwargs.ContainsKey("fields") ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(kwargs["fields"], jsonOptions), jsonOptions) : args.Count > 1 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[1], jsonOptions), jsonOptions) : null;
                        return await _genericModelService.SearchReadAsync(modelName, domain, fields);
                    }
                case "create":
                    {
                        var entity = args.Count > 0 ? args[0] : throw new UserFriendlyException("Entity is required");
                        var fields = kwargs.ContainsKey("fields") ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(kwargs["fields"], jsonOptions), jsonOptions) : args.Count > 1 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[1], jsonOptions), jsonOptions) : null;
                        return await _genericModelService.CreateAsync(modelName, entity, fields);
                    }
                case "write":
                    {
                        var ids = args.Count > 0 ? JsonSerializer.Deserialize<List<Guid>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : throw new UserFriendlyException("IDs are required");
                        var values = args.Count > 1 ? args[1] : throw new UserFriendlyException("Values are required");
                        var fields = kwargs.ContainsKey("fields") ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(kwargs["fields"], jsonOptions), jsonOptions) : args.Count > 2 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[2], jsonOptions), jsonOptions) : null;
                        return await _genericModelService.WriteAsync(modelName, ids, values, fields);
                    }
                case "unlink":
                    {
                        var ids = args.Count > 0 ? JsonSerializer.Deserialize<List<Guid>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : throw new UserFriendlyException("IDs are required");
                        await _genericModelService.DeleteAsync(modelName, ids);
                        // foreach (var id in ids)
                        // {
                        //     await _genericModelService.DeleteAsync(modelName, id);
                        // }
                        return true;
                    }
                case "name_get":
                    {
                        var ids = args.Count > 0 ? JsonSerializer.Deserialize<List<Guid>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : new List<Guid>();
                        var result = await _genericModelService.NameGetAsync(modelName, ids);
                        return result.Select(x => new object[] { x.Id, x.Name }).ToList();
                    }
                case "name_search":
                    {
                        var name = kwargs.ContainsKey("name") ? kwargs["name"]?.ToString() : args.Count > 0 ? args[0]?.ToString() : "";
                        JsonElement? domain = kwargs.ContainsKey("domain") ? JsonSerializer.SerializeToElement(kwargs["domain"], jsonOptions) : args.Count > 1 ? JsonSerializer.SerializeToElement(args[1], jsonOptions) : null;
                        var @operator = kwargs.ContainsKey("operator") ? kwargs["operator"]?.ToString() : args.Count > 2 ? args[2]?.ToString() : "ilike";
                        var limit = kwargs.ContainsKey("limit") ? JsonSerializer.Deserialize<int>(JsonSerializer.Serialize(kwargs["limit"], jsonOptions), jsonOptions) : args.Count > 3 ? JsonSerializer.Deserialize<int>(JsonSerializer.Serialize(args[3], jsonOptions), jsonOptions) : 100;
                        var result = await _genericModelService.NameSearchAsync(modelName, name, domain, @operator, limit);
                        return result.Select(x => new object[] { x.Id, x.Name }).ToList();
                    }
                case "copy":
                    {
                        var id = args.Count > 0 ? JsonSerializer.Deserialize<Guid>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : throw new UserFriendlyException("ID is required");
                        var defaultValues = kwargs.ContainsKey("default") ? kwargs["default"] : args.Count > 1 ? args[1] : null;
                        var fields = kwargs.ContainsKey("fields") ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(kwargs["fields"], jsonOptions), jsonOptions) : args.Count > 2 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[2], jsonOptions), jsonOptions) : null;
                        return await _genericModelService.CopyAsync(modelName, id, fields, defaultValues);
                    }
                case "onchange":
                    {
                        var changedFields = args.Count > 0 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : throw new UserFriendlyException("Changed fields are required");
                        var values = args.Count > 1 ? args[1] : throw new UserFriendlyException("Values are required");
                        var fieldInfo = args.Count > 2 ? JsonSerializer.Deserialize<Dictionary<string, object>>(JsonSerializer.Serialize(args[2], jsonOptions), jsonOptions) : new Dictionary<string, object>();
                        return await _genericModelService.OnchangeAsync(modelName, changedFields, values, fieldInfo);
                    }
                case "default_get":
                    {
                        var fields = kwargs.ContainsKey("fields") ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(kwargs["fields"], jsonOptions), jsonOptions) : args.Count > 0 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : null;
                        return await _genericModelService.DefaultGetAsync(modelName, fields);
                    }
                case "fields_get":
                    {
                        var fields = kwargs.ContainsKey("fields") ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(kwargs["fields"], jsonOptions), jsonOptions) : args.Count > 0 ? JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(args[0], jsonOptions), jsonOptions) : null;
                        var attributes = kwargs.ContainsKey("attributes") ? JsonSerializer.Deserialize<Dictionary<string, List<string>>>(JsonSerializer.Serialize(kwargs["attributes"], jsonOptions), jsonOptions) : args.Count > 1 ? JsonSerializer.Deserialize<Dictionary<string, List<string>>>(JsonSerializer.Serialize(args[1], jsonOptions), jsonOptions) : null;
                        return await _genericModelService.FieldsGetAsync(modelName, fields, attributes);
                    }
                default:
                    throw new UserFriendlyException($"Method {method} not supported");
            }
        }

        private object CreateErrorResponse(object id, int code, string message)
        {
            return new JsonRpcResponse
            {
                Jsonrpc = "2.0",
                Id = id,
                Error = new JsonRpcError
                {
                    Code = code,
                    Message = message
                }
            };
        }
    }

    public class JsonRpcRequest
    {
        [JsonPropertyName("jsonrpc")]
        public string? Jsonrpc { get; set; }

        [JsonPropertyName("method")]
        public string? Method { get; set; }

        [JsonPropertyName("params")]
        public JsonRpcParams? Params { get; set; }
        [JsonPropertyName("id")]
        public object? Id { get; set; }
    }

    public class JsonRpcParams
    {
        [JsonPropertyName("model")]
        public string? Model { get; set; }

        [JsonPropertyName("method")]
        public string? Method { get; set; }

        [JsonPropertyName("args")]
        public List<object>? Args { get; set; }

        [JsonPropertyName("kwargs")]
        public Dictionary<string, object>? Kwargs { get; set; }
    }

    public class JsonRpcResponse
    {
        [JsonPropertyName("jsonrpc")]
        public string? Jsonrpc { get; set; }

        [JsonPropertyName("id")]
        public object? Id { get; set; }

        [JsonPropertyName("result")]
        public object? Result { get; set; }

        [JsonPropertyName("error")]
        public JsonRpcError? Error { get; set; }
    }

    public class JsonRpcError
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("data")]
        public object? Data { get; set; }
    }

    public class JsonV2Params
    {

        [JsonPropertyName("ids")]
        public List<Guid>? Ids { get; set; }

        [JsonPropertyName("context")]
        public JsonElement? Context { get; set; }

        [JsonPropertyName("domain")]
        public JsonElement? Domain { get; set; }

        [JsonPropertyName("fields")]
        public List<string>? Fields { get; set; }


        [JsonPropertyName("args")]
        public List<object> Args { get; set; }

        [JsonPropertyName("kwargs")]
        public Dictionary<string, object> Kwargs { get; set; }
    }
}