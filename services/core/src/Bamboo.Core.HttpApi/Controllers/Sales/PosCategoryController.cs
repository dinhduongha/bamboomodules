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
    [Route("api/v1/sales/PosCategory")]
    public partial class PosCategoryController : AbpController
    {
        protected readonly IPosCategoryAppService _appService;
        public PosCategoryController(IPosCategoryAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("get-default-color")]
        public async Task<IActionResult> GetDefaultColorAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetDefaultColorAsync(ids);
            return Ok(result);
        }
    }
    
}