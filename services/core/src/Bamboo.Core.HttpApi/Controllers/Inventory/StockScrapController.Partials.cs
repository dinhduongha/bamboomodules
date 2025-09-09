using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Stock
{
    public partial class StockScrapController
    {
        
        [HttpPost]
        [Route("{id}/action-get-stock-move-lines")]
        public async Task<IActionResult> ActionGetStockMoveLinesAsync(Guid id)
        {
            var result = await _appService.GetStockMoveLinesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-get-stock-picking")]
        public async Task<IActionResult> ActionGetStockPickingAsync(Guid id)
        {
            var result = await _appService.GetStockPickingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-validate")]
        public async Task<IActionResult> ActionValidateAsync(Guid id)
        {
            var result = await _appService.ValidateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-available-qty")]
        public async Task<IActionResult> CheckAvailableQtyAsync(Guid id)
        {
            var result = await _appService.CheckAvailableQtyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/do-replenish")]
        public async Task<IActionResult> DoReplenishAsync(Guid id, [FromBody] StockScrapDoReplenishRequestDto input)
        {
            var result = await _appService.DoReplenishAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/do-scrap")]
        public async Task<IActionResult> DoScrapAsync(Guid id)
        {
            var result = await _appService.DoScrapAsync(id);
            return Ok(result);
        }
    }
}