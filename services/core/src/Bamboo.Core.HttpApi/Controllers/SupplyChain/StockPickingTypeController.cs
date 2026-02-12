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
    [Route("api/v1/supply-chain/StockPickingType")]
    public partial class StockPickingTypeController : AbpController
    {
        protected readonly IStockPickingTypeAppService _appService;
        public StockPickingTypeController(IStockPickingTypeAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-batch")]
        public async Task<IActionResult> BatchAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.BatchAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-barcode-installation")]
        public async Task<IActionResult> RedirectToBarcodeInstallationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RedirectToBarcodeInstallationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-wave")]
        public async Task<IActionResult> WaveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.WaveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] StockPickingTypeCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-action-picking-tree-backorder")]
        public async Task<IActionResult> GetPickingTreeBackorderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetPickingTreeBackorderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-action-picking-tree-late")]
        public async Task<IActionResult> GetPickingTreeLateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetPickingTreeLateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-action-picking-tree-ready")]
        public async Task<IActionResult> GetPickingTreeReadyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetPickingTreeReadyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-action-picking-tree-waiting")]
        public async Task<IActionResult> GetPickingTreeWaitingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetPickingTreeWaitingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-action-picking-type-moves-analysis")]
        public async Task<IActionResult> GetPickingTypeMovesAnalysisAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetPickingTypeMovesAnalysisAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-action-picking-type-ready-moves")]
        public async Task<IActionResult> GetPickingTypeReadyMovesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetPickingTypeReadyMovesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-mrp-stock-picking-action-picking-type")]
        public async Task<IActionResult> GetMrpStockPickingPickingTypeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetMrpStockPickingPickingTypeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-repair-stock-picking-action-picking-type")]
        public async Task<IActionResult> GetRepairStockPickingPickingTypeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetRepairStockPickingPickingTypeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-stock-picking-action-picking-type")]
        public async Task<IActionResult> GetStockPickingPickingTypeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetStockPickingPickingTypeAsync(ids);
            return Ok(result);
        }
    }
    
}