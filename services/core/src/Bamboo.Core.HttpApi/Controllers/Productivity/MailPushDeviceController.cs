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
    [Route("api/v1/productivity/MailPushDevice")]
    public partial class MailPushDeviceController : AbpController
    {
        protected readonly IMailPushDeviceAppService _appService;
        public MailPushDeviceController(IMailPushDeviceAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("get-web-push-vapid-public-key")]
        public async Task<IActionResult> GetWebPushVapidPublicKeyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetWebPushVapidPublicKeyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("register-devices")]
        public async Task<IActionResult> RegisterDevicesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RegisterDevicesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("unregister-devices")]
        public async Task<IActionResult> UnregisterDevicesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnregisterDevicesAsync(ids);
            return Ok(result);
        }
    }
    
}