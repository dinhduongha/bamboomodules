using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrEmployeeSkillController
    {
        
        [HttpPost]
        [Route("action-save")]
        public async Task<IActionResult> ActionSaveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SaveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-current-skills-by-employee")]
        public async Task<IActionResult> GetCurrentSkillsByEmployeeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetCurrentSkillsByEmployeeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-hr-employee-skill-modal")]
        public async Task<IActionResult> OpenHrEmployeeSkillModalAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenHrEmployeeSkillModalAsync(ids);
            return Ok(result);
        }
    }
}