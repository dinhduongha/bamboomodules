using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.HrWorkEntryModule
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
        [Route("{id}/action-validate")]
        public async Task<IActionResult> ActionValidateAsync(Guid id)
        {
            var result = await _appService.ValidateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/init")]
        public async Task<IActionResult> InitAsync(Guid id)
        {
            var result = await _appService.InitAsync(id);
            return Ok(result);
        }
    }
}