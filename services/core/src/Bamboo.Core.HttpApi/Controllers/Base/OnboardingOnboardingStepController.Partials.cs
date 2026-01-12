using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class OnboardingOnboardingStepController
    {
        
        [HttpPost]
        [Route("{id}/action-open-step-bank-account")]
        public async Task<IActionResult> ActionOpenStepBankAccountAsync(Guid id)
        {
            var result = await _appService.OpenStepBankAccountAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-step-base-document-layout")]
        public async Task<IActionResult> ActionOpenStepBaseDocumentLayoutAsync(Guid id)
        {
            var result = await _appService.OpenStepBaseDocumentLayoutAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-step-chart-of-accounts")]
        public async Task<IActionResult> ActionOpenStepChartOfAccountsAsync(Guid id)
        {
            var result = await _appService.OpenStepChartOfAccountsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-step-company-data")]
        public async Task<IActionResult> ActionOpenStepCompanyDataAsync(Guid id)
        {
            var result = await _appService.OpenStepCompanyDataAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-step-create-invoice")]
        public async Task<IActionResult> ActionOpenStepCreateInvoiceAsync(Guid id)
        {
            var result = await _appService.OpenStepCreateInvoiceAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-step-fiscal-year")]
        public async Task<IActionResult> ActionOpenStepFiscalYearAsync(Guid id)
        {
            var result = await _appService.OpenStepFiscalYearAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-step-sales-tax")]
        public async Task<IActionResult> ActionOpenStepSalesTaxAsync(Guid id)
        {
            var result = await _appService.OpenStepSalesTaxAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-set-just-done")]
        public async Task<IActionResult> ActionSetJustDoneAsync(Guid id)
        {
            var result = await _appService.SetJustDoneAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-validate-step")]
        public async Task<IActionResult> ActionValidateStepAsync(Guid id, [FromBody] OnboardingOnboardingStepValidateStepRequestDto input)
        {
            var result = await _appService.ValidateStepAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-validate-step-base-document-layout")]
        public async Task<IActionResult> ActionValidateStepBaseDocumentLayoutAsync(Guid id)
        {
            var result = await _appService.ValidateStepBaseDocumentLayoutAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-step-on-onboarding-has-action")]
        public async Task<IActionResult> CheckStepOnOnboardingHasActionAsync(Guid id)
        {
            var result = await _appService.CheckStepOnOnboardingHasActionAsync(id);
            return Ok(result);
        }
    }
}