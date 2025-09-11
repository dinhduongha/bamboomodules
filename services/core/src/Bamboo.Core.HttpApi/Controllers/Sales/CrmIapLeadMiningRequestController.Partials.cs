using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System;
using Microsoft.AspNetCore.Authorization;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class CrmIapLeadMiningRequestController
    {
        
        [HttpPost]
        [Route("{id}/action-buy-credits")]
        public async Task<IActionResult> ActionBuyCreditsAsync(Guid id)
        {
            var result = await _appService.BuyCreditsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-draft")]
        public async Task<IActionResult> ActionDraftAsync(Guid id)
        {
            var result = await _appService.DraftAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-get-lead-action")]
        public async Task<IActionResult> ActionGetLeadActionAsync(Guid id)
        {
            var result = await _appService.GetLeadActionAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-get-opportunity-action")]
        public async Task<IActionResult> ActionGetOpportunityActionAsync(Guid id)
        {
            var result = await _appService.GetOpportunityActionAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-submit")]
        public async Task<IActionResult> ActionSubmitAsync(Guid id)
        {
            var result = await _appService.SubmitAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync(Guid id, [FromBody] CrmIapLeadMiningRequestGetEmptyListHelpRequestDto input)
        {
            var result = await _appService.GetEmptyListHelpAsync(id, input);
            return Ok(result);
        }
    }
}