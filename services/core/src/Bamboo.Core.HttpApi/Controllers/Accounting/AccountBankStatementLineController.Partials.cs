using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class AccountBankStatementLineController
    {
        
        [HttpPost]
        [Route("action-undo-reconciliation")]
        public async Task<IActionResult> ActionUndoReconciliationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UndoReconciliationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("formatted-read-group")]
        public async Task<IActionResult> FormattedReadGroupAsync(AccountBankStatementLineFormattedReadGroupRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FormattedReadGroupAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> NewAsync(AccountBankStatementLineNewRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.NewAsync(input);
            return Ok(result);
        }
    }
}