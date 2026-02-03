using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class CrmIapLeadMiningRequestController
    {
        
        [HttpPost]
        [Route("action-buy-credits")]
        public async Task<IActionResult> ActionBuyCreditsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.BuyCreditsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-draft")]
        public async Task<IActionResult> ActionDraftAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DraftAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-get-lead-action")]
        public async Task<IActionResult> ActionGetLeadActionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetLeadActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-get-opportunity-action")]
        public async Task<IActionResult> ActionGetOpportunityActionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetOpportunityActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-submit")]
        public async Task<IActionResult> ActionSubmitAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SubmitAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync(CrmIapLeadMiningRequestGetEmptyListHelpRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetEmptyListHelpAsync(input);
            return Ok(result);
        }
    }
}