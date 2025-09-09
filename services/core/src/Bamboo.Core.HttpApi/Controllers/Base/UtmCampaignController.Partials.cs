using System;
using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Bamboo.Core.HttpApi.Controllers.Utm
{
    public partial class UtmCampaignController
    {
        
        [HttpPost]
        [Route("{id}/action-create-mass-sms")]
        public async Task<IActionResult> ActionCreateMassSmsAsync(Guid id)
        {
            var result = await _appService.CreateMassSmsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-redirect-to-invoiced")]
        public async Task<IActionResult> ActionRedirectToInvoicedAsync(Guid id)
        {
            var result = await _appService.RedirectToInvoicedAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-redirect-to-leads-opportunities")]
        public async Task<IActionResult> ActionRedirectToLeadsOpportunitiesAsync(Guid id)
        {
            var result = await _appService.RedirectToLeadsOpportunitiesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-redirect-to-mailing-sms")]
        public async Task<IActionResult> ActionRedirectToMailingSmsAsync(Guid id)
        {
            var result = await _appService.RedirectToMailingSmsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-redirect-to-quotations")]
        public async Task<IActionResult> ActionRedirectToQuotationsAsync(Guid id)
        {
            var result = await _appService.RedirectToQuotationsAsync(id);
            return Ok(result);
        }
    }
}