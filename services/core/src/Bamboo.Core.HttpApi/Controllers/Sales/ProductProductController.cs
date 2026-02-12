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
    [Route("api/v1/sales/ProductProduct")]
    public partial class ProductProductController : AbpController
    {
        protected readonly IProductProductAppService _appService;
        public ProductProductController(IProductProductAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-archive")]
        public async Task<IActionResult> ArchiveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-bom-cost")]
        public async Task<IActionResult> BomCostAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.BomCostAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-documents")]
        public async Task<IActionResult> OpenDocumentsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenDocumentsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-label-layout")]
        public async Task<IActionResult> OpenLabelLayoutAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenLabelLayoutAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-product-lot")]
        public async Task<IActionResult> OpenProductLotAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenProductLotAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-quants")]
        public async Task<IActionResult> OpenQuantsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenQuantsAsync(ids);
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
        [Route("action-unarchive")]
        public async Task<IActionResult> UnarchiveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnarchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-used-in-bom")]
        public async Task<IActionResult> UsedInBomAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UsedInBomAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-bom")]
        public async Task<IActionResult> ViewBomAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewBomAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mos")]
        public async Task<IActionResult> ViewMosAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewMosAsync(ids);
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
        [Route("action-view-po")]
        public async Task<IActionResult> ViewPoAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewPoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-related-putaway-rules")]
        public async Task<IActionResult> ViewRelatedPutawayRulesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewRelatedPutawayRulesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-routes")]
        public async Task<IActionResult> ViewRoutesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewRoutesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sales")]
        public async Task<IActionResult> ViewSalesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewSalesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-stock-move-lines")]
        public async Task<IActionResult> ViewStockMoveLinesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewStockMoveLinesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-storage-category-capacity")]
        public async Task<IActionResult> ViewStorageCategoryCapacityAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewStorageCategoryCapacityAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-bom-cost")]
        public async Task<IActionResult> ButtonBomCostAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonBomCostAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("filter-has-routes")]
        public async Task<IActionResult> FilterHasRoutesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.FilterHasRoutesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-components")]
        public async Task<IActionResult> GetComponentsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetComponentsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-contextual-price")]
        public async Task<IActionResult> GetContextualPriceAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetContextualPriceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync([FromBody] ProductProductGetEmptyListHelpRequestDto input)
        {
            var result = await _appService.GetEmptyListHelpAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-product-multiline-description-sale")]
        public async Task<IActionResult> GetProductMultilineDescriptionSaleAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetProductMultilineDescriptionSaleAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-total-routes")]
        public async Task<IActionResult> GetTotalRoutesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetTotalRoutesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-product-template")]
        public async Task<IActionResult> OpenProductTemplateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenProductTemplateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-website-url")]
        public async Task<IActionResult> OpenWebsiteUrlAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenWebsiteUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("view-header-get")]
        public async Task<IActionResult> ViewHeaderGetAsync([FromBody] ProductProductViewHeaderGetRequestDto input)
        {
            var result = await _appService.ViewHeaderGetAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("website-publish-button")]
        public async Task<IActionResult> WebsitePublishButtonAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.WebsitePublishButtonAsync(ids);
            return Ok(result);
        }
    }
    
}