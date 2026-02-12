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
    [Route("api/v1/services/ProjectProjectStage")]
    public partial class ProjectProjectStageController : AbpController
    {
        protected readonly IProjectProjectStageAppService _appService;
        public ProjectProjectStageController(IProjectProjectStageAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-unarchive")]
        public async Task<IActionResult> UnarchiveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnarchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] ProjectProjectStageCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("unlink-wizard")]
        public async Task<IActionResult> UnlinkWizardAsync([FromBody] ProjectProjectStageUnlinkWizardRequestDto input)
        {
            var result = await _appService.UnlinkWizardAsync(input);
            return Ok(result);
        }
    }
    
}