using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class DiscussChannelMemberController
    {
        
        [HttpPost]
        [Route("{id}/init")]
        public async Task<IActionResult> InitAsync(Guid id)
        {
            var result = await _appService.InitAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-custom-notifications")]
        public async Task<IActionResult> SetCustomNotificationsAsync(Guid id, [FromBody] DiscussChannelMemberSetCustomNotificationsRequestDto input)
        {
            var result = await _appService.SetCustomNotificationsAsync(id, input);
            return Ok(result);
        }
    }
}