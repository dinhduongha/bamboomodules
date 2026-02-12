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
    [Route("api/v1/productivity/MailBlacklist")]
    public partial class MailBlacklistController : AbpController
    {
        protected readonly IMailBlacklistAppService _appService;
        public MailBlacklistController(IMailBlacklistAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-add")]
        public async Task<IActionResult> AddAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AddAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("mail-action-blacklist-remove")]
        public async Task<IActionResult> MailBlacklistRemoveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.MailBlacklistRemoveAsync(ids);
            return Ok(result);
        }
    }
    
}