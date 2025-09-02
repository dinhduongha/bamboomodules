using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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