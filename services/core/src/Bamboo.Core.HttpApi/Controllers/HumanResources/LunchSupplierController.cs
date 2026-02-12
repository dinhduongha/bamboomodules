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
    [Route("api/v1/human-resources/LunchSupplier")]
    public partial class LunchSupplierController : AbpController
    {
        protected readonly ILunchSupplierAppService _appService;
        public LunchSupplierController(ILunchSupplierAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-confirm-orders")]
        public async Task<IActionResult> ConfirmOrdersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ConfirmOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-send-orders")]
        public async Task<IActionResult> SendOrdersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SendOrdersAsync(ids);
            return Ok(result);
        }
    }
    
}