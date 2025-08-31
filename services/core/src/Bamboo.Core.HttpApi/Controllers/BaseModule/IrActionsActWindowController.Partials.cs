using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
{
    public partial class IrActionsActWindowController
    {
        
        [HttpPost]
        [Route("{id}/exists")]
        public async Task<IActionResult> ExistsAsync(Guid id)
        {
            var result = await _appService.ExistsAsync(id);
            return Ok(result);
        }
    }
}