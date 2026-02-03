using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class StockQuantController
    {
        
        [HttpPost]
        [Route("action-apply-all")]
        public async Task<IActionResult> ActionApplyAllAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ApplyAllAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-apply-inventory")]
        public async Task<IActionResult> ActionApplyInventoryAsync(StockQuantApplyInventoryRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ApplyInventoryAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-clear-inventory-quantity")]
        public async Task<IActionResult> ActionClearInventoryQuantityAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ClearInventoryQuantityAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-inventory-history")]
        public async Task<IActionResult> ActionInventoryHistoryAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.InventoryHistoryAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reset")]
        public async Task<IActionResult> ActionResetAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ResetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-inventory-quantity")]
        public async Task<IActionResult> ActionSetInventoryQuantityAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetInventoryQuantityAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-inventory-quantity-zero")]
        public async Task<IActionResult> ActionSetInventoryQuantityZeroAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetInventoryQuantityZeroAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-stock-quant-relocate")]
        public async Task<IActionResult> ActionStockQuantRelocateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.StockQuantRelocateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-inventory")]
        public async Task<IActionResult> ActionViewInventoryAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewInventoryAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-orderpoints")]
        public async Task<IActionResult> ActionViewOrderpointsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewOrderpointsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-quants")]
        public async Task<IActionResult> ActionViewQuantsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewQuantsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-stock-moves")]
        public async Task<IActionResult> ActionViewStockMovesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewStockMovesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-location-id")]
        public async Task<IActionResult> CheckLocationIdAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CheckLocationIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-lot-id")]
        public async Task<IActionResult> CheckLotIdAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CheckLotIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-product-id")]
        public async Task<IActionResult> CheckProductIdAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CheckProductIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-quantity")]
        public async Task<IActionResult> CheckQuantityAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CheckQuantityAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-aggregate-barcodes")]
        public async Task<IActionResult> GetAggregateBarcodesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetAggregateBarcodesAsync(ids);
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
        [Route("move-quants")]
        public async Task<IActionResult> MoveQuantsAsync(StockQuantMoveQuantsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MoveQuantsAsync(input);
            return Ok(result);
        }
    }
}