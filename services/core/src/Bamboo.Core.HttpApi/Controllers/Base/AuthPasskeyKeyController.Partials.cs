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