using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    public partial class MailBlacklistController
    {
        
        [HttpPost]
        [Route("{id}/action-add")]
        public async Task<IActionResult> ActionAddAsync(Guid id)
        {
            var result = await _appService.AddAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/mail-action-blacklist-remove")]
        public async Task<IActionResult> MailActionBlacklistRemoveAsync(Guid id)
        {
            var result = await _appService.MailBlacklistRemoveAsync(id);
            return Ok(result);
        }
    }
}