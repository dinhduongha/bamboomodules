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
        [Route("action-open-add-to-wave")]
        public async Task<IActionResult> ActionOpenAddToWaveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenAddToWaveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-reference")]
        public async Task<IActionResult> ActionOpenReferenceAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenReferenceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-put-in-pack")]
        public async Task<IActionResult> ActionPutInPackAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PutInPackAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-revert-inventory")]
        public async Task<IActionResult> ActionRevertInventoryAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RevertInventoryAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-move-line-quant-match")]
        public async Task<IActionResult> GetMoveLineQuantMatchAsync(StockMoveLineGetMoveLineQuantMatchRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetMoveLineQuantMatchAsync(input);
            return Ok(result);
        }
    }
}