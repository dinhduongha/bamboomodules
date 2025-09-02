using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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