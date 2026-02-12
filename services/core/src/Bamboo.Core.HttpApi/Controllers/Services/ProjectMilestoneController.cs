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
    [Route("api/v1/services/ProjectMilestone")]
    public partial class ProjectMilestoneController : AbpController
    {
        protected readonly IProjectMilestoneAppService _appService;
        public ProjectMilestoneController(IProjectMilestoneAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-view-sale-order")]
        public async Task<IActionResult> ViewSaleOrderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewSaleOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-tasks")]
        public async Task<IActionResult> ViewTasksAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewTasksAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("toggle-is-reached")]
        public async Task<IActionResult> ToggleIsReachedAsync([FromBody] ProjectMilestoneToggleIsReachedRequestDto input)
        {
            var result = await _appService.ToggleIsReachedAsync(input);
            return Ok(result);
        }
    }
    
}