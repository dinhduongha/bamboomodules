using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrAttendanceOvertimeLineController
    {
        
        [HttpPost]
        [Route("action-approve")]
        public async Task<IActionResult> ActionApproveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ApproveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-refuse")]
        public async Task<IActionResult> ActionRefuseAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RefuseAsync(ids);
            return Ok(result);
        }
    }
}