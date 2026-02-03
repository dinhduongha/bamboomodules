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
        [Route("action-open-version")]
        public async Task<IActionResult> ActionOpenVersionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenVersionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-contract-finished")]
        public async Task<IActionResult> CheckContractFinishedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CheckContractFinishedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("generate-work-entries")]
        public async Task<IActionResult> GenerateWorkEntriesAsync(HrVersionGenerateWorkEntriesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GenerateWorkEntriesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-formview-action")]
        public async Task<IActionResult> GetFormviewActionAsync(HrVersionGetFormviewActionRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetFormviewActionAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-values-from-contract-template")]
        public async Task<IActionResult> GetValuesFromContractTemplateAsync(HrVersionGetValuesFromContractTemplateRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetValuesFromContractTemplateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("has-static-work-entries")]
        public async Task<IActionResult> HasStaticWorkEntriesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.HasStaticWorkEntriesAsync(ids);
            return Ok(result);
        }
    }
}