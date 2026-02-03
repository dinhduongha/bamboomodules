using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class RepairOrderController
    {
        
        [HttpPost]
        [Route("action-add-from-catalog")]
        public async Task<IActionResult> ActionAddFromCatalogAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AddFromCatalogAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-assign")]
        public async Task<IActionResult> ActionAssignAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AssignAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-sale-order")]
        public async Task<IActionResult> ActionCreateSaleOrderAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreateSaleOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-explode")]
        public async Task<IActionResult> ActionExplodeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ExplodeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-generate-serial")]
        public async Task<IActionResult> ActionGenerateSerialAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GenerateSerialAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-repair-cancel")]
        public async Task<IActionResult> ActionRepairCancelAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RepairCancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-repair-cancel-draft")]
        public async Task<IActionResult> ActionRepairCancelDraftAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RepairCancelDraftAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-repair-done")]
        public async Task<IActionResult> ActionRepairDoneAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RepairDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-repair-end")]
        public async Task<IActionResult> ActionRepairEndAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RepairEndAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-repair-start")]
        public async Task<IActionResult> ActionRepairStartAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RepairStartAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unreserve")]
        public async Task<IActionResult> ActionUnreserveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnreserveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-validate")]
        public async Task<IActionResult> ActionValidateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ValidateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mrp-productions")]
        public async Task<IActionResult> ActionViewMrpProductionsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewMrpProductionsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-purchase-orders")]
        public async Task<IActionResult> ActionViewPurchaseOrdersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewPurchaseOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sale-order")]
        public async Task<IActionResult> ActionViewSaleOrderAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewSaleOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("compute-lot-id")]
        public async Task<IActionResult> ComputeLotIdAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ComputeLotIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("compute-product-uom")]
        public async Task<IActionResult> ComputeProductUomAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ComputeProductUomAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-post")]
        public async Task<IActionResult> MessagePostAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.MessagePostAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-product-uom")]
        public async Task<IActionResult> OnchangeProductUomAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangeProductUomAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("print-repair-order")]
        public async Task<IActionResult> PrintRepairOrderAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PrintRepairOrderAsync(ids);
            return Ok(result);
        }
    }
}