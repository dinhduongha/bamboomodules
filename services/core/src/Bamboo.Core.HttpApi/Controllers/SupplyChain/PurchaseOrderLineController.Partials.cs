using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class PurchaseOrderLineController
    {
        
        [HttpPost]
        [Route("action-add-from-catalog")]
        public async Task<IActionResult> ActionAddFromCatalogAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AddFromCatalogAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-choose")]
        public async Task<IActionResult> ActionChooseAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ChooseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-clear-quantities")]
        public async Task<IActionResult> ActionClearQuantitiesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ClearQuantitiesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-order")]
        public async Task<IActionResult> ActionOpenOrderAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenOrderAsync(ids);
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
        [Route("get-parent-section-line")]
        public async Task<IActionResult> GetParentSectionLineAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetParentSectionLineAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-product-id")]
        public async Task<IActionResult> OnchangeProductIdAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangeProductIdAsync(ids);
            return Ok(result);
        }
    }
}