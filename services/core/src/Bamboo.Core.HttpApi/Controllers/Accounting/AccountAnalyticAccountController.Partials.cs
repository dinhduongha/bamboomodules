using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class AccountAnalyticAccountController
    {
        
        [HttpPost]
        [Route("action-view-invoice")]
        public async Task<IActionResult> ActionViewInvoiceAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewInvoiceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mrp-bom")]
        public async Task<IActionResult> ActionViewMrpBomAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewMrpBomAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mrp-production")]
        public async Task<IActionResult> ActionViewMrpProductionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewMrpProductionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-projects")]
        public async Task<IActionResult> ActionViewProjectsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewProjectsAsync(ids);
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
        [Route("action-view-vendor-bill")]
        public async Task<IActionResult> ActionViewVendorBillAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewVendorBillAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-workorder")]
        public async Task<IActionResult> ActionViewWorkorderAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewWorkorderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(AccountAnalyticAccountCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("web-read")]
        public async Task<IActionResult> WebReadAsync(AccountAnalyticAccountWebReadRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.WebReadAsync(input);
            return Ok(result);
        }
    }
}