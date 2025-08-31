using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.StockLandedCosts
{
    public partial class StockLandedCostController
    {
        
        [HttpPost]
        [Route("{id}/action-view-stock-valuation-layers")]
        public async Task<IActionResult> ActionViewStockValuationLayersAsync(Guid id)
        {
            var result = await _appService.ViewStockValuationLayersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-cancel")]
        public async Task<IActionResult> ButtonCancelAsync(Guid id)
        {
            var result = await _appService.ButtonCancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-validate")]
        public async Task<IActionResult> ButtonValidateAsync(Guid id)
        {
            var result = await _appService.ButtonValidateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/compute-landed-cost")]
        public async Task<IActionResult> ComputeLandedCostAsync(Guid id)
        {
            var result = await _appService.ComputeLandedCostAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-valuation-lines")]
        public async Task<IActionResult> GetValuationLinesAsync(Guid id)
        {
            var result = await _appService.GetValuationLinesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/reconcile-landed-cost")]
        public async Task<IActionResult> ReconcileLandedCostAsync(Guid id)
        {
            var result = await _appService.ReconcileLandedCostAsync(id);
            return Ok(result);
        }
    }
}