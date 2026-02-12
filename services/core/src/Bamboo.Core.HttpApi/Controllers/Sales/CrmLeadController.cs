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
    [Route("api/v1/sales/CrmLead")]
    public partial class CrmLeadController : AbpController
    {
        protected readonly ICrmLeadAppService _appService;
        public CrmLeadController(ICrmLeadAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-assign-partner")]
        public async Task<IActionResult> AssignPartnerAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AssignPartnerAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-generate-leads")]
        public async Task<IActionResult> GenerateLeadsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GenerateLeadsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-new-quotation")]
        public async Task<IActionResult> NewQuotationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.NewQuotationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-livechat")]
        public async Task<IActionResult> OpenLivechatAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenLivechatAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-livechat-sessions")]
        public async Task<IActionResult> RedirectToLivechatSessionsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RedirectToLivechatSessionsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-redirect-to-page-views")]
        public async Task<IActionResult> RedirectToPageViewsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RedirectToPageViewsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-reschedule-meeting")]
        public async Task<IActionResult> RescheduleMeetingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RescheduleMeetingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-restore")]
        public async Task<IActionResult> RestoreAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RestoreAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-sale-quotations-new")]
        public async Task<IActionResult> SaleQuotationsNewAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SaleQuotationsNewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-schedule-meeting")]
        public async Task<IActionResult> ScheduleMeetingAsync([FromBody] CrmLeadScheduleMeetingRequestDto input)
        {
            var result = await _appService.ScheduleMeetingAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-automated-probability")]
        public async Task<IActionResult> SetAutomatedProbabilityAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetAutomatedProbabilityAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-lost")]
        public async Task<IActionResult> SetLostAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetLostAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-won")]
        public async Task<IActionResult> SetWonAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetWonAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-set-won-rainbowman")]
        public async Task<IActionResult> SetWonRainbowmanAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SetWonRainbowmanAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-show-potential-duplicates")]
        public async Task<IActionResult> ShowPotentialDuplicatesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ShowPotentialDuplicatesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-unarchive")]
        public async Task<IActionResult> UnarchiveAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UnarchiveAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sale-order")]
        public async Task<IActionResult> ViewSaleOrderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewSaleOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sale-quotation")]
        public async Task<IActionResult> ViewSaleQuotationAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewSaleQuotationAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("assign-geo-localize")]
        public async Task<IActionResult> AssignGeoLocalizeAsync([FromBody] CrmLeadAssignGeoLocalizeRequestDto input)
        {
            var result = await _appService.AssignGeoLocalizeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("assign-partner")]
        public async Task<IActionResult> AssignPartnerAsync([FromBody] CrmLeadAssignPartnerRequestDto input)
        {
            var result = await _appService.AssignPartnerAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("assign-salesman-of-assigned-partner")]
        public async Task<IActionResult> AssignSalesmanOfAssignedPartnerAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.AssignSalesmanOfAssignedPartnerAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("convert-opportunity")]
        public async Task<IActionResult> ConvertOpportunityAsync([FromBody] CrmLeadConvertOpportunityRequestDto input)
        {
            var result = await _appService.ConvertOpportunityAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] CrmLeadCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-opp-portal")]
        public async Task<IActionResult> CreateOppPortalAsync([FromBody] CrmLeadCreateOppPortalRequestDto input)
        {
            var result = await _appService.CreateOppPortalAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-empty-list-help")]
        public async Task<IActionResult> GetEmptyListHelpAsync([FromBody] CrmLeadGetEmptyListHelpRequestDto input)
        {
            var result = await _appService.GetEmptyListHelpAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-import-templates")]
        public async Task<IActionResult> GetImportTemplatesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetImportTemplatesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-rainbowman-message")]
        public async Task<IActionResult> GetRainbowmanMessageAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetRainbowmanMessageAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("iap-enrich")]
        public async Task<IActionResult> IapEnrichAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.IapEnrichAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("log-meeting")]
        public async Task<IActionResult> LogMeetingAsync([FromBody] CrmLeadLogMeetingRequestDto input)
        {
            var result = await _appService.LogMeetingAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("merge-opportunity")]
        public async Task<IActionResult> MergeOpportunityAsync([FromBody] CrmLeadMergeOpportunityRequestDto input)
        {
            var result = await _appService.MergeOpportunityAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-new")]
        public async Task<IActionResult> MessageNewAsync([FromBody] CrmLeadMessageNewRequestDto input)
        {
            var result = await _appService.MessageNewAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("partner-desinterested")]
        public async Task<IActionResult> PartnerDesinterestedAsync([FromBody] CrmLeadPartnerDesinterestedRequestDto input)
        {
            var result = await _appService.PartnerDesinterestedAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("partner-interested")]
        public async Task<IActionResult> PartnerInterestedAsync([FromBody] CrmLeadPartnerInterestedRequestDto input)
        {
            var result = await _appService.PartnerInterestedAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("prepare-pls-tooltip-data")]
        public async Task<IActionResult> PreparePlsTooltipDataAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PreparePlsTooltipDataAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("redirect-lead-opportunity-view")]
        public async Task<IActionResult> RedirectLeadOpportunityViewAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.RedirectLeadOpportunityViewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("search-fetch")]
        public async Task<IActionResult> SearchFetchAsync([FromBody] CrmLeadSearchFetchRequestDto input)
        {
            var result = await _appService.SearchFetchAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("search-geo-partner")]
        public async Task<IActionResult> SearchGeoPartnerAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SearchGeoPartnerAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-contact-details-from-portal")]
        public async Task<IActionResult> UpdateContactDetailsFromPortalAsync([FromBody] CrmLeadUpdateContactDetailsFromPortalRequestDto input)
        {
            var result = await _appService.UpdateContactDetailsFromPortalAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("update-lead-portal")]
        public async Task<IActionResult> UpdateLeadPortalAsync([FromBody] CrmLeadUpdateLeadPortalRequestDto input)
        {
            var result = await _appService.UpdateLeadPortalAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("website-form-input-filter")]
        public async Task<IActionResult> WebsiteFormInputFilterAsync([FromBody] CrmLeadWebsiteFormInputFilterRequestDto input)
        {
            var result = await _appService.WebsiteFormInputFilterAsync(input);
            return Ok(result);
        }
    }
    
}