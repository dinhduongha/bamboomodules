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
    [Route("api/v1/website/ProductFeed")]
    public partial class ProductFeedController : AbpController
    {
        protected readonly IProductFeedAppService _appService;
        public ProductFeedController(IProductFeedAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-invalidate-cache")]
        public async Task<IActionResult> InvalidateCacheAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.InvalidateCacheAsync(ids);
            return Ok(result);
        }
    }
    
}