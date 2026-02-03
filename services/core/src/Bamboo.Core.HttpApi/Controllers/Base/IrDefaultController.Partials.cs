using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class IrDefaultController
    {
        
        [HttpPost]
        [Route("discard-records")]
        public async Task<IActionResult> DiscardRecordsAsync(IrDefaultDiscardRecordsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.DiscardRecordsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("discard-values")]
        public async Task<IActionResult> DiscardValuesAsync(IrDefaultDiscardValuesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.DiscardValuesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set")]
        public async Task<IActionResult> SetAsync(IrDefaultSetRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SetAsync(input);
            return Ok(result);
        }
    }
}