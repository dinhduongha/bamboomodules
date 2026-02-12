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
    [Route("api/v1/base/ResUsersSettings")]
    public partial class ResUsersSettingsController : AbpController
    {
        protected readonly IResUsersSettingsAppService _appService;
        public ResUsersSettingsController(IResUsersSettingsAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("get-embedded-actions-settings")]
        public async Task<IActionResult> GetEmbeddedActionsSettingsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetEmbeddedActionsSettingsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-embedded-actions-setting")]
        public async Task<IActionResult> SetEmbeddedActionsSettingAsync([FromBody] ResUsersSettingsSetEmbeddedActionsSettingRequestDto input)
        {
            var result = await _appService.SetEmbeddedActionsSettingAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-res-users-settings")]
        public async Task<IActionResult> SetResUsersSettingsAsync([FromBody] ResUsersSettingsSetResUsersSettingsRequestDto input)
        {
            var result = await _appService.SetResUsersSettingsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-volume-setting")]
        public async Task<IActionResult> SetVolumeSettingAsync([FromBody] ResUsersSettingsSetVolumeSettingRequestDto input)
        {
            var result = await _appService.SetVolumeSettingAsync(input);
            return Ok(result);
        }
    }
    
}