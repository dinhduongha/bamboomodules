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
    [Route("api/v1/accounting/AccountBankStatementLine")]
    public partial class AccountBankStatementLineController : AbpController
    {
        protected readonly IAccountBankStatementLineAppService _appService;
        public AccountBankStatementLineController(IAccountBankStatementLineAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-undo-reconciliation")]
        public async Task<IActionResult> UndoReconciliationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UndoReconciliationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("formatted-read-group")]
        public async Task<IActionResult> FormattedReadGroupAsync([FromBody] AccountBankStatementLineFormattedReadGroupRequestDto input)
        {
            var result = await _appService.FormattedReadGroupAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> NewAsync([FromBody] AccountBankStatementLineNewRequestDto input)
        {
            var result = await _appService.NewAsync(input);
            return Ok(result);
        }
    }
    
}