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
    [Route("api/v1/human-resources/HrContract")]
    public partial class HrContractController : AbpController
    {
        protected readonly IHrContractAppService _appService;
        public HrContractController(IHrContractAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-open-contract-form")]
        public async Task<IActionResult> OpenContractFormAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenContractFormAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-contract-history")]
        public async Task<IActionResult> OpenContractHistoryAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenContractHistoryAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-contract-list")]
        public async Task<IActionResult> OpenContractListAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenContractListAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("generate-work-entries")]
        public async Task<IActionResult> GenerateWorkEntriesAsync([FromBody] HrContractGenerateWorkEntriesRequestDto input)
        {
            var result = await _appService.GenerateWorkEntriesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-all-structures")]
        public async Task<IActionResult> GetAllStructuresAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetAllStructuresAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-attribute")]
        public async Task<IActionResult> GetAttributeAsync([FromBody] HrContractGetAttributeRequestDto input)
        {
            var result = await _appService.GetAttributeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("has-static-work-entries")]
        public async Task<IActionResult> HasStaticWorkEntriesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.HasStaticWorkEntriesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-attribute-value")]
        public async Task<IActionResult> SetAttributeValueAsync([FromBody] HrContractSetAttributeValueRequestDto input)
        {
            var result = await _appService.SetAttributeValueAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-state")]
        public async Task<IActionResult> UpdateStateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UpdateStateAsync(ids);
            return Ok(result);
        }
    }
    
}