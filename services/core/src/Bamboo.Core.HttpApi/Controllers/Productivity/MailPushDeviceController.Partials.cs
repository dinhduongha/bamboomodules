using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MailPushDeviceController
    {
        
        [HttpPost]
        [Route("get-web-push-vapid-public-key")]
        public async Task<IActionResult> GetWebPushVapidPublicKeyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetWebPushVapidPublicKeyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("register-devices")]
        public async Task<IActionResult> RegisterDevicesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RegisterDevicesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("unregister-devices")]
        public async Task<IActionResult> UnregisterDevicesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnregisterDevicesAsync(ids);
            return Ok(result);
        }
    }
}