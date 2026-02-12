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
    [Route("api/v1/base/ResCountry")]
    public partial class ResCountryController : AbpController
    {
        protected readonly IResCountryAppService _appService;
        public ResCountryController(IResCountryAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("get-address-fields")]
        public async Task<IActionResult> GetAddressFieldsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetAddressFieldsAsync(ids);
            return Ok(result);
        }
    }
    
}