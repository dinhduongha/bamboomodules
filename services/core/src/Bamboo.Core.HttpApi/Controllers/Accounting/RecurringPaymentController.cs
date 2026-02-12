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
    [Route("api/v1/accounting/RecurringPayment")]
    public partial class RecurringPaymentController : AbpController
    {
        protected readonly IRecurringPaymentAppService _appService;
        public RecurringPaymentController(IRecurringPaymentAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-create-lines")]
        public async Task<IActionResult> CreateLinesAsync([FromBody] RecurringPaymentCreateLinesRequestDto input)
        {
            var result = await _appService.CreateLinesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-done")]
        public async Task<IActionResult> DoneAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-draft")]
        public async Task<IActionResult> DraftAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DraftAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-generate-payment")]
        public async Task<IActionResult> GeneratePaymentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GeneratePaymentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("compute-next-date")]
        public async Task<IActionResult> ComputeNextDateAsync([FromBody] RecurringPaymentComputeNextDateRequestDto input)
        {
            var result = await _appService.ComputeNextDateAsync(input);
            return Ok(result);
        }
    }
    
}