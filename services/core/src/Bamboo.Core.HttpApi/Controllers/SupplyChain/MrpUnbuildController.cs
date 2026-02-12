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
    [Route("api/v1/supply-chain/MrpUnbuild")]
    public partial class MrpUnbuildController : AbpController
    {
        protected readonly IMrpUnbuildAppService _appService;
        public MrpUnbuildController(IMrpUnbuildAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-unbuild")]
        public async Task<IActionResult> UnbuildAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnbuildAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-validate")]
        public async Task<IActionResult> ValidateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ValidateAsync(ids);
            return Ok(result);
        }
    }
    
}