using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
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