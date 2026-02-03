using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class CrmLeadController
    {
        
        [HttpPost]
        [Route("action-assign-partner")]
        public async Task<IActionResult> ActionAssignPartnerAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AssignPartnerAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-generate-leads")]
        public async Task<IActionResult> ActionGenerateLeadsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GenerateLeadsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-new-quotation")]
        public async Task<IActionResult> ActionNewQuotationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.NewQuotationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-livechat")]
        public async Task<IActionResult> ActionOpenLivechatAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenLivechatAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-livechat-sessions")]
        public async Task<IActionResult> ActionRedirectToLivechatSessionsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RedirectToLivechatSessionsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-page-views")]
        public async Task<IActionResult> ActionRedirectToPageViewsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RedirectToPageViewsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reschedule-meeting")]
        public async Task<IActionResult> ActionRescheduleMeetingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RescheduleMeetingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-restore")]
        public async Task<IActionResult> ActionRestoreAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RestoreAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-sale-quotations-new")]
        public async Task<IActionResult> ActionSaleQuotationsNewAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SaleQuotationsNewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-schedule-meeting")]
        public async Task<IActionResult> ActionScheduleMeetingAsync(CrmLeadScheduleMeetingRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ScheduleMeetingAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-automated-probability")]
        public async Task<IActionResult> ActionSetAutomatedProbabilityAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetAutomatedProbabilityAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-lost")]
        public async Task<IActionResult> ActionSetLostAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetLostAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-won")]
        public async Task<IActionResult> ActionSetWonAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetWonAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-won-rainbowman")]
        public async Task<IActionResult> ActionSetWonRainbowmanAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SetWonRainbowmanAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-show-potential-duplicates")]
        public async Task<IActionResult> ActionShowPotentialDuplicatesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ShowPotentialDuplicatesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unarchive")]
        public async Task<IActionResult> ActionUnarchiveAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UnarchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sale-order")]
        public async Task<IActionResult> ActionViewSaleOrderAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewSaleOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sale-quotation")]
        public async Task<IActionResult> ActionViewSaleQuotationAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewSaleQuotationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("assign-geo-localize")]
        public async Task<IActionResult> AssignGeoLocalizeAsync(CrmLeadAssignGeoLocalizeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.AssignGeoLocalizeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("assign-partner")]
        public async Task<IActionResult> AssignPartnerAsync(CrmLeadAssignPartnerRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.AssignPartnerAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("assign-salesman-of-assigned-partner")]
        public async Task<IActionResult> AssignSalesmanOfAssignedPartnerAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.AssignSalesmanOfAssignedPartnerAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("convert-opportunity")]
        public async Task<IActionResult> ConvertOpportunityAsync(CrmLeadConvertOpportunityRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ConvertOpportunityAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(CrmLeadCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-opp-portal")]
        public async Task<IActionResult> CreateOppPortalAsync(CrmLeadCreateOppPortalRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CreateOppPortalAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync(CrmLeadGetEmptyListHelpRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetEmptyListHelpAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetImportTemplatesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-rainbowman-message")]
        public async Task<IActionResult> GetRainbowmanMessageAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetRainbowmanMessageAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("iap-enrich")]
        public async Task<IActionResult> IapEnrichAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.IapEnrichAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("log-meeting")]
        public async Task<IActionResult> LogMeetingAsync(CrmLeadLogMeetingRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.LogMeetingAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("merge-opportunity")]
        public async Task<IActionResult> MergeOpportunityAsync(CrmLeadMergeOpportunityRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MergeOpportunityAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-new")]
        public async Task<IActionResult> MessageNewAsync(CrmLeadMessageNewRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MessageNewAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("partner-desinterested")]
        public async Task<IActionResult> PartnerDesinterestedAsync(CrmLeadPartnerDesinterestedRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.PartnerDesinterestedAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("partner-interested")]
        public async Task<IActionResult> PartnerInterestedAsync(CrmLeadPartnerInterestedRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.PartnerInterestedAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("prepare-pls-tooltip-data")]
        public async Task<IActionResult> PreparePlsTooltipDataAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PreparePlsTooltipDataAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("redirect-lead-opportunity-view")]
        public async Task<IActionResult> RedirectLeadOpportunityViewAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.RedirectLeadOpportunityViewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("search-fetch")]
        public async Task<IActionResult> SearchFetchAsync(CrmLeadSearchFetchRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SearchFetchAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("search-geo-partner")]
        public async Task<IActionResult> SearchGeoPartnerAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SearchGeoPartnerAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-contact-details-from-portal")]
        public async Task<IActionResult> UpdateContactDetailsFromPortalAsync(CrmLeadUpdateContactDetailsFromPortalRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.UpdateContactDetailsFromPortalAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-lead-portal")]
        public async Task<IActionResult> UpdateLeadPortalAsync(CrmLeadUpdateLeadPortalRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.UpdateLeadPortalAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("website-form-input-filter")]
        public async Task<IActionResult> WebsiteFormInputFilterAsync(CrmLeadWebsiteFormInputFilterRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.WebsiteFormInputFilterAsync(input);
            return Ok(result);
        }
    }
}