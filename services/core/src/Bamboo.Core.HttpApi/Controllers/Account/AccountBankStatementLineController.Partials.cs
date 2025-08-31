using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Account
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
            var result = await _appService.NewAsync(id, input.Values, input.Origin, input.Ref);
            return Ok(result);
        }
    }
}