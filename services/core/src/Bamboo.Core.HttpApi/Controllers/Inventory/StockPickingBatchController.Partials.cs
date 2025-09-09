using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.StockPickingBatchModule
{
    public partial class StockPickingBatchController
    {
        
        [HttpPost]
        [Route("{id}/action-assign")]
        public async Task<IActionResult> ActionAssignAsync(Guid id)
        {
            var result = await _appService.AssignAsync(id);
            return Ok(result);
        }
        
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
        [Route("{id}/action-open-label-layout")]
        public async Task<IActionResult> ActionOpenLabelLayoutAsync(Guid id)
        {
            var result = await _appService.OpenLabelLayoutAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-print")]
        public async Task<IActionResult> ActionPrintAsync(Guid id)
        {
            var result = await _appService.PrintAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-put-in-pack")]
        public async Task<IActionResult> ActionPutInPackAsync(Guid id)
        {
            var result = await _appService.PutInPackAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-reception-report")]
        public async Task<IActionResult> ActionViewReceptionReportAsync(Guid id)
        {
            var result = await _appService.ViewReceptionReportAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-scheduled-date")]
        public async Task<IActionResult> OnchangeScheduledDateAsync(Guid id)
        {
            var result = await _appService.OnchangeScheduledDateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/order-on-zip")]
        public async Task<IActionResult> OrderOnZipAsync(Guid id)
        {
            var result = await _appService.OrderOnZipAsync(id);
            return Ok(result);
        }
    }
}