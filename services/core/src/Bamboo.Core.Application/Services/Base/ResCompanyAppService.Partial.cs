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
    public partial class ResCompanyAppService
    {

        protected async Task<ResCompany> AccessibleBranchesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _accessible_branches) ---
            */
            return default;
        }

        protected async Task<ResCompany> AccountPeppolSendWelcomeEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _account_peppol_send_welcome_email) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCompany> ActionCheckHashIntegrityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _action_check_hash_integrity) ---
            */
            return default;
        }

        protected async Task<ResCompany> ActionCloseStockValuationInternalAsync(object at_date)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: _action_close_stock_valuation) ---
            */
            return default;
        }

        protected async Task<ResCompany> ActionOpenKioskModeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: res_company.py, METHOD: _action_open_kiosk_mode) ---
            */
            return default;
        }

        protected async Task<ResCompany> ActionOpenSmsTwilioAccountManageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sms_twilio, FILE: res_company.py, METHOD: _action_open_sms_twilio_account_manage) ---
            */
            return default;
        }

        protected async Task<ResCompany> ActivateOrCreatePricelistsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: res_company.py, METHOD: _activate_or_create_pricelists) ---
            */
            return default;
        }

        protected async Task<ResCompany> AllBranchesSelectedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _all_branches_selected) ---
            */
            return default;
        }

        protected async Task<ResCompany> AssertTwilioSidInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sms_twilio, FILE: res_company.py, METHOD: _assert_twilio_sid) ---
            */
            return default;
        }

        protected async Task<ResCompany> ChartTemplateSelectionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _chart_template_selection) ---
            */
            return default;
        }

        protected async Task<ResCompany> CheckAccountPeppolPhoneNumberInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _check_account_peppol_phone_number) ---
            */
            return default;
        }

        protected async Task<ResCompany> CheckActiveInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_company.py, METHOD: _check_active) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _check_active) ---
            */
            return default;
        }

        protected async Task<ResCompany> CheckAuditTrailRestrictionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _check_audit_trail_restriction) ---
            */
            return default;
        }

        protected async Task<ResCompany> CheckFiscalyearLastDayInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _check_fiscalyear_last_day) ---
            */
            return default;
        }

        protected async Task<ResCompany> CheckHashIntegrityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _check_hash_integrity) ---
            */
            return default;
        }

        protected async Task<ResCompany> CheckHrPresenceControlInternalAsync(object at_install)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: res_company.py, METHOD: _check_hr_presence_control) ---
            */
            return default;
        }

        protected async Task<ResCompany> CheckInternalProjectIdCompanyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: res_company.py, METHOD: _check_internal_project_id_company) ---
            */
            return default;
        }

        protected async Task<ResCompany> CheckPeppolEndpointInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _check_peppol_endpoint) ---
            */
            return default;
        }

        protected async Task<ResCompany> CheckPeppolEndpointNumberInternalAsync(object warning)
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _check_peppol_endpoint_number) ---
            */
            return default;
        }

        protected async Task<ResCompany> CheckPeppolPurchaseJournalIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _check_peppol_purchase_journal_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCompany> CheckPhonenumbersImportInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _check_phonenumbers_import) ---
            */
            return default;
        }

        protected async Task<ResCompany> CheckPrepaymentPercentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: res_company.py, METHOD: _check_prepayment_percent) ---
            */
            return default;
        }

        protected async Task<ResCompany> CheckRootDelegatedFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _check_root_delegated_fields) ---
            */
            return default;
        }

        protected async Task<ResCompany> CheckSetAccountPriceIncludeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _check_set_account_price_include) ---
            */
            return default;
        }

        protected async Task<ResCompany> CheckTaxReturnConfigurationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _check_tax_return_configuration) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeAccountEnabledTaxCountryIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_account_enabled_tax_country_ids) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeAccountFiscalCountryGroupCodesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_account_fiscal_country_group_codes) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeAccountPeppolContactEmailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _compute_account_peppol_contact_email) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeAccountPeppolEdiUserInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _compute_account_peppol_edi_user) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeAccountPeppolPhoneNumberInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _compute_account_peppol_phone_number) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeAccountStornoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_account_storno) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeAddressInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_address) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeAttendanceKioskUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: res_company.py, METHOD: _compute_attendance_kiosk_url) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeBounceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_company.py, METHOD: _compute_bounce) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeCatchallInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_company.py, METHOD: _compute_catchall) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeColorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_color) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeCompanyRegistryPlaceholderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_company_registry_placeholder) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeCompanyVatPlaceholderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_company_vat_placeholder) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeDisplayAccountStornoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_display_account_storno) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeDomesticFiscalPositionIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_domestic_fiscal_position_id) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeEmailFormattedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_company.py, METHOD: _compute_email_formatted) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeEmptyCompanyDetailsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_empty_company_details) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeForceRestrictiveAuditTrailInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_force_restrictive_audit_trail) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeInvoiceTermsHtmlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_invoice_terms_html) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeLogoWebInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_logo_web) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeMultiVatForeignCountryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_multi_vat_foreign_country) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeParentIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_parent_ids) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputePeppolCanSendInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _compute_peppol_can_send) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputePeppolParentCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _compute_peppol_parent_company_id) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputePeppolPurchaseJournalIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _compute_peppol_purchase_journal_id) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputePeppolSelfBillingReceptionJournalIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _compute_peppol_self_billing_reception_journal_id) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeUninstalledL10nModuleIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_uninstalled_l10n_module_ids) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeUserFiscalyearLockDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_user_fiscalyear_lock_date) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeUserHardLockDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_user_hard_lock_date) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeUserPurchaseLockDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_user_purchase_lock_date) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeUserSaleLockDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_user_sale_lock_date) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeUserTaxLockDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_user_tax_lock_date) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeUsesDefaultLogoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_uses_default_logo) ---
            */
            return default;
        }

        protected async Task<ResCompany> ComputeWebsiteIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_company.py, METHOD: _compute_website_id) ---
            */
            return default;
        }

        protected async Task<ResCompany> CreateDropshipPickingTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py, METHOD: _create_dropship_picking_type) ---
            */
            return default;
        }

        protected async Task<ResCompany> CreateDropshipRuleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py, METHOD: _create_dropship_rule) ---
            */
            return default;
        }

        protected async Task<ResCompany> CreateDropshipSequenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py, METHOD: _create_dropship_sequence) ---
            */
            return default;
        }

        protected async Task<ResCompany> CreateInternalProjectTaskInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: res_company.py, METHOD: _create_internal_project_task) ---
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: res_company.py, METHOD: _create_internal_project_task) ---
            */
            return default;
        }

        protected async Task<ResCompany> CreateInventoryLossLocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: _create_inventory_loss_location) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCompany> CreateMissingSubcontractingDropshippingPickingTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py, METHOD: _create_missing_subcontracting_dropshipping_picking_type) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCompany> CreateMissingSubcontractingDropshippingRulesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py, METHOD: _create_missing_subcontracting_dropshipping_rules) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCompany> CreateMissingSubcontractingDropshippingSequenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py, METHOD: _create_missing_subcontracting_dropshipping_sequence) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCompany> CreateMissingSubcontractingLocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_company.py, METHOD: _create_missing_subcontracting_location) ---
            */
            return default;
        }

        protected async Task<ResCompany> CreatePerCompanyLocationsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_company.py, METHOD: _create_per_company_locations) ---
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: _create_per_company_locations) ---
            */
            return default;
        }

        protected async Task<ResCompany> CreatePerCompanyPickingTypesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py, METHOD: _create_per_company_picking_types) ---
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: _create_per_company_picking_types) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py, METHOD: _create_per_company_picking_types) ---
            */
            return default;
        }

        protected async Task<ResCompany> CreatePerCompanyRulesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py, METHOD: _create_per_company_rules) ---
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: _create_per_company_rules) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py, METHOD: _create_per_company_rules) ---
            */
            return default;
        }

        protected async Task<ResCompany> CreatePerCompanySequencesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: res_company.py, METHOD: _create_per_company_sequences) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py, METHOD: _create_per_company_sequences) ---
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: _create_per_company_sequences) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py, METHOD: _create_per_company_sequences) ---
            */
            return default;
        }

        protected async Task<ResCompany> CreateProductionLocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: _create_production_location) ---
            */
            return default;
        }

        protected async Task<ResCompany> CreateResourceCalendarInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: res_company.py, METHOD: _create_resource_calendar) ---
            */
            return default;
        }

        protected async Task<ResCompany> CreateScrapLocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: _create_scrap_location) ---
            */
            return default;
        }

        protected async Task<ResCompany> CreateScrapSequenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: _create_scrap_sequence) ---
            */
            return default;
        }

        protected async Task<ResCompany> CreateSubcontractingDropshippingPickingTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py, METHOD: _create_subcontracting_dropshipping_picking_type) ---
            */
            return default;
        }

        protected async Task<ResCompany> CreateSubcontractingDropshippingRulesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py, METHOD: _create_subcontracting_dropshipping_rules) ---
            */
            return default;
        }

        protected async Task<ResCompany> CreateSubcontractingDropshippingSequenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py, METHOD: _create_subcontracting_dropshipping_sequence) ---
            */
            return default;
        }

        protected async Task<ResCompany> CreateSubcontractingLocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_company.py, METHOD: _create_subcontracting_location) ---
            */
            return default;
        }

        protected async Task<ResCompany> CreateTransitLocationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: _create_transit_location) ---
            */
            return default;
        }

        protected async Task<ResCompany> CreateUnbuildSequenceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: res_company.py, METHOD: _create_unbuild_sequence) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCompany> CronPostStockValuationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: _cron_post_stock_valuation) ---
            */
            return default;
        }

        protected async Task<ResCompany> DefaultAliasDomainIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_company.py, METHOD: _default_alias_domain_id) ---
            */
            return default;
        }

        protected async Task<ResCompany> DefaultCompanyTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: res_company.py, METHOD: _default_company_token) ---
            */
            return default;
        }

        protected async Task<ResCompany> DefaultConfirmationMailTemplateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: _default_confirmation_mail_template) ---
            */
            return default;
        }

        protected async Task<ResCompany> DefaultConfirmationSmsPickingTemplateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_sms, FILE: res_company.py, METHOD: _default_confirmation_sms_picking_template) ---
            */
            return default;
        }

        protected async Task<ResCompany> DefaultCurrencyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _default_currency_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCompany> DefaultProjectTimeModeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: res_company.py, METHOD: _default_project_time_mode_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCompany> DefaultTimesheetEncodeUomIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: res_company.py, METHOD: _default_timesheet_encode_uom_id) ---
            */
            return default;
        }

        protected async Task<ResCompany> EnrichExtractM2oIdInternalAsync(object iap_data, object m2o_fields)
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_company.py, METHOD: _enrich_extract_m2o_id) ---
            */
            return default;
        }

        protected async Task<ResCompany> EnrichInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_company.py, METHOD: _enrich) ---
            */
            return default;
        }

        protected async Task<bool> ExistingAccountingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _existing_accounting) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCompany> FormatLockDatesInternalAsync(object lock_dates)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _format_lock_dates) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetAccountsByProductInternalAsync(object products)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: _get_accounts_by_product) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetActivePeppolParentCompanyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _get_active_peppol_parent_company) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetAssetStyleB64InternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: _get_asset_style_b64) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetCompanyAddressFieldNamesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_company_address_field_names) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetCompanyAddressUpdateInternalAsync(object partner)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_company_address_update) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetCompanyDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_company.py, METHOD: _get_company_domain) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetCompanyInfoOnPeppolInternalAsync(object edi_identification)
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _get_company_info_on_peppol) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetCompanyRootDelegatedFieldNamesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _get_company_root_delegated_field_names) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_company_root_delegated_field_names) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetContinentalRealtimeVariationValsInternalAsync(object accounts_by_product, object at_date, object extra_aml_vals_list)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: _get_continental_realtime_variation_vals) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetDefaultNomenclatureInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: barcodes, FILE: res_company.py, METHOD: _get_default_nomenclature) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCompany> GetDefaultOpeningMoveValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _get_default_opening_move_values) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetDefaultPricelistValsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: res_company.py, METHOD: _get_default_pricelist_vals) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_company.py, METHOD: _get_default_pricelist_vals) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCompany> GetExtraBalanceInternalAsync(object vals_list)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: _get_extra_balance) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetLastClosingDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: _get_last_closing_date) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetLocationValuationValsInternalAsync(object at_date, object location_domain)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: _get_location_valuation_vals) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetLockDateViolationsInternalAsync(object accounting_date, object fiscalyear, object sale, object purchase, object tax, object hard)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _get_lock_date_violations) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetLogoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_logo) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCompany> GetMainCompanyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_main_company) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetPeppolEdiModeInternalAsync(object temporary_eas)
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _get_peppol_edi_mode) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetPeppolWebhookEndpointInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _get_peppol_webhook_endpoint) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetPublicUserInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_public_user) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetSmsApiClassInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: res_company.py, METHOD: _get_sms_api_class) ---
            --- METHOD SOURCE (MODULE: sms_twilio, FILE: res_company.py, METHOD: _get_sms_api_class) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetSocialMediaLinksInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: res_company.py, METHOD: _get_social_media_links) ---
            --- METHOD SOURCE (MODULE: website_mass_mailing, FILE: res_company.py, METHOD: _get_social_media_links) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetStockValuationAccountValsInternalAsync(object accounts_by_product, object at_date, object extra_aml_vals_list)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: _get_stock_valuation_account_vals) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetTextValidationInternalAsync(object confirmation_type)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: _get_text_validation) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetUnreconciledStatementLinesDomainInternalAsync(object last_date)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _get_unreconciled_statement_lines_domain) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetUnreconciledStatementLinesRedirectActionInternalAsync(object unreconciled_statement_lines)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _get_unreconciled_statement_lines_redirect_action) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetUserFiscalLockDateInternalAsync(object journal, object ignore_exceptions)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _get_user_fiscal_lock_date) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetUserLockDateInternalAsync(object soft_lock_date_field, object ignore_exceptions)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _get_user_lock_date) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCompany> GetViewInternalAsync(Guid view_id, object view_type)
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_company.py, METHOD: _get_view) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_view) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetViolatedLockDatesInternalAsync(object accounting_date, object has_tax, object journal)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _get_violated_lock_dates) ---
            */
            return default;
        }

        protected async Task<ResCompany> GetViolatedSoftLockDateInternalAsync(object soft_lock_date_field, object date)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _get_violated_soft_lock_date) ---
            */
            return default;
        }

        protected async Task<ResCompany> HaveUnauthorizedPeppolParentCompanyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _have_unauthorized_peppol_parent_company) ---
            */
            return default;
        }

        protected async Task<ResCompany> InitColumnInternalAsync(object column_name)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: res_company.py, METHOD: _init_column) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCompany> InitDataResourceCalendarInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: res_company.py, METHOD: _init_data_resource_calendar) ---
            */
            return default;
        }

        protected async Task<ResCompany> InitiateAccountOnboardingsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _initiate_account_onboardings) ---
            */
            return default;
        }

        protected async Task<ResCompany> InverseCityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_city) ---
            */
            return default;
        }

        protected async Task<ResCompany> InverseColorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_color) ---
            */
            return default;
        }

        protected async Task<ResCompany> InverseCountryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_country) ---
            */
            return default;
        }

        protected async Task<ResCompany> InversePeppolPurchaseJournalIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _inverse_peppol_purchase_journal_id) ---
            */
            return default;
        }

        protected async Task<ResCompany> InversePeppolSelfBillingReceptionJournalIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _inverse_peppol_self_billing_reception_journal_id) ---
            */
            return default;
        }

        protected async Task<ResCompany> InverseStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_state) ---
            */
            return default;
        }

        protected async Task<ResCompany> InverseStreet2InternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_street2) ---
            */
            return default;
        }

        protected async Task<ResCompany> InverseStreetInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_street) ---
            */
            return default;
        }

        protected async Task<ResCompany> InverseZipInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_zip) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCompany> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_company.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCompany> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_company.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        protected async Task<ResCompany> OnchangeCountryIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _onchange_country_id) ---
            */
            return default;
        }

        protected async Task<ResCompany> OnchangeParentIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _onchange_parent_id) ---
            */
            return default;
        }

        protected async Task<ResCompany> OnchangeStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _onchange_state) ---
            */
            return default;
        }

        protected async Task<ResCompany> PeppolModulesDocumentTypesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _peppol_modules_document_types) ---
            */
            return default;
        }

        protected async Task<ResCompany> PeppolSupportedDocumentTypesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _peppol_supported_document_types) ---
            */
            return default;
        }

        protected async Task<ResCompany> PrepareInventoryAmlValsInternalAsync(object debit_acc, object credit_acc, object balance, object @ref, Guid product_id)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: _prepare_inventory_aml_vals) ---
            */
            return default;
        }

        protected async Task<ResCompany> PrepareResourceCalendarValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: res_company.py, METHOD: _prepare_resource_calendar_values) ---
            */
            return default;
        }

        protected async Task<ResCompany> RegenerateAttendanceKioskKeyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: res_company.py, METHOD: _regenerate_attendance_kiosk_key) ---
            */
            return default;
        }

        protected async Task<ResCompany> ResetPeppolConfigurationInternalAsync(object soft)
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _reset_peppol_configuration) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCompany> SanitizePeppolEndpointInValuesInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _sanitize_peppol_endpoint_in_values) ---
            */
            return default;
        }

        protected async Task<ResCompany> SanitizePeppolPhoneNumberInternalAsync(object phone_number)
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _sanitize_peppol_phone_number) ---
            */
            return default;
        }

        protected async Task<ResCompany> SaveClosingIdInternalAsync(Guid move_id)
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: _save_closing_id) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCompany> SearchDisplayNameInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _search_display_name) ---
            */
            return default;
        }

        protected async Task<ResCompany> SetCategoryDefaultsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _set_category_defaults) ---
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: _set_category_defaults) ---
            */
            return default;
        }

        protected async Task<ResCompany> SetPerCompanyInterCompanyLocationsInternalAsync(object inter_company_location)
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: _set_per_company_inter_company_locations) ---
            */
            return default;
        }

        protected async Task<ResCompany> UpdateAssetStyleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: _update_asset_style) ---
            */
            return default;
        }

        protected async Task<ResCompany> UpdateOpeningMoveInternalAsync(object to_update)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _update_opening_move) ---
            */
            return default;
        }

        protected async Task<ResCompany> ValidateFiscalyearLockInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: om_fiscal_year, FILE: res_company.py, METHOD: _validate_fiscalyear_lock) ---
            */
            return default;
        }

        protected async Task<ResCompany> ValidateLocksInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _validate_locks) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResCompany> WithLockedRecordsInternalAsync(object records, object allow_raising)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _with_locked_records) ---
            */
            return default;
        }

        private async Task<ResCompany> _AccessibleBranchesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: __accessible_branches) ---
            */
            return default;
        }
    }
}