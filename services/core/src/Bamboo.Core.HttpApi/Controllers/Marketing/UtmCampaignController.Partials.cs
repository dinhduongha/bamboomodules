using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class UtmCampaignController
    {
        
        [HttpPost]
        [Route("action-create-mass-sms")]
        public async Task<IActionResult> ActionCreateMassSmsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreateMassSmsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-invoiced")]
        public async Task<IActionResult> ActionRedirectToInvoicedAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RedirectToInvoicedAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-leads-opportunities")]
        public async Task<IActionResult> ActionRedirectToLeadsOpportunitiesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RedirectToLeadsOpportunitiesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-mailing-sms")]
        public async Task<IActionResult> ActionRedirectToMailingSmsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RedirectToMailingSmsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-quotations")]
        public async Task<IActionResult> ActionRedirectToQuotationsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RedirectToQuotationsAsync(ids);
            return Ok(result);
        }
    }
}