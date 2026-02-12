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
    [Route("api/v1/base/IrActionsTodo")]
    public partial class IrActionsTodoController : AbpController
    {
        protected readonly IIrActionsTodoAppService _appService;
        public IrActionsTodoController(IIrActionsTodoAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-launch")]
        public async Task<IActionResult> LaunchAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.LaunchAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open")]
        public async Task<IActionResult> OpenAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("ensure-one-open-todo")]
        public async Task<IActionResult> EnsureOneOpenTodoAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.EnsureOneOpenTodoAsync(ids);
            return Ok(result);
        }
    }
    
}