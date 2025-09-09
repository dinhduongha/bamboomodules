using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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