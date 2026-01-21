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
namespace Bamboo.Core.HttpApi
{
    [Route("api/v1/generic")]
    ///web/dataset/call_kw
    public class GenericModelController : AbpController
    {
        private readonly IGenericModelService _genericModelService;
        static readonly JsonSerializerOptions _jsonSerializerOptions =
            new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.KebabCaseLower,
                DictionaryKeyPolicy = JsonNamingPolicy.SnakeCaseLower, // nếu serialize Dictionary
                PropertyNameCaseInsensitive = true // thường bật cho deserialize
            };

        //private readonly JsonSerializerOptions _jsonSerializerOptions;
        public GenericModelController(IOptions<JsonSerializerOptions> jsonSerializerOptions, IGenericModelService genericModelService)
        {
            _genericModelService = genericModelService;
            //_jsonSerializerOptions = jsonSerializerOptions.Value;
        }

        [HttpGet("{model}/read/{id}")]
        public async Task<JsonElement> ReadAsync(string model, Guid id, List<string> fields = null)
        {
            var results = await _genericModelService.ReadAsync(model, [id], fields);
            JsonElement jsonElement = results
            .Select(item => JsonSerializer.SerializeToElement(item, _jsonSerializerOptions).ToCamelCase())
            .FirstOrDefault();
            return jsonElement;
        }

        [HttpPost("{model}/read")]
        public async Task<List<JsonElement>> ReadAsync(string model, [FromBody] ReadRequestDto request)
        {
            var results = await _genericModelService.ReadAsync(model, request.Ids, request.Fields);
            List<JsonElement> jsonElementList = results
            .Select(item => JsonSerializer.SerializeToElement(item, _jsonSerializerOptions).ToCamelCase())
            .ToList();
            return jsonElementList;
        }

        [HttpPost("{model}/search")]
        public async Task<List<Guid>> SearchAsync(string model, [FromBody] SearchRequestDto request)
        {
            return await _genericModelService.SearchAsync(model, request.Domain, request.Offset, request.Limit, request.Order);
        }

        [HttpPost("{model}/search_read")]
        public async Task<List<JsonElement>> SearchReadAsync(string model, [FromBody] SearchReadRequestDto request)
        {
            var results = await _genericModelService.SearchReadAsync(model, request.Domain, request.Fields, request.Offset, request.Limit, request.Order);
            List<JsonElement> jsonElementList = results
                .Select(item => JsonSerializer.SerializeToElement(item).ToCamelCase())
                .ToList();
            return jsonElementList;
        }

        [HttpPost("{model}/create")]
        public async Task<JsonElement> CreateAsync(string model, [FromBody] CreateRequestDto request)
        {
            var result = await _genericModelService.CreateAsync(model, request.Entity, request.Fields);
            return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
        }

        [HttpPut("{model}/update/{id}")]
        public async Task<JsonElement> UpdateAsync(string model, Guid id, [FromBody] UpdateRequestDto request)
        {
            var results = await _genericModelService.WriteAsync(model, [id], request.Entity, request.Fields);
            if (results != null && results.Count > 0)
            {
                return JsonSerializer.SerializeToElement(results[0], _jsonSerializerOptions);
            }
            return default;
        }

        [HttpPut("{model}/write")]
        public async Task<List<JsonElement>> WriteAsync(string model, List<Guid> ids, [FromBody] UpdateRequestDto request)
        {
            var results = await _genericModelService.WriteAsync(model, ids, request.Entity, request.Fields);
            List<JsonElement> jsonElementList = results
                .Select(item => JsonSerializer.SerializeToElement(item, _jsonSerializerOptions))
                .ToList();
            return jsonElementList;
        }

        [HttpDelete("{model}/unlink")]
        public async Task DeleteAsync(string model, List<Guid> ids)
        {
            await _genericModelService.DeleteAsync(model, ids);
        }

        [HttpPost("{model}/update_json")]
        public async Task<object> UpdateJsonAsync(string model, [FromBody] UpdateJsonRequestDto request)
        {
            return null;
            //return await _genericModelService.UpdateJsonAsync(model, request.Entity, request.Fields);
        }

        [HttpPost("{model}/fields_get")]
        public async Task<JsonElement> FieldsGetAsync(string model)
        {
            var result = await _genericModelService.FieldsGetAsync(model);
            return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
        }

        [HttpPost("{model}/name_get")]
        public async Task<List<(Guid Id, string Name)>> NameGetAsync(string model, [FromBody] NameGetRequestDto request)
        {
            return await _genericModelService.NameGetAsync(model, request.Ids);
        }

        [HttpPost("{model}/name_search")]
        public async Task<List<(Guid Id, string Name)>> NameSearchAsync(string model, [FromBody] NameSearchRequestDto request)
        {
            return await _genericModelService.NameSearchAsync(model, request.Name, request.Domain, request.Operator, request.Limit);
        }

        [HttpPost("{model}/copy/{id}")]
        public async Task<JsonElement> CopyAsync(string model, Guid id, [FromBody] CopyRequestDto request)
        {
            var result = await _genericModelService.CopyAsync(model, id, request.Fields, request.DefaultValues);
            return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
        }

        [HttpPost("{model}/default")]
        public async Task<JsonElement> DefaultAsync(string model, List<string> fields)
        {
            var result = await _genericModelService.DefaultGetAsync(model, fields);
            return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
        }

        [HttpPost("{model}/call/{method}")]
        public async Task<JsonElement> CallServiceAsync(string model, string method, [FromBody] List<object> args)
        {
            var result = await _genericModelService.CallServiceAsync(model, method, args);
            return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
        }
    }

}