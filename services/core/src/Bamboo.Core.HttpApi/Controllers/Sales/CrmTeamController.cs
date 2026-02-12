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
    [Route("api/v1/sales/CrmTeam")]
    public partial class CrmTeamController : AbpController
    {
        protected readonly ICrmTeamAppService _appService;
        public CrmTeamController(ICrmTeamAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-assign-leads")]
        public async Task<IActionResult> AssignLeadsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AssignLeadsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-leads")]
        public async Task<IActionResult> OpenLeadsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenLeadsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-unassigned-leads")]
        public async Task<IActionResult> OpenUnassignedLeadsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenUnassignedLeadsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-opportunity-forecast")]
        public async Task<IActionResult> OpportunityForecastAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpportunityForecastAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-primary-channel-button")]
        public async Task<IActionResult> PrimaryChannelButtonAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PrimaryChannelButtonAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-your-pipeline")]
        public async Task<IActionResult> YourPipelineAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.YourPipelineAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-abandoned-carts")]
        public async Task<IActionResult> GetAbandonedCartsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetAbandonedCartsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-invoiced-target")]
        public async Task<IActionResult> UpdateInvoicedTargetAsync([FromBody] CrmTeamUpdateInvoicedTargetRequestDto input)
        {
            var result = await _appService.UpdateInvoicedTargetAsync(input);
            return Ok(result);
        }
    }
    
}