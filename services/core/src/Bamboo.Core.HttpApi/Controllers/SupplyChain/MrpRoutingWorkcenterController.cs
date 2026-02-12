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
    [Route("api/v1/supply-chain/MrpRoutingWorkcenter")]
    public partial class MrpRoutingWorkcenterController : AbpController
    {
        protected readonly IMrpRoutingWorkcenterAppService _appService;
        public MrpRoutingWorkcenterController(IMrpRoutingWorkcenterAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-archive")]
        public async Task<IActionResult> ArchiveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-operation-form")]
        public async Task<IActionResult> OpenOperationFormAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenOperationFormAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unarchive")]
        public async Task<IActionResult> UnarchiveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnarchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-existing-operations")]
        public async Task<IActionResult> CopyExistingOperationsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CopyExistingOperationsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-to-bom")]
        public async Task<IActionResult> CopyToBomAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CopyToBomAsync(ids);
            return Ok(result);
        }
    }
    
}