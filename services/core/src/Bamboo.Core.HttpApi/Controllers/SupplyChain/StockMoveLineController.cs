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
    [Route("api/v1/supply-chain/StockMoveLine")]
    public partial class StockMoveLineController : AbpController
    {
        protected readonly IStockMoveLineAppService _appService;
        public StockMoveLineController(IStockMoveLineAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-open-add-to-wave")]
        public async Task<IActionResult> OpenAddToWaveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenAddToWaveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-reference")]
        public async Task<IActionResult> OpenReferenceAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenReferenceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-put-in-pack")]
        public async Task<IActionResult> PutInPackAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PutInPackAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-revert-inventory")]
        public async Task<IActionResult> RevertInventoryAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RevertInventoryAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-move-line-quant-match")]
        public async Task<IActionResult> GetMoveLineQuantMatchAsync([FromBody] StockMoveLineGetMoveLineQuantMatchRequestDto input)
        {
            var result = await _appService.GetMoveLineQuantMatchAsync(input);
            return Ok(result);
        }
    }
    
}