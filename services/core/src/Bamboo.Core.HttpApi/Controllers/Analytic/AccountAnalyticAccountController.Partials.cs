using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Analytic
{
    public partial class AccountAnalyticAccountController
    {
        
        [HttpPost]
        [Route("{id}/action-view-invoice")]
        public async Task<IActionResult> ActionViewInvoiceAsync(Guid id)
        {
            var result = await _appService.ViewInvoiceAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-mrp-bom")]
        public async Task<IActionResult> ActionViewMrpBomAsync(Guid id)
        {
            var result = await _appService.ViewMrpBomAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-mrp-production")]
        public async Task<IActionResult> ActionViewMrpProductionAsync(Guid id)
        {
            var result = await _appService.ViewMrpProductionAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-projects")]
        public async Task<IActionResult> ActionViewProjectsAsync(Guid id)
        {
            var result = await _appService.ViewProjectsAsync(id);
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
        [Route("{id}/action-view-vendor-bill")]
        public async Task<IActionResult> ActionViewVendorBillAsync(Guid id)
        {
            var result = await _appService.ViewVendorBillAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-workorder")]
        public async Task<IActionResult> ActionViewWorkorderAsync(Guid id)
        {
            var result = await _appService.ViewWorkorderAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] AccountAnalyticAccountCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/web-read")]
        public async Task<IActionResult> WebReadAsync(Guid id, [FromBody] AccountAnalyticAccountWebReadRequestDto input)
        {
            var result = await _appService.WebReadAsync(id, input);
            return Ok(result);
        }
    }
}