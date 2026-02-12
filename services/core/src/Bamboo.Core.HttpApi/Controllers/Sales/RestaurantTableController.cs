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
    [Route("api/v1/sales/RestaurantTable")]
    public partial class RestaurantTableController : AbpController
    {
        protected readonly IRestaurantTableAppService _appService;
        public RestaurantTableController(IRestaurantTableAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("are-orders-still-in-draft")]
        public async Task<IActionResult> AreOrdersStillInDraftAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AreOrdersStillInDraftAsync(ids);
            return Ok(result);
        }
    }
    
}