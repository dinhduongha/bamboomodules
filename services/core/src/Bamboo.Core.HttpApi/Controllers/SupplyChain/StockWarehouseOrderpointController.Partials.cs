using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class StockWarehouseOrderpointController
    {
        
        [HttpPost]
        [Route("{id}/action-open-orderpoints")]
        public async Task<IActionResult> ActionOpenOrderpointsAsync(Guid id)
        {
            var result = await _appService.OpenOrderpointsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-product-forecast-report")]
        public async Task<IActionResult> ActionProductForecastReportAsync(Guid id)
        {
            var result = await _appService.ProductForecastReportAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-remove-manual-qty-to-order")]
        public async Task<IActionResult> ActionRemoveManualQtyToOrderAsync(Guid id)
        {
            var result = await _appService.RemoveManualQtyToOrderAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-replenish")]
        public async Task<IActionResult> ActionReplenishAsync(Guid id, [FromBody] StockWarehouseOrderpointReplenishRequestDto input)
        {
            var result = await _appService.ReplenishAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-replenish-auto")]
        public async Task<IActionResult> ActionReplenishAutoAsync(Guid id)
        {
            var result = await _appService.ReplenishAutoAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-stock-replenishment-info")]
        public async Task<IActionResult> ActionStockReplenishmentInfoAsync(Guid id)
        {
            var result = await _appService.StockReplenishmentInfoAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-purchase")]
        public async Task<IActionResult> ActionViewPurchaseAsync(Guid id)
        {
            var result = await _appService.ViewPurchaseAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-product-is-not-kit")]
        public async Task<IActionResult> CheckProductIsNotKitAsync(Guid id)
        {
            var result = await _appService.CheckProductIsNotKitAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-visibility-days")]
        public async Task<IActionResult> GetVisibilityDaysAsync(Guid id)
        {
            var result = await _appService.GetVisibilityDaysAsync(id);
            return Ok(result);
        }
    }
}