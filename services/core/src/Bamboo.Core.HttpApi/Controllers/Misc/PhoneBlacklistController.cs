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
    [Route("api/v1/phone-validation/PhoneBlacklist")]
    public partial class PhoneBlacklistController : AbpController
    {
        protected readonly IPhoneBlacklistAppService _appService;
        public PhoneBlacklistController(IPhoneBlacklistAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-add")]
        public async Task<IActionResult> AddAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AddAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAsync([FromBody] PhoneBlacklistAddRequestDto input)
        {
            var result = await _appService.AddAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("phone-action-blacklist-remove")]
        public async Task<IActionResult> PhoneBlacklistRemoveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PhoneBlacklistRemoveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("remove")]
        public async Task<IActionResult> RemoveAsync([FromBody] PhoneBlacklistRemoveRequestDto input)
        {
            var result = await _appService.RemoveAsync(input);
            return Ok(result);
        }
    }
    
}