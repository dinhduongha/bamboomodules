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
        [Route("check-parent-id")]
        public async Task<IActionResult> CheckParentIdAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CheckParentIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-available-snippet-categories")]
        public async Task<IActionResult> GetAvailableSnippetCategoriesAsync(ProductPublicCategoryGetAvailableSnippetCategoriesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetAvailableSnippetCategoriesAsync(input);
            return Ok(result);
        }
    }
}