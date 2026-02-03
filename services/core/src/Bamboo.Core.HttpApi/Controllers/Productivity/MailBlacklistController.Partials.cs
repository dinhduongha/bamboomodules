using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MailBlacklistController
    {
        
        [HttpPost]
        [Route("action-add")]
        public async Task<IActionResult> ActionAddAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AddAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("mail-action-blacklist-remove")]
        public async Task<IActionResult> MailActionBlacklistRemoveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.MailBlacklistRemoveAsync(ids);
            return Ok(result);
        }
    }
}