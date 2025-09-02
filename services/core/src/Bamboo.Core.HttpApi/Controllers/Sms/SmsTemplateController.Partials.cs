using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Sms
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