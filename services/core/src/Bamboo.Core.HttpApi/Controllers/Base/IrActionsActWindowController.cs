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
    [Route("api/v1/base/IrActionsActWindow")]
    public partial class IrActionsActWindowController : AbpController
    {
        protected readonly IIrActionsActWindowAppService _appService;
        public IrActionsActWindowController(IIrActionsActWindowAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("exists")]
        public async Task<IActionResult> ExistsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ExistsAsync(ids);
            return Ok(result);
        }
    }
    
}