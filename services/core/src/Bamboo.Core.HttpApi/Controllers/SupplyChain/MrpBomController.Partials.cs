using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MrpBomController
    {
        
        [HttpPost]
        [Route("{id}/action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid id)
        {
            var result = await _appService.ArchiveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-compute-bom-days")]
        public async Task<IActionResult> ActionComputeBomDaysAsync(Guid id)
        {
            var result = await _appService.ComputeBomDaysAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-operation-form")]
        public async Task<IActionResult> ActionOpenOperationFormAsync(Guid id)
        {
            var result = await _appService.OpenOperationFormAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-set-bom-on-orderpoint")]
        public async Task<IActionResult> ActionSetBomOnOrderpointAsync(Guid id)
        {
            var result = await _appService.SetBomOnOrderpointAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-unarchive")]
        public async Task<IActionResult> ActionUnarchiveAsync(Guid id)
        {
            var result = await _appService.UnarchiveAsync(id);
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
    }
}