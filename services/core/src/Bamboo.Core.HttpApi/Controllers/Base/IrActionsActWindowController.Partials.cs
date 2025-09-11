using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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