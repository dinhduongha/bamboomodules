using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ResPartnerBankController
    {
        
        [HttpPost]
        [Route("action-archive-bank")]
        public async Task<IActionResult> ActionArchiveBankAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ArchiveBankAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-allocation-wizard")]
        public async Task<IActionResult> ActionOpenAllocationWizardAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenAllocationWizardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("build-qr-code-base64")]
        public async Task<IActionResult> BuildQrCodeBase64Async(ResPartnerBankBuildQrCodeBase64RequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.BuildQrCodeBase64Async(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("build-qr-code-url")]
        public async Task<IActionResult> BuildQrCodeUrlAsync(ResPartnerBankBuildQrCodeUrlRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.BuildQrCodeUrlAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-iban")]
        public async Task<IActionResult> CheckIbanAsync(ResPartnerBankCheckIbanRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckIbanAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-available-qr-methods-in-sequence")]
        public async Task<IActionResult> GetAvailableQrMethodsInSequenceAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetAvailableQrMethodsInSequenceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-bban")]
        public async Task<IActionResult> GetBbanAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetBbanAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-supported-account-types")]
        public async Task<IActionResult> GetSupportedAccountTypesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetSupportedAccountTypesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("retrieve-acc-type")]
        public async Task<IActionResult> RetrieveAccTypeAsync(ResPartnerBankRetrieveAccTypeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.RetrieveAccTypeAsync(input);
            return Ok(result);
        }
    }
}