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
    [Route("api/v1/website/ResPartnerTag")]
    public partial class ResPartnerTagController : AbpController
    {
        protected readonly IResPartnerTagAppService _appService;
        public ResPartnerTagController(IResPartnerTagAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("get-selection-class")]
        public async Task<IActionResult> GetSelectionClassAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetSelectionClassAsync(ids);
            return Ok(result);
        }
    }
    
}