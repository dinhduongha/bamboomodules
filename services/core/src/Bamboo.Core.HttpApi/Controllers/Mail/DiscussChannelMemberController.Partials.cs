using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mail
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