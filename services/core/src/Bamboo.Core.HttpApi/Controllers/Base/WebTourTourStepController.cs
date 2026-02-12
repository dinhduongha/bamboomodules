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
    [Route("api/v1/web-tour/WebTourTourStep")]
    public partial class WebTourTourStepController : AbpController
    {
        protected readonly IWebTourTourStepAppService _appService;
        public WebTourTourStepController(IWebTourTourStepAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("get-steps-json")]
        public async Task<IActionResult> GetStepsJsonAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetStepsJsonAsync(ids);
            return Ok(result);
        }
    }
    
}