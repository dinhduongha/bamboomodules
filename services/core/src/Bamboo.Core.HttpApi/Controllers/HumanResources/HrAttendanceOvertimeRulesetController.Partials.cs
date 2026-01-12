using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrAttendanceOvertimeRulesetController
    {
        
        [HttpPost]
        [Route("{id}/action-regenerate-overtimes")]
        public async Task<IActionResult> ActionRegenerateOvertimesAsync(Guid id)
        {
            var result = await _appService.RegenerateOvertimesAsync(id);
            return Ok(result);
        }
    }
}