using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Mail
{
    public partial class MailPushDeviceController
    {
        
        [HttpPost]
        [Route("{id}/get-web-push-vapid-public-key")]
        public async Task<IActionResult> GetWebPushVapidPublicKeyAsync(Guid id)
        {
            var result = await _appService.GetWebPushVapidPublicKeyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/register-devices")]
        public async Task<IActionResult> RegisterDevicesAsync(Guid id)
        {
            var result = await _appService.RegisterDevicesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/unregister-devices")]
        public async Task<IActionResult> UnregisterDevicesAsync(Guid id)
        {
            var result = await _appService.UnregisterDevicesAsync(id);
            return Ok(result);
        }
    }
}