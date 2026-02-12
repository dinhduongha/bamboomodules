using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class ResPartnerAppService
    {

        protected async Task<ResPartner> ActionShowInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _action_show) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> AddressFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _address_fields) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _address_fields) ---
            */
            return default;
        }

        protected async Task<ResPartner> AssetDifferenceSearchInternalAsync(object account_type, object @operator, object operand)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _asset_difference_search) ---
            */
            return default;
        }

        protected async Task<ResPartner> AvatarGetPlaceholderPathInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: res_partner.py, METHOD: _avatar_get_placeholder_path) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _avatar_get_placeholder_path) ---
            */
            return default;
        }

        protected async Task<ResPartner> BuildErrorPeppolEndpointInternalAsync(object eas, object endpoint)
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _build_error_peppol_endpoint) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> BuildVatErrorMessageInternalAsync(object country_code, object wrong_vat, object record_label)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _build_vat_error_message) ---
            */
            return default;
        }

        protected async Task<ResPartner> BuildVcardInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: res_partner.py, METHOD: _build_vcard) ---
            */
            return default;
        }

        protected async Task<ResPartner> BusSendHistoryMessageInternalAsync(object channel, object page_history)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _bus_send_history_message) ---
            */
            return default;
        }

        protected async Task<ResPartner> CanBeEditedByCurrentCustomerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: res_partner.py, METHOD: _can_be_edited_by_current_customer) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: _can_be_edited_by_current_customer) ---
            */
            return default;
        }

        protected async Task<ResPartner> CanEditCountryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _can_edit_country) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: _can_edit_country) ---
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _can_edit_country) ---
            */
            return default;
        }

        protected async Task<ResPartner> CheckBarcodeUnicityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_barcode_unicity) ---
            */
            return default;
        }

        protected async Task<ResPartner> CheckDocumentTypeSupportInternalAsync(object participant_info, object ubl_cii_format, object process_type)
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _check_document_type_support) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> CheckImportConsistencyInternalAsync(object vals_list)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_import_consistency) ---
            */
            return default;
        }

        protected async Task<ResPartner> CheckParentIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_parent_id) ---
            */
            return default;
        }

        protected async Task<ResPartner> CheckPartnerCompanyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _check_partner_company) ---
            */
            return default;
        }

        protected async Task<ResPartner> CheckPeppolFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _check_peppol_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> CheckPeppolParticipantExistsInternalAsync(object participant_info, object edi_identification)
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _check_peppol_participant_exists) ---
            */
            return default;
        }

        protected async Task<ResPartner> CheckVatInternalAsync(object validation)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _check_vat) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> CheckVatNumberInternalAsync(object country_code, object vat_number)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _check_vat_number) ---
            */
            return default;
        }

        protected async Task<ResPartner> ChildrenSyncInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _children_sync) ---
            */
            return default;
        }

        protected async Task<ResPartner> CleanWebsiteInternalAsync(object website)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _clean_website) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> ClearRemovedEdiFormatsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _clear_removed_edi_formats) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> CommercialFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _commercial_fields) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _commercial_fields) ---
            */
            return default;
        }

        protected async Task<ResPartner> CommercialSyncFromCompanyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _commercial_sync_from_company) ---
            */
            return default;
        }

        protected async Task<ResPartner> CommercialSyncToDescendantsInternalAsync(object fields_to_sync)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _commercial_sync_to_descendants) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> CompanyDependentCommercialFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _company_dependent_commercial_fields) ---
            */
            return default;
        }

        protected async Task<ResPartner> CompanyDependentCommercialSyncInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _company_dependent_commercial_sync) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeAccountMoveCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_account_move_count) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeActiveLangCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_active_lang_count) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeApplicationStatisticsHookInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_application_statistics_hook) ---
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            --- METHOD SOURCE (MODULE: crm, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_application_statistics_hook) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeApplicationStatisticsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_application_statistics) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeAvailableInvoiceTemplatePdfReportIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_available_invoice_template_pdf_report_ids) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeAvailablePeppolEasInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _compute_available_peppol_eas) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _compute_available_peppol_eas) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeAvailablePeppolEdiFormatsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _compute_available_peppol_edi_formats) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeAvailablePeppolSendingMethodsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _compute_available_peppol_sending_methods) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeAvatar1024InternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_1024) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeAvatar128InternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_128) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeAvatar1920InternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_1920) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeAvatar256InternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_256) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeAvatar512InternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar_512) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeAvatarInternalAsync(object avatar_field, object image_field)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_avatar) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeBankCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_bank_count) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeBomIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py, METHOD: _compute_bom_ids) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeCertificationsCompanyCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: res_partner.py, METHOD: _compute_certifications_company_count) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeCertificationsCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: res_partner.py, METHOD: _compute_certifications_count) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeCommercialCompanyNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_commercial_company_name) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeCommercialPartnerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_commercial_partner) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeCompanyRegistryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_registry) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeCompanyRegistryLabelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_registry_label) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeCompanyRegistryPlaceholderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_registry_placeholder) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeCompanyTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_company_type) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeCompleteNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_complete_name) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeContactAddressInlineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _compute_contact_address_inline) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeContactAddressInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_contact_address) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeCountActiveCardsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: res_partner.py, METHOD: _compute_count_active_cards) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeCreditToInvoiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_credit_to_invoice) ---
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _compute_credit_to_invoice) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeDaysSalesOutstandingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_days_sales_outstanding) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: website, FILE: res_partner.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeEmailFormattedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_email_formatted) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeEmployeeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _compute_employee) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeEmployeesCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _compute_employees_count) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeEventCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_partner.py, METHOD: _compute_event_count) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeFiscalCountryCodesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_fiscal_country_codes) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeFiscalCountryGroupCodesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_fiscal_country_group_codes) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeFiscalPositionIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _compute_fiscal_position_id) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeGetIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_get_ids) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeImStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: res_partner.py, METHOD: _compute_im_status) ---
            --- METHOD SOURCE (MODULE: hr_homeworking, FILE: res_partner.py, METHOD: _compute_im_status) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _compute_im_status) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeImplementedPartnerCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py, METHOD: _compute_implemented_partner_count) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeInvoiceEdiFormatInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_invoice_edi_format) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeInvoiceEmailsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _compute_invoice_emails) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeIsInCallInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _compute_is_in_call) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeIsMondialrelayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: res_partner.py, METHOD: _compute_is_mondialrelay) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeIsPeppolEdiFormatInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _compute_is_peppol_edi_format) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeIsPublicInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_is_public) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeIsSubcontractorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py, METHOD: _compute_is_subcontractor) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeIsUblFormatInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _compute_is_ubl_format) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeLangInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_lang) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeLeaveDateToInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: res_partner.py, METHOD: _compute_leave_date_to) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeLivechatChannelCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _compute_livechat_channel_count) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeMainUserIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_main_user_id) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeMeetingCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: _compute_meeting_count) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeMeetingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: _compute_meeting) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeOnTimeRateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_stock, FILE: res_partner.py, METHOD: _compute_on_time_rate) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeOpportunityCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_partner.py, METHOD: _compute_opportunity_count) ---
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py, METHOD: _compute_opportunity_count) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputePartnerCompanyRegistryPlaceholderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_partner_company_registry_placeholder) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputePartnerIapInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail_plugin, FILE: res_partner.py, METHOD: _compute_partner_iap_info) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputePartnerShareInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_partner_share) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputePartnerVatPlaceholderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_partner_vat_placeholder) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputePartnerWeightInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py, METHOD: _compute_partner_weight) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputePaymentTokenCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: payment, FILE: res_partner.py, METHOD: _compute_payment_token_count) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputePeppolEasInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _compute_peppol_eas) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputePeppolEndpointInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _compute_peppol_endpoint) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputePerformViesValidationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _compute_perform_vies_validation) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputePickingIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py, METHOD: _compute_picking_ids) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputePosContactAddressInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _compute_pos_contact_address) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputePosOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _compute_pos_order) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeProductPricelistInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: res_partner.py, METHOD: _compute_product_pricelist) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeProductionIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py, METHOD: _compute_production_ids) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputePurchaseOrderCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: res_partner.py, METHOD: _compute_purchase_order_count) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeSaleOrderCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _compute_sale_order_count) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeSameVatPartnerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_same_vat_partner_id) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeShowCreditLimitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_show_credit_limit) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeSlideChannelCompanyCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py, METHOD: _compute_slide_channel_company_count) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeSlideChannelValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py, METHOD: _compute_slide_channel_values) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeStaticMapUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_partner.py, METHOD: _compute_static_map_url) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeStaticMapUrlIsValidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_partner.py, METHOD: _compute_static_map_url_is_valid) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeStreetDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _compute_street_data) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeSupplierInvoiceCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_supplier_invoice_count) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeTaskCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_partner.py, METHOD: _compute_task_count) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeTypeAddressLabelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_type_address_label) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeTzOffsetInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_tz_offset) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeUsePartnerCreditLimitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _compute_use_partner_credit_limit) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeUserIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_user_id) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeUserLivechatUsernameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _compute_user_livechat_username) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeVatLabelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _compute_vat_label) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeViesValidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _compute_vies_valid) ---
            */
            return default;
        }

        protected async Task<ResPartner> ComputeWebsiteUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_partner, FILE: res_partner.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        protected async Task<ResPartner> ConvertFieldsToValuesInternalAsync(object field_names)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _convert_fields_to_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> ConvertHuLocalToEuVatInternalAsync(object local_vat)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _convert_hu_local_to_eu_vat) ---
            */
            return default;
        }

        protected async Task<ResPartner> CreateContactParentCompanyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _create_contact_parent_company) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _create_contact_parent_company) ---
            */
            return default;
        }

        protected async Task<ResPartner> CreatePortalUsersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_partner.py, METHOD: _create_portal_users) ---
            */
            return default;
        }

        protected async Task<ResPartner> CreditDebitGetInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _credit_debit_get) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> CreditSearchInternalAsync(object @operator, object operand)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _credit_search) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> DebitSearchInternalAsync(object @operator, object operand)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _debit_search) ---
            */
            return default;
        }

        protected async Task<ResPartner> DeduceCountryCodeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _deduce_country_code) ---
            */
            return default;
        }

        protected async Task<ResPartner> DefaultCategoryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _default_category) ---
            */
            return default;
        }

        protected async Task<ResPartner> DefaultDisplayInvoiceTemplatePdfReportIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _default_display_invoice_template_pdf_report_id) ---
            */
            return default;
        }

        protected async Task<ResPartner> DisplayAddressDependsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _display_address_depends) ---
            */
            return default;
        }

        protected async Task<ResPartner> DisplayAddressInternalAsync(object without_company)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _display_address) ---
            */
            return default;
        }

        protected async Task<ResPartner> EnsureSameCompanyThanProjectsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_partner.py, METHOD: _ensure_same_company_than_projects) ---
            */
            return default;
        }

        protected async Task<ResPartner> EnsureSameCompanyThanTasksInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: res_partner.py, METHOD: _ensure_same_company_than_tasks) ---
            */
            return default;
        }

        protected async Task<ResPartner> FetchChildrenPartnersForHierarchyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_partner.py, METHOD: _fetch_children_partners_for_hierarchy) ---
            */
            return default;
        }

        protected async Task<ResPartner> FieldStoreReprInternalAsync(object field_name)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _field_store_repr) ---
            */
            return default;
        }

        protected async Task<ResPartner> FieldsSyncInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _fields_sync) ---
            */
            return default;
        }

        protected async Task<ResPartner> FindAccountingPartnerInternalAsync(object partner)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _find_accounting_partner) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> FindOrCreateFromEmailsInternalAsync(object emails, object ban_emails, object filter_found, object additional_values, object no_create, object sort_key, object sort_reverse)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _find_or_create_from_emails) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> FormatDataCompanyInternalAsync(object iap_data)
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _format_data_company) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> FormatVatNumberInternalAsync(object country_code, object vat)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _format_vat_number) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> FormattingAddressFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _formatting_address_fields) ---
            */
            return default;
        }

        protected async Task<ResPartner> GelatoPrepareAddressPayloadInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_gelato, FILE: res_partner.py, METHOD: _gelato_prepare_address_payload) ---
            */
            return default;
        }

        protected async Task<ResPartner> GenerateSignupTokenInternalAsync(object expiration)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _generate_signup_token) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> GeoLocalizeInternalAsync(object street, object zip, object city, object state, object country)
        {
            /*
            --- METHOD SOURCE (MODULE: base_geolocalize, FILE: res_partner.py, METHOD: _geo_localize) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetAccountStatisticsCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_account_statistics_count) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> GetAddressFormatInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: res_partner.py, METHOD: _get_address_format) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_address_format) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetAddressValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_address_values) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetAllAddrInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _get_all_addr) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_all_addr) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetAmountsAndDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _get_amounts_and_date) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetBackendRootMenuIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: contacts, FILE: res_partner.py, METHOD: _get_backend_root_menu_ids) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetBusyCalendarEventsInternalAsync(object start_datetime, object end_datetime)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: _get_busy_calendar_events) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetCommercialValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_commercial_values) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetCompanyCurrencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_company_currency) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetCompanyRegistryLabelsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_company_registry_labels) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetCompleteNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_complete_name) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetContactOpportunitiesDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_partner.py, METHOD: _get_contact_opportunities_domain) ---
            --- METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: res_partner.py, METHOD: _get_contact_opportunities_domain) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetCountryNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: res_partner.py, METHOD: _get_country_name) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_country_name) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetCurrentPartnerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: _get_current_partner) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_partner.py, METHOD: _get_current_partner) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> GetCurrentPersonaInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_current_persona) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> GetDefaultAddressFormatInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_default_address_format) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetDeliveryAddressDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: delivery, FILE: res_partner.py, METHOD: _get_delivery_address_domain) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: _get_delivery_address_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> GetEdiBuilderInternalAsync(object invoice_edi_format)
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_edi_builder) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetEmployeesFromAttendeesInternalAsync(object everybody)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py, METHOD: _get_employees_from_attendees) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetFollowupOverdueQueryInternalAsync(object args, object overdue_only)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _get_followup_overdue_query) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetFrontendWritableFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_frontend_writable_fields) ---
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _get_frontend_writable_fields) ---
            --- METHOD SOURCE (MODULE: portal, FILE: res_partner.py, METHOD: _get_frontend_writable_fields) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_partner.py, METHOD: _get_frontend_writable_fields) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetImStatusAccessTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_im_status_access_token) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetLatestInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _get_latest) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetLoginDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _get_login_date) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> GetMentionSuggestionsDomainInternalAsync(object search)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_mention_suggestions_domain) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetMentionTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_mention_token) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetNeedactionCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_needaction_count) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> GetOnLeaveIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: res_partner.py, METHOD: _get_on_leave_ids) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> GetParticipantInfoInternalAsync(object edi_identification)
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _get_participant_info) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> GetPartnerFromTokenInternalAsync(object token)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _get_partner_from_token) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetPartnersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _get_partners) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetPeppolEdiFormatInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_peppol_edi_format) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetPeppolEndpointValueInternalAsync(object country_code, object field, object eas)
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_peppol_endpoint_value) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> GetPeppolFormatsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_peppol_formats) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> GetPeppolVerificationStateInternalAsync(object peppol_endpoint, object peppol_eas, object invoice_edi_format, object process_type)
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _get_peppol_verification_state) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> GetSaleOrderDomainCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _get_sale_order_domain_count) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetScheduleInternalAsync(object start_period, object stop_period, object everybody, object merge)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py, METHOD: _get_schedule) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetSignupUrlForActionInternalAsync(object url, object action, object view_type, Guid menu_id, Guid res_id, object model)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _get_signup_url_for_action) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetSignupUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _get_signup_url) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetStoreAvatarCardFieldsInternalAsync(object target)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _get_store_avatar_card_fields) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_store_avatar_card_fields) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetStoreLivechatUsernameFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _get_store_livechat_username_fields) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetStoreMentionFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_store_mention_fields) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetStreetSplitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _get_street_split) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_street_split) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetSuggestedInvoiceEdiFormatInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_suggested_invoice_edi_format) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetSuggestedPeppolEdiFormatInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_suggested_peppol_edi_format) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetSuggestedUblCiiEdiFormatInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_suggested_ubl_cii_edi_format) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetSyncedCommercialValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _get_synced_commercial_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> GetUblCiiFormatsByCountryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_ubl_cii_formats_by_country) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> GetUblCiiFormatsInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_ubl_cii_formats_info) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> GetUblCiiFormatsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _get_ubl_cii_formats) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetVatRequiredValidInternalAsync(object company)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _get_vat_required_valid) ---
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _get_vat_required_valid) ---
            */
            return default;
        }

        protected async Task<ResPartner> GetVcardFileInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: res_partner.py, METHOD: _get_vcard_file) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> GetViewCacheKeyInternalAsync(Guid view_id, object view_type)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _get_view_cache_key) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> GetViewInternalAsync(Guid view_id, object view_type)
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _get_view) ---
            */
            return default;
        }

        protected async Task<ResPartner> GoogleMapSignedImgInternalAsync(object zoom, object width, object height)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_partner.py, METHOD: _google_map_signed_img) ---
            */
            return default;
        }

        protected async Task<ResPartner> HandleFirstContactCreationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _handle_first_contact_creation) ---
            */
            return default;
        }

        protected async Task<ResPartner> HasInvoiceInternalAsync(object partner_domain)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _has_invoice) ---
            */
            return default;
        }

        protected async Task<ResPartner> HasOrderInternalAsync(object partner_domain)
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: res_partner.py, METHOD: _has_order) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> IapReplaceIndustryCodeInternalAsync(object iap_data)
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _iap_replace_industry_code) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> IapReplaceLanguageCodesInternalAsync(object iap_data)
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _iap_replace_language_codes) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> IapReplaceLocationCodesInternalAsync(object iap_data)
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _iap_replace_location_codes) ---
            */
            return default;
        }

        protected async Task<ResPartner> IeCheckCharInternalAsync(object vat)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _ie_check_char) ---
            */
            return default;
        }

        protected async Task<ResPartner> IncreaseRankInternalAsync(string field, int n)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _increase_rank) ---
            */
            return default;
        }

        protected async Task<ResPartner> IntervalToBusinessHoursInternalAsync(object working_intervals)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_calendar, FILE: res_partner.py, METHOD: _interval_to_business_hours) ---
            */
            return default;
        }

        protected async Task<ResPartner> InverseInvoiceEdiFormatInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _inverse_invoice_edi_format) ---
            */
            return default;
        }

        protected async Task<ResPartner> InverseProductPricelistInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: res_partner.py, METHOD: _inverse_product_pricelist) ---
            */
            return default;
        }

        protected async Task<ResPartner> InverseStreetDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _inverse_street_data) ---
            */
            return default;
        }

        protected async Task<ResPartner> InverseUsePartnerCreditLimitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _inverse_use_partner_credit_limit) ---
            */
            return default;
        }

        protected async Task<ResPartner> InverseVatInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _inverse_vat) ---
            */
            return default;
        }

        protected async Task<ResPartner> InvoiceTotalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _invoice_total) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _load_pos_data_fields) ---
            --- METHOD SOURCE (MODULE: pos_sale, FILE: res_partner.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> LoadPosSelfDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: res_partner.py, METHOD: _load_pos_self_data_domain) ---
            */
            return default;
        }

        protected async Task<ResPartner> LoadRecordsCreateInternalAsync(object vals_list)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _load_records_create) ---
            */
            return default;
        }

        protected async Task<ResPartner> LogVerificationStateUpdateInternalAsync(object company, object old_value, object new_value)
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _log_verification_state_update) ---
            */
            return default;
        }

        protected async Task<ResPartner> MailGetPartnersInternalAsync(object introspect_fields)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _mail_get_partners) ---
            */
            return default;
        }

        protected async Task<ResPartner> MergeMethodInternalAsync(object destination, object source)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _merge_method) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> MondialrelaySearchOrCreateInternalAsync(object data)
        {
            /*
            --- METHOD SOURCE (MODULE: delivery_mondialrelay, FILE: res_partner.py, METHOD: _mondialrelay_search_or_create) ---
            */
            return default;
        }

        protected async Task<ResPartner> OnchangeCityIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _onchange_city_id) ---
            */
            return default;
        }

        protected async Task<ResPartner> OnchangeCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _onchange_company_id) ---
            */
            return default;
        }

        protected async Task<ResPartner> OnchangeCountryIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_address_extended, FILE: res_partner.py, METHOD: _onchange_country_id) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _onchange_country_id) ---
            */
            return default;
        }

        protected async Task<ResPartner> OnchangePhoneValidationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: res_partner.py, METHOD: _onchange_phone_validation) ---
            */
            return default;
        }

        protected async Task<ResPartner> OnchangePropertyProductPricelistInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_partner.py, METHOD: _onchange_property_product_pricelist) ---
            */
            return default;
        }

        protected async Task<ResPartner> OnchangeStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _onchange_state) ---
            */
            return default;
        }

        protected async Task<ResPartner> OnchangeVatInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _onchange_vat) ---
            */
            return default;
        }

        protected async Task<ResPartner> OnchangeVerifyPeppolStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _onchange_verify_peppol_status) ---
            */
            return default;
        }

        protected async Task<ResPartner> OrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _order) ---
            */
            return default;
        }

        protected async Task<ResPartner> PaymentDueSearchInternalAsync(object @operator, object operand)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _payment_due_search) ---
            */
            return default;
        }

        protected async Task<ResPartner> PaymentEarliestDateSearchInternalAsync(object @operator, object operand)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _payment_earliest_date_search) ---
            */
            return default;
        }

        protected async Task<ResPartner> PaymentOverdueSearchInternalAsync(object @operator, object operand)
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_followup, FILE: partner.py, METHOD: _payment_overdue_search) ---
            */
            return default;
        }

        protected async Task<ResPartner> PeppolEasEndpointDependsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_edi_ubl_cii, FILE: res_partner.py, METHOD: _peppol_eas_endpoint_depends) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> PeppolLookupParticipantInternalAsync(object edi_identification)
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _peppol_lookup_participant) ---
            */
            return default;
        }

        protected async Task<ResPartner> PrepareDisplayAddressInternalAsync(object without_company)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _prepare_display_address) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> ProcessEnrichedResponseInternalAsync(object response, object error)
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_partner.py, METHOD: _process_enriched_response) ---
            */
            return default;
        }

        protected async Task<ResPartner> RetrievePartnerInternalAsync(object name, object phone, object email, object vat, object domain, object company)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _retrieve_partner) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> RetrievePartnerWithNameInternalAsync(object name, object extra_domain)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _retrieve_partner_with_name) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> RetrievePartnerWithPhoneEmailInternalAsync(object phone, object email, object extra_domain)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _retrieve_partner_with_phone_email) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> RetrievePartnerWithVatInternalAsync(object vat, object extra_domain)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _retrieve_partner_with_vat) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> RunVatChecksInternalAsync(object country, object vat, object partner_name, object validation)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _run_vat_checks) ---
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _run_vat_checks) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> SearchForChannelInviteInternalAsync(object store, object search_term, Guid channel_id, object limit)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _search_for_channel_invite) ---
            */
            return default;
        }

        protected async Task<ResPartner> SearchForChannelInviteToStoreInternalAsync(object store, object channel)
        {
            /*
            --- METHOD SOURCE (MODULE: im_livechat, FILE: res_partner.py, METHOD: _search_for_channel_invite_to_store) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _search_for_channel_invite_to_store) ---
            */
            return default;
        }

        protected async Task<ResPartner> SearchIsSubcontractorInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_partner.py, METHOD: _search_is_subcontractor) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> SearchMentionSuggestionsInternalAsync(object domain, object limit, object extra_domain)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _search_mention_suggestions) ---
            */
            return default;
        }

        protected async Task<ResPartner> SearchSlideChannelCompletedIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py, METHOD: _search_slide_channel_completed_ids) ---
            */
            return default;
        }

        protected async Task<ResPartner> SearchSlideChannelIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: res_partner.py, METHOD: _search_slide_channel_ids) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> SetCalendarLastNotifAckInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: res_partner.py, METHOD: _set_calendar_last_notif_ack) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> SignupRetrieveInfoInternalAsync(object token)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _signup_retrieve_info) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> SignupRetrievePartnerInternalAsync(object token, object check_validity, object raise_exception)
        {
            /*
            --- METHOD SOURCE (MODULE: auth_signup, FILE: res_partner.py, METHOD: _signup_retrieve_partner) ---
            */
            return default;
        }

        protected async Task<ResPartner> SplitVatInternalAsync(object vat)
        {
            /*
            --- METHOD SOURCE (MODULE: base_vat, FILE: res_partner.py, METHOD: _split_vat) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResPartner> SyncedCommercialFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: res_partner.py, METHOD: _synced_commercial_fields) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _synced_commercial_fields) ---
            */
            return default;
        }

        protected async Task<ResPartner> ToStoreDefaultsInternalAsync(object target)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: res_partner.py, METHOD: _to_store_defaults) ---
            --- METHOD SOURCE (MODULE: mail, FILE: res_partner.py, METHOD: _to_store_defaults) ---
            */
            return default;
        }

        protected async Task<ResPartner> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- METHOD SOURCE (MODULE: website_partner, FILE: res_partner.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        protected async Task<ResPartner> UnlinkContactRelEmployeeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner.py, METHOD: _unlink_contact_rel_employee) ---
            */
            return default;
        }

        protected async Task<ResPartner> UnlinkExceptUserInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _unlink_except_user) ---
            */
            return default;
        }

        protected async Task<ResPartner> UnlinkIfPartnerInAccountMoveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: partner.py, METHOD: _unlink_if_partner_in_account_move) ---
            */
            return default;
        }

        protected async Task<ResPartner> UnlinkIfPosNoOrdersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_partner.py, METHOD: _unlink_if_pos_no_orders) ---
            */
            return default;
        }

        protected async Task<ResPartner> UpdateAddressInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _update_address) ---
            */
            return default;
        }

        protected async Task<ResPartner> UpdatePeppolStatePerCompanyInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_partner.py, METHOD: _update_peppol_state_per_company) ---
            */
            return default;
        }

        protected async Task<ResPartner> WriteCompanyTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_partner.py, METHOD: _write_company_type) ---
            */
            return default;
        }
    }
}