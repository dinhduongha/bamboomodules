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
    [Route("api/v1/supply-chain/StockWarehouseOrderpoint")]
    public partial class StockWarehouseOrderpointController : AbpController
    {
        protected readonly IStockWarehouseOrderpointAppService _appService;
        public StockWarehouseOrderpointController(IStockWarehouseOrderpointAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-open-orderpoints")]
        public async Task<IActionResult> OpenOrderpointsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenOrderpointsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-product-forecast-report")]
        public async Task<IActionResult> ProductForecastReportAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ProductForecastReportAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-remove-manual-qty-to-order")]
        public async Task<IActionResult> RemoveManualQtyToOrderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RemoveManualQtyToOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-replenish")]
        public async Task<IActionResult> ReplenishAsync([FromBody] StockWarehouseOrderpointReplenishRequestDto input)
        {
            var result = await _appService.ReplenishAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-replenish-auto")]
        public async Task<IActionResult> ReplenishAutoAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ReplenishAutoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-stock-replenishment-info")]
        public async Task<IActionResult> StockReplenishmentInfoAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.StockReplenishmentInfoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-purchase")]
        public async Task<IActionResult> ViewPurchaseAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewPurchaseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-product-is-not-kit")]
        public async Task<IActionResult> CheckProductIsNotKitAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CheckProductIsNotKitAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-horizon-days")]
        public async Task<IActionResult> GetHorizonDaysAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetHorizonDaysAsync(ids);
            return Ok(result);
        }
    }
    
}