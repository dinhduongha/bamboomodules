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
    [Route("api/v1/base/ResGroups")]
    public partial class ResGroupsController : AbpController
    {
        protected readonly IResGroupsAppService _appService;
        public ResGroupsController(IResGroupsAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-show-all-users")]
        public async Task<IActionResult> ShowAllUsersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ShowAllUsersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] ResGroupsCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-application-groups")]
        public async Task<IActionResult> GetApplicationGroupsAsync([FromBody] ResGroupsGetApplicationGroupsRequestDto input)
        {
            var result = await _appService.GetApplicationGroupsAsync(input);
            return Ok(result);
        }
    }
    
}