using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
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