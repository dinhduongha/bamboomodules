using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Stock
{
    public partial class StockQuantController
    {
        
        [HttpPost]
        [Route("{id}/action-apply-all")]
        public async Task<IActionResult> ActionApplyAllAsync(Guid id)
        {
            var result = await _appService.ApplyAllAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-apply-inventory")]
        public async Task<IActionResult> ActionApplyInventoryAsync(Guid id)
        {
            var result = await _appService.ApplyInventoryAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-clear-inventory-quantity")]
        public async Task<IActionResult> ActionClearInventoryQuantityAsync(Guid id)
        {
            var result = await _appService.ClearInventoryQuantityAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-inventory-history")]
        public async Task<IActionResult> ActionInventoryHistoryAsync(Guid id)
        {
            var result = await _appService.InventoryHistoryAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-reset")]
        public async Task<IActionResult> ActionResetAsync(Guid id)
        {
            var result = await _appService.ResetAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-set-inventory-quantity")]
        public async Task<IActionResult> ActionSetInventoryQuantityAsync(Guid id)
        {
            var result = await _appService.SetInventoryQuantityAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-set-inventory-quantity-zero")]
        public async Task<IActionResult> ActionSetInventoryQuantityZeroAsync(Guid id)
        {
            var result = await _appService.SetInventoryQuantityZeroAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-stock-quant-relocate")]
        public async Task<IActionResult> ActionStockQuantRelocateAsync(Guid id)
        {
            var result = await _appService.StockQuantRelocateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-inventory")]
        public async Task<IActionResult> ActionViewInventoryAsync(Guid id)
        {
            var result = await _appService.ViewInventoryAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-orderpoints")]
        public async Task<IActionResult> ActionViewOrderpointsAsync(Guid id)
        {
            var result = await _appService.ViewOrderpointsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-quants")]
        public async Task<IActionResult> ActionViewQuantsAsync(Guid id)
        {
            var result = await _appService.ViewQuantsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-stock-moves")]
        public async Task<IActionResult> ActionViewStockMovesAsync(Guid id)
        {
            var result = await _appService.ViewStockMovesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-warning-duplicated-sn")]
        public async Task<IActionResult> ActionWarningDuplicatedSnAsync(Guid id)
        {
            var result = await _appService.WarningDuplicatedSnAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-location-id")]
        public async Task<IActionResult> CheckLocationIdAsync(Guid id)
        {
            var result = await _appService.CheckLocationIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-lot-id")]
        public async Task<IActionResult> CheckLotIdAsync(Guid id)
        {
            var result = await _appService.CheckLotIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-product-id")]
        public async Task<IActionResult> CheckProductIdAsync(Guid id)
        {
            var result = await _appService.CheckProductIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-quantity")]
        public async Task<IActionResult> CheckQuantityAsync(Guid id)
        {
            var result = await _appService.CheckQuantityAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-aggregate-barcodes")]
        public async Task<IActionResult> GetAggregateBarcodesAsync(Guid id)
        {
            var result = await _appService.GetAggregateBarcodesAsync(id);
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
        [Route("{id}/move-quants")]
        public async Task<IActionResult> MoveQuantsAsync(Guid id, [FromBody] StockQuantMoveQuantsRequestDto input)
        {
            var result = await _appService.MoveQuantsAsync(id, input);
            return Ok(result);
        }
    }
}