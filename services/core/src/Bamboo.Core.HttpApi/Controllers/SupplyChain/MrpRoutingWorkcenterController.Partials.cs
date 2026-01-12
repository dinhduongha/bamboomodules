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
        [Route("{id}/action-archive")]
        public async Task<IActionResult> ActionArchiveAsync(Guid id)
        {
            var result = await _appService.ArchiveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-unarchive")]
        public async Task<IActionResult> ActionUnarchiveAsync(Guid id)
        {
            var result = await _appService.UnarchiveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-existing-operations")]
        public async Task<IActionResult> CopyExistingOperationsAsync(Guid id)
        {
            var result = await _appService.CopyExistingOperationsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-to-bom")]
        public async Task<IActionResult> CopyToBomAsync(Guid id)
        {
            var result = await _appService.CopyToBomAsync(id);
            return Ok(result);
        }
    }
}