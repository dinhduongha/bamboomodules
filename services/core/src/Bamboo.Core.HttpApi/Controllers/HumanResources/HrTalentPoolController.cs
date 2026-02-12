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
    [Route("api/v1/human-resources/HrTalentPool")]
    public partial class HrTalentPoolController : AbpController
    {
        protected readonly IHrTalentPoolAppService _appService;
        public HrTalentPoolController(IHrTalentPoolAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-talent-pool-add-talents")]
        public async Task<IActionResult> TalentPoolAddTalentsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.TalentPoolAddTalentsAsync(ids);
            return Ok(result);
        }
    }
    
}