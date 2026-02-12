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
    [Route("api/v1/inventory/StockPackageLevel")]
    public partial class StockPackageLevelController : AbpController
    {
        protected readonly IStockPackageLevelAppService _appService;
        public StockPackageLevelController(IStockPackageLevelAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-show-package-details")]
        public async Task<IActionResult> ShowPackageDetailsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ShowPackageDetailsAsync(ids);
            return Ok(result);
        }
    }
    
}