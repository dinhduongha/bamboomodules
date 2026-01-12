using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrVersionController
    {
        
        [HttpPost]
        [Route("{id}/action-open-version")]
        public async Task<IActionResult> ActionOpenVersionAsync(Guid id)
        {
            var result = await _appService.OpenVersionAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-contract-finished")]
        public async Task<IActionResult> CheckContractFinishedAsync(Guid id)
        {
            var result = await _appService.CheckContractFinishedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/generate-work-entries")]
        public async Task<IActionResult> GenerateWorkEntriesAsync(Guid id, [FromBody] HrVersionGenerateWorkEntriesRequestDto input)
        {
            var result = await _appService.GenerateWorkEntriesAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-formview-action")]
        public async Task<IActionResult> GetFormviewActionAsync(Guid id, [FromBody] HrVersionGetFormviewActionRequestDto input)
        {
            var result = await _appService.GetFormviewActionAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-values-from-contract-template")]
        public async Task<IActionResult> GetValuesFromContractTemplateAsync(Guid id, [FromBody] HrVersionGetValuesFromContractTemplateRequestDto input)
        {
            var result = await _appService.GetValuesFromContractTemplateAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/has-static-work-entries")]
        public async Task<IActionResult> HasStaticWorkEntriesAsync(Guid id)
        {
            var result = await _appService.HasStaticWorkEntriesAsync(id);
            return Ok(result);
        }
    }
}