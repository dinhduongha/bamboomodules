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
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("hr", Category = "HumanResources", Depends = new[] { "base_setup", "digest", "phone_validation", "resource_mail", "web" })]
    public partial class HrMixinAppService : ApplicationService, IHrMixinAppService
    {

        public HrMixinAppService() 
        {

        }

        public async Task<TEntity> ActionCloseKioskSessionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: action_close_kiosk_session) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: action_open_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPosConfigModalEditAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: action_pos_config_modal_edit) ---
            */
            return default;
        }

        public async Task<TEntity> ActionToOpenUiInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _action_to_open_ui) ---
            */
            return default;
        }

        public async Task<TEntity> AddTrustedConfigIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _add_trusted_config_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAdyenAskCustomerForTipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_adyen, FILE: pos_config.py, METHOD: _check_adyen_ask_customer_for_tip) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBeforeCreatingNewSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_before_creating_new_session) ---
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_config.py, METHOD: _check_before_creating_new_session) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCompaniesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_companies) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCompanyHasFiscalCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_company_has_fiscal_country) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCompanyHasTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_company_has_template) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCompanyPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_company_payment) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCurrenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_currencies) ---
            */
            return default;
        }

        public async Task<TEntity> CheckDefaultUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _check_default_user) ---
            */
            return default;
        }

        public async Task<TEntity> CheckGroupsImpliedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_groups_implied) ---
            */
            return default;
        }

        public async Task<TEntity> CheckHeaderFooterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_header_footer) ---
            */
            return default;
        }

        public async Task<TEntity> CheckModulesToInstallInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_modules_to_install) ---
            */
            return default;
        }

        public async Task<TEntity> CheckOnlinePaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_config.py, METHOD: _check_online_payment_methods) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPaymentMethodIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_payment_method_ids) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPaymentMethodIdsJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_payment_method_ids_journal) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPricelistsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_pricelists) ---
            */
            return default;
        }

        public async Task<TEntity> CheckProfitLossCashJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_profit_loss_cash_journal) ---
            */
            return default;
        }

        public async Task<TEntity> CheckRoundingMethodStrategyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_rounding_method_strategy) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSelfOrderOnlinePaymentMethodIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: pos_config.py, METHOD: _check_self_order_online_payment_method_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckTrustedConfigIdsCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_trusted_config_ids_currency) ---
            */
            return default;
        }

        public async Task<TEntity> CloseUiAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: close_ui) ---
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: close_ui) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCashControlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_cash_control) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyHasTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_company_has_template) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_currency) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrentSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_current_session) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrentSessionUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_current_session_user) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFastPaymentMethodIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_fast_payment_method_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsInstalledAccountAccountantInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_is_installed_account_accountant) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLastSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_last_session) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLocalDataIntegrityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_local_data_integrity) ---
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py, METHOD: _compute_local_data_integrity) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSelectionPayAfterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _compute_selection_pay_after) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSelfOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _compute_self_order) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSelfOrderingUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _compute_self_ordering_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStatisticsForSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_statistics_for_session) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _compute_status) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_mixin.py, METHOD: create) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateCashPaymentMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cash_journal_vals) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _create_cash_payment_method) ---
            */
            return default;
        }

        public async Task<TEntity> CreateJournalAndPaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cash_ref, object cash_journal_vals) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _create_journal_and_payment_methods) ---
            */
            return default;
        }

        public async Task<TEntity> CreateSequencesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _create_sequences) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultDiscountValueOnModuleInstallInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_discount, FILE: pos_config.py, METHOD: _default_discount_value_on_module_install) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultInvoiceJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _default_invoice_journal) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultPaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _default_payment_methods) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultPickingTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _default_picking_type_id) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultSaleJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _default_sale_journal) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultWarehouseIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _default_warehouse_id) ---
            */
            return default;
        }

        public async Task<TEntity> EmployeeDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: pos_config.py, METHOD: _employee_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> EnsureDownpaymentProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_sale, FILE: pos_config.py, METHOD: _ensure_downpayment_product) ---
            */
            return default;
        }

        public async Task<TEntity> EnsurePublicAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _ensure_public_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> EnvWithCleanContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _env_with_clean_context) ---
            */
            return default;
        }

        public async Task<TEntity> ExecuteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: execute) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateSingleQrCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _generate_single_qr_code__) ---
            */
            return default;
        }

        public async Task<TEntity> GetAvailablePricelistsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_available_pricelists) ---
            */
            return default;
        }

        public async Task<TEntity> GetCashierOnlinePaymentMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_config.py, METHOD: _get_cashier_online_payment_method) ---
            */
            return default;
        }

        public async Task<TEntity> GetCustomerDisplayDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_customer_display_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultDemoDataXmlIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_default_demo_data_xml_id) ---
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py, METHOD: _get_default_demo_data_xml_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultTipProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_default_tip_product) ---
            */
            return default;
        }

        public async Task<TEntity> GetDemoDataLoaderMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_demo_data_loader_methods) ---
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py, METHOD: _get_demo_data_loader_methods) ---
            */
            return default;
        }

        public async Task<TEntity> GetDisplayDeviceIpInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_display_device_ip) ---
            */
            return default;
        }

        public async Task<TEntity> GetForbiddenChangeFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_forbidden_change_fields) ---
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py, METHOD: _get_forbidden_change_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetGroupPosManagerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_group_pos_manager) ---
            */
            return default;
        }

        public async Task<TEntity> GetGroupPosUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_group_pos_user) ---
            */
            return default;
        }

        public async Task<TEntity> GetKioskUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: get_kiosk_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetLimitedPartnerCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_limited_partner_count) ---
            */
            return default;
        }

        public async Task<TEntity> GetLimitedPartnersLoadingAsync<TEntity>(IEnumerable<TEntity> entities, object offset) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: get_limited_partners_loading) ---
            */
            return default;
        }

        public async Task<TEntity> GetLimitedProductCountAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: get_limited_product_count) ---
            */
            return default;
        }

        public async Task<TEntity> GetNextOrderRefsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object device_identifier) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_next_order_refs) ---
            */
            return default;
        }

        public async Task<TEntity> GetPaymentMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_type) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_payment_method) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPosKanbanViewStateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: get_pos_kanban_view_state) ---
            */
            return default;
        }

        public async Task<TEntity> GetPosQrOrderDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: get_pos_qr_order_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetProgramIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_config.py, METHOD: _get_program_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetQrCodeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _get_qr_code_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetRecordByRefAsync<TEntity>(IEnumerable<TEntity> entities, object recordRefs) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: get_record_by_ref) ---
            */
            return default;
        }

        public async Task<string> GetSelfOrderRouteInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid table_id) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _get_self_order_route) ---
            */
            return default;
        }

        public async Task<string> GetSelfOrderUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid table_id) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _get_self_order_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetSelfOrderingAttachmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object images) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _get_self_ordering_attachment) ---
            */
            return default;
        }

        public async Task<TEntity> GetSelfOrderingDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: pos_config.py, METHOD: _get_self_ordering_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetSpecialProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_special_products) ---
            --- METHOD SOURCE (MODULE: pos_discount, FILE: pos_config.py, METHOD: _get_special_products) ---
            --- METHOD SOURCE (MODULE: pos_sale, FILE: pos_config.py, METHOD: _get_special_products) ---
            */
            return default;
        }

        public async Task<TEntity> GetStatisticsForSessionAsync<TEntity>(IEnumerable<TEntity> entities, object session) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: get_statistics_for_session) ---
            */
            return default;
        }

        public async Task<TEntity> GetSuffixedRefNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object ref_name) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_suffixed_ref_name) ---
            */
            return default;
        }

        public async Task<TEntity> GetUrlToCacheInternalAsync<TEntity>(IEnumerable<TEntity> entities, object debug) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_url_to_cache) ---
            */
            return default;
        }

        public async Task<TEntity> HasValidSelfPaymentMethodAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment_self_order, FILE: pos_config.py, METHOD: has_valid_self_payment_method) ---
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: has_valid_self_payment_method) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> InstallPosRestaurantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: install_pos_restaurant) ---
            */
            return default;
        }

        public async Task<TEntity> IsJournalExistInternalAsync<TEntity>(IEnumerable<TEntity> entities, object journal_code, object name, Guid company_id) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _is_journal_exist) ---
            */
            return default;
        }

        public async Task<TEntity> IsPosPmExistInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, Guid journal_id, Guid company_id) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _is_pos_pm_exist) ---
            */
            return default;
        }

        public async Task<TEntity> IsQuantitiesSetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _is_quantities_set) ---
            */
            return default;
        }

        public async Task<TEntity> KeepNewValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _keep_new_vals) ---
            */
            return default;
        }

        public async Task<TEntity> LinkSameNonCashPaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object source_config) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _link_same_non_cash_payment_methods) ---
            */
            return default;
        }

        public async Task<TEntity> LoadBarDemoDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py, METHOD: _load_bar_demo_data) ---
            */
            return default;
        }

        public async Task<TEntity> LoadDataParamsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: load_data_params) ---
            */
            return default;
        }

        public async Task<TEntity> LoadDemoDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: load_demo_data) ---
            */
            return default;
        }

        public async Task<TEntity> LoadOnboardingBakeryDemoDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _load_onboarding_bakery_demo_data) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadOnboardingBakeryScenarioAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: load_onboarding_bakery_scenario) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadOnboardingBarScenarioAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py, METHOD: load_onboarding_bar_scenario) ---
            */
            return default;
        }

        public async Task<TEntity> LoadOnboardingClothesDemoDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _load_onboarding_clothes_demo_data) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadOnboardingClothesScenarioAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: load_onboarding_clothes_scenario) ---
            */
            return default;
        }

        public async Task<TEntity> LoadOnboardingFurnitureDemoDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _load_onboarding_furniture_demo_data) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadOnboardingFurnitureScenarioAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: load_onboarding_furniture_scenario) ---
            --- METHOD SOURCE (MODULE: pos_sale, FILE: pos_config.py, METHOD: load_onboarding_furniture_scenario) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadOnboardingKioskScenarioAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: load_onboarding_kiosk_scenario) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadOnboardingRestaurantScenarioAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py, METHOD: load_onboarding_restaurant_scenario) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadOnboardingRetailScenarioAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: load_onboarding_retail_scenario) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataReadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records, object config) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _load_pos_data_read) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosSelfDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _load_pos_self_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosSelfDataReadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records, object config) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _load_pos_self_data_read) ---
            */
            return default;
        }

        public async Task<TEntity> LoadRestaurantDemoDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py, METHOD: _load_restaurant_demo_data) ---
            */
            return default;
        }

        public async Task<TEntity> LoadSelfDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: load_self_data) ---
            */
            return default;
        }

        public async Task<TEntity> LoadSelfDataModelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _load_self_data_models) ---
            */
            return default;
        }

        public async Task<TEntity> NotifySynchronisationAsync<TEntity>(IEnumerable<TEntity> entities, Guid session_id, object device_identifier, object records) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: notify_synchronisation) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAdvancedEmployeeIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: pos_config.py, METHOD: _onchange_advanced_employee_ids) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeBasicEmployeeIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: pos_config.py, METHOD: _onchange_basic_employee_ids) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeEpsonPrinterIpInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _onchange_epson_printer_ip) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeMinimalEmployeeIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_hr, FILE: pos_config.py, METHOD: _onchange_minimal_employee_ids) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePaymentMethodIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _onchange_payment_method_ids) ---
            */
            return default;
        }

        public async Task<TEntity> OpenExistingSessionCbAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: open_existing_session_cb) ---
            */
            return default;
        }

        public async Task<TEntity> OpenOpenedRescueSessionFormAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: open_opened_rescue_session_form) ---
            */
            return default;
        }

        public async Task<TEntity> OpenSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid session_id) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _open_session) ---
            */
            return default;
        }

        public async Task<TEntity> OpenUiAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: open_ui) ---
            --- METHOD SOURCE (MODULE: pos_discount, FILE: pos_config.py, METHOD: open_ui) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareSelfOrderCustomBtnInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _prepare_self_order_custom_btn) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareSelfOrderSplashScreenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list, object is_new) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _prepare_self_order_splash_screen) ---
            */
            return default;
        }

        public async Task<TEntity> PreprocessX2manyValsFromSettingsViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _preprocess_x2many_vals_from_settings_view) ---
            */
            return default;
        }

        public async Task<TEntity> PreviewSelfOrderAppAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: preview_self_order_app) ---
            */
            return default;
        }

        public async Task<TEntity> ReadConfigOpenOrdersAsync<TEntity>(IEnumerable<TEntity> entities, object domain, List<Guid> record_ids) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: read_config_open_orders) ---
            */
            return default;
        }

        public async Task<TEntity> RegisterNewDeviceIdentifierAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: register_new_device_identifier) ---
            */
            return default;
        }

        public async Task<TEntity> RemoveTrustedConfigIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _remove_trusted_config_id) ---
            */
            return default;
        }

        public async Task<TEntity> ResetDefaultOnValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _reset_default_on_vals) ---
            */
            return default;
        }

        public async Task<TEntity> SelfOrderDefaultUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _self_order_default_user) ---
            */
            return default;
        }

        public async Task<TEntity> SelfOrderKioskDefaultLanguagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _self_order_kiosk_default_languages) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SetDefaultPosLoadLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _set_default_pos_load_limit) ---
            */
            return default;
        }

        public async Task<TEntity> SetFiscalPositionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _set_fiscal_position) ---
            */
            return default;
        }

        public async Task<TEntity> SetupDefaultFloorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object pos_config) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_restaurant, FILE: pos_config.py, METHOD: _setup_default_floor) ---
            */
            return default;
        }

        public async Task<List<Dictionary<string, object>>> SplitQrCodesListInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Dictionary<string, object>> floors, int cols) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _split_qr_codes_list) ---
            */
            return default;
        }

        public async Task<TEntity> SupportedKioskPaymentTerminalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _supported_kiosk_payment_terminal) ---
            --- METHOD SOURCE (MODULE: pos_self_order_qfpay, FILE: pos_config.py, METHOD: _supported_kiosk_payment_terminal) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_self_order, FILE: pos_config.py, METHOD: _update_access_token) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateCustomerDisplayAsync<TEntity>(IEnumerable<TEntity> entities, object order, object device_uuid) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: update_customer_display) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateEventsSeatsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object events) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_event, FILE: pos_config.py, METHOD: _update_events_seats) ---
            */
            return default;
        }

        public async Task<TEntity> UpdatePreparationPrintersMenuitemVisibilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _update_preparation_printers_menuitem_visibility) ---
            */
            return default;
        }

        public async Task<TEntity> UseCouponCodeAsync<TEntity>(IEnumerable<TEntity> entities, object code, object creation_date, Guid partner_id, Guid pricelist_id) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: pos_loyalty, FILE: pos_config.py, METHOD: use_coupon_code) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IHrMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_mixin.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: pos_hr, FILE: pos_config.py, METHOD: write) ---
            */
            return default;
        }
    }
}