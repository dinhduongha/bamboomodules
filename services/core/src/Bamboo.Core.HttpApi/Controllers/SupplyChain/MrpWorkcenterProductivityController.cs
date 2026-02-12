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
    [Route("api/v1/supply-chain/MrpWorkcenterProductivity")]
    public partial class MrpWorkcenterProductivityController : AbpController
    {
        protected readonly IMrpWorkcenterProductivityAppService _appService;
        public MrpWorkcenterProductivityController(IMrpWorkcenterProductivityAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("button-block")]
        public async Task<IActionResult> ButtonBlockAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonBlockAsync(ids);
            return Ok(result);
        }
    }
    
}