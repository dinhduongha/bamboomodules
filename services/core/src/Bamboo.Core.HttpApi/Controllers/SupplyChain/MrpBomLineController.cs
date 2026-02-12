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
    [Route("api/v1/supply-chain/MrpBomLine")]
    public partial class MrpBomLineController : AbpController
    {
        protected readonly IMrpBomLineAppService _appService;
        public MrpBomLineController(IMrpBomLineAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-add-from-catalog")]
        public async Task<IActionResult> AddFromCatalogAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AddFromCatalogAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-see-attachments")]
        public async Task<IActionResult> SeeAttachmentsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SeeAttachmentsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-product-id")]
        public async Task<IActionResult> OnchangeProductIdAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangeProductIdAsync(ids);
            return Ok(result);
        }
    }
    
}