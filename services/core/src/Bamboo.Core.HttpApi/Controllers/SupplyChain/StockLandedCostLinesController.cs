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
    [Route("api/v1/supply-chain/StockLandedCostLines")]
    public partial class StockLandedCostLinesController : AbpController
    {
        protected readonly IStockLandedCostLinesAppService _appService;
        public StockLandedCostLinesController(IStockLandedCostLinesAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("onchange-product-id")]
        public async Task<IActionResult> OnchangeProductIdAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangeProductIdAsync(ids);
            return Ok(result);
        }
    }
    
}