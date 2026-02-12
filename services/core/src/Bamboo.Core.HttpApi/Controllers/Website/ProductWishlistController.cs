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
    [Route("api/v1/website/ProductWishlist")]
    public partial class ProductWishlistController : AbpController
    {
        protected readonly IProductWishlistAppService _appService;
        public ProductWishlistController(IProductWishlistAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("current")]
        public async Task<IActionResult> CurrentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CurrentAsync(ids);
            return Ok(result);
        }
    }
    
}