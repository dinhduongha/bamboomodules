using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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