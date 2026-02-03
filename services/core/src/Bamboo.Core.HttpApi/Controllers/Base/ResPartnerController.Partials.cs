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
        [Route("action-done")]
        public async Task<IActionResult> ActionDoneAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-event-view")]
        public async Task<IActionResult> ActionEventViewAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.EventViewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-business-doc")]
        public async Task<IActionResult> ActionOpenBusinessDocAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenBusinessDocAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-employees")]
        public async Task<IActionResult> ActionOpenEmployeesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenEmployeesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-privacy-lookup")]
        public async Task<IActionResult> ActionPrivacyLookupAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PrivacyLookupAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-signup-prepare")]
        public async Task<IActionResult> ActionSignupPrepareAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SignupPrepareAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-certifications")]
        public async Task<IActionResult> ActionViewCertificationsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewCertificationsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-courses")]
        public async Task<IActionResult> ActionViewCoursesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewCoursesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-livechat-sessions")]
        public async Task<IActionResult> ActionViewLivechatSessionsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewLivechatSessionsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-loyalty-cards")]
        public async Task<IActionResult> ActionViewLoyaltyCardsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewLoyaltyCardsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-opportunity")]
        public async Task<IActionResult> ActionViewOpportunityAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewOpportunityAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-partner-invoices")]
        public async Task<IActionResult> ActionViewPartnerInvoicesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewPartnerInvoicesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-pos-order")]
        public async Task<IActionResult> ActionViewPosOrderAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewPosOrderAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-stock-serial")]
        public async Task<IActionResult> ActionViewStockSerialAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewStockSerialAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-tasks")]
        public async Task<IActionResult> ActionViewTasksAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewTasksAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("address-get")]
        public async Task<IActionResult> AddressGetAsync(ResPartnerAddressGetRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.AddressGetAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("autocomplete-by-name")]
        public async Task<IActionResult> AutocompleteByNameAsync(ResPartnerAutocompleteByNameRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.AutocompleteByNameAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("autocomplete-by-vat")]
        public async Task<IActionResult> AutocompleteByVatAsync(ResPartnerAutocompleteByVatRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.AutocompleteByVatAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("button-account-peppol-check-partner-endpoint")]
        public async Task<IActionResult> ButtonAccountPeppolCheckPartnerEndpointAsync(ResPartnerButtonAccountPeppolCheckPartnerEndpointRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ButtonAccountPeppolCheckPartnerEndpointAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("can-edit-vat")]
        public async Task<IActionResult> CanEditVatAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CanEditVatAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-al")]
        public async Task<IActionResult> CheckVatAlAsync(ResPartnerCheckVatAlRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatAlAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-br")]
        public async Task<IActionResult> CheckVatBrAsync(ResPartnerCheckVatBrRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatBrAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-ch")]
        public async Task<IActionResult> CheckVatChAsync(ResPartnerCheckVatChRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatChAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-cr")]
        public async Task<IActionResult> CheckVatCrAsync(ResPartnerCheckVatCrRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatCrAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-de")]
        public async Task<IActionResult> CheckVatDeAsync(ResPartnerCheckVatDeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatDeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-do")]
        public async Task<IActionResult> CheckVatDoAsync(ResPartnerCheckVatDoRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatDoAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-ec")]
        public async Task<IActionResult> CheckVatEcAsync(ResPartnerCheckVatEcRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatEcAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-gr")]
        public async Task<IActionResult> CheckVatGrAsync(ResPartnerCheckVatGrRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatGrAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-gt")]
        public async Task<IActionResult> CheckVatGtAsync(ResPartnerCheckVatGtRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatGtAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-hu")]
        public async Task<IActionResult> CheckVatHuAsync(ResPartnerCheckVatHuRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatHuAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-id")]
        public async Task<IActionResult> CheckVatIdAsync(ResPartnerCheckVatIdRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatIdAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-ie")]
        public async Task<IActionResult> CheckVatIeAsync(ResPartnerCheckVatIeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatIeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-il")]
        public async Task<IActionResult> CheckVatIlAsync(ResPartnerCheckVatIlRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatIlAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-in")]
        public async Task<IActionResult> CheckVatInAsync(ResPartnerCheckVatInRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatInAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-jp")]
        public async Task<IActionResult> CheckVatJpAsync(ResPartnerCheckVatJpRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatJpAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-ma")]
        public async Task<IActionResult> CheckVatMaAsync(ResPartnerCheckVatMaRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatMaAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-mx")]
        public async Task<IActionResult> CheckVatMxAsync(ResPartnerCheckVatMxRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatMxAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-no")]
        public async Task<IActionResult> CheckVatNoAsync(ResPartnerCheckVatNoRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatNoAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-pe")]
        public async Task<IActionResult> CheckVatPeAsync(ResPartnerCheckVatPeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatPeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-ph")]
        public async Task<IActionResult> CheckVatPhAsync(ResPartnerCheckVatPhRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatPhAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-ro")]
        public async Task<IActionResult> CheckVatRoAsync(ResPartnerCheckVatRoRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatRoAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-rs")]
        public async Task<IActionResult> CheckVatRsAsync(ResPartnerCheckVatRsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatRsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-ru")]
        public async Task<IActionResult> CheckVatRuAsync(ResPartnerCheckVatRuRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatRuAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-sa")]
        public async Task<IActionResult> CheckVatSaAsync(ResPartnerCheckVatSaRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatSaAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-th")]
        public async Task<IActionResult> CheckVatThAsync(ResPartnerCheckVatThRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatThAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-tr")]
        public async Task<IActionResult> CheckVatTrAsync(ResPartnerCheckVatTrRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatTrAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-tw")]
        public async Task<IActionResult> CheckVatTwAsync(ResPartnerCheckVatTwRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatTwAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-ua")]
        public async Task<IActionResult> CheckVatUaAsync(ResPartnerCheckVatUaRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatUaAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-uy")]
        public async Task<IActionResult> CheckVatUyAsync(ResPartnerCheckVatUyRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatUyAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-ve")]
        public async Task<IActionResult> CheckVatVeAsync(ResPartnerCheckVatVeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatVeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-vat-vn")]
        public async Task<IActionResult> CheckVatVnAsync(ResPartnerCheckVatVnRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckVatVnAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(ResPartnerCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-company")]
        public async Task<IActionResult> CreateCompanyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreateCompanyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("do-button-print")]
        public async Task<IActionResult> DoButtonPrintAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DoButtonPrintAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("do-partner-mail")]
        public async Task<IActionResult> DoPartnerMailAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.DoPartnerMailAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("do-partner-manual-action")]
        public async Task<IActionResult> DoPartnerManualActionAsync(ResPartnerDoPartnerManualActionRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.DoPartnerManualActionAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("do-partner-manual-action-dermanord")]
        public async Task<IActionResult> DoPartnerManualActionDermanordAsync(ResPartnerDoPartnerManualDermanordRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.DoPartnerManualDermanordAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("do-partner-print")]
        public async Task<IActionResult> DoPartnerPrintAsync(ResPartnerDoPartnerPrintRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.DoPartnerPrintAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("enrich-by-domain")]
        public async Task<IActionResult> EnrichByDomainAsync(ResPartnerEnrichByDomainRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.EnrichByDomainAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("enrich-by-duns")]
        public async Task<IActionResult> EnrichByDunsAsync(ResPartnerEnrichByDunsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.EnrichByDunsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("enrich-by-gst")]
        public async Task<IActionResult> EnrichByGstAsync(ResPartnerEnrichByGstRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.EnrichByGstAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("fields-view-get")]
        public async Task<IActionResult> FieldsViewGetAsync(ResPartnerFieldsViewGetRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FieldsViewGetAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("find-or-create")]
        public async Task<IActionResult> FindOrCreateAsync(ResPartnerFindOrCreateRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FindOrCreateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("format-vat-ch")]
        public async Task<IActionResult> FormatVatChAsync(ResPartnerFormatVatChRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FormatVatChAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("format-vat-cl")]
        public async Task<IActionResult> FormatVatClAsync(ResPartnerFormatVatClRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FormatVatClAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("format-vat-co")]
        public async Task<IActionResult> FormatVatCoAsync(ResPartnerFormatVatCoRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FormatVatCoAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("format-vat-eu")]
        public async Task<IActionResult> FormatVatEuAsync(ResPartnerFormatVatEuRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FormatVatEuAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("format-vat-hu")]
        public async Task<IActionResult> FormatVatHuAsync(ResPartnerFormatVatHuRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FormatVatHuAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("format-vat-sm")]
        public async Task<IActionResult> FormatVatSmAsync(ResPartnerFormatVatSmRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FormatVatSmAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("format-vat-vn")]
        public async Task<IActionResult> FormatVatVnAsync(ResPartnerFormatVatVnRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.FormatVatVnAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("geo-localize")]
        public async Task<IActionResult> GeoLocalizeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GeoLocalizeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-attendee-detail")]
        public async Task<IActionResult> GetAttendeeDetailAsync(ResPartnerGetAttendeeDetailRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetAttendeeDetailAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-backend-menu-id")]
        public async Task<IActionResult> GetBackendMenuIdAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetBackendMenuIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-followup-table-html")]
        public async Task<IActionResult> GetFollowupTableHtmlAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetFollowupTableHtmlAsync(ids);
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
        [Route("get-mention-suggestions")]
        public async Task<IActionResult> GetMentionSuggestionsAsync(ResPartnerGetMentionSuggestionsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetMentionSuggestionsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-mention-suggestions-from-channel")]
        public async Task<IActionResult> GetMentionSuggestionsFromChannelAsync(ResPartnerGetMentionSuggestionsFromChannelRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetMentionSuggestionsFromChannelAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-new-partner")]
        public async Task<IActionResult> GetNewPartnerAsync(ResPartnerGetNewPartnerRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetNewPartnerAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-partner-localisation-fields-required-to-invoice")]
        public async Task<IActionResult> GetPartnerLocalisationFieldsRequiredToInvoiceAsync(ResPartnerGetPartnerLocalisationFieldsRequiredToInvoiceRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetPartnerLocalisationFieldsRequiredToInvoiceAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-working-hours-for-all-attendees")]
        public async Task<IActionResult> GetWorkingHoursForAllAttendeesAsync(ResPartnerGetWorkingHoursForAllAttendeesRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetWorkingHoursForAllAttendeesAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-worklocation")]
        public async Task<IActionResult> GetWorklocationAsync(ResPartnerGetWorklocationRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetWorklocationAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("google-map-img")]
        public async Task<IActionResult> GoogleMapImgAsync(ResPartnerGoogleMapImgRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GoogleMapImgAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("google-map-link")]
        public async Task<IActionResult> GoogleMapLinkAsync(ResPartnerGoogleMapLinkRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GoogleMapLinkAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("iap-partner-autocomplete-get-tag-ids")]
        public async Task<IActionResult> IapPartnerAutocompleteGetTagIdsAsync(ResPartnerIapPartnerAutocompleteGetTagIdsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.IapPartnerAutocompleteGetTagIdsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("is-valid-ruc-ec")]
        public async Task<IActionResult> IsValidRucEcAsync(ResPartnerIsValidRucEcRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.IsValidRucEcAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-company-type")]
        public async Task<IActionResult> OnchangeCompanyTypeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangeCompanyTypeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("onchange-parent-id")]
        public async Task<IActionResult> OnchangeParentIdAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OnchangeParentIdAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("open-commercial-entity")]
        public async Task<IActionResult> OpenCommercialEntityAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenCommercialEntityAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("schedule-meeting")]
        public async Task<IActionResult> ScheduleMeetingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ScheduleMeetingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("search-for-channel-invite")]
        public async Task<IActionResult> SearchForChannelInviteAsync(ResPartnerSearchForChannelInviteRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SearchForChannelInviteAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("signup-cancel")]
        public async Task<IActionResult> SignupCancelAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SignupCancelAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("signup-get-auth-param")]
        public async Task<IActionResult> SignupGetAuthParamAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.SignupGetAuthParamAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("signup-prepare")]
        public async Task<IActionResult> SignupPrepareAsync(ResPartnerSignupPrepareRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.SignupPrepareAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("view-header-get")]
        public async Task<IActionResult> ViewHeaderGetAsync(ResPartnerViewHeaderGetRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ViewHeaderGetAsync(input);
            return Ok(result);
        }
    }
}