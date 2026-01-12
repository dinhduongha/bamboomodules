using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class StockMoveLineController
    {
        
        [HttpPost]
        [Route("{id}/action-open-add-to-wave")]
        public async Task<IActionResult> ActionOpenAddToWaveAsync(Guid id)
        {
            var result = await _appService.OpenAddToWaveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-reference")]
        public async Task<IActionResult> ActionOpenReferenceAsync(Guid id)
        {
            var result = await _appService.OpenReferenceAsync(id);
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
        [Route("{id}/action-revert-inventory")]
        public async Task<IActionResult> ActionRevertInventoryAsync(Guid id)
        {
            var result = await _appService.RevertInventoryAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-move-line-quant-match")]
        public async Task<IActionResult> GetMoveLineQuantMatchAsync(Guid id, [FromBody] StockMoveLineGetMoveLineQuantMatchRequestDto input)
        {
            var result = await _appService.GetMoveLineQuantMatchAsync(id, input);
            return Ok(result);
        }
    }
}