using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class AccountAccountController
    {
        
        [HttpPost]
        [Route("{id}/action-open-related-taxes")]
        public async Task<IActionResult> ActionOpenRelatedTaxesAsync(Guid id)
        {
            var result = await _appService.OpenRelatedTaxesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-unmerge")]
        public async Task<IActionResult> ActionUnmergeAsync(Guid id)
        {
            var result = await _appService.UnmergeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] AccountAccountCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-translations")]
        public async Task<IActionResult> CopyTranslationsAsync(Guid id, [FromBody] AccountAccountCopyTranslationsRequestDto input)
        {
            var result = await _appService.CopyTranslationsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-account-group")]
        public async Task<IActionResult> GetAccountGroupAsync(Guid id, [FromBody] AccountAccountGetAccountGroupRequestDto input)
        {
            var result = await _appService.GetAccountGroupAsync(id, input);
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
        [Route("{id}/spreadsheet-fetch-balance-tag")]
        public async Task<IActionResult> SpreadsheetFetchBalanceTagAsync(Guid id, [FromBody] AccountAccountSpreadsheetFetchBalanceTagRequestDto input)
        {
            var result = await _appService.SpreadsheetFetchBalanceTagAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/spreadsheet-fetch-debit-credit")]
        public async Task<IActionResult> SpreadsheetFetchDebitCreditAsync(Guid id, [FromBody] AccountAccountSpreadsheetFetchDebitCreditRequestDto input)
        {
            var result = await _appService.SpreadsheetFetchDebitCreditAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/spreadsheet-fetch-partner-balance")]
        public async Task<IActionResult> SpreadsheetFetchPartnerBalanceAsync(Guid id, [FromBody] AccountAccountSpreadsheetFetchPartnerBalanceRequestDto input)
        {
            var result = await _appService.SpreadsheetFetchPartnerBalanceAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/spreadsheet-fetch-residual-amount")]
        public async Task<IActionResult> SpreadsheetFetchResidualAmountAsync(Guid id, [FromBody] AccountAccountSpreadsheetFetchResidualAmountRequestDto input)
        {
            var result = await _appService.SpreadsheetFetchResidualAmountAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/spreadsheet-move-line-action")]
        public async Task<IActionResult> SpreadsheetMoveLineActionAsync(Guid id, [FromBody] AccountAccountSpreadsheetMoveLineActionRequestDto input)
        {
            var result = await _appService.SpreadsheetMoveLineActionAsync(id, input);
            return Ok(result);
        }
    }
}