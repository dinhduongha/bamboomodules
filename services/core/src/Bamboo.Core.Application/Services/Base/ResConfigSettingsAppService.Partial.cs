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
    public partial class ResConfigSettingsAppService
    {

        protected async Task<ResConfigSettings> CheckCloudStorageUninstallableInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage, FILE: res_config_settings.py, METHOD: _check_cloud_storage_uninstallable) ---
            --- METHOD SOURCE (MODULE: cloud_storage_azure, FILE: res_config_settings.py, METHOD: _check_cloud_storage_uninstallable) ---
            --- METHOD SOURCE (MODULE: cloud_storage_google, FILE: res_config_settings.py, METHOD: _check_cloud_storage_uninstallable) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> CheckGoogleMapsStaticApiSecretInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_config_settings.py, METHOD: _check_google_maps_static_api_secret) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeAccountDefaultCreditLimitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_config_settings.py, METHOD: _compute_account_default_credit_limit) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeAccountOnCheckoutInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_config_settings.py, METHOD: _compute_account_on_checkout) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeActiveProviderIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_payment, FILE: res_config_settings.py, METHOD: _compute_active_provider_id) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeActiveUserCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_setup, FILE: res_config_settings.py, METHOD: _compute_active_user_count) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeAuthSignupUninvitedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_config_settings.py, METHOD: _compute_auth_signup_uninvited) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeCloudStorageGoogleAccountInfoInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_google, FILE: res_config_settings.py, METHOD: _compute_cloud_storage_google_account_info) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeCompanyCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_setup, FILE: res_config_settings.py, METHOD: _compute_company_count) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeCompanyInformationsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_setup, FILE: res_config_settings.py, METHOD: _compute_company_informations) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeCoverReadonlyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: res_config_settings.py, METHOD: _compute_cover_readonly) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeCrmAutoAssignmentDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_config_settings.py, METHOD: _compute_crm_auto_assignment_data) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_config.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeFailCounterInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_config_settings.py, METHOD: _compute_fail_counter) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeHasChartOfAccountsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_config_settings.py, METHOD: _compute_has_chart_of_accounts) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeHasDefaultShareImageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_config_settings.py, METHOD: _compute_has_default_share_image) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeHasEnabledProviderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_payment, FILE: res_config_settings.py, METHOD: _compute_has_enabled_provider) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeHasGoogleAnalyticsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_config_settings.py, METHOD: _compute_has_google_analytics) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeHasGoogleSearchConsoleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_config_settings.py, METHOD: _compute_has_google_search_console) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeHasPlausibleSharedKeyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_config_settings.py, METHOD: _compute_has_plausible_shared_key) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeHrExpenseAliasDomainIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: res_config_settings.py, METHOD: _compute_hr_expense_alias_domain_id) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeHrExpenseAliasPrefixInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: res_config_settings.py, METHOD: _compute_hr_expense_alias_prefix) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeIsAccountPeppolEligibleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_config_settings.py, METHOD: _compute_is_account_peppol_eligible) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeIsEncodeUomDaysInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: res_config_settings.py, METHOD: _compute_is_encode_uom_days) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeIsNewsletterEnabledInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale_mass_mailing, FILE: res_config_settings.py, METHOD: _compute_is_newsletter_enabled) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeIsRootCompanyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_setup, FILE: res_config_settings.py, METHOD: _compute_is_root_company) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeLanguageCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: base_setup, FILE: res_config_settings.py, METHOD: _compute_language_count) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeMapsStaticApiKeyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_config_settings.py, METHOD: _compute_maps_static_api_key) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeMapsStaticApiSecretInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_config_settings.py, METHOD: _compute_maps_static_api_secret) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeModuleAccountBankStatementExtractInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_config_settings.py, METHOD: _compute_module_account_bank_statement_extract) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeModuleAccountInvoiceExtractInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_config_settings.py, METHOD: _compute_module_account_invoice_extract) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputePartnerAutocompleteInsufficientCreditInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_config_settings.py, METHOD: _compute_partner_autocomplete_insufficient_credit) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputePeppolUseParentCompanyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_config_settings.py, METHOD: _compute_peppol_use_parent_company) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputePlsFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_config_settings.py, METHOD: _compute_pls_fields) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputePlsStartDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_config_settings.py, METHOD: _compute_pls_start_date) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputePortalAllowApiKeysInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: portal, FILE: res_config_settings.py, METHOD: _compute_portal_allow_api_keys) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputePosAdyenAskCustomerForTipInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_adyen, FILE: res_config_settings.py, METHOD: _compute_pos_adyen_ask_customer_for_tip) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputePosAllowedPricelistIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_config_settings.py, METHOD: _compute_pos_allowed_pricelist_ids) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputePosDiscountProductIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_discount, FILE: res_config_settings.py, METHOD: _compute_pos_discount_product_id) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputePosFiscalPositionsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_config_settings.py, METHOD: _compute_pos_fiscal_positions) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputePosIfaceAvailableCategIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_config_settings.py, METHOD: _compute_pos_iface_available_categ_ids) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputePosIfaceCashdrawerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_config_settings.py, METHOD: _compute_pos_iface_cashdrawer) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputePosIfaceElectronicScaleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_config_settings.py, METHOD: _compute_pos_iface_electronic_scale) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputePosIfacePrintViaProxyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_config_settings.py, METHOD: _compute_pos_iface_print_via_proxy) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputePosIfaceScanViaProxyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_config_settings.py, METHOD: _compute_pos_iface_scan_via_proxy) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputePosModulePosRestaurantInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: res_config_settings.py, METHOD: _compute_pos_module_pos_restaurant) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputePosPricelistIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_config_settings.py, METHOD: _compute_pos_pricelist_id) ---
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: res_config_settings.py, METHOD: _compute_pos_pricelist_id) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputePosPrinterInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_config_settings.py, METHOD: _compute_pos_printer) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputePosReceiptHeaderFooterInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_config_settings.py, METHOD: _compute_pos_receipt_header_footer) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputePosSelectableCategIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_config_settings.py, METHOD: _compute_pos_selectable_categ_ids) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputePosSetTipAfterPaymentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: res_config_settings.py, METHOD: _compute_pos_set_tip_after_payment) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputePosTipProductIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_config_settings.py, METHOD: _compute_pos_tip_product_id) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputePredictiveLeadScoringFieldLabelsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_config_settings.py, METHOD: _compute_predictive_lead_scoring_field_labels) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeReplenishOnOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_config_settings.py, METHOD: _compute_replenish_on_order) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeSharedUserAccountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_config_settings.py, METHOD: _compute_shared_user_account) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeTermsPreviewInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_config_settings.py, METHOD: _compute_terms_preview) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeTimesheetEncodeMethodInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: res_config_settings.py, METHOD: _compute_timesheet_encode_method) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ComputeTimesheetModulesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: res_config_settings.py, METHOD: _compute_timesheet_modules) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> DefaultPosConfigInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_config_settings.py, METHOD: _default_pos_config) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> DefaultUseGoogleMapsStaticApiInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_config_settings.py, METHOD: _default_use_google_maps_static_api) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> DefaultWebsiteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_config_settings.py, METHOD: _default_website) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> GenerateExcelInternalAsync(object rows, object headers)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: res_config_settings.py, METHOD: _generate_excel) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> GetActiveProvidersDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_payment, FILE: res_config_settings.py, METHOD: _get_active_providers_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResConfigSettings> GetClassifiedFieldsInternalAsync(object fnames)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_config.py, METHOD: _get_classified_fields) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> GetCloudStorageConfigurationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage, FILE: res_config_settings.py, METHOD: _get_cloud_storage_configuration) ---
            --- METHOD SOURCE (MODULE: cloud_storage_azure, FILE: res_config_settings.py, METHOD: _get_cloud_storage_configuration) ---
            --- METHOD SOURCE (MODULE: cloud_storage_google, FILE: res_config_settings.py, METHOD: _get_cloud_storage_configuration) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> GetCrmAutoAssignmmentRunDatetimeInternalAsync(object run_datetime, object run_interval, object run_interval_number)
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_config_settings.py, METHOD: _get_crm_auto_assignmment_run_datetime) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResConfigSettings> InstallModulesInternalAsync(object modules)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_config.py, METHOD: _install_modules) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> InverseAccountDefaultCreditLimitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_config_settings.py, METHOD: _inverse_account_default_credit_limit) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> InverseAccountOnCheckoutInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_config_settings.py, METHOD: _inverse_account_on_checkout) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> InverseAuthSignupUninvitedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_config_settings.py, METHOD: _inverse_auth_signup_uninvited) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> InverseCloudStorageMigrationAllModelIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_migration, FILE: res_config_settings.py, METHOD: _inverse_cloud_storage_migration_all_model_ids) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> InverseCloudStorageMigrationMessageModelIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage_migration, FILE: res_config_settings.py, METHOD: _inverse_cloud_storage_migration_message_model_ids) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> InverseHasDefaultShareImageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_config_settings.py, METHOD: _inverse_has_default_share_image) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> InverseHasGoogleAnalyticsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_config_settings.py, METHOD: _inverse_has_google_analytics) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> InverseHasGoogleSearchConsoleInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_config_settings.py, METHOD: _inverse_has_google_search_console) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> InverseHasPlausibleSharedKeyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_config_settings.py, METHOD: _inverse_has_plausible_shared_key) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> InverseHrExpenseAliasDomainIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_expense, FILE: res_config_settings.py, METHOD: _inverse_hr_expense_alias_domain_id) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> InversePlsFieldsStrInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_config_settings.py, METHOD: _inverse_pls_fields_str) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> InversePlsStartDateStrInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_config_settings.py, METHOD: _inverse_pls_start_date_str) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> InversePortalAllowApiKeysInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: portal, FILE: res_config_settings.py, METHOD: _inverse_portal_allow_api_keys) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> InverseReplenishOnOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_config_settings.py, METHOD: _inverse_replenish_on_order) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> InverseSharedUserAccountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_config_settings.py, METHOD: _inverse_shared_user_account) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> InverseTimesheetEncodeMethodInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: res_config_settings.py, METHOD: _inverse_timesheet_encode_method) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> IsCashdrawerDisplayedInternalAsync(object res_config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_config_settings.py, METHOD: _is_cashdrawer_displayed) ---
            --- METHOD SOURCE (MODULE: pos_imin, FILE: res_config_settings.py, METHOD: _is_cashdrawer_displayed) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> IsLayoutCoverRequiredInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: res_config_settings.py, METHOD: _is_layout_cover_required) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnChangeMinsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_password_policy, FILE: res_config_settings.py, METHOD: _on_change_mins) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeAdvancedEmployeeIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: res_config_settings.py, METHOD: _onchange_advanced_employee_ids) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeAuthTotpEnforceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: auth_totp_mail, FILE: res_config_settings.py, METHOD: _onchange_auth_totp_enforce) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeBasicEmployeeIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: res_config_settings.py, METHOD: _onchange_basic_employee_ids) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeCrmAutoAssignmentRunDatetimeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: crm, FILE: res_config_settings.py, METHOD: _onchange_crm_auto_assignment_run_datetime) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeDefaultUserInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: res_config_settings.py, METHOD: _onchange_default_user) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeEpsonPrinterIpInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_config_settings.py, METHOD: _onchange_epson_printer_ip) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeGroupLotOnDeliverySlipInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product_expiry, FILE: res_config_settings.py, METHOD: _onchange_group_lot_on_delivery_slip) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeGroupProductVariantPurchaseInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: res_config_settings.py, METHOD: _onchange_group_product_variant_purchase) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeGroupSalePricelistInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: res_config_settings.py, METHOD: _onchange_group_sale_pricelist) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeGroupStockMultiLocationsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_config_settings.py, METHOD: _onchange_group_stock_multi_locations) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeGroupStockProductionLotInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product_expiry, FILE: res_config_settings.py, METHOD: _onchange_group_stock_production_lot) ---
            --- METHOD SOURCE (MODULE: stock, FILE: res_config_settings.py, METHOD: _onchange_group_stock_production_lot) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeGroupUnlockedByDefaultInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: res_config_settings.py, METHOD: _onchange_group_unlocked_by_default) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeLanguageIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_config_settings.py, METHOD: _onchange_language_ids) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeLayoutInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: res_config_settings.py, METHOD: _onchange_layout) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeMassMailingOutgoingMailServerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: res_config_settings.py, METHOD: _onchange_mass_mailing_outgoing_mail_server) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeMinimalEmployeeIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: res_config_settings.py, METHOD: _onchange_minimal_employee_ids) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeModuleProductExpiryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: product_expiry, FILE: res_config_settings.py, METHOD: _onchange_module_product_expiry) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeModulePurchaseProductMatrixInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: res_config_settings.py, METHOD: _onchange_module_purchase_product_matrix) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeModuleWebsiteEventTrackInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: res_config_settings.py, METHOD: _onchange_module_website_event_track) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangePartnershipLabelInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: partnership, FILE: res_config_settings.py, METHOD: _onchange_partnership_label) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangePosPaymentMethodIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: res_config_settings.py, METHOD: _onchange_pos_payment_method_ids) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangePosSelfOrderKioskDefaultLanguageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: res_config_settings.py, METHOD: _onchange_pos_self_order_kiosk_default_language) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangePosSelfOrderKioskInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: res_config_settings.py, METHOD: _onchange_pos_self_order_kiosk) ---
            --- METHOD SOURCE (MODULE: pos_self_order_sale, FILE: res_config_settings.py, METHOD: _onchange_pos_self_order_kiosk) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangePosSelfOrderPayAfterInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: res_config_settings.py, METHOD: _onchange_pos_self_order_pay_after) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangePosSelfOrderServiceModeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: res_config_settings.py, METHOD: _onchange_pos_self_order_service_mode) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeSharedKeyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_config_settings.py, METHOD: _onchange_shared_key) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeStockConfirmationFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_config_settings.py, METHOD: _onchange_stock_confirmation_fields) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeTaxExigibilityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_config_settings.py, METHOD: _onchange_tax_exigibility) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeTimesheetProjectIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: res_config_settings.py, METHOD: _onchange_timesheet_project_id) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeTimesheetTaskIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: res_config_settings.py, METHOD: _onchange_timesheet_task_id) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeTrustedConfigIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_config_settings.py, METHOD: _onchange_trusted_config_ids) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> OnchangeUseSecurityLeadInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_stock, FILE: res_config_settings.py, METHOD: _onchange_use_security_lead) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ResConfigSettings> PrepareReportViewActionInternalAsync(object template)
        {
            /*
            --- METHOD SOURCE (MODULE: base_setup, FILE: res_config_settings.py, METHOD: _prepare_report_view_action) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> SetupCloudStorageProviderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: cloud_storage, FILE: res_config_settings.py, METHOD: _setup_cloud_storage_provider) ---
            --- METHOD SOURCE (MODULE: cloud_storage_azure, FILE: res_config_settings.py, METHOD: _setup_cloud_storage_provider) ---
            --- METHOD SOURCE (MODULE: cloud_storage_google, FILE: res_config_settings.py, METHOD: _setup_cloud_storage_provider) ---
            */
            return default;
        }

        protected async Task<ResConfigSettings> ValidFieldParameterInternalAsync(object field, object name)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_config.py, METHOD: _valid_field_parameter) ---
            */
            return default;
        }
    }
}