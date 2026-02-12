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
    public partial class PosConfigAppService
    {

        protected async Task<PosConfig> ActionToOpenUiInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _action_to_open_ui) ---
            */
            return default;
        }

        protected async Task<PosConfig> AddTrustedConfigIdInternalAsync(Guid config_id)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _add_trusted_config_id) ---
            */
            return default;
        }

        protected async Task<PosConfig> CheckAdyenAskCustomerForTipInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_adyen, FILE: pos_config.py, METHOD: _check_adyen_ask_customer_for_tip) ---
            */
            return default;
        }

        protected async Task<PosConfig> CheckBeforeCreatingNewSessionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_before_creating_new_session) ---
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_config.py, METHOD: _check_before_creating_new_session) ---
            */
            return default;
        }

        protected async Task<PosConfig> CheckCompaniesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_companies) ---
            */
            return default;
        }

        protected async Task<PosConfig> CheckCompanyHasFiscalCountryInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_company_has_fiscal_country) ---
            */
            return default;
        }

        protected async Task<PosConfig> CheckCompanyHasTemplateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_company_has_template) ---
            */
            return default;
        }

        protected async Task<PosConfig> CheckCompanyPaymentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_company_payment) ---
            */
            return default;
        }

        protected async Task<PosConfig> CheckCurrenciesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_currencies) ---
            */
            return default;
        }

        protected async Task<PosConfig> CheckDefaultUserInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _check_default_user) ---
            */
            return default;
        }

        protected async Task<PosConfig> CheckGroupsImpliedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_groups_implied) ---
            */
            return default;
        }

        protected async Task<PosConfig> CheckHeaderFooterInternalAsync(object values)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_header_footer) ---
            */
            return default;
        }

        protected async Task<PosConfig> CheckModulesToInstallInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_modules_to_install) ---
            */
            return default;
        }

        protected async Task<PosConfig> CheckOnlinePaymentMethodsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_config.py, METHOD: _check_online_payment_methods) ---
            */
            return default;
        }

        protected async Task<PosConfig> CheckPaymentMethodIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_payment_method_ids) ---
            */
            return default;
        }

        protected async Task<PosConfig> CheckPaymentMethodIdsJournalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_payment_method_ids_journal) ---
            */
            return default;
        }

        protected async Task<PosConfig> CheckPricelistsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_pricelists) ---
            */
            return default;
        }

        protected async Task<PosConfig> CheckProfitLossCashJournalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_profit_loss_cash_journal) ---
            */
            return default;
        }

        protected async Task<PosConfig> CheckRoundingMethodStrategyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_rounding_method_strategy) ---
            */
            return default;
        }

        protected async Task<PosConfig> CheckSelfOrderOnlinePaymentMethodIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: pos_config.py, METHOD: _check_self_order_online_payment_method_id) ---
            */
            return default;
        }

        protected async Task<PosConfig> CheckTrustedConfigIdsCurrencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_trusted_config_ids_currency) ---
            */
            return default;
        }

        protected async Task<PosConfig> ComputeCashControlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_cash_control) ---
            */
            return default;
        }

        protected async Task<PosConfig> ComputeCompanyHasTemplateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_company_has_template) ---
            */
            return default;
        }

        protected async Task<PosConfig> ComputeCurrencyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_currency) ---
            */
            return default;
        }

        protected async Task<PosConfig> ComputeCurrentSessionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_current_session) ---
            */
            return default;
        }

        protected async Task<PosConfig> ComputeCurrentSessionUserInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_current_session_user) ---
            */
            return default;
        }

        protected async Task<PosConfig> ComputeFastPaymentMethodIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_fast_payment_method_ids) ---
            */
            return default;
        }

        protected async Task<PosConfig> ComputeIsInstalledAccountAccountantInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_is_installed_account_accountant) ---
            */
            return default;
        }

        protected async Task<PosConfig> ComputeLastSessionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_last_session) ---
            */
            return default;
        }

        protected async Task<PosConfig> ComputeLocalDataIntegrityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_local_data_integrity) ---
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py, METHOD: _compute_local_data_integrity) ---
            */
            return default;
        }

        protected async Task<PosConfig> ComputeSelectionPayAfterInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _compute_selection_pay_after) ---
            */
            return default;
        }

        protected async Task<PosConfig> ComputeSelfOrderInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _compute_self_order) ---
            */
            return default;
        }

        protected async Task<PosConfig> ComputeSelfOrderingUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _compute_self_ordering_url) ---
            */
            return default;
        }

        protected async Task<PosConfig> ComputeStatisticsForSessionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_statistics_for_session) ---
            */
            return default;
        }

        protected async Task<PosConfig> ComputeStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _compute_status) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosConfig> CreateCashPaymentMethodInternalAsync(object cash_journal_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _create_cash_payment_method) ---
            */
            return default;
        }

        protected async Task<PosConfig> CreateJournalAndPaymentMethodsInternalAsync(object cash_ref, object cash_journal_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _create_journal_and_payment_methods) ---
            */
            return default;
        }

        protected async Task<PosConfig> CreateSequencesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _create_sequences) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosConfig> DefaultDiscountValueOnModuleInstallInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_discount, FILE: pos_config.py, METHOD: _default_discount_value_on_module_install) ---
            */
            return default;
        }

        protected async Task<PosConfig> DefaultInvoiceJournalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _default_invoice_journal) ---
            */
            return default;
        }

        protected async Task<PosConfig> DefaultPaymentMethodsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _default_payment_methods) ---
            */
            return default;
        }

        protected async Task<PosConfig> DefaultPickingTypeIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _default_picking_type_id) ---
            */
            return default;
        }

        protected async Task<PosConfig> DefaultSaleJournalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _default_sale_journal) ---
            */
            return default;
        }

        protected async Task<PosConfig> DefaultWarehouseIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _default_warehouse_id) ---
            */
            return default;
        }

        protected async Task<PosConfig> EmployeeDomainInternalAsync(Guid user_id)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: pos_config.py, METHOD: _employee_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosConfig> EnsureDownpaymentProductInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: pos_config.py, METHOD: _ensure_downpayment_product) ---
            */
            return default;
        }

        protected async Task<PosConfig> EnsurePublicAttachmentsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _ensure_public_attachments) ---
            */
            return default;
        }

        protected async Task<PosConfig> EnvWithCleanContextInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _env_with_clean_context) ---
            */
            return default;
        }

        protected async Task<PosConfig> GenerateSingleQrCodeInternalAsync(object url)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _generate_single_qr_code__) ---
            */
            return default;
        }

        protected async Task<PosConfig> GetAvailablePricelistsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_available_pricelists) ---
            */
            return default;
        }

        protected async Task<PosConfig> GetCashierOnlinePaymentMethodInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_config.py, METHOD: _get_cashier_online_payment_method) ---
            */
            return default;
        }

        protected async Task<PosConfig> GetCustomerDisplayDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_customer_display_data) ---
            */
            return default;
        }

        protected async Task<PosConfig> GetDefaultDemoDataXmlIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_default_demo_data_xml_id) ---
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py, METHOD: _get_default_demo_data_xml_id) ---
            */
            return default;
        }

        protected async Task<PosConfig> GetDefaultTipProductInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_default_tip_product) ---
            */
            return default;
        }

        protected async Task<PosConfig> GetDemoDataLoaderMethodsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_demo_data_loader_methods) ---
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py, METHOD: _get_demo_data_loader_methods) ---
            */
            return default;
        }

        protected async Task<PosConfig> GetDisplayDeviceIpInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_display_device_ip) ---
            */
            return default;
        }

        protected async Task<PosConfig> GetForbiddenChangeFieldsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_forbidden_change_fields) ---
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py, METHOD: _get_forbidden_change_fields) ---
            */
            return default;
        }

        protected async Task<PosConfig> GetGroupPosManagerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_group_pos_manager) ---
            */
            return default;
        }

        protected async Task<PosConfig> GetGroupPosUserInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_group_pos_user) ---
            */
            return default;
        }

        protected async Task<PosConfig> GetLimitedPartnerCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_limited_partner_count) ---
            */
            return default;
        }

        protected async Task<PosConfig> GetNextOrderRefsInternalAsync(object device_identifier)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_next_order_refs) ---
            */
            return default;
        }

        protected async Task<PosConfig> GetPaymentMethodInternalAsync(object payment_type)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_payment_method) ---
            */
            return default;
        }

        protected async Task<PosConfig> GetProgramIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_config.py, METHOD: _get_program_ids) ---
            */
            return default;
        }

        protected async Task<PosConfig> GetQrCodeDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _get_qr_code_data) ---
            */
            return default;
        }

        protected async Task<string> GetSelfOrderRouteInternalAsync(Guid table_id)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _get_self_order_route) ---
            */
            return default;
        }

        protected async Task<string> GetSelfOrderUrlInternalAsync(Guid table_id)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _get_self_order_url) ---
            */
            return default;
        }

        protected async Task<PosConfig> GetSelfOrderingAttachmentInternalAsync(object images)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _get_self_ordering_attachment) ---
            */
            return default;
        }

        protected async Task<PosConfig> GetSelfOrderingDataInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: pos_config.py, METHOD: _get_self_ordering_data) ---
            */
            return default;
        }

        protected async Task<PosConfig> GetSpecialProductsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_special_products) ---
            --- METHOD SOURCE (MODULE: pos_discount, FILE: pos_config.py, METHOD: _get_special_products) ---
            --- METHOD SOURCE (MODULE: pos_sale, FILE: pos_config.py, METHOD: _get_special_products) ---
            */
            return default;
        }

        protected async Task<PosConfig> GetSuffixedRefNameInternalAsync(object ref_name)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_suffixed_ref_name) ---
            */
            return default;
        }

        protected async Task<PosConfig> GetUrlToCacheInternalAsync(object debug)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_url_to_cache) ---
            */
            return default;
        }

        protected async Task<PosConfig> IsJournalExistInternalAsync(object journal_code, object name, Guid company_id)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _is_journal_exist) ---
            */
            return default;
        }

        protected async Task<PosConfig> IsPosPmExistInternalAsync(object name, Guid journal_id, Guid company_id)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _is_pos_pm_exist) ---
            */
            return default;
        }

        protected async Task<PosConfig> IsQuantitiesSetInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _is_quantities_set) ---
            */
            return default;
        }

        protected async Task<PosConfig> KeepNewValsInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _keep_new_vals) ---
            */
            return default;
        }

        protected async Task<PosConfig> LinkSameNonCashPaymentMethodsInternalAsync(object source_config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _link_same_non_cash_payment_methods) ---
            */
            return default;
        }

        protected async Task<PosConfig> LoadBarDemoDataInternalAsync(object with_demo_data)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py, METHOD: _load_bar_demo_data) ---
            */
            return default;
        }

        protected async Task<PosConfig> LoadOnboardingBakeryDemoDataInternalAsync(object with_demo_data)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _load_onboarding_bakery_demo_data) ---
            */
            return default;
        }

        protected async Task<PosConfig> LoadOnboardingClothesDemoDataInternalAsync(object with_demo_data)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _load_onboarding_clothes_demo_data) ---
            */
            return default;
        }

        protected async Task<PosConfig> LoadOnboardingFurnitureDemoDataInternalAsync(object with_demo_data)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _load_onboarding_furniture_demo_data) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosConfig> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosConfig> LoadPosDataReadInternalAsync(object records, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _load_pos_data_read) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosConfig> LoadPosSelfDataDomainInternalAsync(object data, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _load_pos_self_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosConfig> LoadPosSelfDataReadInternalAsync(object records, object config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _load_pos_self_data_read) ---
            */
            return default;
        }

        protected async Task<PosConfig> LoadRestaurantDemoDataInternalAsync(object with_demo_data)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py, METHOD: _load_restaurant_demo_data) ---
            */
            return default;
        }

        protected async Task<PosConfig> LoadSelfDataModelsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _load_self_data_models) ---
            */
            return default;
        }

        protected async Task<PosConfig> OnchangeAdvancedEmployeeIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: pos_config.py, METHOD: _onchange_advanced_employee_ids) ---
            */
            return default;
        }

        protected async Task<PosConfig> OnchangeBasicEmployeeIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: pos_config.py, METHOD: _onchange_basic_employee_ids) ---
            */
            return default;
        }

        protected async Task<PosConfig> OnchangeEpsonPrinterIpInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _onchange_epson_printer_ip) ---
            */
            return default;
        }

        protected async Task<PosConfig> OnchangeMinimalEmployeeIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: pos_config.py, METHOD: _onchange_minimal_employee_ids) ---
            */
            return default;
        }

        protected async Task<PosConfig> OnchangePaymentMethodIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _onchange_payment_method_ids) ---
            */
            return default;
        }

        protected async Task<PosConfig> OpenSessionInternalAsync(Guid session_id)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _open_session) ---
            */
            return default;
        }

        protected async Task<PosConfig> PrepareSelfOrderCustomBtnInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _prepare_self_order_custom_btn) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosConfig> PrepareSelfOrderSplashScreenInternalAsync(object vals_list, object is_new)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _prepare_self_order_splash_screen) ---
            */
            return default;
        }

        protected async Task<PosConfig> PreprocessX2manyValsFromSettingsViewInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _preprocess_x2many_vals_from_settings_view) ---
            */
            return default;
        }

        protected async Task<PosConfig> RemoveTrustedConfigIdInternalAsync(Guid config_id)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _remove_trusted_config_id) ---
            */
            return default;
        }

        protected async Task<PosConfig> ResetDefaultOnValsInternalAsync(object vals)
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _reset_default_on_vals) ---
            */
            return default;
        }

        protected async Task<PosConfig> SelfOrderDefaultUserInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _self_order_default_user) ---
            */
            return default;
        }

        protected async Task<PosConfig> SelfOrderKioskDefaultLanguagesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _self_order_kiosk_default_languages) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<PosConfig> SetDefaultPosLoadLimitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _set_default_pos_load_limit) ---
            */
            return default;
        }

        protected async Task<PosConfig> SetFiscalPositionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _set_fiscal_position) ---
            */
            return default;
        }

        protected async Task<PosConfig> SetupDefaultFloorInternalAsync(object pos_config)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py, METHOD: _setup_default_floor) ---
            */
            return default;
        }

        protected async Task<List<Dictionary<string, object>>> SplitQrCodesListInternalAsync(List<Dictionary<string, object>> floors, int cols)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _split_qr_codes_list) ---
            */
            return default;
        }

        protected async Task<PosConfig> SupportedKioskPaymentTerminalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _supported_kiosk_payment_terminal) ---
            --- METHOD SOURCE (MODULE: pos_self_order_qfpay, FILE: pos_config.py, METHOD: _supported_kiosk_payment_terminal) ---
            */
            return default;
        }

        protected async Task<PosConfig> UpdateAccessTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _update_access_token) ---
            */
            return default;
        }

        protected async Task<PosConfig> UpdateEventsSeatsInternalAsync(object events)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: pos_config.py, METHOD: _update_events_seats) ---
            */
            return default;
        }

        protected async Task<PosConfig> UpdatePreparationPrintersMenuitemVisibilityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _update_preparation_printers_menuitem_visibility) ---
            */
            return default;
        }
    }
}