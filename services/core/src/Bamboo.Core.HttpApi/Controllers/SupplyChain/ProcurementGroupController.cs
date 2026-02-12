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
    [Route("api/v1/inventory/ProcurementGroup")]
    public partial class ProcurementGroupController : AbpController
    {
        protected readonly IProcurementGroupAppService _appService;
        public ProcurementGroupController(IProcurementGroupAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("run")]
        public async Task<IActionResult> RunAsync([FromBody] ProcurementGroupRunRequestDto input)
        {
            var result = await _appService.RunAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("run-scheduler")]
        public async Task<IActionResult> RunSchedulerAsync([FromBody] ProcurementGroupRunSchedulerRequestDto input)
        {
            var result = await _appService.RunSchedulerAsync(input);
            return Ok(result);
        }
    }
    
}