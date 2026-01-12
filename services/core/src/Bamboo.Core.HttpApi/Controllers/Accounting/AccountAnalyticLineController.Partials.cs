using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class AccountAnalyticLineController
    {
        
        [HttpPost]
        [Route("{id}/action-invoice-from-timesheet")]
        public async Task<IActionResult> ActionInvoiceFromTimesheetAsync(Guid id)
        {
            var result = await _appService.InvoiceFromTimesheetAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-timesheet-view-portal")]
        public async Task<IActionResult> ActionOpenTimesheetViewPortalAsync(Guid id)
        {
            var result = await _appService.OpenTimesheetViewPortalAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-sale-order-from-timesheet")]
        public async Task<IActionResult> ActionSaleOrderFromTimesheetAsync(Guid id)
        {
            var result = await _appService.SaleOrderFromTimesheetAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync(Guid id)
        {
            var result = await _appService.GetImportTemplatesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-unusual-days")]
        public async Task<IActionResult> GetUnusualDaysAsync(Guid id, [FromBody] AccountAnalyticLineGetUnusualDaysRequestDto input)
        {
            var result = await _appService.GetUnusualDaysAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-views")]
        public async Task<IActionResult> GetViewsAsync(Guid id, [FromBody] AccountAnalyticLineGetViewsRequestDto input)
        {
            var result = await _appService.GetViewsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/on-change-unit-amount")]
        public async Task<IActionResult> OnChangeUnitAmountAsync(Guid id)
        {
            var result = await _appService.OnChangeUnitAmountAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/view-header-get")]
        public async Task<IActionResult> ViewHeaderGetAsync(Guid id, [FromBody] AccountAnalyticLineViewHeaderGetRequestDto input)
        {
            var result = await _appService.ViewHeaderGetAsync(id, input);
            return Ok(result);
        }
    }
}