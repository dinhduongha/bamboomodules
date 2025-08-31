using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Purchase
{
    public partial class PurchaseOrderLineController
    {
        
        [HttpPost]
        [Route("{id}/action-add-from-catalog")]
        public async Task<IActionResult> ActionAddFromCatalogAsync(Guid id)
        {
            var result = await _appService.AddFromCatalogAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-choose")]
        public async Task<IActionResult> ActionChooseAsync(Guid id)
        {
            var result = await _appService.ChooseAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-clear-quantities")]
        public async Task<IActionResult> ActionClearQuantitiesAsync(Guid id)
        {
            var result = await _appService.ClearQuantitiesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-order")]
        public async Task<IActionResult> ActionOpenOrderAsync(Guid id)
        {
            var result = await _appService.OpenOrderAsync(id);
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
        [Route("{id}/action-purchase-history")]
        public async Task<IActionResult> ActionPurchaseHistoryAsync(Guid id)
        {
            var result = await _appService.PurchaseHistoryAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-product-id")]
        public async Task<IActionResult> OnchangeProductIdAsync(Guid id)
        {
            var result = await _appService.OnchangeProductIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-product-id-warning")]
        public async Task<IActionResult> OnchangeProductIdWarningAsync(Guid id)
        {
            var result = await _appService.OnchangeProductIdWarningAsync(id);
            return Ok(result);
        }
    }
}