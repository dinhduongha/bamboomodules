using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Json;
using Volo.Abp.Json.SystemTextJson;
using Bamboo.Core.Application;
using Bamboo.Core.Application.Dtos;
using Bamboo.Core.Application.Contracts.DTOs;
using Volo.Abp.Application.Dtos;
namespace Bamboo.Core.HttpApi
{
    [Route("api/v1/generic")]
    ///web/dataset/call_kw
    public class GenericModelController : AbpController
    {
        private readonly IRpcDispatcherAppService _rpcDispatcher;
        static readonly JsonSerializerOptions _jsonSerializerOptions =
            new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.KebabCaseLower,
                DictionaryKeyPolicy = JsonNamingPolicy.SnakeCaseLower, // nếu serialize Dictionary
                PropertyNameCaseInsensitive = true // thường bật cho deserialize
            };

        //private readonly JsonSerializerOptions _jsonSerializerOptions;
        public GenericModelController(IOptions<JsonSerializerOptions> jsonSerializerOptions, IRpcDispatcherAppService rpcDispatcher)
        {
            _rpcDispatcher = rpcDispatcher;
            //_jsonSerializerOptions = jsonSerializerOptions.Value;
        }

        [HttpGet("{model}")]
        public async Task<JsonElement> CrudGetListAsync(string model, PagedAndSortedResultRequestDto input)
        {
            SearchReadRequestDto request = new SearchReadRequestDto()
            {
                Offset = input.SkipCount,
                Limit = input.MaxResultCount,
                Order = input.Sorting,
                //Ids = [id],
                //Fields = fields,
            };
            var results = await _rpcDispatcher.SearchReadAsync(model, request);
            JsonElement jsonElement = results
            .Select(item => JsonSerializer.SerializeToElement(item, _jsonSerializerOptions).ToCamelCase())
            .FirstOrDefault();
            return jsonElement;
        }

        [HttpPost("{model}")]
        public async Task<JsonElement> CrudCreateAsync(string model, CreateRequestDto input)
        {
            var results = await _rpcDispatcher.CreateAsync(model, input);
            return results;
        }

        [HttpGet("{model}/{id}")]
        public async Task<JsonElement> CrudReadByIdAsync(string model, Guid id)
        {
            ReadRequestDto request = new ReadRequestDto()
            {
                Ids = [id],
            };
            var results = await _rpcDispatcher.ReadAsync(model, request);
            JsonElement jsonElement = results
                .Select(item => JsonSerializer.SerializeToElement(item, _jsonSerializerOptions).ToCamelCase())
                .FirstOrDefault();
            return jsonElement;
        }

        [HttpPut("{model}/{id}")]
        public async Task<JsonElement> CrudUpdateByIdAsync(string model, Guid id, UpdateRequestDto input)
        {
            input.Ids = [id];

            var results = await _rpcDispatcher.WriteAsync(model, input);
            JsonElement jsonElement = results
                .Select(item => JsonSerializer.SerializeToElement(item, _jsonSerializerOptions).ToCamelCase())
                .FirstOrDefault();
            return jsonElement;
        }

        [HttpDelete("{model}/{id}")]
        public async Task CrudDeleteByIdAsync(string model, Guid id)
        {
            await _rpcDispatcher.DeleteAsync(model, [id]);
        }

        [HttpGet("{model}/read/{id}")]
        public async Task<JsonElement> ReadAsync(string model, Guid id, List<string> fields = null)
        {
            ReadRequestDto request = new ReadRequestDto()
            {
                Ids = [id],
                Fields = fields,
            };
            var results = await _rpcDispatcher.ReadAsync(model, request);
            JsonElement jsonElement = results
            .Select(item => JsonSerializer.SerializeToElement(item, _jsonSerializerOptions).ToCamelCase())
            .FirstOrDefault();
            return jsonElement;
        }

        #region Common
        [HttpPost("{model}/read")]
        public async Task<List<JsonElement>> ReadAsync(string model, [FromBody] ReadRequestDto request)
        {
            var results = await _rpcDispatcher.ReadAsync(model, request);
            List<JsonElement> jsonElementList = results
            .Select(item => JsonSerializer.SerializeToElement(item, _jsonSerializerOptions).ToCamelCase())
            .ToList();
            return jsonElementList;
        }

        [HttpPost("{model}/search")]
        public async Task<List<Guid>> SearchAsync(string model, [FromBody] SearchRequestDto request)
        {
            return await _rpcDispatcher.SearchAsync(model, request);
        }

        [HttpPost("{model}/search_read")]
        public async Task<List<JsonElement>> SearchReadAsync(string model, [FromBody] SearchReadRequestDto request)
        {
            var results = await _rpcDispatcher.SearchReadAsync(model, request);
            List<JsonElement> jsonElementList = results
                .Select(item => JsonSerializer.SerializeToElement(item).ToCamelCase())
                .ToList();
            return jsonElementList;
        }

        [HttpPost("{model}/create")]
        public async Task<JsonElement> CreateAsync(string model, [FromBody] CreateRequestDto request)
        {
            var result = await _rpcDispatcher.CreateAsync(model, request);
            return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
        }

        [HttpPut("{model}/update/{id}")]
        public async Task<JsonElement> UpdateAsync(string model, Guid id, [FromBody] UpdateRequestDto request)
        {
            UpdateRequestDto requestWithIds = new UpdateRequestDto()
            {
                Ids = [id],
                Entity = request.Entity,
                Fields = request.Fields,
                Context = request.Context,
            };
            var results = await _rpcDispatcher.WriteAsync(model, requestWithIds);
            if (results != null && results.Count > 0)
            {
                return JsonSerializer.SerializeToElement(results[0], _jsonSerializerOptions);
            }
            return default;
        }

        [HttpPut("{model}/write")]
        public async Task<List<JsonElement>> WriteAsync(string model, [FromBody] UpdateRequestDto request)
        {
            var results = await _rpcDispatcher.WriteAsync(model, request);
            List<JsonElement> jsonElementList = results
                .Select(item => JsonSerializer.SerializeToElement(item, _jsonSerializerOptions))
                .ToList();
            return jsonElementList;
        }

        [HttpDelete("{model}/unlink")]
        public async Task DeleteAsync(string model, List<Guid> ids)
        {
            await _rpcDispatcher.DeleteAsync(model, ids);
        }

        [HttpPost("{model}/update_json")]
        public async Task<object> UpdateJsonAsync(string model, [FromBody] UpdateJsonRequestDto request)
        {
            return await _rpcDispatcher.UpdateJsonAsync(model, request);
        }

        [HttpPost("{model}/copy/{id}")]
        public async Task<JsonElement> CopyAsync(string model, [FromBody] CopyRequestDto request)
        {
            var result = await _rpcDispatcher.CopyAsync(model, request);
            return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
        }
        [HttpPost("{model}/default_get")]
        public async Task<JsonElement> DefaultAsync(string model, DefaultGetRequestDto request)
        {
            var result = await _rpcDispatcher.DefaultGetAsync(model, request);
            return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
        }

        [HttpPost("{model}/fields_get")]
        public async Task<JsonElement> FieldsGetAsync(string model, FieldsGetRequestDto input)
        {
            var result = await _rpcDispatcher.FieldsGetAsync(model, input);
            return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
        }

        [HttpPost("{model}/name_get")]
        public async Task<List<(Guid Id, string Name)>> NameGetAsync(string model, [FromBody] NameGetRequestDto request)
        {
            return await _rpcDispatcher.NameGetAsync(model, request);
        }

        [HttpPost("{model}/name_search")]
        public async Task<List<(Guid Id, string Name)>> NameSearchAsync(string model, [FromBody] NameSearchRequestDto request)
        {
            return await _rpcDispatcher.NameSearchAsync(model, request);
        }

        [HttpPost("{model}/name_create")]
        public async Task<JsonElement> NameCreateAsync(string model, [FromBody] NameCreateRequestDto request)
        {
            return await _rpcDispatcher.NameCreateAsync(model, request);
        }

        [HttpPost("{model}/call/{method}")]
        public async Task<JsonElement> CallServiceAsync(string model, string method, [FromBody] List<object> args)
        {
            var result = await _rpcDispatcher.CallServiceAsync(model, method, args);
            return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
        }
    }
        #endregion
}