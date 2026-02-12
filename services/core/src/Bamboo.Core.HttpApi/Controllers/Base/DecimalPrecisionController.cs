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
    [Route("api/v1/base/DecimalPrecision")]
    public partial class DecimalPrecisionController : AbpController
    {
        protected readonly IDecimalPrecisionAppService _appService;
        public DecimalPrecisionController(IDecimalPrecisionAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("precision-get")]
        public async Task<IActionResult> PrecisionGetAsync([FromBody] DecimalPrecisionPrecisionGetRequestDto input)
        {
            var result = await _appService.PrecisionGetAsync(input);
            return Ok(result);
        }
    }
    
}