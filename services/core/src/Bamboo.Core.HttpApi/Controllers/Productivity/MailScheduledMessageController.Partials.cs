using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MailScheduledMessageController
    {
        
        [HttpPost]
        [Route("open-edit-form")]
        public async Task<IActionResult> OpenEditFormAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenEditFormAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("post-message")]
        public async Task<IActionResult> PostMessageAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PostMessageAsync(ids);
            return Ok(result);
        }
    }
}