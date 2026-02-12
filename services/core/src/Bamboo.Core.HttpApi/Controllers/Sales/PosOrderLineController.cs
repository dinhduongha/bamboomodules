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
    [Route("api/v1/sales/PosOrderLine")]
    public partial class PosOrderLineController : AbpController
    {
        protected readonly IPosOrderLineAppService _appService;
        public PosOrderLineController(IPosOrderLineAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("get-existing-lots")]
        public async Task<IActionResult> GetExistingLotsAsync([FromBody] PosOrderLineGetExistingLotsRequestDto input)
        {
            var result = await _appService.GetExistingLotsAsync(input);
            return Ok(result);
        }
    }
    
}