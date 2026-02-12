using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/human-resources/HrEmployeeSkill")]
    public partial class HrEmployeeSkillController : AbpController
    {
        protected readonly IHrEmployeeSkillAppService _appService;
        public HrEmployeeSkillController(IHrEmployeeSkillAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-save")]
        public async Task<IActionResult> SaveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SaveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-current-skills-by-employee")]
        public async Task<IActionResult> GetCurrentSkillsByEmployeeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetCurrentSkillsByEmployeeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-hr-employee-skill-modal")]
        public async Task<IActionResult> OpenHrEmployeeSkillModalAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenHrEmployeeSkillModalAsync(ids);
            return Ok(result);
        }
    }
    
}