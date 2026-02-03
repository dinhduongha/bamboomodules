using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class StockLotController
    {
        
        [HttpPost]
        [Route("action-lot-open-quants")]
        public async Task<IActionResult> ActionLotOpenQuantsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.LotOpenQuantsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-lot-open-repairs")]
        public async Task<IActionResult> ActionLotOpenRepairsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.LotOpenRepairsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-lot-open-transfers")]
        public async Task<IActionResult> ActionLotOpenTransfersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.LotOpenTransfersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-po")]
        public async Task<IActionResult> ActionViewPoAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewPoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-ro")]
        public async Task<IActionResult> ActionViewRoAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewRoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-so")]
        public async Task<IActionResult> ActionViewSoAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewSoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(StockLotCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("generate-lot-names")]
        public async Task<IActionResult> GenerateLotNamesAsync(StockLotGenerateLotNamesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GenerateLotNamesAsync(input);
            return Ok(result);
        }
    }
}