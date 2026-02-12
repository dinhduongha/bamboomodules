using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/website/ProductPublicCategory")]
    public partial class ProductPublicCategoryController : AbpController
    {
        protected readonly IProductPublicCategoryAppService _appService;
        public ProductPublicCategoryController(IProductPublicCategoryAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("check-parent-id")]
        public async Task<IActionResult> CheckParentIdAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CheckParentIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-available-snippet-categories")]
        public async Task<IActionResult> GetAvailableSnippetCategoriesAsync([FromBody] ProductPublicCategoryGetAvailableSnippetCategoriesRequestDto input)
        {
            var result = await _appService.GetAvailableSnippetCategoriesAsync(input);
            return Ok(result);
        }
    }
    
}