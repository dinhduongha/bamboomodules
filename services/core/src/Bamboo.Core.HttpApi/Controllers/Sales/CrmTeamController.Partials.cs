using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class CrmTeamController
    {
        
        [HttpPost]
        [Route("action-assign-leads")]
        public async Task<IActionResult> ActionAssignLeadsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AssignLeadsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-leads")]
        public async Task<IActionResult> ActionOpenLeadsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenLeadsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-unassigned-leads")]
        public async Task<IActionResult> ActionOpenUnassignedLeadsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenUnassignedLeadsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-opportunity-forecast")]
        public async Task<IActionResult> ActionOpportunityForecastAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpportunityForecastAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-primary-channel-button")]
        public async Task<IActionResult> ActionPrimaryChannelButtonAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PrimaryChannelButtonAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-your-pipeline")]
        public async Task<IActionResult> ActionYourPipelineAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.YourPipelineAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-abandoned-carts")]
        public async Task<IActionResult> GetAbandonedCartsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetAbandonedCartsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-invoiced-target")]
        public async Task<IActionResult> UpdateInvoicedTargetAsync(CrmTeamUpdateInvoicedTargetRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.UpdateInvoicedTargetAsync(input);
            return Ok(result);
        }
    }
}