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
    [Route("api/v1/accounting/AccountReconcileModel")]
    public partial class AccountReconcileModelController : AbpController
    {
        protected readonly IAccountReconcileModelAppService _appService;
        public AccountReconcileModelController(IAccountReconcileModelAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-reconcile-stat")]
        public async Task<IActionResult> ReconcileStatAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ReconcileStatAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-auto-reconcile")]
        public async Task<IActionResult> SetAutoReconcileAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetAutoReconcileAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-manual")]
        public async Task<IActionResult> SetManualAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetManualAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] AccountReconcileModelCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
    }
    
}