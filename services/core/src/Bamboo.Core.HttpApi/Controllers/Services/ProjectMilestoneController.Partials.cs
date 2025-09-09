using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Project
{
    public partial class ProjectMilestoneController
    {
        
        [HttpPost]
        [Route("{id}/action-view-sale-order")]
        public async Task<IActionResult> ActionViewSaleOrderAsync(Guid id)
        {
            var result = await _appService.ViewSaleOrderAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-tasks")]
        public async Task<IActionResult> ActionViewTasksAsync(Guid id)
        {
            var result = await _appService.ViewTasksAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-is-reached")]
        public async Task<IActionResult> ToggleIsReachedAsync(Guid id, [FromBody] ProjectMilestoneToggleIsReachedRequestDto input)
        {
            var result = await _appService.ToggleIsReachedAsync(id, input);
            return Ok(result);
        }
    }
}