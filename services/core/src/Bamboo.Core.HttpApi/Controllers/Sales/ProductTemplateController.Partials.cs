using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    public partial class ProductTemplateController
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
        [Route("{id}/action-create-product-variants-from-gelato-template")]
        public async Task<IActionResult> ActionCreateProductVariantsFromGelatoTemplateAsync(Guid id)
        {
            var result = await _appService.CreateProductVariantsFromGelatoTemplateAsync(id);
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
        [Route("{id}/action-open-routes-diagram")]
        public async Task<IActionResult> ActionOpenRoutesDiagramAsync(Guid id)
        {
            var result = await _appService.OpenRoutesDiagramAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-product-tmpl-forecast-report")]
        public async Task<IActionResult> ActionProductTmplForecastReportAsync(Guid id)
        {
            var result = await _appService.ProductTmplForecastReportAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-sync-gelato-template-info")]
        public async Task<IActionResult> ActionSyncGelatoTemplateInfoAsync(Guid id)
        {
            var result = await _appService.SyncGelatoTemplateInfoAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-update-quantity-on-hand")]
        public async Task<IActionResult> ActionUpdateQuantityOnHandAsync(Guid id)
        {
            var result = await _appService.UpdateQuantityOnHandAsync(id);
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
        [Route("{id}/compute-is-storable")]
        public async Task<IActionResult> ComputeIsStorableAsync(Guid id)
        {
            var result = await _appService.ComputeIsStorableAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] ProductTemplateCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-product-variant")]
        public async Task<IActionResult> CreateProductVariantAsync(Guid id, [FromBody] ProductTemplateCreateProductVariantRequestDto input)
        {
            var result = await _appService.CreateProductVariantAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-contextual-price")]
        public async Task<IActionResult> GetContextualPriceAsync(Guid id, [FromBody] ProductTemplateGetContextualPriceRequestDto input)
        {
            var result = await _appService.GetContextualPriceAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync(Guid id, [FromBody] ProductTemplateGetEmptyListHelpRequestDto input)
        {
            var result = await _appService.GetEmptyListHelpAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync(Guid id)
        {
            var result = await _appService.GetImportTemplatesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-product-accounts")]
        public async Task<IActionResult> GetProductAccountsAsync(Guid id, [FromBody] ProductTemplateGetProductAccountsRequestDto input)
        {
            var result = await _appService.GetProductAccountsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-single-product-variant")]
        public async Task<IActionResult> GetSingleProductVariantAsync(Guid id)
        {
            var result = await _appService.GetSingleProductVariantAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/has-dynamic-attributes")]
        public async Task<IActionResult> HasDynamicAttributesAsync(Guid id)
        {
            var result = await _appService.HasDynamicAttributesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-pricelist-rules")]
        public async Task<IActionResult> OpenPricelistRulesAsync(Guid id)
        {
            var result = await _appService.OpenPricelistRulesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-sequence-bottom")]
        public async Task<IActionResult> SetSequenceBottomAsync(Guid id)
        {
            var result = await _appService.SetSequenceBottomAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-sequence-down")]
        public async Task<IActionResult> SetSequenceDownAsync(Guid id)
        {
            var result = await _appService.SetSequenceDownAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-sequence-top")]
        public async Task<IActionResult> SetSequenceTopAsync(Guid id)
        {
            var result = await _appService.SetSequenceTopAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-sequence-up")]
        public async Task<IActionResult> SetSequenceUpAsync(Guid id)
        {
            var result = await _appService.SetSequenceUpAsync(id);
            return Ok(result);
        }
    }
}