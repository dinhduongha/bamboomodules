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
    [Route("api/v1/sales/ProductTemplate")]
    public partial class ProductTemplateController : AbpController
    {
        protected readonly IProductTemplateAppService _appService;
        public ProductTemplateController(IProductTemplateAppService appService) { _appService = appService; }
        
        
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
        [Route("action-create-product-variants-from-gelato-template")]
        public async Task<IActionResult> CreateProductVariantsFromGelatoTemplateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateProductVariantsFromGelatoTemplateAsync(ids);
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
        [Route("action-open-routes-diagram")]
        public async Task<IActionResult> OpenRoutesDiagramAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenRoutesDiagramAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-product-tmpl-forecast-report")]
        public async Task<IActionResult> ProductTmplForecastReportAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ProductTmplForecastReportAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-sync-gelato-template-info")]
        public async Task<IActionResult> SyncGelatoTemplateInfoAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SyncGelatoTemplateInfoAsync(ids);
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
        [Route("compute-is-storable")]
        public async Task<IActionResult> ComputeIsStorableAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ComputeIsStorableAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] ProductTemplateCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-product-variant")]
        public async Task<IActionResult> CreateProductVariantAsync([FromBody] ProductTemplateCreateProductVariantRequestDto input)
        {
            var result = await _appService.CreateProductVariantAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-product-variant-from-pos")]
        public async Task<IActionResult> CreateProductVariantFromPosAsync([FromBody] ProductTemplateCreateProductVariantFromPosRequestDto input)
        {
            var result = await _appService.CreateProductVariantFromPosAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-contextual-price")]
        public async Task<IActionResult> GetContextualPriceAsync([FromBody] ProductTemplateGetContextualPriceRequestDto input)
        {
            var result = await _appService.GetContextualPriceAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync([FromBody] ProductTemplateGetEmptyListHelpRequestDto input)
        {
            var result = await _appService.GetEmptyListHelpAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetImportTemplatesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-product-accounts")]
        public async Task<IActionResult> GetProductAccountsAsync([FromBody] ProductTemplateGetProductAccountsRequestDto input)
        {
            var result = await _appService.GetProductAccountsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-product-info-pos")]
        public async Task<IActionResult> GetProductInfoPosAsync([FromBody] ProductTemplateGetProductInfoPosRequestDto input)
        {
            var result = await _appService.GetProductInfoPosAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-single-product-variant")]
        public async Task<IActionResult> GetSingleProductVariantAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetSingleProductVariantAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("has-dynamic-attributes")]
        public async Task<IActionResult> HasDynamicAttributesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.HasDynamicAttributesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("load-product-from-pos")]
        public async Task<IActionResult> LoadProductFromPosAsync([FromBody] ProductTemplateLoadProductFromPosRequestDto input)
        {
            var result = await _appService.LoadProductFromPosAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-sequence-bottom")]
        public async Task<IActionResult> SetSequenceBottomAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetSequenceBottomAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-sequence-down")]
        public async Task<IActionResult> SetSequenceDownAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetSequenceDownAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-sequence-top")]
        public async Task<IActionResult> SetSequenceTopAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetSequenceTopAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-sequence-up")]
        public async Task<IActionResult> SetSequenceUpAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetSequenceUpAsync(ids);
            return Ok(result);
        }
    }
    
}