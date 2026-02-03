using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class SnailmailLetterController
    {
        
        [HttpPost]
        [Route("cancel")]
        public async Task<IActionResult> CancelAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("snailmail-print")]
        public async Task<IActionResult> SnailmailPrintAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SnailmailPrintAsync(ids);
            return Ok(result);
        }
    }
}