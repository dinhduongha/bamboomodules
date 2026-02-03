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
using Bamboo.Core.Application.Dtos;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.HttpApi
{
    [Route("/api/jsonrpc")]
    public class JsonRpcController : AbpController
    {
        private readonly IRpcDispatcherAppService _rpcDispatcher;

        public JsonRpcController(IRpcDispatcherAppService rpcDispatcher)
        {
            _rpcDispatcher = rpcDispatcher;
        }

        [HttpPost]
        [Route("/json/2/{model}/{method}")]
        public async Task<object> HandleJsonRpcV2Async(string model, string method, [FromBody] JsonElement request)
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
        [Route("{model}/{method}")]
        public async Task<object> HandleJsonRpcAsync(string model, string method, [FromBody] JsonRpcRequest request)
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
        [HttpPost]
        public async Task<object> HandleJsonRpcModelAsync([FromBody] JsonRpcRequest request)
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
            var model = request.Params?.Model ?? throw new UserFriendlyException("Model is required");
            var method = request.Params?.Method ?? throw new UserFriendlyException("Method is required");
            var args = request.Params?.Args ?? new List<object>();
            var kwargs = request.Params?.Kwargs ?? new Dictionary<string, object>();
            return await _rpcDispatcher.ProcessRequestAsync(model, method, args, kwargs, null);
            //return await _rpcDispatcher.DispatchLegacyJsonRpcAsync(request.Params);
        }

        private async Task<object> ProcessV2RequestAsync(string model, string method, JsonElement body)
        {
            //var args = request.Args ?? new List<object>();
            //var kwargs = request.Kwargs ?? new Dictionary<string, object>();
            //return await _rpcDispatcher.ProcessRequestAsync(modelName, method, args, kwargs, null);
            return await _rpcDispatcher.DispatchJson2Async(model, method, body);
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


}