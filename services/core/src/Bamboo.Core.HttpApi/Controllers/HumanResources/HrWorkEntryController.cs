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
    [Route("api/v1/human-resources/HrWorkEntry")]
    public partial class HrWorkEntryController : AbpController
    {
        protected readonly IHrWorkEntryAppService _appService;
        public HrWorkEntryController(IHrWorkEntryAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-approve-leave")]
        public async Task<IActionResult> ApproveLeaveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ApproveLeaveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-refuse-leave")]
        public async Task<IActionResult> RefuseLeaveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RefuseLeaveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-split")]
        public async Task<IActionResult> SplitAsync([FromBody] HrWorkEntrySplitRequestDto input)
        {
            var result = await _appService.SplitAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-validate")]
        public async Task<IActionResult> ValidateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ValidateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-unusual-days")]
        public async Task<IActionResult> GetUnusualDaysAsync([FromBody] HrWorkEntryGetUnusualDaysRequestDto input)
        {
            var result = await _appService.GetUnusualDaysAsync(input);
            return Ok(result);
        }
    }
    
}