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
    [Route("api/v1/supply-chain/MrpWorkcenter")]
    public partial class MrpWorkcenterController : AbpController
    {
        protected readonly IMrpWorkcenterAppService _appService;
        public MrpWorkcenterController(IMrpWorkcenterAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-archive")]
        public async Task<IActionResult> ArchiveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-show-operations")]
        public async Task<IActionResult> ShowOperationsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ShowOperationsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-work-order")]
        public async Task<IActionResult> WorkOrderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.WorkOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-work-order-alternatives")]
        public async Task<IActionResult> WorkOrderAlternativesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.WorkOrderAlternativesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("unblock")]
        public async Task<IActionResult> UnblockAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnblockAsync(ids);
            return Ok(result);
        }
    }
    
}