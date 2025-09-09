using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Stock
{
    public partial class StockLotController
    {
        
        [HttpPost]
        [Route("{id}/action-lot-open-quants")]
        public async Task<IActionResult> ActionLotOpenQuantsAsync(Guid id)
        {
            var result = await _appService.LotOpenQuantsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-lot-open-repairs")]
        public async Task<IActionResult> ActionLotOpenRepairsAsync(Guid id)
        {
            var result = await _appService.LotOpenRepairsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-lot-open-transfers")]
        public async Task<IActionResult> ActionLotOpenTransfersAsync(Guid id)
        {
            var result = await _appService.LotOpenTransfersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-revaluation")]
        public async Task<IActionResult> ActionRevaluationAsync(Guid id)
        {
            var result = await _appService.RevaluationAsync(id);
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
        [Route("{id}/action-view-ro")]
        public async Task<IActionResult> ActionViewRoAsync(Guid id)
        {
            var result = await _appService.ViewRoAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-so")]
        public async Task<IActionResult> ActionViewSoAsync(Guid id)
        {
            var result = await _appService.ViewSoAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-stock-valuation-layers")]
        public async Task<IActionResult> ActionViewStockValuationLayersAsync(Guid id)
        {
            var result = await _appService.ViewStockValuationLayersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] StockLotCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/generate-lot-names")]
        public async Task<IActionResult> GenerateLotNamesAsync(Guid id, [FromBody] StockLotGenerateLotNamesRequestDto input)
        {
            var result = await _appService.GenerateLotNamesAsync(id, input);
            return Ok(result);
        }
    }
}