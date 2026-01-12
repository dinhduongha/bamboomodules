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
        [Route("{id}/action-archive-bank")]
        public async Task<IActionResult> ActionArchiveBankAsync(Guid id)
        {
            var result = await _appService.ArchiveBankAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-allocation-wizard")]
        public async Task<IActionResult> ActionOpenAllocationWizardAsync(Guid id)
        {
            var result = await _appService.OpenAllocationWizardAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/build-qr-code-base64")]
        public async Task<IActionResult> BuildQrCodeBase64Async(Guid id, [FromBody] ResPartnerBankBuildQrCodeBase64RequestDto input)
        {
            var result = await _appService.BuildQrCodeBase64Async(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/build-qr-code-url")]
        public async Task<IActionResult> BuildQrCodeUrlAsync(Guid id, [FromBody] ResPartnerBankBuildQrCodeUrlRequestDto input)
        {
            var result = await _appService.BuildQrCodeUrlAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-iban")]
        public async Task<IActionResult> CheckIbanAsync(Guid id, [FromBody] ResPartnerBankCheckIbanRequestDto input)
        {
            var result = await _appService.CheckIbanAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-available-qr-methods-in-sequence")]
        public async Task<IActionResult> GetAvailableQrMethodsInSequenceAsync(Guid id)
        {
            var result = await _appService.GetAvailableQrMethodsInSequenceAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-bban")]
        public async Task<IActionResult> GetBbanAsync(Guid id)
        {
            var result = await _appService.GetBbanAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-supported-account-types")]
        public async Task<IActionResult> GetSupportedAccountTypesAsync(Guid id)
        {
            var result = await _appService.GetSupportedAccountTypesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/retrieve-acc-type")]
        public async Task<IActionResult> RetrieveAccTypeAsync(Guid id, [FromBody] ResPartnerBankRetrieveAccTypeRequestDto input)
        {
            var result = await _appService.RetrieveAccTypeAsync(id, input);
            return Ok(result);
        }
    }
}