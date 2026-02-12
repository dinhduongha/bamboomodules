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
    [Route("api/v1/supply-chain/StockPickingBatch")]
    public partial class StockPickingBatchController : AbpController
    {
        protected readonly IStockPickingBatchAppService _appService;
        public StockPickingBatchController(IStockPickingBatchAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-assign")]
        public async Task<IActionResult> AssignAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AssignAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-batch-detailed-operations")]
        public async Task<IActionResult> BatchDetailedOperationsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.BatchDetailedOperationsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-cancel")]
        public async Task<IActionResult> CancelAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-confirm")]
        public async Task<IActionResult> ConfirmAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ConfirmAsync(ids);
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
        [Route("action-merge")]
        public async Task<IActionResult> MergeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.MergeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-label-layout")]
        public async Task<IActionResult> OpenLabelLayoutAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenLabelLayoutAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-print")]
        public async Task<IActionResult> PrintAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PrintAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-put-in-pack")]
        public async Task<IActionResult> PutInPackAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PutInPackAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-see-packages")]
        public async Task<IActionResult> SeePackagesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SeePackagesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-reception-report")]
        public async Task<IActionResult> ViewReceptionReportAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewReceptionReportAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-scheduled-date")]
        public async Task<IActionResult> OnchangeScheduledDateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangeScheduledDateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("order-on-zip")]
        public async Task<IActionResult> OrderOnZipAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OrderOnZipAsync(ids);
            return Ok(result);
        }
    }
    
}