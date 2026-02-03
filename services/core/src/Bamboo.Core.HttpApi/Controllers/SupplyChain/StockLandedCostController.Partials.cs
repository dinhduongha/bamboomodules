using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class StockLandedCostController
    {
        
        [HttpPost]
        [Route("button-cancel")]
        public async Task<IActionResult> ButtonCancelAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonCancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-validate")]
        public async Task<IActionResult> ButtonValidateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonValidateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("compute-landed-cost")]
        public async Task<IActionResult> ComputeLandedCostAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ComputeLandedCostAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-valuation-lines")]
        public async Task<IActionResult> GetValuationLinesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetValuationLinesAsync(ids);
            return Ok(result);
        }
    }
}