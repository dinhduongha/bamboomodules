using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Bamboo.Core.Application;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace YourNamespace
{
    [Route("api/generic-model")]
    public class GenericModelController : AbpController
    {
        private readonly IGenericModelService _genericModelService;

        public GenericModelController(IGenericModelService genericModelService)
        {
            _genericModelService = genericModelService;
        }

        [HttpPost("{modelName}/read")]
        public async Task<List<object>> ReadAsync(string modelName, [FromBody] ReadRequestDto request)
        {
            return await _genericModelService.ReadAsync(modelName, request.Ids, request.Fields);
        }

        [HttpPost("{modelName}/search")]
        public async Task<List<Guid>> SearchAsync(string modelName, [FromBody] SearchRequestDto request)
        {
            return await _genericModelService.SearchAsync(modelName, request.Domain, request.Offset, request.Limit, request.Order);
        }

        [HttpPost("{modelName}/search_read")]
        public async Task<List<object>> SearchReadAsync(string modelName, [FromBody] SearchReadRequestDto request)
        {
            return await _genericModelService.SearchReadAsync(modelName, request.Domain, request.Fields, request.Offset, request.Limit, request.Order);
        }

        [HttpPost("{modelName}/create")]
        public async Task<object> CreateAsync(string modelName, [FromBody] CreateRequestDto request)
        {
            return await _genericModelService.CreateAsync(modelName, request.Entity, request.Fields);
        }

        [HttpPut("{modelName}/write")]
        public async Task<object> WriteAsync(string modelName, List<Guid> ids, [FromBody] UpdateRequestDto request)
        {
            return await _genericModelService.WriteAsync(modelName, ids, request.Entity, request.Fields);
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
        public async Task<object> FieldsGetAsync(string modelName)
        {
            return await _genericModelService.FieldsGetAsync(modelName);
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
        public async Task<object> CopyAsync(string modelName, Guid id, [FromBody] CopyRequestDto request)
        {
            return await _genericModelService.CopyAsync(modelName, id, request.Fields, request.DefaultValues);
        }

        [HttpPost("{modelName}/default")]
        public async Task<object> DefaultAsync(string modelName, List<string> fields)
        {
            return await _genericModelService.DefaultGetAsync(modelName, fields);
        }
    }

    public class ReadRequestDto
    {
        public List<Guid> Ids { get; set; }
        public List<string> Fields { get; set; }
        public JsonElement? context { get; set; } = null;
    }

    public class SearchRequestDto
    {
        public string Domain { get; set; }
        public long Offset { get; set; } = 0;
        public int Limit { get; set; } = 10;
        public string Order { get; set; } = null;
        public bool Count { get; set; } = false;
    }

    public class SearchReadRequestDto
    {
        public string Domain { get; set; }
        public List<string> Fields { get; set; }
        public long Offset { get; set; } = 0;
        public int Limit { get; set; } = 100;
        public string Order { get; set; } = null;
        bool Count { get; set; } = false;
    }

    public class CreateRequestDto
    {
        public JsonElement Entity { get; set; }
        public List<string> Fields { get; set; }
    }

    public class UpdateRequestDto
    {
        public List<Guid> Ids { get; set; }
        public JsonElement Entity { get; set; }
        public List<string> Fields { get; set; }
    }

    public class UpdateJsonRequestDto
    {
        public List<Guid> Ids { get; set; }
        public string Field { get; set; }
        public string Action { get; set; }
        public JsonElement? Values { get; set; }
    }

    public class NameGetRequestDto
    {
        public List<Guid> Ids { get; set; }
    }

    public class NameSearchRequestDto
    {
        public string Name { get; set; }
        public string Domain { get; set; }
        public string Operator { get; set; } = "ilike";
        public int Limit { get; set; } = 100;
    }

    public class CopyRequestDto
    {
        public List<string> Fields { get; set; }
        public object DefaultValues { get; set; }
    }
}