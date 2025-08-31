using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Project
{
    public partial class ProjectTaskTypeController
    {
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] ProjectTaskTypeCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input.Default);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-active")]
        public async Task<IActionResult> ToggleActiveAsync(Guid id)
        {
            var result = await _appService.ToggleActiveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/unlink-wizard")]
        public async Task<IActionResult> UnlinkWizardAsync(Guid id, [FromBody] ProjectTaskTypeUnlinkWizardRequestDto input)
        {
            var result = await _appService.UnlinkWizardAsync(id, input.StageView);
            return Ok(result);
        }
    }
}