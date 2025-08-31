using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Snailmail
{
    public partial class SnailmailLetterController
    {
        
        [HttpPost]
        [Route("{id}/cancel")]
        public async Task<IActionResult> CancelAsync(Guid id)
        {
            var result = await _appService.CancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/snailmail-print")]
        public async Task<IActionResult> SnailmailPrintAsync(Guid id)
        {
            var result = await _appService.SnailmailPrintAsync(id);
            return Ok(result);
        }
    }
}