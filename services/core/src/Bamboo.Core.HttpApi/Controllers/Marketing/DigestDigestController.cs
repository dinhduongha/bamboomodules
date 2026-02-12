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
    [Route("api/v1/marketing/DigestDigest")]
    public partial class DigestDigestController : AbpController
    {
        protected readonly IDigestDigestAppService _appService;
        public DigestDigestController(IDigestDigestAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-activate")]
        public async Task<IActionResult> ActivateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ActivateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-deactivate")]
        public async Task<IActionResult> DeactivateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DeactivateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send")]
        public async Task<IActionResult> SendAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-manual")]
        public async Task<IActionResult> SendManualAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendManualAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-periodicity")]
        public async Task<IActionResult> SetPeriodicityAsync([FromBody] DigestDigestSetPeriodicityRequestDto input)
        {
            var result = await _appService.SetPeriodicityAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-subscribe")]
        public async Task<IActionResult> SubscribeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SubscribeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unsubscribe")]
        public async Task<IActionResult> UnsubscribeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnsubscribeAsync(ids);
            return Ok(result);
        }
    }
    
}