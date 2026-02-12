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
    [Route("api/v1/sales/SaleOrderOption")]
    public partial class SaleOrderOptionController : AbpController
    {
        protected readonly ISaleOrderOptionAppService _appService;
        public SaleOrderOptionController(ISaleOrderOptionAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("add-option-to-order")]
        public async Task<IActionResult> AddOptionToOrderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AddOptionToOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-add-to-order")]
        public async Task<IActionResult> ButtonAddToOrderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonAddToOrderAsync(ids);
            return Ok(result);
        }
    }
    
}