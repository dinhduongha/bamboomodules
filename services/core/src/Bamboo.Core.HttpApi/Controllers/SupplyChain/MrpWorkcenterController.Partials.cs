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
        [Route("{id}/action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid id)
        {
            var result = await _appService.ArchiveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-show-operations")]
        public async Task<IActionResult> ActionShowOperationsAsync(Guid id)
        {
            var result = await _appService.ShowOperationsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-work-order")]
        public async Task<IActionResult> ActionWorkOrderAsync(Guid id)
        {
            var result = await _appService.WorkOrderAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-work-order-alternatives")]
        public async Task<IActionResult> ActionWorkOrderAlternativesAsync(Guid id)
        {
            var result = await _appService.WorkOrderAlternativesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/unblock")]
        public async Task<IActionResult> UnblockAsync(Guid id)
        {
            var result = await _appService.UnblockAsync(id);
            return Ok(result);
        }
    }
}