using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class StockPickingTypeController
    {
        
        [HttpPost]
        [Route("{id}/action-batch")]
        public async Task<IActionResult> ActionBatchAsync(Guid id)
        {
            var result = await _appService.BatchAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-redirect-to-barcode-installation")]
        public async Task<IActionResult> ActionRedirectToBarcodeInstallationAsync(Guid id)
        {
            var result = await _appService.RedirectToBarcodeInstallationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-repair-overview")]
        public async Task<IActionResult> ActionRepairOverviewAsync(Guid id)
        {
            var result = await _appService.RepairOverviewAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] StockPickingTypeCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-action-picking-tree-backorder")]
        public async Task<IActionResult> GetActionPickingTreeBackorderAsync(Guid id)
        {
            var result = await _appService.GetPickingTreeBackorderAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-action-picking-tree-late")]
        public async Task<IActionResult> GetActionPickingTreeLateAsync(Guid id)
        {
            var result = await _appService.GetPickingTreeLateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-action-picking-tree-ready")]
        public async Task<IActionResult> GetActionPickingTreeReadyAsync(Guid id)
        {
            var result = await _appService.GetPickingTreeReadyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-action-picking-tree-waiting")]
        public async Task<IActionResult> GetActionPickingTreeWaitingAsync(Guid id)
        {
            var result = await _appService.GetPickingTreeWaitingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-action-picking-type-moves-analysis")]
        public async Task<IActionResult> GetActionPickingTypeMovesAnalysisAsync(Guid id)
        {
            var result = await _appService.GetPickingTypeMovesAnalysisAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-action-picking-type-ready-moves")]
        public async Task<IActionResult> GetActionPickingTypeReadyMovesAsync(Guid id)
        {
            var result = await _appService.GetPickingTypeReadyMovesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-mrp-stock-picking-action-picking-type")]
        public async Task<IActionResult> GetMrpStockPickingActionPickingTypeAsync(Guid id)
        {
            var result = await _appService.GetMrpStockPickingPickingTypeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-repair-stock-picking-action-picking-type")]
        public async Task<IActionResult> GetRepairStockPickingActionPickingTypeAsync(Guid id)
        {
            var result = await _appService.GetRepairStockPickingPickingTypeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-stock-picking-action-picking-type")]
        public async Task<IActionResult> GetStockPickingActionPickingTypeAsync(Guid id)
        {
            var result = await _appService.GetStockPickingPickingTypeAsync(id);
            return Ok(result);
        }
    }
}