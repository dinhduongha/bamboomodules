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
        [Route("action-reconcile-stat")]
        public async Task<IActionResult> ActionReconcileStatAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ReconcileStatAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-auto-reconcile")]
        public async Task<IActionResult> ActionSetAutoReconcileAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetAutoReconcileAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-manual")]
        public async Task<IActionResult> ActionSetManualAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetManualAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(AccountReconcileModelCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
    }
}