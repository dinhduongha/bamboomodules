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
        [Route("action-open-step-bank-account")]
        public async Task<IActionResult> ActionOpenStepBankAccountAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenStepBankAccountAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-step-base-document-layout")]
        public async Task<IActionResult> ActionOpenStepBaseDocumentLayoutAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenStepBaseDocumentLayoutAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-step-chart-of-accounts")]
        public async Task<IActionResult> ActionOpenStepChartOfAccountsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenStepChartOfAccountsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-step-company-data")]
        public async Task<IActionResult> ActionOpenStepCompanyDataAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenStepCompanyDataAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-step-create-invoice")]
        public async Task<IActionResult> ActionOpenStepCreateInvoiceAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenStepCreateInvoiceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-step-fiscal-year")]
        public async Task<IActionResult> ActionOpenStepFiscalYearAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenStepFiscalYearAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-step-sales-tax")]
        public async Task<IActionResult> ActionOpenStepSalesTaxAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenStepSalesTaxAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-just-done")]
        public async Task<IActionResult> ActionSetJustDoneAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetJustDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-validate-step")]
        public async Task<IActionResult> ActionValidateStepAsync(OnboardingOnboardingStepValidateStepRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ValidateStepAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-validate-step-base-document-layout")]
        public async Task<IActionResult> ActionValidateStepBaseDocumentLayoutAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ValidateStepBaseDocumentLayoutAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-step-on-onboarding-has-action")]
        public async Task<IActionResult> CheckStepOnOnboardingHasActionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CheckStepOnOnboardingHasActionAsync(ids);
            return Ok(result);
        }
    }
}