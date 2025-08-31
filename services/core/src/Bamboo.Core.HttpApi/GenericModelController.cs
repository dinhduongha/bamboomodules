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
    [Route("api/abp/generic-model")]
    public class GenericModelController : AbpController
    {
        private readonly IGenericModelService _genericModelService;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public GenericModelController(IOptions<JsonSerializerOptions> jsonSerializerOptions, IGenericModelService genericModelService)
        {
            _genericModelService = genericModelService;
            _jsonSerializerOptions = jsonSerializerOptions.Value;
        }

        [HttpGet("{modelName}/read/{id}")]
        public async Task<JsonElement> ReadAsync(string modelName, Guid id, List<string> fields = null)
        {
            var results = await _genericModelService.ReadAsync(modelName, [id], fields);
            JsonElement jsonElement = results
            .Select(item => JsonSerializer.SerializeToElement(item, _jsonSerializerOptions))
            .FirstOrDefault();
            return jsonElement;
        }

        [HttpPost("{modelName}/read")]
        public async Task<List<JsonElement>> ReadAsync(string modelName, [FromBody] ReadRequestDto request)
        {
            var results = await _genericModelService.ReadAsync(modelName, request.Ids, request.Fields);
            List<JsonElement> jsonElementList = results
            .Select(item => JsonSerializer.SerializeToElement(item, _jsonSerializerOptions))
            .ToList();
            return jsonElementList;
        }

        [HttpPost("{modelName}/search")]
        public async Task<List<Guid>> SearchAsync(string modelName, [FromBody] SearchRequestDto request)
        {
            return await _genericModelService.SearchAsync(modelName, request.Domain, request.Offset, request.Limit, request.Order);
        }

        [HttpPost("{modelName}/search_read")]
        public async Task<List<JsonElement>> SearchReadAsync(string modelName, [FromBody] SearchReadRequestDto request)
        {
            var results = await _genericModelService.SearchReadAsync(modelName, request.Domain, request.Fields, request.Offset, request.Limit, request.Order);
            List<JsonElement> jsonElementList = results
                .Select(item => JsonSerializer.SerializeToElement(item, _jsonSerializerOptions))
                .ToList();
                return jsonElementList;
        }

        [HttpPost("{modelName}/create")]
        public async Task<JsonElement> CreateAsync(string modelName, [FromBody] CreateRequestDto request)
        {
            var result = await _genericModelService.CreateAsync(modelName, request.Entity, request.Fields);
            return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
        }

        [HttpPut("{modelName}/update/{id}")]
        public async Task<JsonElement> UpdateAsync(string modelName, Guid id, [FromBody] UpdateRequestDto request)
        {
            var results = await _genericModelService.WriteAsync(modelName, [id], request.Entity, request.Fields);
            if (results != null && results.Count > 0)
            { 
                return JsonSerializer.SerializeToElement(results[0], _jsonSerializerOptions);
            }
            return default;
        }

        [HttpPut("{modelName}/write")]
        public async Task<List<JsonElement>> WriteAsync(string modelName, List<Guid> ids, [FromBody] UpdateRequestDto request)
        {
            var results = await _genericModelService.WriteAsync(modelName, ids, request.Entity, request.Fields);
            List<JsonElement> jsonElementList = results
                .Select(item => JsonSerializer.SerializeToElement(item, _jsonSerializerOptions))
                .ToList();
            return jsonElementList;
        }

        [HttpDelete("{modelName}/unlink")]
        public async Task DeleteAsync(string modelName, List<Guid> ids)
        {
            await _genericModelService.DeleteAsync(modelName, ids);
        }

        [HttpPost("{modelName}/update_json")]
        public async Task<object> UpdateJsonAsync(string modelName, [FromBody] UpdateJsonRequestDto request)
        {
            return null;
            //return await _genericModelService.UpdateJsonAsync(modelName, request.Entity, request.Fields);
        }

        [HttpPost("{modelName}/fields_get")]
        public async Task<JsonElement> FieldsGetAsync(string modelName)
        {
            var result = await _genericModelService.FieldsGetAsync(modelName);
            return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
        }

        [HttpPost("{modelName}/name_get")]
        public async Task<List<(Guid Id, string Name)>> NameGetAsync(string modelName, [FromBody] NameGetRequestDto request)
        {
            return await _genericModelService.NameGetAsync(modelName, request.Ids);
        }

        [HttpPost("{modelName}/name_search")]
        public async Task<List<(Guid Id, string Name)>> NameSearchAsync(string modelName, [FromBody] NameSearchRequestDto request)
        {
            return await _genericModelService.NameSearchAsync(modelName, request.Name, request.Domain, request.Operator, request.Limit);
        }

        [HttpPost("{modelName}/copy/{id}")]
        public async Task<JsonElement> CopyAsync(string modelName, Guid id, [FromBody] CopyRequestDto request)
        {
            var result = await _genericModelService.CopyAsync(modelName, id, request.Fields, request.DefaultValues);
            return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
        }

        [HttpPost("{modelName}/default")]
        public async Task<JsonElement> DefaultAsync(string modelName, List<string> fields)
        {
            var result = await _genericModelService.DefaultGetAsync(modelName, fields);
            return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
        }

        [HttpPost("{modelName}/call")]
        public async Task<JsonElement> CallServiceAsync(string modelName, string method, [FromBody] List<object> args)
        {
            var result = await _genericModelService.CallServiceAsync(modelName, method, args);
            return JsonSerializer.SerializeToElement(result, _jsonSerializerOptions);
        }
    }

}