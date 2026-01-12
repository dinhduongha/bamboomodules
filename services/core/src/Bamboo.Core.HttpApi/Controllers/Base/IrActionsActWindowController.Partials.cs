using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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