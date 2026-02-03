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
        [Route("action-cancel")]
        public async Task<IActionResult> ActionCancelAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-mark-as-done")]
        public async Task<IActionResult> ActionMarkAsDoneAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.MarkAsDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-wizard")]
        public async Task<IActionResult> ActionOpenWizardAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenWizardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-replan")]
        public async Task<IActionResult> ActionReplanAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ReplanAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-see-move-scrap")]
        public async Task<IActionResult> ActionSeeMoveScrapAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SeeMoveScrapAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-finish")]
        public async Task<IActionResult> ButtonFinishAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonFinishAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-pending")]
        public async Task<IActionResult> ButtonPendingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonPendingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-scrap")]
        public async Task<IActionResult> ButtonScrapAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonScrapAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-start")]
        public async Task<IActionResult> ButtonStartAsync(MrpWorkorderButtonStartRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ButtonStartAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-unblock")]
        public async Task<IActionResult> ButtonUnblockAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ButtonUnblockAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("end-all")]
        public async Task<IActionResult> EndAllAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.EndAllAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("end-previous")]
        public async Task<IActionResult> EndPreviousAsync(MrpWorkorderEndPreviousRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.EndPreviousAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-duration")]
        public async Task<IActionResult> GetDurationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetDurationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-working-duration")]
        public async Task<IActionResult> GetWorkingDurationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetWorkingDurationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-state")]
        public async Task<IActionResult> SetStateAsync(MrpWorkorderSetStateRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SetStateAsync(input);
            return Ok(result);
        }
    }
}