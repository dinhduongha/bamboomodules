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
        [Route("{id}/get-embedded-actions-settings")]
        public async Task<IActionResult> GetEmbeddedActionsSettingsAsync(Guid id)
        {
            var result = await _appService.GetEmbeddedActionsSettingsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-embedded-actions-setting")]
        public async Task<IActionResult> SetEmbeddedActionsSettingAsync(Guid id, [FromBody] ResUsersSettingsSetEmbeddedActionsSettingRequestDto input)
        {
            var result = await _appService.SetEmbeddedActionsSettingAsync(id, input);
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