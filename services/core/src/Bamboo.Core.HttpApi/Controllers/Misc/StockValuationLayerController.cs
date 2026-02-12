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
    [Route("api/v1/stock-account/StockValuationLayer")]
    public partial class StockValuationLayerController : AbpController
    {
        protected readonly IStockValuationLayerAppService _appService;
        public StockValuationLayerController(IStockValuationLayerAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-open-journal-entry")]
        public async Task<IActionResult> OpenJournalEntryAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenJournalEntryAsync(ids);
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
        [Route("action-valuation-at-date")]
        public async Task<IActionResult> ValuationAtDateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ValuationAtDateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("init")]
        public async Task<IActionResult> InitAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.InitAsync(ids);
            return Ok(result);
        }
    }
    
}