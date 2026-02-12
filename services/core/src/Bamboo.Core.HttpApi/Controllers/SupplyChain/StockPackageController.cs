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
    [Route("api/v1/supply-chain/StockPackage")]
    public partial class StockPackageController : AbpController
    {
        protected readonly IStockPackageAppService _appService;
        public StockPackageController(IStockPackageAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-add-to-picking")]
        public async Task<IActionResult> AddToPickingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AddToPickingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-put-in-pack")]
        public async Task<IActionResult> PutInPackAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PutInPackAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-remove-package")]
        public async Task<IActionResult> RemovePackageAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RemovePackageAsync(ids);
            return Ok(result);
        }
        
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