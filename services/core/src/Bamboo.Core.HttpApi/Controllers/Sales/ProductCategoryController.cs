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
    [Route("api/v1/sales/ProductCategory")]
    public partial class ProductCategoryController : AbpController
    {
        protected readonly IProductCategoryAppService _appService;
        public ProductCategoryController(IProductCategoryAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] ProductCategoryCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
    }
    
}