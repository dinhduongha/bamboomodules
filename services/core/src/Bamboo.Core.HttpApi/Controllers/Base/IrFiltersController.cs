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
    [Route("api/v1/base/IrFilters")]
    public partial class IrFiltersController : AbpController
    {
        protected readonly IIrFiltersAppService _appService;
        public IrFiltersController(IIrFiltersAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] IrFiltersCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-filter")]
        public async Task<IActionResult> CreateFilterAsync([FromBody] IrFiltersCreateFilterRequestDto input)
        {
            var result = await _appService.CreateFilterAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-filters")]
        public async Task<IActionResult> GetFiltersAsync([FromBody] IrFiltersGetFiltersRequestDto input)
        {
            var result = await _appService.GetFiltersAsync(input);
            return Ok(result);
        }
    }
    
}