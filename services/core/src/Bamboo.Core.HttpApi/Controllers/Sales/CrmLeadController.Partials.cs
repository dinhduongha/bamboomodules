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
        [Route("{id}/action-assign-partner")]
        public async Task<IActionResult> ActionAssignPartnerAsync(Guid id)
        {
            var result = await _appService.AssignPartnerAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-generate-leads")]
        public async Task<IActionResult> ActionGenerateLeadsAsync(Guid id)
        {
            var result = await _appService.GenerateLeadsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-new-quotation")]
        public async Task<IActionResult> ActionNewQuotationAsync(Guid id)
        {
            var result = await _appService.NewQuotationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-redirect-to-livechat-sessions")]
        public async Task<IActionResult> ActionRedirectToLivechatSessionsAsync(Guid id)
        {
            var result = await _appService.RedirectToLivechatSessionsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-redirect-to-page-views")]
        public async Task<IActionResult> ActionRedirectToPageViewsAsync(Guid id)
        {
            var result = await _appService.RedirectToPageViewsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-reschedule-meeting")]
        public async Task<IActionResult> ActionRescheduleMeetingAsync(Guid id)
        {
            var result = await _appService.RescheduleMeetingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-sale-quotations-new")]
        public async Task<IActionResult> ActionSaleQuotationsNewAsync(Guid id)
        {
            var result = await _appService.SaleQuotationsNewAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-schedule-meeting")]
        public async Task<IActionResult> ActionScheduleMeetingAsync(Guid id, [FromBody] CrmLeadScheduleMeetingRequestDto input)
        {
            var result = await _appService.ScheduleMeetingAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-set-automated-probability")]
        public async Task<IActionResult> ActionSetAutomatedProbabilityAsync(Guid id)
        {
            var result = await _appService.SetAutomatedProbabilityAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-set-lost")]
        public async Task<IActionResult> ActionSetLostAsync(Guid id)
        {
            var result = await _appService.SetLostAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-set-won")]
        public async Task<IActionResult> ActionSetWonAsync(Guid id)
        {
            var result = await _appService.SetWonAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-set-won-rainbowman")]
        public async Task<IActionResult> ActionSetWonRainbowmanAsync(Guid id)
        {
            var result = await _appService.SetWonRainbowmanAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-show-potential-duplicates")]
        public async Task<IActionResult> ActionShowPotentialDuplicatesAsync(Guid id)
        {
            var result = await _appService.ShowPotentialDuplicatesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-snooze")]
        public async Task<IActionResult> ActionSnoozeAsync(Guid id)
        {
            var result = await _appService.SnoozeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-sale-order")]
        public async Task<IActionResult> ActionViewSaleOrderAsync(Guid id)
        {
            var result = await _appService.ViewSaleOrderAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-sale-quotation")]
        public async Task<IActionResult> ActionViewSaleQuotationAsync(Guid id)
        {
            var result = await _appService.ViewSaleQuotationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/assign-geo-localize")]
        public async Task<IActionResult> AssignGeoLocalizeAsync(Guid id, [FromBody] CrmLeadAssignGeoLocalizeRequestDto input)
        {
            var result = await _appService.AssignGeoLocalizeAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/assign-partner")]
        public async Task<IActionResult> AssignPartnerAsync(Guid id, [FromBody] CrmLeadAssignPartnerRequestDto input)
        {
            var result = await _appService.AssignPartnerAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/assign-salesman-of-assigned-partner")]
        public async Task<IActionResult> AssignSalesmanOfAssignedPartnerAsync(Guid id)
        {
            var result = await _appService.AssignSalesmanOfAssignedPartnerAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/convert-opportunity")]
        public async Task<IActionResult> ConvertOpportunityAsync(Guid id, [FromBody] CrmLeadConvertOpportunityRequestDto input)
        {
            var result = await _appService.ConvertOpportunityAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] CrmLeadCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-opp-portal")]
        public async Task<IActionResult> CreateOppPortalAsync(Guid id, [FromBody] CrmLeadCreateOppPortalRequestDto input)
        {
            var result = await _appService.CreateOppPortalAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync(Guid id, [FromBody] CrmLeadGetEmptyListHelpRequestDto input)
        {
            var result = await _appService.GetEmptyListHelpAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync(Guid id)
        {
            var result = await _appService.GetImportTemplatesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-rainbowman-message")]
        public async Task<IActionResult> GetRainbowmanMessageAsync(Guid id)
        {
            var result = await _appService.GetRainbowmanMessageAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/iap-enrich")]
        public async Task<IActionResult> IapEnrichAsync(Guid id, [FromBody] CrmLeadIapEnrichRequestDto input)
        {
            var result = await _appService.IapEnrichAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/log-meeting")]
        public async Task<IActionResult> LogMeetingAsync(Guid id, [FromBody] CrmLeadLogMeetingRequestDto input)
        {
            var result = await _appService.LogMeetingAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/merge-opportunity")]
        public async Task<IActionResult> MergeOpportunityAsync(Guid id, [FromBody] CrmLeadMergeOpportunityRequestDto input)
        {
            var result = await _appService.MergeOpportunityAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/message-new")]
        public async Task<IActionResult> MessageNewAsync(Guid id, [FromBody] CrmLeadMessageNewRequestDto input)
        {
            var result = await _appService.MessageNewAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/partner-desinterested")]
        public async Task<IActionResult> PartnerDesinterestedAsync(Guid id, [FromBody] CrmLeadPartnerDesinterestedRequestDto input)
        {
            var result = await _appService.PartnerDesinterestedAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/partner-interested")]
        public async Task<IActionResult> PartnerInterestedAsync(Guid id, [FromBody] CrmLeadPartnerInterestedRequestDto input)
        {
            var result = await _appService.PartnerInterestedAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/redirect-lead-opportunity-view")]
        public async Task<IActionResult> RedirectLeadOpportunityViewAsync(Guid id)
        {
            var result = await _appService.RedirectLeadOpportunityViewAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/search-fetch")]
        public async Task<IActionResult> SearchFetchAsync(Guid id, [FromBody] CrmLeadSearchFetchRequestDto input)
        {
            var result = await _appService.SearchFetchAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/search-geo-partner")]
        public async Task<IActionResult> SearchGeoPartnerAsync(Guid id)
        {
            var result = await _appService.SearchGeoPartnerAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-active")]
        public async Task<IActionResult> ToggleActiveAsync(Guid id)
        {
            var result = await _appService.ToggleActiveAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/update-contact-details-from-portal")]
        public async Task<IActionResult> UpdateContactDetailsFromPortalAsync(Guid id, [FromBody] CrmLeadUpdateContactDetailsFromPortalRequestDto input)
        {
            var result = await _appService.UpdateContactDetailsFromPortalAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/update-lead-portal")]
        public async Task<IActionResult> UpdateLeadPortalAsync(Guid id, [FromBody] CrmLeadUpdateLeadPortalRequestDto input)
        {
            var result = await _appService.UpdateLeadPortalAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/website-form-input-filter")]
        public async Task<IActionResult> WebsiteFormInputFilterAsync(Guid id, [FromBody] CrmLeadWebsiteFormInputFilterRequestDto input)
        {
            var result = await _appService.WebsiteFormInputFilterAsync(id, input);
            return Ok(result);
        }
    }
}