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
    [Route("api/v1/supply-chain/StockScrap")]
    public partial class StockScrapController : AbpController
    {
        protected readonly IStockScrapAppService _appService;
        public StockScrapController(IStockScrapAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-get-stock-move-lines")]
        public async Task<IActionResult> GetStockMoveLinesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetStockMoveLinesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-get-stock-picking")]
        public async Task<IActionResult> GetStockPickingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetStockPickingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-validate")]
        public async Task<IActionResult> ValidateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ValidateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-available-qty")]
        public async Task<IActionResult> CheckAvailableQtyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CheckAvailableQtyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("do-replenish")]
        public async Task<IActionResult> DoReplenishAsync([FromBody] StockScrapDoReplenishRequestDto input)
        {
            var result = await _appService.DoReplenishAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("do-scrap")]
        public async Task<IActionResult> DoScrapAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DoScrapAsync(ids);
            return Ok(result);
        }
    }
    
}