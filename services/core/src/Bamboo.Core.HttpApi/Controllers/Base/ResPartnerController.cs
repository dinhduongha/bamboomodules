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
    [Route("api/v1/base/ResPartner")]
    public partial class ResPartnerController : AbpController
    {
        protected readonly IResPartnerAppService _appService;
        public ResPartnerController(IResPartnerAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-done")]
        public async Task<IActionResult> DoneAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-event-view")]
        public async Task<IActionResult> EventViewAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.EventViewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-business-doc")]
        public async Task<IActionResult> OpenBusinessDocAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenBusinessDocAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-employees")]
        public async Task<IActionResult> OpenEmployeesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenEmployeesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-privacy-lookup")]
        public async Task<IActionResult> PrivacyLookupAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PrivacyLookupAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-signup-prepare")]
        public async Task<IActionResult> SignupPrepareAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SignupPrepareAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-certifications")]
        public async Task<IActionResult> ViewCertificationsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewCertificationsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-courses")]
        public async Task<IActionResult> ViewCoursesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewCoursesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-livechat-sessions")]
        public async Task<IActionResult> ViewLivechatSessionsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewLivechatSessionsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-loyalty-cards")]
        public async Task<IActionResult> ViewLoyaltyCardsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewLoyaltyCardsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-opportunity")]
        public async Task<IActionResult> ViewOpportunityAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewOpportunityAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-partner-invoices")]
        public async Task<IActionResult> ViewPartnerInvoicesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewPartnerInvoicesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-pos-order")]
        public async Task<IActionResult> ViewPosOrderAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewPosOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-stock-serial")]
        public async Task<IActionResult> ViewStockSerialAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewStockSerialAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-tasks")]
        public async Task<IActionResult> ViewTasksAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewTasksAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("address-get")]
        public async Task<IActionResult> AddressGetAsync([FromBody] ResPartnerAddressGetRequestDto input)
        {
            var result = await _appService.AddressGetAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("autocomplete-by-name")]
        public async Task<IActionResult> AutocompleteByNameAsync([FromBody] ResPartnerAutocompleteByNameRequestDto input)
        {
            var result = await _appService.AutocompleteByNameAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("autocomplete-by-vat")]
        public async Task<IActionResult> AutocompleteByVatAsync([FromBody] ResPartnerAutocompleteByVatRequestDto input)
        {
            var result = await _appService.AutocompleteByVatAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-account-peppol-check-partner-endpoint")]
        public async Task<IActionResult> ButtonAccountPeppolCheckPartnerEndpointAsync([FromBody] ResPartnerButtonAccountPeppolCheckPartnerEndpointRequestDto input)
        {
            var result = await _appService.ButtonAccountPeppolCheckPartnerEndpointAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("can-edit-vat")]
        public async Task<IActionResult> CanEditVatAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CanEditVatAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-al")]
        public async Task<IActionResult> CheckVatAlAsync([FromBody] ResPartnerCheckVatAlRequestDto input)
        {
            var result = await _appService.CheckVatAlAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-br")]
        public async Task<IActionResult> CheckVatBrAsync([FromBody] ResPartnerCheckVatBrRequestDto input)
        {
            var result = await _appService.CheckVatBrAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-ch")]
        public async Task<IActionResult> CheckVatChAsync([FromBody] ResPartnerCheckVatChRequestDto input)
        {
            var result = await _appService.CheckVatChAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-cr")]
        public async Task<IActionResult> CheckVatCrAsync([FromBody] ResPartnerCheckVatCrRequestDto input)
        {
            var result = await _appService.CheckVatCrAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-de")]
        public async Task<IActionResult> CheckVatDeAsync([FromBody] ResPartnerCheckVatDeRequestDto input)
        {
            var result = await _appService.CheckVatDeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-do")]
        public async Task<IActionResult> CheckVatDoAsync([FromBody] ResPartnerCheckVatDoRequestDto input)
        {
            var result = await _appService.CheckVatDoAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-ec")]
        public async Task<IActionResult> CheckVatEcAsync([FromBody] ResPartnerCheckVatEcRequestDto input)
        {
            var result = await _appService.CheckVatEcAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-gr")]
        public async Task<IActionResult> CheckVatGrAsync([FromBody] ResPartnerCheckVatGrRequestDto input)
        {
            var result = await _appService.CheckVatGrAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-gt")]
        public async Task<IActionResult> CheckVatGtAsync([FromBody] ResPartnerCheckVatGtRequestDto input)
        {
            var result = await _appService.CheckVatGtAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-hu")]
        public async Task<IActionResult> CheckVatHuAsync([FromBody] ResPartnerCheckVatHuRequestDto input)
        {
            var result = await _appService.CheckVatHuAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-id")]
        public async Task<IActionResult> CheckVatIdAsync([FromBody] ResPartnerCheckVatIdRequestDto input)
        {
            var result = await _appService.CheckVatIdAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-ie")]
        public async Task<IActionResult> CheckVatIeAsync([FromBody] ResPartnerCheckVatIeRequestDto input)
        {
            var result = await _appService.CheckVatIeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-il")]
        public async Task<IActionResult> CheckVatIlAsync([FromBody] ResPartnerCheckVatIlRequestDto input)
        {
            var result = await _appService.CheckVatIlAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-in")]
        public async Task<IActionResult> CheckVatInAsync([FromBody] ResPartnerCheckVatInRequestDto input)
        {
            var result = await _appService.CheckVatInAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-jp")]
        public async Task<IActionResult> CheckVatJpAsync([FromBody] ResPartnerCheckVatJpRequestDto input)
        {
            var result = await _appService.CheckVatJpAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-ma")]
        public async Task<IActionResult> CheckVatMaAsync([FromBody] ResPartnerCheckVatMaRequestDto input)
        {
            var result = await _appService.CheckVatMaAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-mx")]
        public async Task<IActionResult> CheckVatMxAsync([FromBody] ResPartnerCheckVatMxRequestDto input)
        {
            var result = await _appService.CheckVatMxAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-no")]
        public async Task<IActionResult> CheckVatNoAsync([FromBody] ResPartnerCheckVatNoRequestDto input)
        {
            var result = await _appService.CheckVatNoAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-pe")]
        public async Task<IActionResult> CheckVatPeAsync([FromBody] ResPartnerCheckVatPeRequestDto input)
        {
            var result = await _appService.CheckVatPeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-ph")]
        public async Task<IActionResult> CheckVatPhAsync([FromBody] ResPartnerCheckVatPhRequestDto input)
        {
            var result = await _appService.CheckVatPhAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-ro")]
        public async Task<IActionResult> CheckVatRoAsync([FromBody] ResPartnerCheckVatRoRequestDto input)
        {
            var result = await _appService.CheckVatRoAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-rs")]
        public async Task<IActionResult> CheckVatRsAsync([FromBody] ResPartnerCheckVatRsRequestDto input)
        {
            var result = await _appService.CheckVatRsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-ru")]
        public async Task<IActionResult> CheckVatRuAsync([FromBody] ResPartnerCheckVatRuRequestDto input)
        {
            var result = await _appService.CheckVatRuAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-sa")]
        public async Task<IActionResult> CheckVatSaAsync([FromBody] ResPartnerCheckVatSaRequestDto input)
        {
            var result = await _appService.CheckVatSaAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-th")]
        public async Task<IActionResult> CheckVatThAsync([FromBody] ResPartnerCheckVatThRequestDto input)
        {
            var result = await _appService.CheckVatThAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-tr")]
        public async Task<IActionResult> CheckVatTrAsync([FromBody] ResPartnerCheckVatTrRequestDto input)
        {
            var result = await _appService.CheckVatTrAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-tw")]
        public async Task<IActionResult> CheckVatTwAsync([FromBody] ResPartnerCheckVatTwRequestDto input)
        {
            var result = await _appService.CheckVatTwAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-ua")]
        public async Task<IActionResult> CheckVatUaAsync([FromBody] ResPartnerCheckVatUaRequestDto input)
        {
            var result = await _appService.CheckVatUaAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-uy")]
        public async Task<IActionResult> CheckVatUyAsync([FromBody] ResPartnerCheckVatUyRequestDto input)
        {
            var result = await _appService.CheckVatUyAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-ve")]
        public async Task<IActionResult> CheckVatVeAsync([FromBody] ResPartnerCheckVatVeRequestDto input)
        {
            var result = await _appService.CheckVatVeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-vn")]
        public async Task<IActionResult> CheckVatVnAsync([FromBody] ResPartnerCheckVatVnRequestDto input)
        {
            var result = await _appService.CheckVatVnAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] ResPartnerCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-company")]
        public async Task<IActionResult> CreateCompanyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateCompanyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("do-button-print")]
        public async Task<IActionResult> DoButtonPrintAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DoButtonPrintAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("do-partner-mail")]
        public async Task<IActionResult> DoPartnerMailAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.DoPartnerMailAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("do-partner-manual-action")]
        public async Task<IActionResult> DoPartnerManualActionAsync([FromBody] ResPartnerDoPartnerManualActionRequestDto input)
        {
            var result = await _appService.DoPartnerManualActionAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("do-partner-manual-action-dermanord")]
        public async Task<IActionResult> DoPartnerManualDermanordAsync([FromBody] ResPartnerDoPartnerManualDermanordRequestDto input)
        {
            var result = await _appService.DoPartnerManualDermanordAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("do-partner-print")]
        public async Task<IActionResult> DoPartnerPrintAsync([FromBody] ResPartnerDoPartnerPrintRequestDto input)
        {
            var result = await _appService.DoPartnerPrintAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("enrich-by-domain")]
        public async Task<IActionResult> EnrichByDomainAsync([FromBody] ResPartnerEnrichByDomainRequestDto input)
        {
            var result = await _appService.EnrichByDomainAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("enrich-by-duns")]
        public async Task<IActionResult> EnrichByDunsAsync([FromBody] ResPartnerEnrichByDunsRequestDto input)
        {
            var result = await _appService.EnrichByDunsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("enrich-by-gst")]
        public async Task<IActionResult> EnrichByGstAsync([FromBody] ResPartnerEnrichByGstRequestDto input)
        {
            var result = await _appService.EnrichByGstAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("fields-view-get")]
        public async Task<IActionResult> FieldsViewGetAsync([FromBody] ResPartnerFieldsViewGetRequestDto input)
        {
            var result = await _appService.FieldsViewGetAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("find-or-create")]
        public async Task<IActionResult> FindOrCreateAsync([FromBody] ResPartnerFindOrCreateRequestDto input)
        {
            var result = await _appService.FindOrCreateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("format-vat-ch")]
        public async Task<IActionResult> FormatVatChAsync([FromBody] ResPartnerFormatVatChRequestDto input)
        {
            var result = await _appService.FormatVatChAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("format-vat-cl")]
        public async Task<IActionResult> FormatVatClAsync([FromBody] ResPartnerFormatVatClRequestDto input)
        {
            var result = await _appService.FormatVatClAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("format-vat-co")]
        public async Task<IActionResult> FormatVatCoAsync([FromBody] ResPartnerFormatVatCoRequestDto input)
        {
            var result = await _appService.FormatVatCoAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("format-vat-eu")]
        public async Task<IActionResult> FormatVatEuAsync([FromBody] ResPartnerFormatVatEuRequestDto input)
        {
            var result = await _appService.FormatVatEuAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("format-vat-hu")]
        public async Task<IActionResult> FormatVatHuAsync([FromBody] ResPartnerFormatVatHuRequestDto input)
        {
            var result = await _appService.FormatVatHuAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("format-vat-sm")]
        public async Task<IActionResult> FormatVatSmAsync([FromBody] ResPartnerFormatVatSmRequestDto input)
        {
            var result = await _appService.FormatVatSmAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("format-vat-vn")]
        public async Task<IActionResult> FormatVatVnAsync([FromBody] ResPartnerFormatVatVnRequestDto input)
        {
            var result = await _appService.FormatVatVnAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("geo-localize")]
        public async Task<IActionResult> GeoLocalizeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GeoLocalizeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-attendee-detail")]
        public async Task<IActionResult> GetAttendeeDetailAsync([FromBody] ResPartnerGetAttendeeDetailRequestDto input)
        {
            var result = await _appService.GetAttendeeDetailAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-backend-menu-id")]
        public async Task<IActionResult> GetBackendMenuIdAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetBackendMenuIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-followup-table-html")]
        public async Task<IActionResult> GetFollowupTableHtmlAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetFollowupTableHtmlAsync(ids);
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
        [Route("get-mention-suggestions")]
        public async Task<IActionResult> GetMentionSuggestionsAsync([FromBody] ResPartnerGetMentionSuggestionsRequestDto input)
        {
            var result = await _appService.GetMentionSuggestionsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-mention-suggestions-from-channel")]
        public async Task<IActionResult> GetMentionSuggestionsFromChannelAsync([FromBody] ResPartnerGetMentionSuggestionsFromChannelRequestDto input)
        {
            var result = await _appService.GetMentionSuggestionsFromChannelAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-new-partner")]
        public async Task<IActionResult> GetNewPartnerAsync([FromBody] ResPartnerGetNewPartnerRequestDto input)
        {
            var result = await _appService.GetNewPartnerAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-partner-localisation-fields-required-to-invoice")]
        public async Task<IActionResult> GetPartnerLocalisationFieldsRequiredToInvoiceAsync([FromBody] ResPartnerGetPartnerLocalisationFieldsRequiredToInvoiceRequestDto input)
        {
            var result = await _appService.GetPartnerLocalisationFieldsRequiredToInvoiceAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-working-hours-for-all-attendees")]
        public async Task<IActionResult> GetWorkingHoursForAllAttendeesAsync([FromBody] ResPartnerGetWorkingHoursForAllAttendeesRequestDto input)
        {
            var result = await _appService.GetWorkingHoursForAllAttendeesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-worklocation")]
        public async Task<IActionResult> GetWorklocationAsync([FromBody] ResPartnerGetWorklocationRequestDto input)
        {
            var result = await _appService.GetWorklocationAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("google-map-img")]
        public async Task<IActionResult> GoogleMapImgAsync([FromBody] ResPartnerGoogleMapImgRequestDto input)
        {
            var result = await _appService.GoogleMapImgAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("google-map-link")]
        public async Task<IActionResult> GoogleMapLinkAsync([FromBody] ResPartnerGoogleMapLinkRequestDto input)
        {
            var result = await _appService.GoogleMapLinkAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("iap-partner-autocomplete-get-tag-ids")]
        public async Task<IActionResult> IapPartnerAutocompleteGetTagIdsAsync([FromBody] ResPartnerIapPartnerAutocompleteGetTagIdsRequestDto input)
        {
            var result = await _appService.IapPartnerAutocompleteGetTagIdsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-valid-ruc-ec")]
        public async Task<IActionResult> IsValidRucEcAsync([FromBody] ResPartnerIsValidRucEcRequestDto input)
        {
            var result = await _appService.IsValidRucEcAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-company-type")]
        public async Task<IActionResult> OnchangeCompanyTypeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangeCompanyTypeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-parent-id")]
        public async Task<IActionResult> OnchangeParentIdAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OnchangeParentIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-commercial-entity")]
        public async Task<IActionResult> OpenCommercialEntityAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenCommercialEntityAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("schedule-meeting")]
        public async Task<IActionResult> ScheduleMeetingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ScheduleMeetingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("search-for-channel-invite")]
        public async Task<IActionResult> SearchForChannelInviteAsync([FromBody] ResPartnerSearchForChannelInviteRequestDto input)
        {
            var result = await _appService.SearchForChannelInviteAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("signup-cancel")]
        public async Task<IActionResult> SignupCancelAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SignupCancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("signup-get-auth-param")]
        public async Task<IActionResult> SignupGetAuthParamAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.SignupGetAuthParamAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("signup-prepare")]
        public async Task<IActionResult> SignupPrepareAsync([FromBody] ResPartnerSignupPrepareRequestDto input)
        {
            var result = await _appService.SignupPrepareAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("view-header-get")]
        public async Task<IActionResult> ViewHeaderGetAsync([FromBody] ResPartnerViewHeaderGetRequestDto input)
        {
            var result = await _appService.ViewHeaderGetAsync(input);
            return Ok(result);
        }
    }
    
}