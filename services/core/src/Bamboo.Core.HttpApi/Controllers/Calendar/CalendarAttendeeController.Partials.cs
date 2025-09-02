using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Calendar
{
    public partial class CalendarAttendeeController
    {
        
        [HttpPost]
        [Route("{id}/do-accept")]
        public async Task<IActionResult> DoAcceptAsync(Guid id)
        {
            var result = await _appService.DoAcceptAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/do-decline")]
        public async Task<IActionResult> DoDeclineAsync(Guid id)
        {
            var result = await _appService.DoDeclineAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/do-tentative")]
        public async Task<IActionResult> DoTentativeAsync(Guid id)
        {
            var result = await _appService.DoTentativeAsync(id);
            return Ok(result);
        }
    }
}