using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class StockPickingBatchController
    {
        
        [HttpPost]
        [Route("action-assign")]
        public async Task<IActionResult> ActionAssignAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AssignAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-batch-detailed-operations")]
        public async Task<IActionResult> ActionBatchDetailedOperationsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.BatchDetailedOperationsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-cancel")]
        public async Task<IActionResult> ActionCancelAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-confirm")]
        public async Task<IActionResult> ActionConfirmAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ConfirmAsync(ids);
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
        [Route("action-merge")]
        public async Task<IActionResult> ActionMergeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.MergeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-label-layout")]
        public async Task<IActionResult> ActionOpenLabelLayoutAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenLabelLayoutAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-print")]
        public async Task<IActionResult> ActionPrintAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PrintAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-put-in-pack")]
        public async Task<IActionResult> ActionPutInPackAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PutInPackAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-see-packages")]
        public async Task<IActionResult> ActionSeePackagesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SeePackagesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-reception-report")]
        public async Task<IActionResult> ActionViewReceptionReportAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewReceptionReportAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-scheduled-date")]
        public async Task<IActionResult> OnchangeScheduledDateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangeScheduledDateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("order-on-zip")]
        public async Task<IActionResult> OrderOnZipAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OrderOnZipAsync(ids);
            return Ok(result);
        }
    }
}