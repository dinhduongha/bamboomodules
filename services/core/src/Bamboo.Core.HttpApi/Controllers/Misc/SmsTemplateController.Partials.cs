using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class SmsTemplateController
    {
        
        [HttpPost]
        [Route("{id}/action-create-sidebar-action")]
        public async Task<IActionResult> ActionCreateSidebarActionAsync(Guid id)
        {
            var result = await _appService.CreateSidebarActionAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-unlink-sidebar-action")]
        public async Task<IActionResult> ActionUnlinkSidebarActionAsync(Guid id)
        {
            var result = await _appService.UnlinkSidebarActionAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] SmsTemplateCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
    }
}