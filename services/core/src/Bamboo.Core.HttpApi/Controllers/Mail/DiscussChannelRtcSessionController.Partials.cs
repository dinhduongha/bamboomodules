using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    public partial class DiscussChannelRtcSessionController
    {
        
        [HttpPost]
        [Route("{id}/action-disconnect")]
        public async Task<IActionResult> ActionDisconnectAsync(Guid id)
        {
            var result = await _appService.DisconnectAsync(id);
            return Ok(result);
        }
    }
}