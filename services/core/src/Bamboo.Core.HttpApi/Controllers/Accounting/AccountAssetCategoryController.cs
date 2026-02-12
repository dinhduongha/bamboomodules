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
    [Route("api/v1/accounting/AccountAssetCategory")]
    public partial class AccountAssetCategoryController : AbpController
    {
        protected readonly IAccountAssetCategoryAppService _appService;
        public AccountAssetCategoryController(IAccountAssetCategoryAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("onchange-account-asset")]
        public async Task<IActionResult> OnchangeAccountAssetAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangeAccountAssetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-type")]
        public async Task<IActionResult> OnchangeTypeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangeTypeAsync(ids);
            return Ok(result);
        }
    }
    
}