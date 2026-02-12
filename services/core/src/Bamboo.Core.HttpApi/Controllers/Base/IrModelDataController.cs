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
    [Route("api/v1/base/IrModelData")]
    public partial class IrModelDataController : AbpController
    {
        protected readonly IIrModelDataAppService _appService;
        public IrModelDataController(IIrModelDataAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("check-object-reference")]
        public async Task<IActionResult> CheckObjectReferenceAsync([FromBody] IrModelDataCheckObjectReferenceRequestDto input)
        {
            var result = await _appService.CheckObjectReferenceAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] IrModelDataCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("toggle-noupdate")]
        public async Task<IActionResult> ToggleNoupdateAsync([FromBody] IrModelDataToggleNoupdateRequestDto input)
        {
            var result = await _appService.ToggleNoupdateAsync(input);
            return Ok(result);
        }
    }
    
}