using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.OmRecurringPayments
{
    public partial class RecurringPaymentController
    {
        
        [HttpPost]
        [Route("{id}/action-create-lines")]
        public async Task<IActionResult> ActionCreateLinesAsync(Guid id, [FromBody] RecurringPaymentCreateLinesRequestDto input)
        {
            var result = await _appService.CreateLinesAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-done")]
        public async Task<IActionResult> ActionDoneAsync(Guid id)
        {
            var result = await _appService.DoneAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-draft")]
        public async Task<IActionResult> ActionDraftAsync(Guid id)
        {
            var result = await _appService.DraftAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-generate-payment")]
        public async Task<IActionResult> ActionGeneratePaymentAsync(Guid id)
        {
            var result = await _appService.GeneratePaymentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/compute-next-date")]
        public async Task<IActionResult> ComputeNextDateAsync(Guid id, [FromBody] RecurringPaymentComputeNextDateRequestDto input)
        {
            var result = await _appService.ComputeNextDateAsync(id, input);
            return Ok(result);
        }
    }
}