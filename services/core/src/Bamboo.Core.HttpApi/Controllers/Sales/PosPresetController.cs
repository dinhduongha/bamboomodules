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
    [Route("api/v1/sales/PosPreset")]
    public partial class PosPresetController : AbpController
    {
        protected readonly IPosPresetAppService _appService;
        public PosPresetController(IPosPresetAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-open-linked-config")]
        public async Task<IActionResult> OpenLinkedConfigAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenLinkedConfigAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-linked-orders")]
        public async Task<IActionResult> OpenLinkedOrdersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenLinkedOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-available-slots")]
        public async Task<IActionResult> GetAvailableSlotsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetAvailableSlotsAsync(ids);
            return Ok(result);
        }
    }
    
}