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
    [Route("api/v1/marketing/UtmCampaign")]
    public partial class UtmCampaignController : AbpController
    {
        protected readonly IUtmCampaignAppService _appService;
        public UtmCampaignController(IUtmCampaignAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-create-mass-sms")]
        public async Task<IActionResult> CreateMassSmsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateMassSmsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-invoiced")]
        public async Task<IActionResult> RedirectToInvoicedAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RedirectToInvoicedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-leads-opportunities")]
        public async Task<IActionResult> RedirectToLeadsOpportunitiesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RedirectToLeadsOpportunitiesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-mailing-sms")]
        public async Task<IActionResult> RedirectToMailingSmsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RedirectToMailingSmsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-quotations")]
        public async Task<IActionResult> RedirectToQuotationsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RedirectToQuotationsAsync(ids);
            return Ok(result);
        }
    }
    
}