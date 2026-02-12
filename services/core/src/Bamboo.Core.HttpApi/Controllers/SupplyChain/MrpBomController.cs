using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/supply-chain/MrpBom")]
    public partial class MrpBomController : AbpController
    {
        protected readonly IMrpBomAppService _appService;
        public MrpBomController(IMrpBomAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-archive")]
        public async Task<IActionResult> ArchiveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-compute-bom-days")]
        public async Task<IActionResult> ComputeBomDaysAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ComputeBomDaysAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-operation-form")]
        public async Task<IActionResult> OpenOperationFormAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenOperationFormAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-bom-on-orderpoint")]
        public async Task<IActionResult> SetBomOnOrderpointAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetBomOnOrderpointAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unarchive")]
        public async Task<IActionResult> UnarchiveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnarchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-kit-has-not-orderpoint")]
        public async Task<IActionResult> CheckKitHasNotOrderpointAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CheckKitHasNotOrderpointAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("explode")]
        public async Task<IActionResult> ExplodeAsync([FromBody] MrpBomExplodeRequestDto input)
        {
            var result = await _appService.ExplodeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetImportTemplatesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-bom-structure")]
        public async Task<IActionResult> OnchangeBomStructureAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangeBomStructureAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-product-tmpl-id")]
        public async Task<IActionResult> OnchangeProductTmplIdAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangeProductTmplIdAsync(ids);
            return Ok(result);
        }
    }
    
}