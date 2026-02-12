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
    [Route("api/v1/supply-chain/PurchaseBillLineMatch")]
    public partial class PurchaseBillLineMatchController : AbpController
    {
        protected readonly IPurchaseBillLineMatchAppService _appService;
        public PurchaseBillLineMatchController(IPurchaseBillLineMatchAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-add-to-po")]
        public async Task<IActionResult> AddToPoAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AddToPoAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-match-lines")]
        public async Task<IActionResult> MatchLinesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.MatchLinesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-line")]
        public async Task<IActionResult> OpenLineAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenLineAsync(ids);
            return Ok(result);
        }
    }
    
}