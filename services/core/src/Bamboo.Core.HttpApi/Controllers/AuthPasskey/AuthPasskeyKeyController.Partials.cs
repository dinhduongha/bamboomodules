using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.AuthPasskey
{
    public partial class AuthPasskeyKeyController
    {
        
        [HttpPost]
        [Route("{id}/action-delete-passkey")]
        public async Task<IActionResult> ActionDeletePasskeyAsync(Guid id)
        {
            var result = await _appService.DeletePasskeyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-rename-passkey")]
        public async Task<IActionResult> ActionRenamePasskeyAsync(Guid id)
        {
            var result = await _appService.RenamePasskeyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/init")]
        public async Task<IActionResult> InitAsync(Guid id)
        {
            var result = await _appService.InitAsync(id);
            return Ok(result);
        }
    }
}