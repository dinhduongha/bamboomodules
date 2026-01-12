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
        [Route("{id}/action-approve-leave")]
        public async Task<IActionResult> ActionApproveLeaveAsync(Guid id)
        {
            var result = await _appService.ApproveLeaveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-refuse-leave")]
        public async Task<IActionResult> ActionRefuseLeaveAsync(Guid id)
        {
            var result = await _appService.RefuseLeaveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-split")]
        public async Task<IActionResult> ActionSplitAsync(Guid id, [FromBody] HrWorkEntrySplitRequestDto input)
        {
            var result = await _appService.SplitAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-validate")]
        public async Task<IActionResult> ActionValidateAsync(Guid id)
        {
            var result = await _appService.ValidateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-unusual-days")]
        public async Task<IActionResult> GetUnusualDaysAsync(Guid id, [FromBody] HrWorkEntryGetUnusualDaysRequestDto input)
        {
            var result = await _appService.GetUnusualDaysAsync(id, input);
            return Ok(result);
        }
    }
}