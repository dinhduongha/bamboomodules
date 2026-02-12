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
    [Route("api/v1/supply-chain/MrpWorkorder")]
    public partial class MrpWorkorderController : AbpController
    {
        protected readonly IMrpWorkorderAppService _appService;
        public MrpWorkorderController(IMrpWorkorderAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-cancel")]
        public async Task<IActionResult> CancelAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-mark-as-done")]
        public async Task<IActionResult> MarkAsDoneAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.MarkAsDoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-wizard")]
        public async Task<IActionResult> OpenWizardAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenWizardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-replan")]
        public async Task<IActionResult> ReplanAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ReplanAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-see-move-scrap")]
        public async Task<IActionResult> SeeMoveScrapAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SeeMoveScrapAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-finish")]
        public async Task<IActionResult> ButtonFinishAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonFinishAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-pending")]
        public async Task<IActionResult> ButtonPendingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonPendingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-scrap")]
        public async Task<IActionResult> ButtonScrapAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonScrapAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-start")]
        public async Task<IActionResult> ButtonStartAsync([FromBody] MrpWorkorderButtonStartRequestDto input)
        {
            var result = await _appService.ButtonStartAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-unblock")]
        public async Task<IActionResult> ButtonUnblockAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ButtonUnblockAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("end-all")]
        public async Task<IActionResult> EndAllAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.EndAllAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("end-previous")]
        public async Task<IActionResult> EndPreviousAsync([FromBody] MrpWorkorderEndPreviousRequestDto input)
        {
            var result = await _appService.EndPreviousAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-duration")]
        public async Task<IActionResult> GetDurationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetDurationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-working-duration")]
        public async Task<IActionResult> GetWorkingDurationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetWorkingDurationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("set-state")]
        public async Task<IActionResult> SetStateAsync([FromBody] MrpWorkorderSetStateRequestDto input)
        {
            var result = await _appService.SetStateAsync(input);
            return Ok(result);
        }
    }
    
}