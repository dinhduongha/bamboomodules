using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrWorkEntryController
    {
        
        [HttpPost]
        [Route("action-approve-leave")]
        public async Task<IActionResult> ActionApproveLeaveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ApproveLeaveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-refuse-leave")]
        public async Task<IActionResult> ActionRefuseLeaveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RefuseLeaveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-split")]
        public async Task<IActionResult> ActionSplitAsync(HrWorkEntrySplitRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SplitAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-validate")]
        public async Task<IActionResult> ActionValidateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ValidateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-unusual-days")]
        public async Task<IActionResult> GetUnusualDaysAsync(HrWorkEntryGetUnusualDaysRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetUnusualDaysAsync(input);
            return Ok(result);
        }
    }
}