using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class StockPickingTypeController
    {
        
        [HttpPost]
        [Route("action-batch")]
        public async Task<IActionResult> ActionBatchAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.BatchAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-barcode-installation")]
        public async Task<IActionResult> ActionRedirectToBarcodeInstallationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RedirectToBarcodeInstallationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-wave")]
        public async Task<IActionResult> ActionWaveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.WaveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(StockPickingTypeCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-action-picking-tree-backorder")]
        public async Task<IActionResult> GetActionPickingTreeBackorderAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetPickingTreeBackorderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-action-picking-tree-late")]
        public async Task<IActionResult> GetActionPickingTreeLateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetPickingTreeLateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-action-picking-tree-ready")]
        public async Task<IActionResult> GetActionPickingTreeReadyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetPickingTreeReadyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-action-picking-tree-waiting")]
        public async Task<IActionResult> GetActionPickingTreeWaitingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetPickingTreeWaitingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-action-picking-type-moves-analysis")]
        public async Task<IActionResult> GetActionPickingTypeMovesAnalysisAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetPickingTypeMovesAnalysisAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-action-picking-type-ready-moves")]
        public async Task<IActionResult> GetActionPickingTypeReadyMovesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetPickingTypeReadyMovesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-mrp-stock-picking-action-picking-type")]
        public async Task<IActionResult> GetMrpStockPickingActionPickingTypeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetMrpStockPickingPickingTypeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-repair-stock-picking-action-picking-type")]
        public async Task<IActionResult> GetRepairStockPickingActionPickingTypeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetRepairStockPickingPickingTypeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-stock-picking-action-picking-type")]
        public async Task<IActionResult> GetStockPickingActionPickingTypeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetStockPickingPickingTypeAsync(ids);
            return Ok(result);
        }
    }
}