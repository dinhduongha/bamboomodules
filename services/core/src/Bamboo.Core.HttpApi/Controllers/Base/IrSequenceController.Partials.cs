using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class IrSequenceController
    {
        
        [HttpPost]
        [Route("get-next-char")]
        public async Task<IActionResult> GetNextCharAsync(IrSequenceGetNextCharRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetNextCharAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("next-by-code")]
        public async Task<IActionResult> NextByCodeAsync(IrSequenceNextByCodeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.NextByCodeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("next-by-id")]
        public async Task<IActionResult> NextByIdAsync(IrSequenceNextByIdRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.NextByIdAsync(input);
            return Ok(result);
        }
    }
}