using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class CalendarAttendeeController
    {
        
        [HttpPost]
        [Route("do-accept")]
        public async Task<IActionResult> DoAcceptAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DoAcceptAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("do-decline")]
        public async Task<IActionResult> DoDeclineAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DoDeclineAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("do-tentative")]
        public async Task<IActionResult> DoTentativeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DoTentativeAsync(ids);
            return Ok(result);
        }
    }
}