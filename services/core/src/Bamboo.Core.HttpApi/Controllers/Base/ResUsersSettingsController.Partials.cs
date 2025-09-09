using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class ResUsersSettingsController
    {
        
        [HttpPost]
        [Route("{id}/set-custom-notifications")]
        public async Task<IActionResult> SetCustomNotificationsAsync(Guid id, [FromBody] ResUsersSettingsSetCustomNotificationsRequestDto input)
        {
            var result = await _appService.SetCustomNotificationsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-res-users-settings")]
        public async Task<IActionResult> SetResUsersSettingsAsync(Guid id, [FromBody] ResUsersSettingsSetResUsersSettingsRequestDto input)
        {
            var result = await _appService.SetResUsersSettingsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-volume-setting")]
        public async Task<IActionResult> SetVolumeSettingAsync(Guid id, [FromBody] ResUsersSettingsSetVolumeSettingRequestDto input)
        {
            var result = await _appService.SetVolumeSettingAsync(id, input);
            return Ok(result);
        }
    }
}