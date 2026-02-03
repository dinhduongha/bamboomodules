using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class StockScrapController
    {
        
        [HttpPost]
        [Route("action-get-stock-move-lines")]
        public async Task<IActionResult> ActionGetStockMoveLinesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetStockMoveLinesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-get-stock-picking")]
        public async Task<IActionResult> ActionGetStockPickingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetStockPickingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-validate")]
        public async Task<IActionResult> ActionValidateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ValidateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-available-qty")]
        public async Task<IActionResult> CheckAvailableQtyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CheckAvailableQtyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("do-replenish")]
        public async Task<IActionResult> DoReplenishAsync(StockScrapDoReplenishRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.DoReplenishAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("do-scrap")]
        public async Task<IActionResult> DoScrapAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DoScrapAsync(ids);
            return Ok(result);
        }
    }
}