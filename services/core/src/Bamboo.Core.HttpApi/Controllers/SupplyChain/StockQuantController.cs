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
    [Route("api/v1/supply-chain/StockQuant")]
    public partial class StockQuantController : AbpController
    {
        protected readonly IStockQuantAppService _appService;
        public StockQuantController(IStockQuantAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-apply-all")]
        public async Task<IActionResult> ApplyAllAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ApplyAllAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-apply-inventory")]
        public async Task<IActionResult> ApplyInventoryAsync([FromBody] StockQuantApplyInventoryRequestDto input)
        {
            var result = await _appService.ApplyInventoryAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-clear-inventory-quantity")]
        public async Task<IActionResult> ClearInventoryQuantityAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ClearInventoryQuantityAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-inventory-history")]
        public async Task<IActionResult> InventoryHistoryAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.InventoryHistoryAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reset")]
        public async Task<IActionResult> ResetAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ResetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-inventory-quantity")]
        public async Task<IActionResult> SetInventoryQuantityAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetInventoryQuantityAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-inventory-quantity-zero")]
        public async Task<IActionResult> SetInventoryQuantityZeroAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetInventoryQuantityZeroAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-stock-quant-relocate")]
        public async Task<IActionResult> StockQuantRelocateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.StockQuantRelocateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-inventory")]
        public async Task<IActionResult> ViewInventoryAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewInventoryAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-orderpoints")]
        public async Task<IActionResult> ViewOrderpointsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewOrderpointsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-quants")]
        public async Task<IActionResult> ViewQuantsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewQuantsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-stock-moves")]
        public async Task<IActionResult> ViewStockMovesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewStockMovesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-location-id")]
        public async Task<IActionResult> CheckLocationIdAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CheckLocationIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-lot-id")]
        public async Task<IActionResult> CheckLotIdAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CheckLotIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-product-id")]
        public async Task<IActionResult> CheckProductIdAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CheckProductIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-quantity")]
        public async Task<IActionResult> CheckQuantityAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CheckQuantityAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-aggregate-barcodes")]
        public async Task<IActionResult> GetAggregateBarcodesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetAggregateBarcodesAsync(ids);
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
        [Route("move-quants")]
        public async Task<IActionResult> MoveQuantsAsync([FromBody] StockQuantMoveQuantsRequestDto input)
        {
            var result = await _appService.MoveQuantsAsync(input);
            return Ok(result);
        }
    }
    
}