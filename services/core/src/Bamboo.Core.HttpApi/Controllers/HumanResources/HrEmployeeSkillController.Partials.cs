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
        [Route("{id}/action-save")]
        public async Task<IActionResult> ActionSaveAsync(Guid id)
        {
            var result = await _appService.SaveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-current-skills-by-employee")]
        public async Task<IActionResult> GetCurrentSkillsByEmployeeAsync(Guid id)
        {
            var result = await _appService.GetCurrentSkillsByEmployeeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-hr-employee-skill-modal")]
        public async Task<IActionResult> OpenHrEmployeeSkillModalAsync(Guid id)
        {
            var result = await _appService.OpenHrEmployeeSkillModalAsync(id);
            return Ok(result);
        }
    }
}