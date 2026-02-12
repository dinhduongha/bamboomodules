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
    [Route("api/v1/base/ResPartnerBank")]
    public partial class ResPartnerBankController : AbpController
    {
        protected readonly IResPartnerBankAppService _appService;
        public ResPartnerBankController(IResPartnerBankAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-archive-bank")]
        public async Task<IActionResult> ArchiveBankAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ArchiveBankAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-allocation-wizard")]
        public async Task<IActionResult> OpenAllocationWizardAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenAllocationWizardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("build-qr-code-base64")]
        public async Task<IActionResult> BuildQrCodeBase64Async([FromBody] ResPartnerBankBuildQrCodeBase64RequestDto input)
        {
            var result = await _appService.BuildQrCodeBase64Async(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("build-qr-code-url")]
        public async Task<IActionResult> BuildQrCodeUrlAsync([FromBody] ResPartnerBankBuildQrCodeUrlRequestDto input)
        {
            var result = await _appService.BuildQrCodeUrlAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-iban")]
        public async Task<IActionResult> CheckIbanAsync([FromBody] ResPartnerBankCheckIbanRequestDto input)
        {
            var result = await _appService.CheckIbanAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-available-qr-methods-in-sequence")]
        public async Task<IActionResult> GetAvailableQrMethodsInSequenceAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetAvailableQrMethodsInSequenceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-bban")]
        public async Task<IActionResult> GetBbanAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetBbanAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-supported-account-types")]
        public async Task<IActionResult> GetSupportedAccountTypesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetSupportedAccountTypesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("retrieve-acc-type")]
        public async Task<IActionResult> RetrieveAccTypeAsync([FromBody] ResPartnerBankRetrieveAccTypeRequestDto input)
        {
            var result = await _appService.RetrieveAccTypeAsync(input);
            return Ok(result);
        }
    }
    
}