using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Iap
{
    public partial class IapAccountController
    {
        
        [HttpPost]
        [Route("{id}/action-buy-credits")]
        public async Task<IActionResult> ActionBuyCreditsAsync(Guid id)
        {
            var result = await _appService.BuyCreditsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-registration-wizard")]
        public async Task<IActionResult> ActionOpenRegistrationWizardAsync(Guid id)
        {
            var result = await _appService.OpenRegistrationWizardAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-sender-name-wizard")]
        public async Task<IActionResult> ActionOpenSenderNameWizardAsync(Guid id)
        {
            var result = await _appService.OpenSenderNameWizardAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get")]
        public async Task<IActionResult> GetAsync(Guid id, [FromBody] IapAccountGetRequestDto input)
        {
            var result = await _appService.GetAsync(id, input.ServiceName, input.ForceCreate);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-account-id")]
        public async Task<IActionResult> GetAccountIdAsync(Guid id, [FromBody] IapAccountGetAccountIdRequestDto input)
        {
            var result = await _appService.GetAccountIdAsync(id, input.ServiceName);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-config-account-url")]
        public async Task<IActionResult> GetConfigAccountUrlAsync(Guid id)
        {
            var result = await _appService.GetConfigAccountUrlAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-credits")]
        public async Task<IActionResult> GetCreditsAsync(Guid id, [FromBody] IapAccountGetCreditsRequestDto input)
        {
            var result = await _appService.GetCreditsAsync(id, input.ServiceName);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-credits-url")]
        public async Task<IActionResult> GetCreditsUrlAsync(Guid id, [FromBody] IapAccountGetCreditsUrlRequestDto input)
        {
            var result = await _appService.GetCreditsUrlAsync(id, input.ServiceName, input.BaseUrl, input.Credit, input.Trial, input.AccountToken);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/is-running-test-suite")]
        public async Task<IActionResult> IsRunningTestSuiteAsync(Guid id)
        {
            var result = await _appService.IsRunningTestSuiteAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/validate-warning-alerts")]
        public async Task<IActionResult> ValidateWarningAlertsAsync(Guid id)
        {
            var result = await _appService.ValidateWarningAlertsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/web-read")]
        public async Task<IActionResult> WebReadAsync(Guid id)
        {
            var result = await _appService.WebReadAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/web-save")]
        public async Task<IActionResult> WebSaveAsync(Guid id)
        {
            var result = await _appService.WebSaveAsync(id);
            return Ok(result);
        }
    }
}