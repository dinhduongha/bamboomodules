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
    [Route("api/v1/human-resources/GamificationBadge")]
    public partial class GamificationBadgeController : AbpController
    {
        protected readonly IGamificationBadgeAppService _appService;
        public GamificationBadgeController(IGamificationBadgeAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("check-granting")]
        public async Task<IActionResult> CheckGrantingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CheckGrantingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-granted-employees")]
        public async Task<IActionResult> GetGrantedEmployeesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetGrantedEmployeesAsync(ids);
            return Ok(result);
        }
    }
    
}