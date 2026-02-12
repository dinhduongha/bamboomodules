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
    [Route("api/v1/accounting/AccountFiscalPosition")]
    public partial class AccountFiscalPositionController : AbpController
    {
        protected readonly IAccountFiscalPositionAppService _appService;
        public AccountFiscalPositionController(IAccountFiscalPositionAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-archive")]
        public async Task<IActionResult> ArchiveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ArchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-foreign-taxes")]
        public async Task<IActionResult> CreateForeignTaxesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateForeignTaxesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-related-taxes")]
        public async Task<IActionResult> OpenRelatedTaxesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenRelatedTaxesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("map-account")]
        public async Task<IActionResult> MapAccountAsync([FromBody] AccountFiscalPositionMapAccountRequestDto input)
        {
            var result = await _appService.MapAccountAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("map-tax")]
        public async Task<IActionResult> MapTaxAsync([FromBody] AccountFiscalPositionMapTaxRequestDto input)
        {
            var result = await _appService.MapTaxAsync(input);
            return Ok(result);
        }
    }
    
}