using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Repair
{
    public partial class RepairOrderController
    {
        
        [HttpPost]
        [Route("{id}/action-add-from-catalog")]
        public async Task<IActionResult> ActionAddFromCatalogAsync(Guid id)
        {
            var result = await _appService.AddFromCatalogAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-assign")]
        public async Task<IActionResult> ActionAssignAsync(Guid id)
        {
            var result = await _appService.AssignAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-create-sale-order")]
        public async Task<IActionResult> ActionCreateSaleOrderAsync(Guid id)
        {
            var result = await _appService.CreateSaleOrderAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-explode")]
        public async Task<IActionResult> ActionExplodeAsync(Guid id)
        {
            var result = await _appService.ExplodeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-repair-cancel")]
        public async Task<IActionResult> ActionRepairCancelAsync(Guid id)
        {
            var result = await _appService.RepairCancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-repair-cancel-draft")]
        public async Task<IActionResult> ActionRepairCancelDraftAsync(Guid id)
        {
            var result = await _appService.RepairCancelDraftAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-repair-done")]
        public async Task<IActionResult> ActionRepairDoneAsync(Guid id)
        {
            var result = await _appService.RepairDoneAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-repair-end")]
        public async Task<IActionResult> ActionRepairEndAsync(Guid id)
        {
            var result = await _appService.RepairEndAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-repair-start")]
        public async Task<IActionResult> ActionRepairStartAsync(Guid id)
        {
            var result = await _appService.RepairStartAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-unreserve")]
        public async Task<IActionResult> ActionUnreserveAsync(Guid id)
        {
            var result = await _appService.UnreserveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-validate")]
        public async Task<IActionResult> ActionValidateAsync(Guid id)
        {
            var result = await _appService.ValidateAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-mrp-productions")]
        public async Task<IActionResult> ActionViewMrpProductionsAsync(Guid id)
        {
            var result = await _appService.ViewMrpProductionsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-purchase-orders")]
        public async Task<IActionResult> ActionViewPurchaseOrdersAsync(Guid id)
        {
            var result = await _appService.ViewPurchaseOrdersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-sale-order")]
        public async Task<IActionResult> ActionViewSaleOrderAsync(Guid id)
        {
            var result = await _appService.ViewSaleOrderAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/compute-lot-id")]
        public async Task<IActionResult> ComputeLotIdAsync(Guid id)
        {
            var result = await _appService.ComputeLotIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/compute-product-uom")]
        public async Task<IActionResult> ComputeProductUomAsync(Guid id)
        {
            var result = await _appService.ComputeProductUomAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-product-uom")]
        public async Task<IActionResult> OnchangeProductUomAsync(Guid id)
        {
            var result = await _appService.OnchangeProductUomAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/print-repair-order")]
        public async Task<IActionResult> PrintRepairOrderAsync(Guid id)
        {
            var result = await _appService.PrintRepairOrderAsync(id);
            return Ok(result);
        }
    }
}