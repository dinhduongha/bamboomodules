using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class IapAccountController
    {
        
        [HttpPost]
        [Route("action-buy-credits")]
        public async Task<IActionResult> ActionBuyCreditsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.BuyCreditsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-registration-wizard")]
        public async Task<IActionResult> ActionOpenRegistrationWizardAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenRegistrationWizardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-sender-name-wizard")]
        public async Task<IActionResult> ActionOpenSenderNameWizardAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenSenderNameWizardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get")]
        public async Task<IActionResult> GetAsync(IapAccountGetRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-account-id")]
        public async Task<IActionResult> GetAccountIdAsync(IapAccountGetAccountIdRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetAccountIdAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-config-account-url")]
        public async Task<IActionResult> GetConfigAccountUrlAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetConfigAccountUrlAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-credits")]
        public async Task<IActionResult> GetCreditsAsync(IapAccountGetCreditsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetCreditsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-credits-url")]
        public async Task<IActionResult> GetCreditsUrlAsync(IapAccountGetCreditsUrlRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetCreditsUrlAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("validate-warning-alerts")]
        public async Task<IActionResult> ValidateWarningAlertsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ValidateWarningAlertsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("web-read")]
        public async Task<IActionResult> WebReadAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.WebReadAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("web-save")]
        public async Task<IActionResult> WebSaveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.WebSaveAsync(ids);
            return Ok(result);
        }
    }
}