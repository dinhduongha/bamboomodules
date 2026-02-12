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
    [Route("api/v1/sales/SmsTemplate")]
    public partial class SmsTemplateController : AbpController
    {
        protected readonly ISmsTemplateAppService _appService;
        public SmsTemplateController(ISmsTemplateAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-create-sidebar-action")]
        public async Task<IActionResult> CreateSidebarActionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateSidebarActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unlink-sidebar-action")]
        public async Task<IActionResult> UnlinkSidebarActionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnlinkSidebarActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] SmsTemplateCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
    }
    
}