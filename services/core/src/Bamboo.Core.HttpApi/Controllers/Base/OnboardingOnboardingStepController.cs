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
    [Route("api/v1/onboarding/OnboardingOnboardingStep")]
    public partial class OnboardingOnboardingStepController : AbpController
    {
        protected readonly IOnboardingOnboardingStepAppService _appService;
        public OnboardingOnboardingStepController(IOnboardingOnboardingStepAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-open-step-bank-account")]
        public async Task<IActionResult> OpenStepBankAccountAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenStepBankAccountAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-step-base-document-layout")]
        public async Task<IActionResult> OpenStepBaseDocumentLayoutAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenStepBaseDocumentLayoutAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-step-chart-of-accounts")]
        public async Task<IActionResult> OpenStepChartOfAccountsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenStepChartOfAccountsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-step-company-data")]
        public async Task<IActionResult> OpenStepCompanyDataAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenStepCompanyDataAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-step-create-invoice")]
        public async Task<IActionResult> OpenStepCreateInvoiceAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenStepCreateInvoiceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-step-fiscal-year")]
        public async Task<IActionResult> OpenStepFiscalYearAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenStepFiscalYearAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-step-sales-tax")]
        public async Task<IActionResult> OpenStepSalesTaxAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenStepSalesTaxAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-just-done")]
        public async Task<IActionResult> SetJustDoneAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetJustDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-validate-step")]
        public async Task<IActionResult> ValidateStepAsync([FromBody] OnboardingOnboardingStepValidateStepRequestDto input)
        {
            var result = await _appService.ValidateStepAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-validate-step-base-document-layout")]
        public async Task<IActionResult> ValidateStepBaseDocumentLayoutAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ValidateStepBaseDocumentLayoutAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-step-on-onboarding-has-action")]
        public async Task<IActionResult> CheckStepOnOnboardingHasActionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CheckStepOnOnboardingHasActionAsync(ids);
            return Ok(result);
        }
    }
    
}