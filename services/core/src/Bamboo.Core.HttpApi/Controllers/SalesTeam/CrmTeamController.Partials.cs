using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.SalesTeam
{
    public partial class CrmTeamController
    {
        
        [HttpPost]
        [Route("{id}/action-assign-leads")]
        public async Task<IActionResult> ActionAssignLeadsAsync(Guid id)
        {
            var result = await _appService.AssignLeadsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-opportunity-forecast")]
        public async Task<IActionResult> ActionOpportunityForecastAsync(Guid id)
        {
            var result = await _appService.OpportunityForecastAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-primary-channel-button")]
        public async Task<IActionResult> ActionPrimaryChannelButtonAsync(Guid id)
        {
            var result = await _appService.PrimaryChannelButtonAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-your-pipeline")]
        public async Task<IActionResult> ActionYourPipelineAsync(Guid id)
        {
            var result = await _appService.YourPipelineAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-abandoned-carts")]
        public async Task<IActionResult> GetAbandonedCartsAsync(Guid id)
        {
            var result = await _appService.GetAbandonedCartsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/update-invoiced-target")]
        public async Task<IActionResult> UpdateInvoicedTargetAsync(Guid id, [FromBody] CrmTeamUpdateInvoicedTargetRequestDto input)
        {
            var result = await _appService.UpdateInvoicedTargetAsync(id, input.Value);
            return Ok(result);
        }
    }
}