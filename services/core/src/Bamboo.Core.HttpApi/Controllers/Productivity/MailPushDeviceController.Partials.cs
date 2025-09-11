using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
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