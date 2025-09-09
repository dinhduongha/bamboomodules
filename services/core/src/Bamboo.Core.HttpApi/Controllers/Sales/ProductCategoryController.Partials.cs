using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Product
{
    public partial class ProductCategoryController
    {
        
        [HttpPost]
        [Route("{id}/onchange-property-cost")]
        public async Task<IActionResult> OnchangePropertyCostAsync(Guid id)
        {
            var result = await _appService.OnchangePropertyCostAsync(id);
            return Ok(result);
        }
    }
}