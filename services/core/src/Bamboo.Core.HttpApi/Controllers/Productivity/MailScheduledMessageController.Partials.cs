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
        [Route("{id}/open-edit-form")]
        public async Task<IActionResult> OpenEditFormAsync(Guid id)
        {
            var result = await _appService.OpenEditFormAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/post-message")]
        public async Task<IActionResult> PostMessageAsync(Guid id)
        {
            var result = await _appService.PostMessageAsync(id);
            return Ok(result);
        }
    }
}