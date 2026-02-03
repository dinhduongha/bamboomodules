using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Services;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Domain.Entities;

namespace YourProject.HttpApi.Controllers.Commons // Thay YourProject bằng namespace của bạn
{
    public abstract class GenericController<TEntity, TAppService> : AbpControllerBase
        where TEntity : class, IEntity<Guid>
        where TAppService : IGenericAppService<TEntity>
    {
        protected readonly TAppService AppService;

        protected GenericController(TAppService appService)
        {
            AppService = appService;
        }

        static JsonElement? ParseJsonElementOrNull(string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return null;

            try
            {
                using var doc = JsonDocument.Parse(json);
                return doc.RootElement.Clone();
            }
            catch (JsonException)
            {
                // JSON không hợp lệ
                return null;
            }
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetAsync([FromRoute] Guid id, [FromQuery] List<string> fields)
        {
            ReadRequestDto input = new ReadRequestDto()
            {
                Ids = [id],
                Fields = fields,
            };
            var result = await AppService.ReadAsync(input);
            if (result == null || !result.Any()) return NotFound();
            return Ok(result.FirstOrDefault());
        }

        [HttpPost("read")]
        public virtual async Task<IActionResult> ReadAsync([FromBody] ReadRequestDto input)
        {
            var result = await AppService.ReadAsync(input);
            return Ok(result);
        }

        // THAY ĐỔI: Chuyển sang POST, domain trong body
        [HttpPost("search")]
        public virtual async Task<IActionResult> SearchAsync([FromBody] SearchRequestDto input)
        {
            var result = await AppService.SearchAsync(input);
            return Ok(result);
        }

        // THAY ĐỔI: Chuyển sang POST, domain trong body
        [HttpPost("search-read")]
        public virtual async Task<IActionResult> SearchReadAsync([FromBody] SearchReadRequestDto input)
        {
            var result = await AppService.SearchReadAsync(input);
            return Ok(result);
        }


        [HttpPost]
        public virtual async Task<IActionResult> CreateAsync([FromBody] JsonElement payload)
        {
            var input = JsonSerializer.Deserialize<CreateRequestDto<TEntity>>(payload);
            var result = await AppService.CreateAsync(input);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] JsonElement payload)
        {
            var input = JsonSerializer.Deserialize<UpdateRequestDto<TEntity>>(payload);
            input.Ids = [id];
            var result = await AppService.WriteAsync(input);
            return Ok(result.FirstOrDefault());
        }

        [HttpPost("write")]
        public virtual async Task<IActionResult> WriteAsync([FromBody] JsonElement payload)
        {
            if (!payload.TryGetProperty("ids", out var idsElement) || !payload.TryGetProperty("values", out var valuesElement))
                return BadRequest("Payload must contain 'ids' and 'values' properties.");

            //var ids = JsonSerializer.Deserialize<List<Guid>>(idsElement.GetRawText());
            var input = JsonSerializer.Deserialize<UpdateRequestDto<TEntity>>(payload);
            var result = await AppService.WriteAsync(input);
            return Ok(result);
        }

        [HttpDelete]
        public virtual async Task<IActionResult> DeleteAsync([FromBody] List<Guid> ids)
        {
            await AppService.DeleteAsync(ids);
            return NoContent();
        }

        //<editor-fold desc="Other Odoo Common API Methods">
        [HttpPost("name-get")]
        public virtual async Task<IActionResult> NameGetAsync([FromBody] List<Guid> ids)
        {
            //var input = JsonSerializer.Deserialize<UpdateRequestDto<TEntity>>(payload);
            NameGetRequestDto nameGetRequestDto = new NameGetRequestDto()
            {
                Ids = ids,
            };
            var result = await AppService.NameGetAsync(nameGetRequestDto);
            return Ok(result);
        }
        [HttpGet("name-search")]
        public virtual async Task<IActionResult> NameSearchAsync([FromQuery] string name, [FromQuery] string domain = null, [FromQuery] string op = "ilike", [FromQuery] int limit = 100)
        {
            //var requestDto = JsonSerializer.Deserialize<NameSearchRequestDto>(payload);
            var requestDto = new NameSearchRequestDto()
            {
                Name = name,
                //Domain = domain,
            };
            var result = await AppService.NameSearchAsync(requestDto);
            return Ok(result);
        }
        [HttpPost("{id}/copy")]
        public virtual async Task<IActionResult> CopyAsync([FromBody] JsonElement payload)
        {
            var input = JsonSerializer.Deserialize<CopyRequestDto<TEntity>>(payload);
            var result = await AppService.CopyAsync(input);
            return Ok(result);
        }
        [HttpGet("default-get")]
        public virtual async Task<IActionResult> DefaultGetAsync([FromQuery] List<string> fields)
        {
            var requestDto = new DefaultGetRequestDto()
            {
                Fields = fields,
            };
            var result = await AppService.DefaultGetAsync(requestDto);
            return Ok(result);
        }
        [HttpGet("fields-get")]
        public virtual async Task<IActionResult> FieldsGetAsync(FieldsGetRequestDto input)
        {
            var result = await AppService.FieldsGetAsync(input);
            return Ok(result);
        }
        [HttpPost("onchange")]
        public virtual async Task<IActionResult> OnchangeAsync([FromBody] JsonElement payload)
        {
            // if (!payload.TryGetProperty("changedFields", out var changedFieldsElement) ||
            //     !payload.TryGetProperty("values", out var valuesElement) ||
            //     !payload.TryGetProperty("fieldInfo", out var fieldInfoElement))
            //     return BadRequest("Payload must contain 'changedFields', 'values', and 'fieldInfo' properties.");

            // var changedFields = JsonSerializer.Deserialize<List<string>>(changedFieldsElement.GetRawText());
            // var fieldInfo = JsonSerializer.Deserialize<Dictionary<string, object>>(fieldInfoElement.GetRawText());
            // var input = JsonSerializer.Deserialize<TEntity>(valuesElement);
            // var result = await AppService.OnChangeAsync(changedFields, input, fieldInfo);

            var input = JsonSerializer.Deserialize<OnChangeRequestDto<TEntity>>(payload);
            var result = await AppService.OnChangeAsync(input);
            return Ok(result);
        }
        //</editor-fold>
    }
}