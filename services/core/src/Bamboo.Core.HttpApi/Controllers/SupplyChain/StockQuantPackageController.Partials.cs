using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class StockQuantPackageController
    {
        
        [HttpPost]
        [Route("{id}/action-view-picking")]
        public async Task<IActionResult> ActionViewPickingAsync(Guid id)
        {
            var result = await _appService.ViewPickingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/unpack")]
        public async Task<IActionResult> UnpackAsync(Guid id)
        {
            var result = await _appService.UnpackAsync(id);
            return Ok(result);
        }
    }
}