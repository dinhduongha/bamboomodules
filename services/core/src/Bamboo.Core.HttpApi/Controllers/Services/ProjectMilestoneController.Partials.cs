using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ProjectMilestoneController
    {
        
        [HttpPost]
        [Route("action-view-sale-order")]
        public async Task<IActionResult> ActionViewSaleOrderAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewSaleOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-tasks")]
        public async Task<IActionResult> ActionViewTasksAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewTasksAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("toggle-is-reached")]
        public async Task<IActionResult> ToggleIsReachedAsync(ProjectMilestoneToggleIsReachedRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ToggleIsReachedAsync(input);
            return Ok(result);
        }
    }
}