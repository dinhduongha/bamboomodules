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
    [Route("api/v1/accounting/AccountAnalyticAccount")]
    public partial class AccountAnalyticAccountController : AbpController
    {
        protected readonly IAccountAnalyticAccountAppService _appService;
        public AccountAnalyticAccountController(IAccountAnalyticAccountAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-view-invoice")]
        public async Task<IActionResult> ViewInvoiceAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewInvoiceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mrp-bom")]
        public async Task<IActionResult> ViewMrpBomAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewMrpBomAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mrp-production")]
        public async Task<IActionResult> ViewMrpProductionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewMrpProductionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-projects")]
        public async Task<IActionResult> ViewProjectsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewProjectsAsync(ids);
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
        [Route("action-view-vendor-bill")]
        public async Task<IActionResult> ViewVendorBillAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewVendorBillAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-workorder")]
        public async Task<IActionResult> ViewWorkorderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewWorkorderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] AccountAnalyticAccountCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("web-read")]
        public async Task<IActionResult> WebReadAsync([FromBody] AccountAnalyticAccountWebReadRequestDto input)
        {
            var result = await _appService.WebReadAsync(input);
            return Ok(result);
        }
    }
    
}