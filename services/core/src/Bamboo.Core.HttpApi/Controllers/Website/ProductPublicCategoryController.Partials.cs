using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
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