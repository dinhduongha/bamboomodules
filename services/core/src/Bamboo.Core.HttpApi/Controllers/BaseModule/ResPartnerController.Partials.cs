using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.BaseModule
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
        [Route("{id}/action-l10n-in-verify-gstin-status")]
        public async Task<IActionResult> ActionL10nInVerifyGstinStatusAsync(Guid id)
        {
            var result = await _appService.L10nInVerifyGstinStatusAsync(id);
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
        [Route("{id}/action-update-state-as-per-gstin")]
        public async Task<IActionResult> ActionUpdateStateAsPerGstinAsync(Guid id)
        {
            var result = await _appService.UpdateStateAsPerGstinAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-validate-tin")]
        public async Task<IActionResult> ActionValidateTinAsync(Guid id)
        {
            var result = await _appService.ValidateTinAsync(id);
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
        [Route("{id}/action-view-partner-with-same-bank")]
        public async Task<IActionResult> ActionViewPartnerWithSameBankAsync(Guid id)
        {
            var result = await _appService.ViewPartnerWithSameBankAsync(id);
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
        [Route("{id}/action-view-sale-order")]
        public async Task<IActionResult> ActionViewSaleOrderAsync(Guid id)
        {
            var result = await _appService.ViewSaleOrderAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-stock-lots")]
        public async Task<IActionResult> ActionViewStockLotsAsync(Guid id)
        {
            var result = await _appService.ViewStockLotsAsync(id);
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
            var result = await _appService.AddressGetAsync(id, input.AdrPref);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/autocomplete")]
        public async Task<IActionResult> AutocompleteAsync(Guid id, [FromBody] ResPartnerAutocompleteRequestDto input)
        {
            var result = await _appService.AutocompleteAsync(id, input.Query, input.Timeout);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/autocomplete-by-name")]
        public async Task<IActionResult> AutocompleteByNameAsync(Guid id, [FromBody] ResPartnerAutocompleteByNameRequestDto input)
        {
            var result = await _appService.AutocompleteByNameAsync(id, input.Query, input.QueryCountryId, input.Timeout);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/autocomplete-by-vat")]
        public async Task<IActionResult> AutocompleteByVatAsync(Guid id, [FromBody] ResPartnerAutocompleteByVatRequestDto input)
        {
            var result = await _appService.AutocompleteByVatAsync(id, input.Vat, input.QueryCountryId, input.Timeout);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/button-account-peppol-check-partner-endpoint")]
        public async Task<IActionResult> ButtonAccountPeppolCheckPartnerEndpointAsync(Guid id, [FromBody] ResPartnerButtonAccountPeppolCheckPartnerEndpointRequestDto input)
        {
            var result = await _appService.ButtonAccountPeppolCheckPartnerEndpointAsync(id, input.Company);
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
        [Route("{id}/check-gst-in")]
        public async Task<IActionResult> CheckGstInAsync(Guid id, [FromBody] ResPartnerCheckGstInRequestDto input)
        {
            var result = await _appService.CheckGstInAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-nilvera-customer")]
        public async Task<IActionResult> CheckNilveraCustomerAsync(Guid id)
        {
            var result = await _appService.CheckNilveraCustomerAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat")]
        public async Task<IActionResult> CheckVatAsync(Guid id)
        {
            var result = await _appService.CheckVatAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-al")]
        public async Task<IActionResult> CheckVatAlAsync(Guid id, [FromBody] ResPartnerCheckVatAlRequestDto input)
        {
            var result = await _appService.CheckVatAlAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-br")]
        public async Task<IActionResult> CheckVatBrAsync(Guid id, [FromBody] ResPartnerCheckVatBrRequestDto input)
        {
            var result = await _appService.CheckVatBrAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-ch")]
        public async Task<IActionResult> CheckVatChAsync(Guid id, [FromBody] ResPartnerCheckVatChRequestDto input)
        {
            var result = await _appService.CheckVatChAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-cr")]
        public async Task<IActionResult> CheckVatCrAsync(Guid id, [FromBody] ResPartnerCheckVatCrRequestDto input)
        {
            var result = await _appService.CheckVatCrAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-de")]
        public async Task<IActionResult> CheckVatDeAsync(Guid id, [FromBody] ResPartnerCheckVatDeRequestDto input)
        {
            var result = await _appService.CheckVatDeAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-ec")]
        public async Task<IActionResult> CheckVatEcAsync(Guid id, [FromBody] ResPartnerCheckVatEcRequestDto input)
        {
            var result = await _appService.CheckVatEcAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-gr")]
        public async Task<IActionResult> CheckVatGrAsync(Guid id, [FromBody] ResPartnerCheckVatGrRequestDto input)
        {
            var result = await _appService.CheckVatGrAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-hu")]
        public async Task<IActionResult> CheckVatHuAsync(Guid id, [FromBody] ResPartnerCheckVatHuRequestDto input)
        {
            var result = await _appService.CheckVatHuAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-id")]
        public async Task<IActionResult> CheckVatIdAsync(Guid id, [FromBody] ResPartnerCheckVatIdRequestDto input)
        {
            var result = await _appService.CheckVatIdAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-ie")]
        public async Task<IActionResult> CheckVatIeAsync(Guid id, [FromBody] ResPartnerCheckVatIeRequestDto input)
        {
            var result = await _appService.CheckVatIeAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-il")]
        public async Task<IActionResult> CheckVatIlAsync(Guid id, [FromBody] ResPartnerCheckVatIlRequestDto input)
        {
            var result = await _appService.CheckVatIlAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-in")]
        public async Task<IActionResult> CheckVatInAsync(Guid id, [FromBody] ResPartnerCheckVatInRequestDto input)
        {
            var result = await _appService.CheckVatInAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-ma")]
        public async Task<IActionResult> CheckVatMaAsync(Guid id, [FromBody] ResPartnerCheckVatMaRequestDto input)
        {
            var result = await _appService.CheckVatMaAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-mx")]
        public async Task<IActionResult> CheckVatMxAsync(Guid id, [FromBody] ResPartnerCheckVatMxRequestDto input)
        {
            var result = await _appService.CheckVatMxAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-no")]
        public async Task<IActionResult> CheckVatNoAsync(Guid id, [FromBody] ResPartnerCheckVatNoRequestDto input)
        {
            var result = await _appService.CheckVatNoAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-pe")]
        public async Task<IActionResult> CheckVatPeAsync(Guid id, [FromBody] ResPartnerCheckVatPeRequestDto input)
        {
            var result = await _appService.CheckVatPeAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-ph")]
        public async Task<IActionResult> CheckVatPhAsync(Guid id, [FromBody] ResPartnerCheckVatPhRequestDto input)
        {
            var result = await _appService.CheckVatPhAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-ro")]
        public async Task<IActionResult> CheckVatRoAsync(Guid id, [FromBody] ResPartnerCheckVatRoRequestDto input)
        {
            var result = await _appService.CheckVatRoAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-ru")]
        public async Task<IActionResult> CheckVatRuAsync(Guid id, [FromBody] ResPartnerCheckVatRuRequestDto input)
        {
            var result = await _appService.CheckVatRuAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-sa")]
        public async Task<IActionResult> CheckVatSaAsync(Guid id, [FromBody] ResPartnerCheckVatSaRequestDto input)
        {
            var result = await _appService.CheckVatSaAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-t")]
        public async Task<IActionResult> CheckVatTAsync(Guid id, [FromBody] ResPartnerCheckVatTRequestDto input)
        {
            var result = await _appService.CheckVatTAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-tr")]
        public async Task<IActionResult> CheckVatTrAsync(Guid id, [FromBody] ResPartnerCheckVatTrRequestDto input)
        {
            var result = await _appService.CheckVatTrAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-ua")]
        public async Task<IActionResult> CheckVatUaAsync(Guid id, [FromBody] ResPartnerCheckVatUaRequestDto input)
        {
            var result = await _appService.CheckVatUaAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-uy")]
        public async Task<IActionResult> CheckVatUyAsync(Guid id, [FromBody] ResPartnerCheckVatUyRequestDto input)
        {
            var result = await _appService.CheckVatUyAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-ve")]
        public async Task<IActionResult> CheckVatVeAsync(Guid id, [FromBody] ResPartnerCheckVatVeRequestDto input)
        {
            var result = await _appService.CheckVatVeAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/check-vat-vn")]
        public async Task<IActionResult> CheckVatVnAsync(Guid id, [FromBody] ResPartnerCheckVatVnRequestDto input)
        {
            var result = await _appService.CheckVatVnAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] ResPartnerCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input.Default);
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
        [Route("{id}/create-membership-invoice")]
        public async Task<IActionResult> CreateMembershipInvoiceAsync(Guid id, [FromBody] ResPartnerCreateMembershipInvoiceRequestDto input)
        {
            var result = await _appService.CreateMembershipInvoiceAsync(id, input.Product, input.Amount);
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
            var result = await _appService.DoPartnerManualActionAsync(id, input.PartnerIds);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/do-partner-manual-action-dermanord")]
        public async Task<IActionResult> DoPartnerManualActionDermanordAsync(Guid id, [FromBody] ResPartnerDoPartnerManualDermanordRequestDto input)
        {
            var result = await _appService.DoPartnerManualDermanordAsync(id, input.FollowupLine);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/do-partner-print")]
        public async Task<IActionResult> DoPartnerPrintAsync(Guid id, [FromBody] ResPartnerDoPartnerPrintRequestDto input)
        {
            var result = await _appService.DoPartnerPrintAsync(id, input.WizardPartnerIds, input.Data);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/enrich-by-domain")]
        public async Task<IActionResult> EnrichByDomainAsync(Guid id, [FromBody] ResPartnerEnrichByDomainRequestDto input)
        {
            var result = await _appService.EnrichByDomainAsync(id, input.Domain, input.Timeout);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/enrich-by-duns")]
        public async Task<IActionResult> EnrichByDunsAsync(Guid id, [FromBody] ResPartnerEnrichByDunsRequestDto input)
        {
            var result = await _appService.EnrichByDunsAsync(id, input.Duns, input.Timeout);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/enrich-by-gst")]
        public async Task<IActionResult> EnrichByGstAsync(Guid id, [FromBody] ResPartnerEnrichByGstRequestDto input)
        {
            var result = await _appService.EnrichByGstAsync(id, input.Gst, input.Timeout);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/enrich-company")]
        public async Task<IActionResult> EnrichCompanyAsync(Guid id, [FromBody] ResPartnerEnrichCompanyRequestDto input)
        {
            var result = await _appService.EnrichCompanyAsync(id, input.CompanyDomain, input.PartnerGid, input.Vat, input.Timeout);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/ensure-vat")]
        public async Task<IActionResult> EnsureVatAsync(Guid id)
        {
            var result = await _appService.EnsureVatAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/fields-view-get")]
        public async Task<IActionResult> FieldsViewGetAsync(Guid id, [FromBody] ResPartnerFieldsViewGetRequestDto input)
        {
            var result = await _appService.FieldsViewGetAsync(id, input.ViewId, input.ViewType, input.Toolbar, input.Submenu);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/find-or-create")]
        public async Task<IActionResult> FindOrCreateAsync(Guid id, [FromBody] ResPartnerFindOrCreateRequestDto input)
        {
            var result = await _appService.FindOrCreateAsync(id, input.Email, input.AssertValidEmail);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/fix-eu-vat-number")]
        public async Task<IActionResult> FixEuVatNumberAsync(Guid id, [FromBody] ResPartnerFixEuVatNumberRequestDto input)
        {
            var result = await _appService.FixEuVatNumberAsync(id, input.CountryId, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/format-vat-ch")]
        public async Task<IActionResult> FormatVatChAsync(Guid id, [FromBody] ResPartnerFormatVatChRequestDto input)
        {
            var result = await _appService.FormatVatChAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/format-vat-eu")]
        public async Task<IActionResult> FormatVatEuAsync(Guid id, [FromBody] ResPartnerFormatVatEuRequestDto input)
        {
            var result = await _appService.FormatVatEuAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/format-vat-sm")]
        public async Task<IActionResult> FormatVatSmAsync(Guid id, [FromBody] ResPartnerFormatVatSmRequestDto input)
        {
            var result = await _appService.FormatVatSmAsync(id, input.Vat);
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
            var result = await _appService.GetAttendeeDetailAsync(id, input.MeetingIds);
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
            var result = await _appService.GetMentionSuggestionsAsync(id, input.Search, input.Limit);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-mention-suggestions-from-channel")]
        public async Task<IActionResult> GetMentionSuggestionsFromChannelAsync(Guid id, [FromBody] ResPartnerGetMentionSuggestionsFromChannelRequestDto input)
        {
            var result = await _appService.GetMentionSuggestionsFromChannelAsync(id, input.ChannelId, input.Search, input.Limit);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-partner-localisation-fields-required-to-invoice")]
        public async Task<IActionResult> GetPartnerLocalisationFieldsRequiredToInvoiceAsync(Guid id, [FromBody] ResPartnerGetPartnerLocalisationFieldsRequiredToInvoiceRequestDto input)
        {
            var result = await _appService.GetPartnerLocalisationFieldsRequiredToInvoiceAsync(id, input.CountryId);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-working-hours-for-all-attendees")]
        public async Task<IActionResult> GetWorkingHoursForAllAttendeesAsync(Guid id, [FromBody] ResPartnerGetWorkingHoursForAllAttendeesRequestDto input)
        {
            var result = await _appService.GetWorkingHoursForAllAttendeesAsync(id, input.AttendeeIds, input.DateFrom, input.DateTo, input.Everybody);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-worklocation")]
        public async Task<IActionResult> GetWorklocationAsync(Guid id, [FromBody] ResPartnerGetWorklocationRequestDto input)
        {
            var result = await _appService.GetWorklocationAsync(id, input.StartDate, input.EndDate);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/google-map-img")]
        public async Task<IActionResult> GoogleMapImgAsync(Guid id, [FromBody] ResPartnerGoogleMapImgRequestDto input)
        {
            var result = await _appService.GoogleMapImgAsync(id, input.Zoom, input.Width, input.Height);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/google-map-link")]
        public async Task<IActionResult> GoogleMapLinkAsync(Guid id, [FromBody] ResPartnerGoogleMapLinkRequestDto input)
        {
            var result = await _appService.GoogleMapLinkAsync(id, input.Zoom);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/iap-partner-autocomplete-add-tags")]
        public async Task<IActionResult> IapPartnerAutocompleteAddTagsAsync(Guid id, [FromBody] ResPartnerIapPartnerAutocompleteAddTagsRequestDto input)
        {
            var result = await _appService.IapPartnerAutocompleteAddTagsAsync(id, input.UnspscCodes);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/im-search")]
        public async Task<IActionResult> ImSearchAsync(Guid id, [FromBody] ResPartnerImSearchRequestDto input)
        {
            var result = await _appService.ImSearchAsync(id, input.Name, input.Limit, input.ExcludedIds);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/is-valid-ruc-ec")]
        public async Task<IActionResult> IsValidRucEcAsync(Guid id, [FromBody] ResPartnerIsValidRucEcRequestDto input)
        {
            var result = await _appService.IsValidRucEcAsync(id, input.Vat);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/l10n-ar-identification-validation")]
        public async Task<IActionResult> L10nArIdentificationValidationAsync(Guid id)
        {
            var result = await _appService.L10nArIdentificationValidationAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/l10n-it-edi-doi-action-open-declarations")]
        public async Task<IActionResult> L10nItEdiDoiActionOpenDeclarationsAsync(Guid id)
        {
            var result = await _appService.L10nItEdiDoiOpenDeclarationsAsync(id);
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
        [Route("{id}/onchange-email")]
        public async Task<IActionResult> OnchangeEmailAsync(Guid id)
        {
            var result = await _appService.OnchangeEmailAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/onchange-l10n-se-default-vendor-payment-ref")]
        public async Task<IActionResult> OnchangeL10nSeDefaultVendorPaymentRefAsync(Guid id)
        {
            var result = await _appService.OnchangeL10nSeDefaultVendorPaymentRefAsync(id);
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
        [Route("{id}/onchange-vat")]
        public async Task<IActionResult> OnchangeVatAsync(Guid id)
        {
            var result = await _appService.OnchangeVatAsync(id);
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
        [Route("{id}/read-by-vat")]
        public async Task<IActionResult> ReadByVatAsync(Guid id, [FromBody] ResPartnerReadByVatRequestDto input)
        {
            var result = await _appService.ReadByVatAsync(id, input.Vat, input.Timeout);
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
            var result = await _appService.SearchForChannelInviteAsync(id, input.SearchTerm, input.ChannelId, input.Limit);
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
            var result = await _appService.SignupPrepareAsync(id, input.SignupType);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/simple-vat-check")]
        public async Task<IActionResult> SimpleVatCheckAsync(Guid id, [FromBody] ResPartnerSimpleVatCheckRequestDto input)
        {
            var result = await _appService.SimpleVatCheckAsync(id, input.CountryCode, input.VatNumber);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/update-address")]
        public async Task<IActionResult> UpdateAddressAsync(Guid id, [FromBody] ResPartnerUpdateAddressRequestDto input)
        {
            var result = await _appService.UpdateAddressAsync(id, input.Vals);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/validate-codice-fiscale")]
        public async Task<IActionResult> ValidateCodiceFiscaleAsync(Guid id)
        {
            var result = await _appService.ValidateCodiceFiscaleAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/view-header-get")]
        public async Task<IActionResult> ViewHeaderGetAsync(Guid id, [FromBody] ResPartnerViewHeaderGetRequestDto input)
        {
            var result = await _appService.ViewHeaderGetAsync(id, input.ViewId, input.ViewType);
            return Ok(result);
        }
    }
}