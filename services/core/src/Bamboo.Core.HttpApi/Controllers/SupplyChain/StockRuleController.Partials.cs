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
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(StockRuleCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("run")]
        public async Task<IActionResult> RunAsync(StockRuleRunRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.RunAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("run-scheduler")]
        public async Task<IActionResult> RunSchedulerAsync(StockRuleRunSchedulerRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.RunSchedulerAsync(input);
            return Ok(result);
        }
    }
}