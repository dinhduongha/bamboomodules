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