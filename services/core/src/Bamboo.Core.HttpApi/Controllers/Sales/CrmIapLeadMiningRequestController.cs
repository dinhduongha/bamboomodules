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
    [Route("api/v1/sales/CrmIapLeadMiningRequest")]
    public partial class CrmIapLeadMiningRequestController : AbpController
    {
        protected readonly ICrmIapLeadMiningRequestAppService _appService;
        public CrmIapLeadMiningRequestController(ICrmIapLeadMiningRequestAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-buy-credits")]
        public async Task<IActionResult> BuyCreditsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.BuyCreditsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-draft")]
        public async Task<IActionResult> DraftAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DraftAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-get-lead-action")]
        public async Task<IActionResult> GetLeadActionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetLeadActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-get-opportunity-action")]
        public async Task<IActionResult> GetOpportunityActionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetOpportunityActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-submit")]
        public async Task<IActionResult> SubmitAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SubmitAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync([FromBody] CrmIapLeadMiningRequestGetEmptyListHelpRequestDto input)
        {
            var result = await _appService.GetEmptyListHelpAsync(input);
            return Ok(result);
        }
    }
    
}