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
    [Route("api/v1/human-resources/HrLeaveAccrualLevel")]
    public partial class HrLeaveAccrualLevelController : AbpController
    {
        protected readonly IHrLeaveAccrualLevelAppService _appService;
        public HrLeaveAccrualLevelController(IHrLeaveAccrualLevelAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-save-new")]
        public async Task<IActionResult> SaveNewAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SaveNewAsync(ids);
            return Ok(result);
        }
    }
    
}