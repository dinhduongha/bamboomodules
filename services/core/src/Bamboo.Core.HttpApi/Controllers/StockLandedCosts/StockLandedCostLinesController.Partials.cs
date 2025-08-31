using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.StockLandedCosts
{
    public partial class StockLandedCostLinesController
    {
        
        [HttpPost]
        [Route("{id}/onchange-product-id")]
        public async Task<IActionResult> OnchangeProductIdAsync(Guid id)
        {
            var result = await _appService.OnchangeProductIdAsync(id);
            return Ok(result);
        }
    }
}