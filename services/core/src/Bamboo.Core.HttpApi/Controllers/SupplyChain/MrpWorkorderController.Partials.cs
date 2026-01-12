using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class MrpWorkorderController
    {
        
        [HttpPost]
        [Route("{id}/action-cancel")]
        public async Task<IActionResult> ActionCancelAsync(Guid id)
        {
            var result = await _appService.CancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-mark-as-done")]
        public async Task<IActionResult> ActionMarkAsDoneAsync(Guid id)
        {
            var result = await _appService.MarkAsDoneAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-wizard")]
        public async Task<IActionResult> ActionOpenWizardAsync(Guid id)
        {
            var result = await _appService.OpenWizardAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-replan")]
        public async Task<IActionResult> ActionReplanAsync(Guid id)
        {
            var result = await _appService.ReplanAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-see-move-scrap")]
        public async Task<IActionResult> ActionSeeMoveScrapAsync(Guid id)
        {
            var result = await _appService.SeeMoveScrapAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-done")]
        public async Task<IActionResult> ButtonDoneAsync(Guid id)
        {
            var result = await _appService.ButtonDoneAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-finish")]
        public async Task<IActionResult> ButtonFinishAsync(Guid id)
        {
            var result = await _appService.ButtonFinishAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-pending")]
        public async Task<IActionResult> ButtonPendingAsync(Guid id)
        {
            var result = await _appService.ButtonPendingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-scrap")]
        public async Task<IActionResult> ButtonScrapAsync(Guid id)
        {
            var result = await _appService.ButtonScrapAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-start")]
        public async Task<IActionResult> ButtonStartAsync(Guid id, [FromBody] MrpWorkorderButtonStartRequestDto input)
        {
            var result = await _appService.ButtonStartAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-unblock")]
        public async Task<IActionResult> ButtonUnblockAsync(Guid id)
        {
            var result = await _appService.ButtonUnblockAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/end-all")]
        public async Task<IActionResult> EndAllAsync(Guid id)
        {
            var result = await _appService.EndAllAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/end-previous")]
        public async Task<IActionResult> EndPreviousAsync(Guid id, [FromBody] MrpWorkorderEndPreviousRequestDto input)
        {
            var result = await _appService.EndPreviousAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-duration")]
        public async Task<IActionResult> GetDurationAsync(Guid id)
        {
            var result = await _appService.GetDurationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-working-duration")]
        public async Task<IActionResult> GetWorkingDurationAsync(Guid id)
        {
            var result = await _appService.GetWorkingDurationAsync(id);
            return Ok(result);
        }
    }
}