using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ProductProductController
    {
        
        [HttpPost]
        [Route("action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-bom-cost")]
        public async Task<IActionResult> ActionBomCostAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.BomCostAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-documents")]
        public async Task<IActionResult> ActionOpenDocumentsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenDocumentsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-label-layout")]
        public async Task<IActionResult> ActionOpenLabelLayoutAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenLabelLayoutAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-product-lot")]
        public async Task<IActionResult> ActionOpenProductLotAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenProductLotAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-quants")]
        public async Task<IActionResult> ActionOpenQuantsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenQuantsAsync(ids);
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
        [Route("action-unarchive")]
        public async Task<IActionResult> ActionUnarchiveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnarchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-used-in-bom")]
        public async Task<IActionResult> ActionUsedInBomAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UsedInBomAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-bom")]
        public async Task<IActionResult> ActionViewBomAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewBomAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mos")]
        public async Task<IActionResult> ActionViewMosAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewMosAsync(ids);
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
        [Route("action-view-po")]
        public async Task<IActionResult> ActionViewPoAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewPoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-related-putaway-rules")]
        public async Task<IActionResult> ActionViewRelatedPutawayRulesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewRelatedPutawayRulesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-routes")]
        public async Task<IActionResult> ActionViewRoutesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewRoutesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sales")]
        public async Task<IActionResult> ActionViewSalesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewSalesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-stock-move-lines")]
        public async Task<IActionResult> ActionViewStockMoveLinesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewStockMoveLinesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-storage-category-capacity")]
        public async Task<IActionResult> ActionViewStorageCategoryCapacityAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewStorageCategoryCapacityAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-bom-cost")]
        public async Task<IActionResult> ButtonBomCostAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonBomCostAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("filter-has-routes")]
        public async Task<IActionResult> FilterHasRoutesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.FilterHasRoutesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-components")]
        public async Task<IActionResult> GetComponentsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetComponentsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-contextual-price")]
        public async Task<IActionResult> GetContextualPriceAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetContextualPriceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync(ProductProductGetEmptyListHelpRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetEmptyListHelpAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-product-multiline-description-sale")]
        public async Task<IActionResult> GetProductMultilineDescriptionSaleAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetProductMultilineDescriptionSaleAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-total-routes")]
        public async Task<IActionResult> GetTotalRoutesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetTotalRoutesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-product-template")]
        public async Task<IActionResult> OpenProductTemplateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenProductTemplateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-website-url")]
        public async Task<IActionResult> OpenWebsiteUrlAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenWebsiteUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("view-header-get")]
        public async Task<IActionResult> ViewHeaderGetAsync(ProductProductViewHeaderGetRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ViewHeaderGetAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("website-publish-button")]
        public async Task<IActionResult> WebsitePublishButtonAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.WebsitePublishButtonAsync(ids);
            return Ok(result);
        }
    }
}