using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ResUsersSettingsController
    {
        
        [HttpPost]
        [Route("get-embedded-actions-settings")]
        public async Task<IActionResult> GetEmbeddedActionsSettingsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetEmbeddedActionsSettingsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-embedded-actions-setting")]
        public async Task<IActionResult> SetEmbeddedActionsSettingAsync(ResUsersSettingsSetEmbeddedActionsSettingRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SetEmbeddedActionsSettingAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-res-users-settings")]
        public async Task<IActionResult> SetResUsersSettingsAsync(ResUsersSettingsSetResUsersSettingsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SetResUsersSettingsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-volume-setting")]
        public async Task<IActionResult> SetVolumeSettingAsync(ResUsersSettingsSetVolumeSettingRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SetVolumeSettingAsync(input);
            return Ok(result);
        }
    }
}