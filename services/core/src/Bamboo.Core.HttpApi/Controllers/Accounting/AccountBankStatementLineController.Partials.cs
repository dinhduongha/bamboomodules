using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class AccountBankStatementLineController
    {
        
        [HttpPost]
        [Route("{id}/action-undo-reconciliation")]
        public async Task<IActionResult> ActionUndoReconciliationAsync(Guid id)
        {
            var result = await _appService.UndoReconciliationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/init")]
        public async Task<IActionResult> InitAsync(Guid id)
        {
            var result = await _appService.InitAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/new")]
        public async Task<IActionResult> NewAsync(Guid id, [FromBody] AccountBankStatementLineNewRequestDto input)
        {
            var result = await _appService.NewAsync(id, input);
            return Ok(result);
        }
    }
}