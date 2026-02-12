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
    [Route("api/v1/human-resources/LunchProduct")]
    public partial class LunchProductController : AbpController
    {
        protected readonly ILunchProductAppService _appService;
        public LunchProductController(ILunchProductAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("toggle-active")]
        public async Task<IActionResult> ToggleActiveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ToggleActiveAsync(ids);
            return Ok(result);
        }
    }
    
}