using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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