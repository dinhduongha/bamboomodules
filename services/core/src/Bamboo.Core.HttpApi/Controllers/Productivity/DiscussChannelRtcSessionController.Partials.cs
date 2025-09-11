using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
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