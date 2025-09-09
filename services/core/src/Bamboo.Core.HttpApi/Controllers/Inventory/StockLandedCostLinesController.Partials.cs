using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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