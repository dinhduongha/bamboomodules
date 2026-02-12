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
    [Route("api/v1/base/IrSequence")]
    public partial class IrSequenceController : AbpController
    {
        protected readonly IIrSequenceAppService _appService;
        public IrSequenceController(IIrSequenceAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("get-next-char")]
        public async Task<IActionResult> GetNextCharAsync([FromBody] IrSequenceGetNextCharRequestDto input)
        {
            var result = await _appService.GetNextCharAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("next-by-code")]
        public async Task<IActionResult> NextByCodeAsync([FromBody] IrSequenceNextByCodeRequestDto input)
        {
            var result = await _appService.NextByCodeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("next-by-id")]
        public async Task<IActionResult> NextByIdAsync([FromBody] IrSequenceNextByIdRequestDto input)
        {
            var result = await _appService.NextByIdAsync(input);
            return Ok(result);
        }
    }
    
}