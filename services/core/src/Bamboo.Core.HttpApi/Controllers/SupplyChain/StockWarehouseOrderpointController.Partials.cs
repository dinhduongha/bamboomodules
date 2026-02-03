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
        [Route("action-open-orderpoints")]
        public async Task<IActionResult> ActionOpenOrderpointsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenOrderpointsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-product-forecast-report")]
        public async Task<IActionResult> ActionProductForecastReportAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ProductForecastReportAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-remove-manual-qty-to-order")]
        public async Task<IActionResult> ActionRemoveManualQtyToOrderAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RemoveManualQtyToOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-replenish")]
        public async Task<IActionResult> ActionReplenishAsync(StockWarehouseOrderpointReplenishRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ReplenishAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-replenish-auto")]
        public async Task<IActionResult> ActionReplenishAutoAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ReplenishAutoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-stock-replenishment-info")]
        public async Task<IActionResult> ActionStockReplenishmentInfoAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.StockReplenishmentInfoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-purchase")]
        public async Task<IActionResult> ActionViewPurchaseAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewPurchaseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-product-is-not-kit")]
        public async Task<IActionResult> CheckProductIsNotKitAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CheckProductIsNotKitAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-horizon-days")]
        public async Task<IActionResult> GetHorizonDaysAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetHorizonDaysAsync(ids);
            return Ok(result);
        }
    }
}