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
    [Route("api/v1/snailmail/SnailmailLetter")]
    public partial class SnailmailLetterController : AbpController
    {
        protected readonly ISnailmailLetterAppService _appService;
        public SnailmailLetterController(ISnailmailLetterAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("cancel")]
        public async Task<IActionResult> CancelAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("snailmail-print")]
        public async Task<IActionResult> SnailmailPrintAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SnailmailPrintAsync(ids);
            return Ok(result);
        }
    }
    
}