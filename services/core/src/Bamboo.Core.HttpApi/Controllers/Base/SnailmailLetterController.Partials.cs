using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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