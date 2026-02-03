using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class RecurringPaymentController
    {
        
        [HttpPost]
        [Route("action-create-lines")]
        public async Task<IActionResult> ActionCreateLinesAsync(RecurringPaymentCreateLinesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CreateLinesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-done")]
        public async Task<IActionResult> ActionDoneAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-draft")]
        public async Task<IActionResult> ActionDraftAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DraftAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-generate-payment")]
        public async Task<IActionResult> ActionGeneratePaymentAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GeneratePaymentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("compute-next-date")]
        public async Task<IActionResult> ComputeNextDateAsync(RecurringPaymentComputeNextDateRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ComputeNextDateAsync(input);
            return Ok(result);
        }
    }
}