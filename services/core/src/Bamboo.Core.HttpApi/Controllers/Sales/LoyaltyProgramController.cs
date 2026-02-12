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
    [Route("api/v1/sales/LoyaltyProgram")]
    public partial class LoyaltyProgramController : AbpController
    {
        protected readonly ILoyaltyProgramAppService _appService;
        public LoyaltyProgramController(ILoyaltyProgramAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-open-loyalty-cards")]
        public async Task<IActionResult> OpenLoyaltyCardsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenLoyaltyCardsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-program-share")]
        public async Task<IActionResult> ProgramShareAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ProgramShareAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-from-template")]
        public async Task<IActionResult> CreateFromTemplateAsync([FromBody] LoyaltyProgramCreateFromTemplateRequestDto input)
        {
            var result = await _appService.CreateFromTemplateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-program-templates")]
        public async Task<IActionResult> GetProgramTemplatesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetProgramTemplatesAsync(ids);
            return Ok(result);
        }
    }
    
}