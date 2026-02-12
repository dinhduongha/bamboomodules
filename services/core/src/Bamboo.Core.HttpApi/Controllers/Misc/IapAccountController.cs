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
    [Route("api/v1/iap/IapAccount")]
    public partial class IapAccountController : AbpController
    {
        protected readonly IIapAccountAppService _appService;
        public IapAccountController(IIapAccountAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-buy-credits")]
        public async Task<IActionResult> BuyCreditsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.BuyCreditsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-registration-wizard")]
        public async Task<IActionResult> OpenRegistrationWizardAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenRegistrationWizardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-sender-name-wizard")]
        public async Task<IActionResult> OpenSenderNameWizardAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenSenderNameWizardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get")]
        public async Task<IActionResult> GetAsync([FromBody] IapAccountGetRequestDto input)
        {
            var result = await _appService.GetAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-account-id")]
        public async Task<IActionResult> GetAccountIdAsync([FromBody] IapAccountGetAccountIdRequestDto input)
        {
            var result = await _appService.GetAccountIdAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-config-account-url")]
        public async Task<IActionResult> GetConfigAccountUrlAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetConfigAccountUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-credits")]
        public async Task<IActionResult> GetCreditsAsync([FromBody] IapAccountGetCreditsRequestDto input)
        {
            var result = await _appService.GetCreditsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-credits-url")]
        public async Task<IActionResult> GetCreditsUrlAsync([FromBody] IapAccountGetCreditsUrlRequestDto input)
        {
            var result = await _appService.GetCreditsUrlAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("validate-warning-alerts")]
        public async Task<IActionResult> ValidateWarningAlertsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ValidateWarningAlertsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("web-read")]
        public async Task<IActionResult> WebReadAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.WebReadAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("web-save")]
        public async Task<IActionResult> WebSaveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.WebSaveAsync(ids);
            return Ok(result);
        }
    }
    
}