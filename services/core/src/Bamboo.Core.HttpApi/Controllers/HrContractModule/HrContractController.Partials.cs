using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.HrContractModule
{
    public partial class HrContractController
    {
        
        [HttpPost]
        [Route("{id}/action-open-contract-form")]
        public async Task<IActionResult> ActionOpenContractFormAsync(Guid id)
        {
            var result = await _appService.OpenContractFormAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-contract-history")]
        public async Task<IActionResult> ActionOpenContractHistoryAsync(Guid id)
        {
            var result = await _appService.OpenContractHistoryAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-contract-list")]
        public async Task<IActionResult> ActionOpenContractListAsync(Guid id)
        {
            var result = await _appService.OpenContractListAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/generate-work-entries")]
        public async Task<IActionResult> GenerateWorkEntriesAsync(Guid id, [FromBody] HrContractGenerateWorkEntriesRequestDto input)
        {
            var result = await _appService.GenerateWorkEntriesAsync(id, input.DateStart, input.DateStop, input.Force);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-all-structures")]
        public async Task<IActionResult> GetAllStructuresAsync(Guid id)
        {
            var result = await _appService.GetAllStructuresAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-attribute")]
        public async Task<IActionResult> GetAttributeAsync(Guid id, [FromBody] HrContractGetAttributeRequestDto input)
        {
            var result = await _appService.GetAttributeAsync(id, input.Code, input.Attribute);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/has-static-work-entries")]
        public async Task<IActionResult> HasStaticWorkEntriesAsync(Guid id)
        {
            var result = await _appService.HasStaticWorkEntriesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/set-attribute-value")]
        public async Task<IActionResult> SetAttributeValueAsync(Guid id, [FromBody] HrContractSetAttributeValueRequestDto input)
        {
            var result = await _appService.SetAttributeValueAsync(id, input.Code, input.Active);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/update-state")]
        public async Task<IActionResult> UpdateStateAsync(Guid id)
        {
            var result = await _appService.UpdateStateAsync(id);
            return Ok(result);
        }
    }
}