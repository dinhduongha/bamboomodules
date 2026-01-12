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