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
    [Route("api/v1/accounting/AccountAnalyticLine")]
    public partial class AccountAnalyticLineController : AbpController
    {
        protected readonly IAccountAnalyticLineAppService _appService;
        public AccountAnalyticLineController(IAccountAnalyticLineAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-invoice-from-timesheet")]
        public async Task<IActionResult> InvoiceFromTimesheetAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.InvoiceFromTimesheetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-timesheet-view-portal")]
        public async Task<IActionResult> OpenTimesheetViewPortalAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenTimesheetViewPortalAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-sale-order-from-timesheet")]
        public async Task<IActionResult> SaleOrderFromTimesheetAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SaleOrderFromTimesheetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetImportTemplatesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-unusual-days")]
        public async Task<IActionResult> GetUnusualDaysAsync([FromBody] AccountAnalyticLineGetUnusualDaysRequestDto input)
        {
            var result = await _appService.GetUnusualDaysAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-views")]
        public async Task<IActionResult> GetViewsAsync([FromBody] AccountAnalyticLineGetViewsRequestDto input)
        {
            var result = await _appService.GetViewsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("on-change-unit-amount")]
        public async Task<IActionResult> OnChangeUnitAmountAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnChangeUnitAmountAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("view-header-get")]
        public async Task<IActionResult> ViewHeaderGetAsync([FromBody] AccountAnalyticLineViewHeaderGetRequestDto input)
        {
            var result = await _appService.ViewHeaderGetAsync(input);
            return Ok(result);
        }
    }
    
}