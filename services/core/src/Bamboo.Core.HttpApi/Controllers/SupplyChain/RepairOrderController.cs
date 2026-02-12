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
    [Route("api/v1/supply-chain/RepairOrder")]
    public partial class RepairOrderController : AbpController
    {
        protected readonly IRepairOrderAppService _appService;
        public RepairOrderController(IRepairOrderAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-add-from-catalog")]
        public async Task<IActionResult> AddFromCatalogAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AddFromCatalogAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-assign")]
        public async Task<IActionResult> AssignAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AssignAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-sale-order")]
        public async Task<IActionResult> CreateSaleOrderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateSaleOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-explode")]
        public async Task<IActionResult> ExplodeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ExplodeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-generate-serial")]
        public async Task<IActionResult> GenerateSerialAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GenerateSerialAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-repair-cancel")]
        public async Task<IActionResult> RepairCancelAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RepairCancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-repair-cancel-draft")]
        public async Task<IActionResult> RepairCancelDraftAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RepairCancelDraftAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-repair-done")]
        public async Task<IActionResult> RepairDoneAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RepairDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-repair-end")]
        public async Task<IActionResult> RepairEndAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RepairEndAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-repair-start")]
        public async Task<IActionResult> RepairStartAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RepairStartAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unreserve")]
        public async Task<IActionResult> UnreserveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnreserveAsync(ids);
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
        [Route("action-view-mrp-productions")]
        public async Task<IActionResult> ViewMrpProductionsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewMrpProductionsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-purchase-orders")]
        public async Task<IActionResult> ViewPurchaseOrdersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewPurchaseOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sale-order")]
        public async Task<IActionResult> ViewSaleOrderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewSaleOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("compute-lot-id")]
        public async Task<IActionResult> ComputeLotIdAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ComputeLotIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("compute-product-uom")]
        public async Task<IActionResult> ComputeProductUomAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ComputeProductUomAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-post")]
        public async Task<IActionResult> MessagePostAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.MessagePostAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-product-uom")]
        public async Task<IActionResult> OnchangeProductUomAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangeProductUomAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("print-repair-order")]
        public async Task<IActionResult> PrintRepairOrderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PrintRepairOrderAsync(ids);
            return Ok(result);
        }
    }
    
}