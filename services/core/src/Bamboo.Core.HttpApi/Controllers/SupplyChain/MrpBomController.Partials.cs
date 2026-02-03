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
        [Route("action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-compute-bom-days")]
        public async Task<IActionResult> ActionComputeBomDaysAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ComputeBomDaysAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-operation-form")]
        public async Task<IActionResult> ActionOpenOperationFormAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenOperationFormAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-bom-on-orderpoint")]
        public async Task<IActionResult> ActionSetBomOnOrderpointAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetBomOnOrderpointAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unarchive")]
        public async Task<IActionResult> ActionUnarchiveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnarchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-kit-has-not-orderpoint")]
        public async Task<IActionResult> CheckKitHasNotOrderpointAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CheckKitHasNotOrderpointAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("explode")]
        public async Task<IActionResult> ExplodeAsync(MrpBomExplodeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ExplodeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetImportTemplatesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-bom-structure")]
        public async Task<IActionResult> OnchangeBomStructureAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangeBomStructureAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-product-tmpl-id")]
        public async Task<IActionResult> OnchangeProductTmplIdAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangeProductTmplIdAsync(ids);
            return Ok(result);
        }
    }
}