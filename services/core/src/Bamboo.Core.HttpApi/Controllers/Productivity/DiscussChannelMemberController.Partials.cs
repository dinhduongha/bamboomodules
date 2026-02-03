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

        // [HttpPost]
        // [Route("init")]
        // public async Task<IActionResult> InitAsync(Guid[] ids)
        // {
        //     // content_action has_extra_params: False
        //     var result = await _appService.InitAsync(ids);
        //     return Ok(result);
        // }

        // [HttpPost]
        // [Route("set-custom-notifications")]
        // public async Task<IActionResult> SetCustomNotificationsAsync(DiscussChannelMemberSetCustomNotificationsRequestDto input)
        // {
        //     // content_action has_extra_params: True
        //     var result = await _appService.SetCustomNotificationsAsync(input);
        //     return Ok(result);
        // }
    }
}