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
    [Route("api/v1/supply-chain/StockLandedCost")]
    public partial class StockLandedCostController : AbpController
    {
        protected readonly IStockLandedCostAppService _appService;
        public StockLandedCostController(IStockLandedCostAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("button-cancel")]
        public async Task<IActionResult> ButtonCancelAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonCancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-validate")]
        public async Task<IActionResult> ButtonValidateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonValidateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("compute-landed-cost")]
        public async Task<IActionResult> ComputeLandedCostAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ComputeLandedCostAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-valuation-lines")]
        public async Task<IActionResult> GetValuationLinesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetValuationLinesAsync(ids);
            return Ok(result);
        }
    }
    
}