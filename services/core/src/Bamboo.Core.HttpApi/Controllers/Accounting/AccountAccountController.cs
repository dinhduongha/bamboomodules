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
    [Route("api/v1/accounting/AccountAccount")]
    public partial class AccountAccountController : AbpController
    {
        protected readonly IAccountAccountAppService _appService;
        public AccountAccountController(IAccountAccountAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-open-related-taxes")]
        public async Task<IActionResult> OpenRelatedTaxesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenRelatedTaxesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unmerge")]
        public async Task<IActionResult> UnmergeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnmergeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] AccountAccountCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-translations")]
        public async Task<IActionResult> CopyTranslationsAsync([FromBody] AccountAccountCopyTranslationsRequestDto input)
        {
            var result = await _appService.CopyTranslationsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-account-group")]
        public async Task<IActionResult> GetAccountGroupAsync([FromBody] AccountAccountGetAccountGroupRequestDto input)
        {
            var result = await _appService.GetAccountGroupAsync(input);
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
        [Route("spreadsheet-fetch-balance-tag")]
        public async Task<IActionResult> SpreadsheetFetchBalanceTagAsync([FromBody] AccountAccountSpreadsheetFetchBalanceTagRequestDto input)
        {
            var result = await _appService.SpreadsheetFetchBalanceTagAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("spreadsheet-fetch-debit-credit")]
        public async Task<IActionResult> SpreadsheetFetchDebitCreditAsync([FromBody] AccountAccountSpreadsheetFetchDebitCreditRequestDto input)
        {
            var result = await _appService.SpreadsheetFetchDebitCreditAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("spreadsheet-fetch-partner-balance")]
        public async Task<IActionResult> SpreadsheetFetchPartnerBalanceAsync([FromBody] AccountAccountSpreadsheetFetchPartnerBalanceRequestDto input)
        {
            var result = await _appService.SpreadsheetFetchPartnerBalanceAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("spreadsheet-fetch-residual-amount")]
        public async Task<IActionResult> SpreadsheetFetchResidualAmountAsync([FromBody] AccountAccountSpreadsheetFetchResidualAmountRequestDto input)
        {
            var result = await _appService.SpreadsheetFetchResidualAmountAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("spreadsheet-move-line-action")]
        public async Task<IActionResult> SpreadsheetMoveLineActionAsync([FromBody] AccountAccountSpreadsheetMoveLineActionRequestDto input)
        {
            var result = await _appService.SpreadsheetMoveLineActionAsync(input);
            return Ok(result);
        }
    }
    
}