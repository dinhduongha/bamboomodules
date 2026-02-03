using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ProductTemplateController
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
        [Route("action-create-product-variants-from-gelato-template")]
        public async Task<IActionResult> ActionCreateProductVariantsFromGelatoTemplateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreateProductVariantsFromGelatoTemplateAsync(ids);
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
        [Route("action-open-routes-diagram")]
        public async Task<IActionResult> ActionOpenRoutesDiagramAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenRoutesDiagramAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-product-tmpl-forecast-report")]
        public async Task<IActionResult> ActionProductTmplForecastReportAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ProductTmplForecastReportAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-sync-gelato-template-info")]
        public async Task<IActionResult> ActionSyncGelatoTemplateInfoAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SyncGelatoTemplateInfoAsync(ids);
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
        [Route("compute-is-storable")]
        public async Task<IActionResult> ComputeIsStorableAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ComputeIsStorableAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(ProductTemplateCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-product-variant")]
        public async Task<IActionResult> CreateProductVariantAsync(ProductTemplateCreateProductVariantRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CreateProductVariantAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-product-variant-from-pos")]
        public async Task<IActionResult> CreateProductVariantFromPosAsync(ProductTemplateCreateProductVariantFromPosRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CreateProductVariantFromPosAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-contextual-price")]
        public async Task<IActionResult> GetContextualPriceAsync(ProductTemplateGetContextualPriceRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetContextualPriceAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync(ProductTemplateGetEmptyListHelpRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetEmptyListHelpAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetImportTemplatesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-product-accounts")]
        public async Task<IActionResult> GetProductAccountsAsync(ProductTemplateGetProductAccountsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetProductAccountsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-product-info-pos")]
        public async Task<IActionResult> GetProductInfoPosAsync(ProductTemplateGetProductInfoPosRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetProductInfoPosAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-single-product-variant")]
        public async Task<IActionResult> GetSingleProductVariantAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetSingleProductVariantAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("has-dynamic-attributes")]
        public async Task<IActionResult> HasDynamicAttributesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.HasDynamicAttributesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("load-product-from-pos")]
        public async Task<IActionResult> LoadProductFromPosAsync(ProductTemplateLoadProductFromPosRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.LoadProductFromPosAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-sequence-bottom")]
        public async Task<IActionResult> SetSequenceBottomAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetSequenceBottomAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-sequence-down")]
        public async Task<IActionResult> SetSequenceDownAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetSequenceDownAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-sequence-top")]
        public async Task<IActionResult> SetSequenceTopAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetSequenceTopAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-sequence-up")]
        public async Task<IActionResult> SetSequenceUpAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetSequenceUpAsync(ids);
            return Ok(result);
        }
    }
}