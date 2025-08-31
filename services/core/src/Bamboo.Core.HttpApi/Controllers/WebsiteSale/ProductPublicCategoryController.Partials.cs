using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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