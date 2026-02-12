using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/productivity/DiscussChannelRtcSession")]
    public partial class DiscussChannelRtcSessionController : AbpController
    {
        protected readonly IDiscussChannelRtcSessionAppService _appService;
        public DiscussChannelRtcSessionController(IDiscussChannelRtcSessionAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-disconnect")]
        public async Task<IActionResult> DisconnectAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DisconnectAsync(ids);
            return Ok(result);
        }
    }
    
}