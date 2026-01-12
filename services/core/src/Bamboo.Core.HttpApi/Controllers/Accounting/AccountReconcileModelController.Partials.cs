using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class AccountReconcileModelController
    {
        
        [HttpPost]
        [Route("{id}/action-reconcile-stat")]
        public async Task<IActionResult> ActionReconcileStatAsync(Guid id)
        {
            var result = await _appService.ReconcileStatAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-set-auto-reconcile")]
        public async Task<IActionResult> ActionSetAutoReconcileAsync(Guid id)
        {
            var result = await _appService.SetAutoReconcileAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-set-manual")]
        public async Task<IActionResult> ActionSetManualAsync(Guid id)
        {
            var result = await _appService.SetManualAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] AccountReconcileModelCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
    }
}