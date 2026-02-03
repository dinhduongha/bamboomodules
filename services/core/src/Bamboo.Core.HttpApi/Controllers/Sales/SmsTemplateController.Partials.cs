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
        [Route("action-create-sidebar-action")]
        public async Task<IActionResult> ActionCreateSidebarActionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreateSidebarActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unlink-sidebar-action")]
        public async Task<IActionResult> ActionUnlinkSidebarActionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnlinkSidebarActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(SmsTemplateCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
    }
}