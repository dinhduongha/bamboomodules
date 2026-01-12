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
        [Route("{id}/action-approve")]
        public async Task<IActionResult> ActionApproveAsync(Guid id)
        {
            var result = await _appService.ApproveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-refuse")]
        public async Task<IActionResult> ActionRefuseAsync(Guid id)
        {
            var result = await _appService.RefuseAsync(id);
            return Ok(result);
        }
    }
}