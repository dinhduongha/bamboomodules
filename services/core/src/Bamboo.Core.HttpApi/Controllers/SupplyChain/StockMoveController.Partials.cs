using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class StockMoveController
    {
        
        [HttpPost]
        [Route("action-add-from-catalog-byproduct")]
        public async Task<IActionResult> ActionAddFromCatalogByproductAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AddFromCatalogByproductAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-add-from-catalog-raw")]
        public async Task<IActionResult> ActionAddFromCatalogRawAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AddFromCatalogRawAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-add-from-catalog-repair")]
        public async Task<IActionResult> ActionAddFromCatalogRepairAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AddFromCatalogRepairAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-add-packages")]
        public async Task<IActionResult> ActionAddPackagesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AddPackagesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-adjust-valuation")]
        public async Task<IActionResult> ActionAdjustValuationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AdjustValuationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-explode")]
        public async Task<IActionResult> ActionExplodeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ExplodeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-generate-lot-line-vals")]
        public async Task<IActionResult> ActionGenerateLotLineValsAsync(StockMoveGenerateLotLineValsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GenerateLotLineValsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-reference")]
        public async Task<IActionResult> ActionOpenReferenceAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenReferenceAsync(ids);
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
        [Route("action-show-details")]
        public async Task<IActionResult> ActionShowDetailsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ShowDetailsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-show-subcontract-details")]
        public async Task<IActionResult> ActionShowSubcontractDetailsAsync(StockMoveShowSubcontractDetailsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ShowSubcontractDetailsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(StockMoveCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("search-remaining-qty")]
        public async Task<IActionResult> SearchRemainingQtyAsync(StockMoveSearchRemainingQtyRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SearchRemainingQtyAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("split-lots")]
        public async Task<IActionResult> SplitLotsAsync(StockMoveSplitLotsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SplitLotsAsync(input);
            return Ok(result);
        }
    }
}