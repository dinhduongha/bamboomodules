using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class EventTypeBoothController
    {
        
        [HttpPost]
        [Route("action-confirm")]
        public async Task<IActionResult> ActionConfirmAsync(EventTypeBoothConfirmRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ConfirmAsync(input);
            return Ok(result);
        }
    }
}