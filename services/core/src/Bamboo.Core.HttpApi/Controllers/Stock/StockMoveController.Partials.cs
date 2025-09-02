using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Stock
{
    public partial class StockMoveController
    {
        
        [HttpPost]
        [Route("{id}/action-add-from-catalog-byproduct")]
        public async Task<IActionResult> ActionAddFromCatalogByproductAsync(Guid id)
        {
            var result = await _appService.AddFromCatalogByproductAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-add-from-catalog-raw")]
        public async Task<IActionResult> ActionAddFromCatalogRawAsync(Guid id)
        {
            var result = await _appService.AddFromCatalogRawAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-add-from-catalog-repair")]
        public async Task<IActionResult> ActionAddFromCatalogRepairAsync(Guid id)
        {
            var result = await _appService.AddFromCatalogRepairAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-assign-serial")]
        public async Task<IActionResult> ActionAssignSerialAsync(Guid id)
        {
            var result = await _appService.AssignSerialAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-explode")]
        public async Task<IActionResult> ActionExplodeAsync(Guid id)
        {
            var result = await _appService.ExplodeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-generate-lot-line-vals")]
        public async Task<IActionResult> ActionGenerateLotLineValsAsync(Guid id, [FromBody] StockMoveGenerateLotLineValsRequestDto input)
        {
            var result = await _appService.GenerateLotLineValsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-get-account-moves")]
        public async Task<IActionResult> ActionGetAccountMovesAsync(Guid id)
        {
            var result = await _appService.GetAccountMovesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-reference")]
        public async Task<IActionResult> ActionOpenReferenceAsync(Guid id)
        {
            var result = await _appService.OpenReferenceAsync(id);
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
        [Route("{id}/action-show-details")]
        public async Task<IActionResult> ActionShowDetailsAsync(Guid id)
        {
            var result = await _appService.ShowDetailsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-show-subcontract-details")]
        public async Task<IActionResult> ActionShowSubcontractDetailsAsync(Guid id)
        {
            var result = await _appService.ShowSubcontractDetailsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] StockMoveCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/init")]
        public async Task<IActionResult> InitAsync(Guid id)
        {
            var result = await _appService.InitAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/product-price-update-before-done")]
        public async Task<IActionResult> ProductPriceUpdateBeforeDoneAsync(Guid id, [FromBody] StockMoveProductPriceUpdateBeforeDoneRequestDto input)
        {
            var result = await _appService.ProductPriceUpdateBeforeDoneAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/split-lots")]
        public async Task<IActionResult> SplitLotsAsync(Guid id, [FromBody] StockMoveSplitLotsRequestDto input)
        {
            var result = await _appService.SplitLotsAsync(id, input);
            return Ok(result);
        }
    }
}