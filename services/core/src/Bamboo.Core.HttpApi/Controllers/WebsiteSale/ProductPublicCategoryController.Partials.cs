using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
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