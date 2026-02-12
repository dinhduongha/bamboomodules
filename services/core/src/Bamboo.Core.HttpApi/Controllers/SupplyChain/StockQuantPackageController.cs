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
    [Route("api/v1/inventory/StockQuantPackage")]
    public partial class StockQuantPackageController : AbpController
    {
        protected readonly IStockQuantPackageAppService _appService;
        public StockQuantPackageController(IStockQuantPackageAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-view-picking")]
        public async Task<IActionResult> ViewPickingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewPickingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("unpack")]
        public async Task<IActionResult> UnpackAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnpackAsync(ids);
            return Ok(result);
        }
    }
    
}