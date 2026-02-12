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
    [Route("api/v1/supply-chain/StockMove")]
    public partial class StockMoveController : AbpController
    {
        protected readonly IStockMoveAppService _appService;
        public StockMoveController(IStockMoveAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-add-from-catalog-byproduct")]
        public async Task<IActionResult> AddFromCatalogByproductAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AddFromCatalogByproductAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-add-from-catalog-raw")]
        public async Task<IActionResult> AddFromCatalogRawAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AddFromCatalogRawAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-add-from-catalog-repair")]
        public async Task<IActionResult> AddFromCatalogRepairAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AddFromCatalogRepairAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-add-packages")]
        public async Task<IActionResult> AddPackagesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AddPackagesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-adjust-valuation")]
        public async Task<IActionResult> AdjustValuationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AdjustValuationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-explode")]
        public async Task<IActionResult> ExplodeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ExplodeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-generate-lot-line-vals")]
        public async Task<IActionResult> GenerateLotLineValsAsync([FromBody] StockMoveGenerateLotLineValsRequestDto input)
        {
            var result = await _appService.GenerateLotLineValsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-reference")]
        public async Task<IActionResult> OpenReferenceAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenReferenceAsync(ids);
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
        [Route("action-show-details")]
        public async Task<IActionResult> ShowDetailsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ShowDetailsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-show-subcontract-details")]
        public async Task<IActionResult> ShowSubcontractDetailsAsync([FromBody] StockMoveShowSubcontractDetailsRequestDto input)
        {
            var result = await _appService.ShowSubcontractDetailsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] StockMoveCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("search-remaining-qty")]
        public async Task<IActionResult> SearchRemainingQtyAsync([FromBody] StockMoveSearchRemainingQtyRequestDto input)
        {
            var result = await _appService.SearchRemainingQtyAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("split-lots")]
        public async Task<IActionResult> SplitLotsAsync([FromBody] StockMoveSplitLotsRequestDto input)
        {
            var result = await _appService.SplitLotsAsync(input);
            return Ok(result);
        }
    }
    
}