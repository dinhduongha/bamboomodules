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
    [Route("api/v1/sales/UomUom")]
    public partial class UomUomController : AbpController
    {
        protected readonly IUomUomAppService _appService;
        public UomUomController(IUomUomAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-open-packaging-barcodes")]
        public async Task<IActionResult> OpenPackagingBarcodesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenPackagingBarcodesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("compare")]
        public async Task<IActionResult> CompareAsync([FromBody] UomUomCompareRequestDto input)
        {
            var result = await _appService.CompareAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-zero")]
        public async Task<IActionResult> IsZeroAsync([FromBody] UomUomIsZeroRequestDto input)
        {
            var result = await _appService.IsZeroAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("round")]
        public async Task<IActionResult> RoundAsync([FromBody] UomUomRoundRequestDto input)
        {
            var result = await _appService.RoundAsync(input);
            return Ok(result);
        }
    }
    
}