using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class AuthPasskeyKeyController
    {
        
        [HttpPost]
        [Route("action-delete-passkey")]
        public async Task<IActionResult> ActionDeletePasskeyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DeletePasskeyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-rename-passkey")]
        public async Task<IActionResult> ActionRenamePasskeyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RenamePasskeyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("init")]
        public async Task<IActionResult> InitAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.InitAsync(ids);
            return Ok(result);
        }
    }
}