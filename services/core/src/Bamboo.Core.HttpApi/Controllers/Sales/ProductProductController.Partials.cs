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
        [Route("{id}/action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid id)
        {
            var result = await _appService.ArchiveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-bom-cost")]
        public async Task<IActionResult> ActionBomCostAsync(Guid id)
        {
            var result = await _appService.BomCostAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-documents")]
        public async Task<IActionResult> ActionOpenDocumentsAsync(Guid id)
        {
            var result = await _appService.OpenDocumentsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-label-layout")]
        public async Task<IActionResult> ActionOpenLabelLayoutAsync(Guid id)
        {
            var result = await _appService.OpenLabelLayoutAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-product-lot")]
        public async Task<IActionResult> ActionOpenProductLotAsync(Guid id)
        {
            var result = await _appService.OpenProductLotAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-quants")]
        public async Task<IActionResult> ActionOpenQuantsAsync(Guid id)
        {
            var result = await _appService.OpenQuantsAsync(id);
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
        [Route("{id}/action-unarchive")]
        public async Task<IActionResult> ActionUnarchiveAsync(Guid id)
        {
            var result = await _appService.UnarchiveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-used-in-bom")]
        public async Task<IActionResult> ActionUsedInBomAsync(Guid id)
        {
            var result = await _appService.UsedInBomAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-bom")]
        public async Task<IActionResult> ActionViewBomAsync(Guid id)
        {
            var result = await _appService.ViewBomAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-mos")]
        public async Task<IActionResult> ActionViewMosAsync(Guid id)
        {
            var result = await _appService.ViewMosAsync(id);
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
        [Route("{id}/action-view-po")]
        public async Task<IActionResult> ActionViewPoAsync(Guid id)
        {
            var result = await _appService.ViewPoAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-related-putaway-rules")]
        public async Task<IActionResult> ActionViewRelatedPutawayRulesAsync(Guid id)
        {
            var result = await _appService.ViewRelatedPutawayRulesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-routes")]
        public async Task<IActionResult> ActionViewRoutesAsync(Guid id)
        {
            var result = await _appService.ViewRoutesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-sales")]
        public async Task<IActionResult> ActionViewSalesAsync(Guid id)
        {
            var result = await _appService.ViewSalesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-stock-move-lines")]
        public async Task<IActionResult> ActionViewStockMoveLinesAsync(Guid id)
        {
            var result = await _appService.ViewStockMoveLinesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-storage-category-capacity")]
        public async Task<IActionResult> ActionViewStorageCategoryCapacityAsync(Guid id)
        {
            var result = await _appService.ViewStorageCategoryCapacityAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-bom-cost")]
        public async Task<IActionResult> ButtonBomCostAsync(Guid id)
        {
            var result = await _appService.ButtonBomCostAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/filter-has-routes")]
        public async Task<IActionResult> FilterHasRoutesAsync(Guid id)
        {
            var result = await _appService.FilterHasRoutesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-components")]
        public async Task<IActionResult> GetComponentsAsync(Guid id)
        {
            var result = await _appService.GetComponentsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-contextual-price")]
        public async Task<IActionResult> GetContextualPriceAsync(Guid id)
        {
            var result = await _appService.GetContextualPriceAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync(Guid id, [FromBody] ProductProductGetEmptyListHelpRequestDto input)
        {
            var result = await _appService.GetEmptyListHelpAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-product-multiline-description-sale")]
        public async Task<IActionResult> GetProductMultilineDescriptionSaleAsync(Guid id)
        {
            var result = await _appService.GetProductMultilineDescriptionSaleAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-total-routes")]
        public async Task<IActionResult> GetTotalRoutesAsync(Guid id)
        {
            var result = await _appService.GetTotalRoutesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-product-template")]
        public async Task<IActionResult> OpenProductTemplateAsync(Guid id)
        {
            var result = await _appService.OpenProductTemplateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-website-url")]
        public async Task<IActionResult> OpenWebsiteUrlAsync(Guid id)
        {
            var result = await _appService.OpenWebsiteUrlAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/view-header-get")]
        public async Task<IActionResult> ViewHeaderGetAsync(Guid id, [FromBody] ProductProductViewHeaderGetRequestDto input)
        {
            var result = await _appService.ViewHeaderGetAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/website-publish-button")]
        public async Task<IActionResult> WebsitePublishButtonAsync(Guid id)
        {
            var result = await _appService.WebsitePublishButtonAsync(id);
            return Ok(result);
        }
    }
}