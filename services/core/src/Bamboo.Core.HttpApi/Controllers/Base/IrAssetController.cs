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
    [Route("api/v1/base/IrAsset")]
    public partial class IrAssetController : AbpController
    {
        protected readonly IIrAssetAppService _appService;
        public IrAssetController(IIrAssetAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("filter-duplicate")]
        public async Task<IActionResult> FilterDuplicateAsync([FromBody] IrAssetFilterDuplicateRequestDto input)
        {
            var result = await _appService.FilterDuplicateAsync(input);
            return Ok(result);
        }
    }
    
}