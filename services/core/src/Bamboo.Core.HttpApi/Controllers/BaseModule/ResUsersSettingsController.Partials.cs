using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class ResUsersSettingsController
    {
        
        [HttpPost]
        [Route("{id}/set-custom-notifications")]
        public async Task<IActionResult> SetCustomNotificationsAsync(Guid id, [FromBody] ResUsersSettingsSetCustomNotificationsRequestDto input)
        {
            var result = await _appService.SetCustomNotificationsAsync(id, input.CustomNotifications);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-res-users-settings")]
        public async Task<IActionResult> SetResUsersSettingsAsync(Guid id, [FromBody] ResUsersSettingsSetResUsersSettingsRequestDto input)
        {
            var result = await _appService.SetResUsersSettingsAsync(id, input.NewSettings);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-volume-setting")]
        public async Task<IActionResult> SetVolumeSettingAsync(Guid id, [FromBody] ResUsersSettingsSetVolumeSettingRequestDto input)
        {
            var result = await _appService.SetVolumeSettingAsync(id, input.PartnerId, input.Volume, input.GuestId);
            return Ok(result);
        }
    }
}