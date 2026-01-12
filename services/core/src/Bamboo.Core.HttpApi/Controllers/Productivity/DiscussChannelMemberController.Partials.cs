using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class DiscussChannelMemberController
    {
        // v18-COMPAT
        // [HttpPost]
        // [Route("{id}/init")]
        // public async Task<IActionResult> InitAsync(Guid id)
        // {
        //     var result = await _appService.InitAsync(id);
        //     return Ok(result);
        // }

        // [HttpPost]
        // [Route("{id}/set-custom-notifications")]
        // public async Task<IActionResult> SetCustomNotificationsAsync(Guid id, [FromBody] DiscussChannelMemberSetCustomNotificationsRequestDto input)
        // {
        //     var result = await _appService.SetCustomNotificationsAsync(id, input);
        //     return Ok(result);
        // }
    }
}