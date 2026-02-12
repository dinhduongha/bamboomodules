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
    [Route("api/v1/human-resources/HrRecruitmentSource")]
    public partial class HrRecruitmentSourceController : AbpController
    {
        protected readonly IHrRecruitmentSourceAppService _appService;
        public HrRecruitmentSourceController(IHrRecruitmentSourceAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("create-alias")]
        public async Task<IActionResult> CreateAliasAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateAliasAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-and-get-alias")]
        public async Task<IActionResult> CreateAndGetAliasAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateAndGetAliasAsync(ids);
            return Ok(result);
        }
    }
    
}