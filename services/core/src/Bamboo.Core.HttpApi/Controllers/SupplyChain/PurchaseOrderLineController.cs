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
    [Route("api/v1/supply-chain/PurchaseOrderLine")]
    public partial class PurchaseOrderLineController : AbpController
    {
        protected readonly IPurchaseOrderLineAppService _appService;
        public PurchaseOrderLineController(IPurchaseOrderLineAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-add-from-catalog")]
        public async Task<IActionResult> AddFromCatalogAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AddFromCatalogAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-choose")]
        public async Task<IActionResult> ChooseAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ChooseAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-clear-quantities")]
        public async Task<IActionResult> ClearQuantitiesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ClearQuantitiesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-order")]
        public async Task<IActionResult> OpenOrderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenOrderAsync(ids);
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
        [Route("get-parent-section-line")]
        public async Task<IActionResult> GetParentSectionLineAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetParentSectionLineAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-product-id")]
        public async Task<IActionResult> OnchangeProductIdAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangeProductIdAsync(ids);
            return Ok(result);
        }
    }
    
}