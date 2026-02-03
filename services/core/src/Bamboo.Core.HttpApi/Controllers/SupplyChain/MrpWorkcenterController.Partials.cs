using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MrpWorkcenterController
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
        [Route("action-show-operations")]
        public async Task<IActionResult> ActionShowOperationsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ShowOperationsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-work-order")]
        public async Task<IActionResult> ActionWorkOrderAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.WorkOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-work-order-alternatives")]
        public async Task<IActionResult> ActionWorkOrderAlternativesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.WorkOrderAlternativesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("unblock")]
        public async Task<IActionResult> UnblockAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnblockAsync(ids);
            return Ok(result);
        }
    }
}