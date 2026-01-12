using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class StockRuleController
    {
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] StockRuleCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/run")]
        public async Task<IActionResult> RunAsync(Guid id, [FromBody] StockRuleRunRequestDto input)
        {
            var result = await _appService.RunAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/run-scheduler")]
        public async Task<IActionResult> RunSchedulerAsync(Guid id, [FromBody] StockRuleRunSchedulerRequestDto input)
        {
            var result = await _appService.RunSchedulerAsync(id, input);
            return Ok(result);
        }
    }
}