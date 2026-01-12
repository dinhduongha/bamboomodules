using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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