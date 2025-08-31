using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.PurchaseRequisitionModule
{
    public partial class PurchaseRequisitionController
    {
        
        [HttpPost]
        [Route("{id}/action-cancel")]
        public async Task<IActionResult> ActionCancelAsync(Guid id)
        {
            var result = await _appService.CancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-confirm")]
        public async Task<IActionResult> ActionConfirmAsync(Guid id)
        {
            var result = await _appService.ConfirmAsync(id);
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
    }
}