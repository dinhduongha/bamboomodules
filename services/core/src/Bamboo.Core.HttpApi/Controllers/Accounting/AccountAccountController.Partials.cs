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
        [Route("action-open-related-taxes")]
        public async Task<IActionResult> ActionOpenRelatedTaxesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenRelatedTaxesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unmerge")]
        public async Task<IActionResult> ActionUnmergeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnmergeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(AccountAccountCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-translations")]
        public async Task<IActionResult> CopyTranslationsAsync(AccountAccountCopyTranslationsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyTranslationsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-account-group")]
        public async Task<IActionResult> GetAccountGroupAsync(AccountAccountGetAccountGroupRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetAccountGroupAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetImportTemplatesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("spreadsheet-fetch-balance-tag")]
        public async Task<IActionResult> SpreadsheetFetchBalanceTagAsync(AccountAccountSpreadsheetFetchBalanceTagRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SpreadsheetFetchBalanceTagAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("spreadsheet-fetch-debit-credit")]
        public async Task<IActionResult> SpreadsheetFetchDebitCreditAsync(AccountAccountSpreadsheetFetchDebitCreditRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SpreadsheetFetchDebitCreditAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("spreadsheet-fetch-partner-balance")]
        public async Task<IActionResult> SpreadsheetFetchPartnerBalanceAsync(AccountAccountSpreadsheetFetchPartnerBalanceRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SpreadsheetFetchPartnerBalanceAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("spreadsheet-fetch-residual-amount")]
        public async Task<IActionResult> SpreadsheetFetchResidualAmountAsync(AccountAccountSpreadsheetFetchResidualAmountRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SpreadsheetFetchResidualAmountAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("spreadsheet-move-line-action")]
        public async Task<IActionResult> SpreadsheetMoveLineActionAsync(AccountAccountSpreadsheetMoveLineActionRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SpreadsheetMoveLineActionAsync(input);
            return Ok(result);
        }
    }
}