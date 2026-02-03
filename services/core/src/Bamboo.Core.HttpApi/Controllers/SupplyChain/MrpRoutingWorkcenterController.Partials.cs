using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MrpRoutingWorkcenterController
    {
        
        [HttpPost]
        [Route("action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-operation-form")]
        public async Task<IActionResult> ActionOpenOperationFormAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenOperationFormAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unarchive")]
        public async Task<IActionResult> ActionUnarchiveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnarchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-existing-operations")]
        public async Task<IActionResult> CopyExistingOperationsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CopyExistingOperationsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-to-bom")]
        public async Task<IActionResult> CopyToBomAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CopyToBomAsync(ids);
            return Ok(result);
        }
    }
}