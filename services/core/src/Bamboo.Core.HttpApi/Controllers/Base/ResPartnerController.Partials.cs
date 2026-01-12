using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ResPartnerController
    {
        
        [HttpPost]
        [Route("{id}/action-done")]
        public async Task<IActionResult> ActionDoneAsync(Guid id)
        {
            var result = await _appService.DoneAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-event-view")]
        public async Task<IActionResult> ActionEventViewAsync(Guid id)
        {
            var result = await _appService.EventViewAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-business-doc")]
        public async Task<IActionResult> ActionOpenBusinessDocAsync(Guid id)
        {
            var result = await _appService.OpenBusinessDocAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-employees")]
        public async Task<IActionResult> ActionOpenEmployeesAsync(Guid id)
        {
            var result = await _appService.OpenEmployeesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-privacy-lookup")]
        public async Task<IActionResult> ActionPrivacyLookupAsync(Guid id)
        {
            var result = await _appService.PrivacyLookupAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-signup-prepare")]
        public async Task<IActionResult> ActionSignupPrepareAsync(Guid id)
        {
            var result = await _appService.SignupPrepareAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-certifications")]
        public async Task<IActionResult> ActionViewCertificationsAsync(Guid id)
        {
            var result = await _appService.ViewCertificationsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-courses")]
        public async Task<IActionResult> ActionViewCoursesAsync(Guid id)
        {
            var result = await _appService.ViewCoursesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-livechat-sessions")]
        public async Task<IActionResult> ActionViewLivechatSessionsAsync(Guid id)
        {
            var result = await _appService.ViewLivechatSessionsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-loyalty-cards")]
        public async Task<IActionResult> ActionViewLoyaltyCardsAsync(Guid id)
        {
            var result = await _appService.ViewLoyaltyCardsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-opportunity")]
        public async Task<IActionResult> ActionViewOpportunityAsync(Guid id)
        {
            var result = await _appService.ViewOpportunityAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-partner-invoices")]
        public async Task<IActionResult> ActionViewPartnerInvoicesAsync(Guid id)
        {
            var result = await _appService.ViewPartnerInvoicesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-pos-order")]
        public async Task<IActionResult> ActionViewPosOrderAsync(Guid id)
        {
            var result = await _appService.ViewPosOrderAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-stock-serial")]
        public async Task<IActionResult> ActionViewStockSerialAsync(Guid id)
        {
            var result = await _appService.ViewStockSerialAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-tasks")]
        public async Task<IActionResult> ActionViewTasksAsync(Guid id)
        {
            var result = await _appService.ViewTasksAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/address-get")]
        public async Task<IActionResult> AddressGetAsync(Guid id, [FromBody] ResPartnerAddressGetRequestDto input)
        {
            var result = await _appService.AddressGetAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/autocomplete-by-name")]
        public async Task<IActionResult> AutocompleteByNameAsync(Guid id, [FromBody] ResPartnerAutocompleteByNameRequestDto input)
        {
            var result = await _appService.AutocompleteByNameAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/autocomplete-by-vat")]
        public async Task<IActionResult> AutocompleteByVatAsync(Guid id, [FromBody] ResPartnerAutocompleteByVatRequestDto input)
        {
            var result = await _appService.AutocompleteByVatAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-account-peppol-check-partner-endpoint")]
        public async Task<IActionResult> ButtonAccountPeppolCheckPartnerEndpointAsync(Guid id, [FromBody] ResPartnerButtonAccountPeppolCheckPartnerEndpointRequestDto input)
        {
            var result = await _appService.ButtonAccountPeppolCheckPartnerEndpointAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/can-edit-vat")]
        public async Task<IActionResult> CanEditVatAsync(Guid id)
        {
            var result = await _appService.CanEditVatAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-al")]
        public async Task<IActionResult> CheckVatAlAsync(Guid id, [FromBody] ResPartnerCheckVatAlRequestDto input)
        {
            var result = await _appService.CheckVatAlAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-br")]
        public async Task<IActionResult> CheckVatBrAsync(Guid id, [FromBody] ResPartnerCheckVatBrRequestDto input)
        {
            var result = await _appService.CheckVatBrAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-ch")]
        public async Task<IActionResult> CheckVatChAsync(Guid id, [FromBody] ResPartnerCheckVatChRequestDto input)
        {
            var result = await _appService.CheckVatChAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-cr")]
        public async Task<IActionResult> CheckVatCrAsync(Guid id, [FromBody] ResPartnerCheckVatCrRequestDto input)
        {
            var result = await _appService.CheckVatCrAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-de")]
        public async Task<IActionResult> CheckVatDeAsync(Guid id, [FromBody] ResPartnerCheckVatDeRequestDto input)
        {
            var result = await _appService.CheckVatDeAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-do")]
        public async Task<IActionResult> CheckVatDoAsync(Guid id, [FromBody] ResPartnerCheckVatDoRequestDto input)
        {
            var result = await _appService.CheckVatDoAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-ec")]
        public async Task<IActionResult> CheckVatEcAsync(Guid id, [FromBody] ResPartnerCheckVatEcRequestDto input)
        {
            var result = await _appService.CheckVatEcAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-gr")]
        public async Task<IActionResult> CheckVatGrAsync(Guid id, [FromBody] ResPartnerCheckVatGrRequestDto input)
        {
            var result = await _appService.CheckVatGrAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-gt")]
        public async Task<IActionResult> CheckVatGtAsync(Guid id, [FromBody] ResPartnerCheckVatGtRequestDto input)
        {
            var result = await _appService.CheckVatGtAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-hu")]
        public async Task<IActionResult> CheckVatHuAsync(Guid id, [FromBody] ResPartnerCheckVatHuRequestDto input)
        {
            var result = await _appService.CheckVatHuAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-id")]
        public async Task<IActionResult> CheckVatIdAsync(Guid id, [FromBody] ResPartnerCheckVatIdRequestDto input)
        {
            var result = await _appService.CheckVatIdAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-ie")]
        public async Task<IActionResult> CheckVatIeAsync(Guid id, [FromBody] ResPartnerCheckVatIeRequestDto input)
        {
            var result = await _appService.CheckVatIeAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-il")]
        public async Task<IActionResult> CheckVatIlAsync(Guid id, [FromBody] ResPartnerCheckVatIlRequestDto input)
        {
            var result = await _appService.CheckVatIlAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-in")]
        public async Task<IActionResult> CheckVatInAsync(Guid id, [FromBody] ResPartnerCheckVatInRequestDto input)
        {
            var result = await _appService.CheckVatInAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-jp")]
        public async Task<IActionResult> CheckVatJpAsync(Guid id, [FromBody] ResPartnerCheckVatJpRequestDto input)
        {
            var result = await _appService.CheckVatJpAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-ma")]
        public async Task<IActionResult> CheckVatMaAsync(Guid id, [FromBody] ResPartnerCheckVatMaRequestDto input)
        {
            var result = await _appService.CheckVatMaAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-mx")]
        public async Task<IActionResult> CheckVatMxAsync(Guid id, [FromBody] ResPartnerCheckVatMxRequestDto input)
        {
            var result = await _appService.CheckVatMxAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-no")]
        public async Task<IActionResult> CheckVatNoAsync(Guid id, [FromBody] ResPartnerCheckVatNoRequestDto input)
        {
            var result = await _appService.CheckVatNoAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-pe")]
        public async Task<IActionResult> CheckVatPeAsync(Guid id, [FromBody] ResPartnerCheckVatPeRequestDto input)
        {
            var result = await _appService.CheckVatPeAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-ph")]
        public async Task<IActionResult> CheckVatPhAsync(Guid id, [FromBody] ResPartnerCheckVatPhRequestDto input)
        {
            var result = await _appService.CheckVatPhAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-ro")]
        public async Task<IActionResult> CheckVatRoAsync(Guid id, [FromBody] ResPartnerCheckVatRoRequestDto input)
        {
            var result = await _appService.CheckVatRoAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-rs")]
        public async Task<IActionResult> CheckVatRsAsync(Guid id, [FromBody] ResPartnerCheckVatRsRequestDto input)
        {
            var result = await _appService.CheckVatRsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-ru")]
        public async Task<IActionResult> CheckVatRuAsync(Guid id, [FromBody] ResPartnerCheckVatRuRequestDto input)
        {
            var result = await _appService.CheckVatRuAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-sa")]
        public async Task<IActionResult> CheckVatSaAsync(Guid id, [FromBody] ResPartnerCheckVatSaRequestDto input)
        {
            var result = await _appService.CheckVatSaAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-th")]
        public async Task<IActionResult> CheckVatThAsync(Guid id, [FromBody] ResPartnerCheckVatThRequestDto input)
        {
            var result = await _appService.CheckVatThAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-tr")]
        public async Task<IActionResult> CheckVatTrAsync(Guid id, [FromBody] ResPartnerCheckVatTrRequestDto input)
        {
            var result = await _appService.CheckVatTrAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-tw")]
        public async Task<IActionResult> CheckVatTwAsync(Guid id, [FromBody] ResPartnerCheckVatTwRequestDto input)
        {
            var result = await _appService.CheckVatTwAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-ua")]
        public async Task<IActionResult> CheckVatUaAsync(Guid id, [FromBody] ResPartnerCheckVatUaRequestDto input)
        {
            var result = await _appService.CheckVatUaAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-uy")]
        public async Task<IActionResult> CheckVatUyAsync(Guid id, [FromBody] ResPartnerCheckVatUyRequestDto input)
        {
            var result = await _appService.CheckVatUyAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-ve")]
        public async Task<IActionResult> CheckVatVeAsync(Guid id, [FromBody] ResPartnerCheckVatVeRequestDto input)
        {
            var result = await _appService.CheckVatVeAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-vn")]
        public async Task<IActionResult> CheckVatVnAsync(Guid id, [FromBody] ResPartnerCheckVatVnRequestDto input)
        {
            var result = await _appService.CheckVatVnAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] ResPartnerCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/create-company")]
        public async Task<IActionResult> CreateCompanyAsync(Guid id)
        {
            var result = await _appService.CreateCompanyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/do-button-print")]
        public async Task<IActionResult> DoButtonPrintAsync(Guid id)
        {
            var result = await _appService.DoButtonPrintAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/do-partner-mail")]
        public async Task<IActionResult> DoPartnerMailAsync(Guid id)
        {
            var result = await _appService.DoPartnerMailAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/do-partner-manual-action")]
        public async Task<IActionResult> DoPartnerManualActionAsync(Guid id, [FromBody] ResPartnerDoPartnerManualActionRequestDto input)
        {
            var result = await _appService.DoPartnerManualActionAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/do-partner-manual-action-dermanord")]
        public async Task<IActionResult> DoPartnerManualActionDermanordAsync(Guid id, [FromBody] ResPartnerDoPartnerManualDermanordRequestDto input)
        {
            var result = await _appService.DoPartnerManualDermanordAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/do-partner-print")]
        public async Task<IActionResult> DoPartnerPrintAsync(Guid id, [FromBody] ResPartnerDoPartnerPrintRequestDto input)
        {
            var result = await _appService.DoPartnerPrintAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/enrich-by-domain")]
        public async Task<IActionResult> EnrichByDomainAsync(Guid id, [FromBody] ResPartnerEnrichByDomainRequestDto input)
        {
            var result = await _appService.EnrichByDomainAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/enrich-by-duns")]
        public async Task<IActionResult> EnrichByDunsAsync(Guid id, [FromBody] ResPartnerEnrichByDunsRequestDto input)
        {
            var result = await _appService.EnrichByDunsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/enrich-by-gst")]
        public async Task<IActionResult> EnrichByGstAsync(Guid id, [FromBody] ResPartnerEnrichByGstRequestDto input)
        {
            var result = await _appService.EnrichByGstAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/fields-view-get")]
        public async Task<IActionResult> FieldsViewGetAsync(Guid id, [FromBody] ResPartnerFieldsViewGetRequestDto input)
        {
            var result = await _appService.FieldsViewGetAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/find-or-create")]
        public async Task<IActionResult> FindOrCreateAsync(Guid id, [FromBody] ResPartnerFindOrCreateRequestDto input)
        {
            var result = await _appService.FindOrCreateAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/format-vat-ch")]
        public async Task<IActionResult> FormatVatChAsync(Guid id, [FromBody] ResPartnerFormatVatChRequestDto input)
        {
            var result = await _appService.FormatVatChAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/format-vat-cl")]
        public async Task<IActionResult> FormatVatClAsync(Guid id, [FromBody] ResPartnerFormatVatClRequestDto input)
        {
            var result = await _appService.FormatVatClAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/format-vat-co")]
        public async Task<IActionResult> FormatVatCoAsync(Guid id, [FromBody] ResPartnerFormatVatCoRequestDto input)
        {
            var result = await _appService.FormatVatCoAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/format-vat-eu")]
        public async Task<IActionResult> FormatVatEuAsync(Guid id, [FromBody] ResPartnerFormatVatEuRequestDto input)
        {
            var result = await _appService.FormatVatEuAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/format-vat-hu")]
        public async Task<IActionResult> FormatVatHuAsync(Guid id, [FromBody] ResPartnerFormatVatHuRequestDto input)
        {
            var result = await _appService.FormatVatHuAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/format-vat-sm")]
        public async Task<IActionResult> FormatVatSmAsync(Guid id, [FromBody] ResPartnerFormatVatSmRequestDto input)
        {
            var result = await _appService.FormatVatSmAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/format-vat-vn")]
        public async Task<IActionResult> FormatVatVnAsync(Guid id, [FromBody] ResPartnerFormatVatVnRequestDto input)
        {
            var result = await _appService.FormatVatVnAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/geo-localize")]
        public async Task<IActionResult> GeoLocalizeAsync(Guid id)
        {
            var result = await _appService.GeoLocalizeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-attendee-detail")]
        public async Task<IActionResult> GetAttendeeDetailAsync(Guid id, [FromBody] ResPartnerGetAttendeeDetailRequestDto input)
        {
            var result = await _appService.GetAttendeeDetailAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-backend-menu-id")]
        public async Task<IActionResult> GetBackendMenuIdAsync(Guid id)
        {
            var result = await _appService.GetBackendMenuIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-followup-table-html")]
        public async Task<IActionResult> GetFollowupTableHtmlAsync(Guid id)
        {
            var result = await _appService.GetFollowupTableHtmlAsync(id);
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
        [Route("{id}/get-mention-suggestions")]
        public async Task<IActionResult> GetMentionSuggestionsAsync(Guid id, [FromBody] ResPartnerGetMentionSuggestionsRequestDto input)
        {
            var result = await _appService.GetMentionSuggestionsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-mention-suggestions-from-channel")]
        public async Task<IActionResult> GetMentionSuggestionsFromChannelAsync(Guid id, [FromBody] ResPartnerGetMentionSuggestionsFromChannelRequestDto input)
        {
            var result = await _appService.GetMentionSuggestionsFromChannelAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-new-partner")]
        public async Task<IActionResult> GetNewPartnerAsync(Guid id, [FromBody] ResPartnerGetNewPartnerRequestDto input)
        {
            var result = await _appService.GetNewPartnerAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-partner-localisation-fields-required-to-invoice")]
        public async Task<IActionResult> GetPartnerLocalisationFieldsRequiredToInvoiceAsync(Guid id, [FromBody] ResPartnerGetPartnerLocalisationFieldsRequiredToInvoiceRequestDto input)
        {
            var result = await _appService.GetPartnerLocalisationFieldsRequiredToInvoiceAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-working-hours-for-all-attendees")]
        public async Task<IActionResult> GetWorkingHoursForAllAttendeesAsync(Guid id, [FromBody] ResPartnerGetWorkingHoursForAllAttendeesRequestDto input)
        {
            var result = await _appService.GetWorkingHoursForAllAttendeesAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-worklocation")]
        public async Task<IActionResult> GetWorklocationAsync(Guid id, [FromBody] ResPartnerGetWorklocationRequestDto input)
        {
            var result = await _appService.GetWorklocationAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/google-map-img")]
        public async Task<IActionResult> GoogleMapImgAsync(Guid id, [FromBody] ResPartnerGoogleMapImgRequestDto input)
        {
            var result = await _appService.GoogleMapImgAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/google-map-link")]
        public async Task<IActionResult> GoogleMapLinkAsync(Guid id, [FromBody] ResPartnerGoogleMapLinkRequestDto input)
        {
            var result = await _appService.GoogleMapLinkAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/iap-partner-autocomplete-get-tag-ids")]
        public async Task<IActionResult> IapPartnerAutocompleteGetTagIdsAsync(Guid id, [FromBody] ResPartnerIapPartnerAutocompleteGetTagIdsRequestDto input)
        {
            var result = await _appService.IapPartnerAutocompleteGetTagIdsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/is-valid-ruc-ec")]
        public async Task<IActionResult> IsValidRucEcAsync(Guid id, [FromBody] ResPartnerIsValidRucEcRequestDto input)
        {
            var result = await _appService.IsValidRucEcAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-company-type")]
        public async Task<IActionResult> OnchangeCompanyTypeAsync(Guid id)
        {
            var result = await _appService.OnchangeCompanyTypeAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-parent-id")]
        public async Task<IActionResult> OnchangeParentIdAsync(Guid id)
        {
            var result = await _appService.OnchangeParentIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/open-commercial-entity")]
        public async Task<IActionResult> OpenCommercialEntityAsync(Guid id)
        {
            var result = await _appService.OpenCommercialEntityAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/schedule-meeting")]
        public async Task<IActionResult> ScheduleMeetingAsync(Guid id)
        {
            var result = await _appService.ScheduleMeetingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/search-for-channel-invite")]
        public async Task<IActionResult> SearchForChannelInviteAsync(Guid id, [FromBody] ResPartnerSearchForChannelInviteRequestDto input)
        {
            var result = await _appService.SearchForChannelInviteAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/signup-cancel")]
        public async Task<IActionResult> SignupCancelAsync(Guid id)
        {
            var result = await _appService.SignupCancelAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/signup-get-auth-param")]
        public async Task<IActionResult> SignupGetAuthParamAsync(Guid id)
        {
            var result = await _appService.SignupGetAuthParamAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/signup-prepare")]
        public async Task<IActionResult> SignupPrepareAsync(Guid id, [FromBody] ResPartnerSignupPrepareRequestDto input)
        {
            var result = await _appService.SignupPrepareAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/view-header-get")]
        public async Task<IActionResult> ViewHeaderGetAsync(Guid id, [FromBody] ResPartnerViewHeaderGetRequestDto input)
        {
            var result = await _appService.ViewHeaderGetAsync(id, input);
            return Ok(result);
        }
    }
}