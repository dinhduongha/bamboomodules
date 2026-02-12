using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/supply-chain/StockLot")]
    public partial class StockLotController : AbpController
    {
        protected readonly IStockLotAppService _appService;
        public StockLotController(IStockLotAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-lot-open-quants")]
        public async Task<IActionResult> LotOpenQuantsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.LotOpenQuantsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-lot-open-repairs")]
        public async Task<IActionResult> LotOpenRepairsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.LotOpenRepairsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-lot-open-transfers")]
        public async Task<IActionResult> LotOpenTransfersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.LotOpenTransfersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-po")]
        public async Task<IActionResult> ViewPoAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewPoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-ro")]
        public async Task<IActionResult> ViewRoAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewRoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-so")]
        public async Task<IActionResult> ViewSoAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewSoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] StockLotCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("generate-lot-names")]
        public async Task<IActionResult> GenerateLotNamesAsync([FromBody] StockLotGenerateLotNamesRequestDto input)
        {
            var result = await _appService.GenerateLotNamesAsync(input);
            return Ok(result);
        }
    }
    
}