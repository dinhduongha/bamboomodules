using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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