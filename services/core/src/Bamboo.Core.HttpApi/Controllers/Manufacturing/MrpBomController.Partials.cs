using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MrpBomController
    {
        
        [HttpPost]
        [Route("{id}/action-compute-bom-days")]
        public async Task<IActionResult> ActionComputeBomDaysAsync(Guid id)
        {
            var result = await _appService.ComputeBomDaysAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-kit-has-not-orderpoint")]
        public async Task<IActionResult> CheckKitHasNotOrderpointAsync(Guid id)
        {
            var result = await _appService.CheckKitHasNotOrderpointAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/explode")]
        public async Task<IActionResult> ExplodeAsync(Guid id, [FromBody] MrpBomExplodeRequestDto input)
        {
            var result = await _appService.ExplodeAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync(Guid id)
        {
            var result = await _appService.GetImportTemplatesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-bom-structure")]
        public async Task<IActionResult> OnchangeBomStructureAsync(Guid id)
        {
            var result = await _appService.OnchangeBomStructureAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-product-tmpl-id")]
        public async Task<IActionResult> OnchangeProductTmplIdAsync(Guid id)
        {
            var result = await _appService.OnchangeProductTmplIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-product-uom-id")]
        public async Task<IActionResult> OnchangeProductUomIdAsync(Guid id)
        {
            var result = await _appService.OnchangeProductUomIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-active")]
        public async Task<IActionResult> ToggleActiveAsync(Guid id)
        {
            var result = await _appService.ToggleActiveAsync(id);
            return Ok(result);
        }
    }
}