using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteSale
{
    public partial class ProductPublicCategoryController
    {
        
        [HttpPost]
        [Route("{id}/check-parent-id")]
        public async Task<IActionResult> CheckParentIdAsync(Guid id)
        {
            var result = await _appService.CheckParentIdAsync(id);
            return Ok(result);
        }
    }
}