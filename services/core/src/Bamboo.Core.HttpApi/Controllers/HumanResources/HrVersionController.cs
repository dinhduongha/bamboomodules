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
    [Route("api/v1/human-resources/HrVersion")]
    public partial class HrVersionController : AbpController
    {
        protected readonly IHrVersionAppService _appService;
        public HrVersionController(IHrVersionAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-open-version")]
        public async Task<IActionResult> OpenVersionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenVersionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-contract-finished")]
        public async Task<IActionResult> CheckContractFinishedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CheckContractFinishedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("generate-work-entries")]
        public async Task<IActionResult> GenerateWorkEntriesAsync([FromBody] HrVersionGenerateWorkEntriesRequestDto input)
        {
            var result = await _appService.GenerateWorkEntriesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-formview-action")]
        public async Task<IActionResult> GetFormviewActionAsync([FromBody] HrVersionGetFormviewActionRequestDto input)
        {
            var result = await _appService.GetFormviewActionAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-values-from-contract-template")]
        public async Task<IActionResult> GetValuesFromContractTemplateAsync([FromBody] HrVersionGetValuesFromContractTemplateRequestDto input)
        {
            var result = await _appService.GetValuesFromContractTemplateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("has-static-work-entries")]
        public async Task<IActionResult> HasStaticWorkEntriesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.HasStaticWorkEntriesAsync(ids);
            return Ok(result);
        }
    }
    
}