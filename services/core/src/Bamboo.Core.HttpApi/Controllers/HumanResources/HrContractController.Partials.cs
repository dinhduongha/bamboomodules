using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrContractController
    {
        
        [HttpPost]
        [Route("action-open-contract-form")]
        public async Task<IActionResult> ActionOpenContractFormAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenContractFormAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-contract-history")]
        public async Task<IActionResult> ActionOpenContractHistoryAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenContractHistoryAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-contract-list")]
        public async Task<IActionResult> ActionOpenContractListAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenContractListAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("generate-work-entries")]
        public async Task<IActionResult> GenerateWorkEntriesAsync(HrContractGenerateWorkEntriesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GenerateWorkEntriesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-all-structures")]
        public async Task<IActionResult> GetAllStructuresAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetAllStructuresAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-attribute")]
        public async Task<IActionResult> GetAttributeAsync(HrContractGetAttributeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetAttributeAsync(input);
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
        
        [HttpPost]
        [Route("set-attribute-value")]
        public async Task<IActionResult> SetAttributeValueAsync(HrContractSetAttributeValueRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SetAttributeValueAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-state")]
        public async Task<IActionResult> UpdateStateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UpdateStateAsync(ids);
            return Ok(result);
        }
    }
}