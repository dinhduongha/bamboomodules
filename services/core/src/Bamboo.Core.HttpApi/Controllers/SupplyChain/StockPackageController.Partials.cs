using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class StockPackageController
    {
        
        [HttpPost]
        [Route("{id}/action-add-to-picking")]
        public async Task<IActionResult> ActionAddToPickingAsync(Guid id)
        {
            var result = await _appService.AddToPickingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-put-in-pack")]
        public async Task<IActionResult> ActionPutInPackAsync(Guid id)
        {
            var result = await _appService.PutInPackAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-remove-package")]
        public async Task<IActionResult> ActionRemovePackageAsync(Guid id)
        {
            var result = await _appService.RemovePackageAsync(id);
            return Ok(result);
        }
        
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