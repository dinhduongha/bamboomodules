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
    [Module("point_of_sale", Category = "Sales", Depends = new[] { "resource", "stock_account", "barcodes", "html_editor", "digest", "phone_validation", "partner_autocomplete", "iot_base", "google_address_autocomplete" })]
    public partial class PosBusMixinAppService : ApplicationService, IPosBusMixinAppService
    {

        public PosBusMixinAppService() 
        {

        }

        public async Task<TEntity> AccumulateAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _accumulate_amounts) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateInvoicesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_create_invoices) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPosConfigModalEditAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: action_pos_config_modal_edit) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPosOrderCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_pos_order_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPosOrderInvoiceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_pos_order_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPosOrderPaidAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_pos_order_paid) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPosSessionCloseAsync<TEntity>(IEnumerable<TEntity> entities, object balancing_account, object amount_to_balance, object bank_payment_method_diffs) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: action_pos_session_close) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPosSessionClosingControlAsync<TEntity>(IEnumerable<TEntity> entities, object balancing_account, object amount_to_balance, object bank_payment_method_diffs) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: action_pos_session_closing_control) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPosSessionOpenAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: action_pos_session_open) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPosSessionValidateAsync<TEntity>(IEnumerable<TEntity> entities, object balancing_account, object amount_to_balance, object bank_payment_method_diffs) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: action_pos_session_validate) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendMailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_send_mail) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendReceiptAsync<TEntity>(IEnumerable<TEntity> entities, object email, object ticket_image, object basic_image) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_send_receipt) ---
            */
            return default;
        }

        public async Task<TEntity> ActionShowPaymentsListAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: action_show_payments_list) ---
            */
            return default;
        }

        public async Task<TEntity> ActionStockPickingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_stock_picking) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: action_stock_picking) ---
            */
            return default;
        }

        public async Task<TEntity> ActionToOpenUiInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _action_to_open_ui) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewInvoiceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_view_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: action_view_order) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewRefundOrdersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_view_refund_orders) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewRefundedOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_view_refunded_order) ---
            */
            return default;
        }

        public async Task<TEntity> AddPaymentAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: add_payment) ---
            */
            return default;
        }

        public async Task<TEntity> AddTrustedConfigIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _add_trusted_config_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AlertOldSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _alert_old_session) ---
            */
            return default;
        }

        public async Task<TEntity> AmountConverterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount, object date, object round) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _amount_converter) ---
            */
            return default;
        }

        public async Task<TEntity> ApplyDiffOnAccountPaymentMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object account_payment, object payment_method, object diff_amount) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _apply_diff_on_account_payment_move) ---
            */
            return default;
        }

        public async Task<TEntity> CannotCloseSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bank_payment_method_diffs) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _cannot_close_session) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBeforeCreatingNewSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_before_creating_new_session) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCompaniesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_companies) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCompanyHasFiscalCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_company_has_fiscal_country) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCompanyHasTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_company_has_template) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCompanyPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_company_payment) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCurrenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_currencies) ---
            */
            return default;
        }

        public async Task<TEntity> CheckGroupsImpliedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_groups_implied) ---
            */
            return default;
        }

        public async Task<TEntity> CheckHeaderFooterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_header_footer) ---
            */
            return default;
        }

        public async Task<TEntity> CheckIfNoDraftOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _check_if_no_draft_orders) ---
            */
            return default;
        }

        public async Task<TEntity> CheckInvoicesArePostedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _check_invoices_are_posted) ---
            */
            return default;
        }

        public async Task<TEntity> CheckModulesToInstallInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_modules_to_install) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPaymentMethodIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_payment_method_ids) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPaymentMethodIdsJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_payment_method_ids_journal) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPosConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _check_pos_config) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPricelistsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_pricelists) ---
            */
            return default;
        }

        public async Task<TEntity> CheckProfitLossCashJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_profit_loss_cash_journal) ---
            */
            return default;
        }

        public async Task<TEntity> CheckRoundingMethodStrategyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_rounding_method_strategy) ---
            */
            return default;
        }

        public async Task<TEntity> CheckStartDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _check_start_date) ---
            */
            return default;
        }

        public async Task<TEntity> CheckTrustedConfigIdsCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _check_trusted_config_ids_currency) ---
            */
            return default;
        }

        public async Task<TEntity> CleanPaymentLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _clean_payment_lines) ---
            */
            return default;
        }

        public async Task<TEntity> CloseSessionActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount_to_balance) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _close_session_action) ---
            */
            return default;
        }

        public async Task<TEntity> CloseSessionFromUiAsync<TEntity>(IEnumerable<TEntity> entities, object bank_payment_method_diff_pairs) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: close_session_from_ui) ---
            */
            return default;
        }

        public async Task<TEntity> CloseUiAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: close_ui) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CompleteValuesFromSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object session, object values) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _complete_values_from_session) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountPaidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_amount_paid) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCashBalanceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _compute_cash_balance) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCashControlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_cash_control) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _compute_cash_control) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCashJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _compute_cash_journal) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyHasTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_company_has_template) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContactDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_contact_details) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_currency) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_currency_rate) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrentSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_current_session) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrentSessionUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_current_session_user) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFastPaymentMethodIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_fast_payment_method_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasRefundableLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_has_refundable_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_invoice_status) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsEditedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_is_edited) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsInCompanyCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _compute_is_in_company_currency) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsInstalledAccountAccountantInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_is_installed_account_accountant) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_is_invoiced) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsTotalCostComputedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_is_total_cost_computed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLastSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_last_session) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLocalDataIntegrityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_local_data_integrity) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMarginInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_margin) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOrderConfigIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_order_config_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOrderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _compute_order_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOrderNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object session) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_order_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePickingCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_picking_count) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _compute_picking_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePricesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_prices) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRefundRelatedFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_refund_related_fields) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStatisticsForSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _compute_statistics_for_session) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalCostAtSessionClosingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stock_moves) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_total_cost_at_session_closing) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalCostInRealTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_total_cost_in_real_time) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalPaymentsAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _compute_total_payments_amount) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAccountMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object balancing_account, object amount_to_balance, object bank_payment_method_diffs) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_account_move) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_bus_mixin.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateBalancingLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object balancing_account, object amount_to_balance) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_balancing_line) ---
            */
            return default;
        }

        public async Task<TEntity> CreateBankPaymentMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_bank_payment_moves) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateCashPaymentMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cash_journal_vals) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _create_cash_payment_method) ---
            */
            return default;
        }

        public async Task<TEntity> CreateCashStatementLinesAndCashMoveLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_cash_statement_lines_and_cash_move_lines) ---
            */
            return default;
        }

        public async Task<TEntity> CreateCombineAccountPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_method, object amounts, object diff_amount) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_combine_account_payment) ---
            */
            return default;
        }

        public async Task<TEntity> CreateDiffAccountMoveForSplitPaymentMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_method, object diff_amount) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_diff_account_move_for_split_payment_method) ---
            */
            return default;
        }

        public async Task<TEntity> CreateInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_vals) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _create_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> CreateInvoiceReceivableLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_invoice_receivable_lines) ---
            */
            return default;
        }

        public async Task<TEntity> CreateJournalAndPaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cash_ref, object cash_journal_vals) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _create_journal_and_payment_methods) ---
            */
            return default;
        }

        public async Task<TEntity> CreateMiscReversalMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_moves) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _create_misc_reversal_move) ---
            */
            return default;
        }

        public async Task<TEntity> CreateNonReconciliableMoveLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_non_reconciliable_move_lines) ---
            */
            return default;
        }

        public async Task<TEntity> CreateOrderPickingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _create_order_picking) ---
            */
            return default;
        }

        public async Task<TEntity> CreatePayLaterReceivableLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_pay_later_receivable_lines) ---
            */
            return default;
        }

        public async Task<TEntity> CreatePickingAtEndOfSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_picking_at_end_of_session) ---
            */
            return default;
        }

        public async Task<TEntity> CreatePmChangeLogInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _create_pm_change_log) ---
            */
            return default;
        }

        public async Task<TEntity> CreateSequencesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _create_sequences) ---
            */
            return default;
        }

        public async Task<TEntity> CreateSplitAccountPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment, object amounts) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_split_account_payment) ---
            */
            return default;
        }

        public async Task<TEntity> CreateStockValuationLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_stock_valuation_lines) ---
            */
            return default;
        }

        public async Task<TEntity> CreditAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partial_move_line_vals, object amount, object amount_converted, object force_company_currency) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _credit_amounts) ---
            */
            return default;
        }

        public async Task<TEntity> DebitAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partial_move_line_vals, object amount, object amount_converted, object force_company_currency) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _debit_amounts) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultInvoiceJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _default_invoice_journal) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultPaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _default_payment_methods) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultPickingTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _default_picking_type_id) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultSaleJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _default_sale_journal) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultWarehouseIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _default_warehouse_id) ---
            */
            return default;
        }

        public async Task<TEntity> DeleteCashInOutAsync<TEntity>(IEnumerable<TEntity> entities, Guid absl_id, Guid partner_id) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: delete_cash_in_out) ---
            */
            return default;
        }

        public async Task<TEntity> DeleteOpeningControlSessionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: delete_opening_control_session) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_bus_mixin.py, METHOD: _ensure_access_token) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureToKeepLastPreparationChangeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _ensure_to_keep_last_preparation_change) ---
            */
            return default;
        }

        public async Task<TEntity> EnvWithCleanContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _env_with_clean_context) ---
            */
            return default;
        }

        public async Task<TEntity> ExecuteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: execute) ---
            */
            return default;
        }

        public async Task<TEntity> FilterLocalDataAsync<TEntity>(IEnumerable<TEntity> entities, object models_to_filter) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: filter_local_data) ---
            */
            return default;
        }

        public async Task<TEntity> FindProductByBarcodeAsync<TEntity>(IEnumerable<TEntity> entities, object barcode, Guid config_id) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: find_product_by_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> GeneratePosOrderInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _generate_pos_order_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttributesByPtalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_attributes_by_ptal_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetAvailablePricelistsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_available_pricelists) ---
            */
            return default;
        }

        public async Task<TEntity> GetBalancingAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_balancing_account) ---
            */
            return default;
        }

        public async Task<TEntity> GetCapturedPaymentsDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_captured_payments_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetCashInOutListAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: get_cash_in_out_list) ---
            */
            return default;
        }

        public async Task<TEntity> GetClosedOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_closed_orders) ---
            */
            return default;
        }

        public async Task<TEntity> GetClosingControlDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: get_closing_control_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetCombineReceivableValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_method, object amount, object amount_converted) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_combine_receivable_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetCombineStatementLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object journal, object amount, object payment_method) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_combine_statement_line_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetCustomerDisplayDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_customer_display_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultDemoDataXmlIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_default_demo_data_xml_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultTipProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_default_tip_product) ---
            */
            return default;
        }

        public async Task<TEntity> GetDemoDataLoaderMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_demo_data_loader_methods) ---
            */
            return default;
        }

        public async Task<TEntity> GetDiffAccountMoveRefInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_method) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_diff_account_move_ref) ---
            */
            return default;
        }

        public async Task<TEntity> GetDiffValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid payment_method_id, object diff_amount, object outstanding_account) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_diff_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetDisplayDeviceIpInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_display_device_ip) ---
            */
            return default;
        }

        public async Task<TEntity> GetForbiddenChangeFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_forbidden_change_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetGroupPosManagerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_group_pos_manager) ---
            */
            return default;
        }

        public async Task<TEntity> GetGroupPosUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_group_pos_user) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvoiceLinesValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_values, object pos_line, object move_type) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_invoice_lines_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePostContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_invoice_post_context) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReceivableValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount, object amount_converted) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_invoice_receivable_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceTotalListInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_invoice_total_list) ---
            */
            return default;
        }

        public async Task<TEntity> GetLimitedPartnerCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_limited_partner_count) ---
            */
            return default;
        }

        public async Task<TEntity> GetLimitedPartnersLoadingAsync<TEntity>(IEnumerable<TEntity> entities, object offset) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: get_limited_partners_loading) ---
            */
            return default;
        }

        public async Task<TEntity> GetLimitedProductCountAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: get_limited_product_count) ---
            */
            return default;
        }

        public async Task<TEntity> GetMailAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object ticket, object basic_ticket) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_mail_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> GetNextOrderRefsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object device_identifier) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_next_order_refs) ---
            */
            return default;
        }

        public async Task<TEntity> GetOpenOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_open_order) ---
            */
            return default;
        }

        protected async Task<object> GetOrderLogRepresentationInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_order_log_representation) ---
            */
            return default;
        }

        public async Task<TEntity> GetOtherRelatedMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_other_related_moves) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnerBankIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_partner_bank_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnersDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_partners_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetPaymentMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_type) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_payment_method) ---
            */
            return default;
        }

        public async Task<TEntity> GetPosAngloSaxonPriceUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product, Guid partner_id, object quantity) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_pos_anglo_saxon_price_unit) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPosKanbanViewStateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: get_pos_kanban_view_state) ---
            */
            return default;
        }

        public async Task<TEntity> GetPosUiProductPricelistItemByProductAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> product_tmpl_ids, List<Guid> product_ids, Guid config_id) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: get_pos_ui_product_pricelist_item_by_product) ---
            */
            return default;
        }

        public async Task<TEntity> GetPreparationChangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: get_preparation_change) ---
            */
            return default;
        }

        public async Task<TEntity> GetReceivableAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_method) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_receivable_account) ---
            */
            return default;
        }

        public async Task<TEntity> GetRecordByRefAsync<TEntity>(IEnumerable<TEntity> entities, object recordRefs) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: get_record_by_ref) ---
            */
            return default;
        }

        public async Task<TEntity> GetReferenceLastPartAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: get_reference_last_part) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetRefundedOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_refunded_orders) ---
            */
            return default;
        }

        public async Task<TEntity> GetRelatedAccountMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_related_account_moves) ---
            */
            return default;
        }

        public async Task<TEntity> GetRoundedAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount, object force_round) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_rounded_amount) ---
            */
            return default;
        }

        public async Task<TEntity> GetRoundingDifferenceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount, object amount_converted) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_rounding_difference_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetSaleKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_sale_key) ---
            */
            return default;
        }

        public async Task<TEntity> GetSaleValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object key, object sale_vals) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_sale_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetSessionOrdersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: get_session_orders) ---
            */
            return default;
        }

        public async Task<TEntity> GetSpecialProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_special_products) ---
            */
            return default;
        }

        public async Task<TEntity> GetSplitReceivableValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment, object amount, object amount_converted) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_split_receivable_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetSplitStatementLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object journal, object amount, object payment) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_split_statement_line_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetStatisticsForSessionAsync<TEntity>(IEnumerable<TEntity> entities, object session) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: get_statistics_for_session) ---
            */
            return default;
        }

        public async Task<TEntity> GetStockExpenseValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object exp_account, object amount, object amount_converted) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_stock_expense_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetStockValuationValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stock_val_account, object amount, object amount_converted) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_stock_valuation_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetSuffixedRefNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object ref_name) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_suffixed_ref_name) ---
            */
            return default;
        }

        public async Task<TEntity> GetTaxValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object key, object amount, object amount_converted, object base_amount_converted) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_tax_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetTotalDiscountAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: get_total_discount) ---
            */
            return default;
        }

        public async Task<TEntity> GetTotalInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_total_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> GetUrlToCacheInternalAsync<TEntity>(IEnumerable<TEntity> entities, object debug) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _get_url_to_cache) ---
            */
            return default;
        }

        public async Task<TEntity> GetValidSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_valid_session) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> InstallPosRestaurantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: install_pos_restaurant) ---
            */
            return default;
        }

        public async Task<TEntity> IsJournalExistInternalAsync<TEntity>(IEnumerable<TEntity> entities, object journal_code, object name, Guid company_id) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _is_journal_exist) ---
            */
            return default;
        }

        public async Task<TEntity> IsPosOrderPaidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _is_pos_order_paid) ---
            */
            return default;
        }

        public async Task<TEntity> IsPosPmExistInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, Guid journal_id, Guid company_id) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _is_pos_pm_exist) ---
            */
            return default;
        }

        public async Task<TEntity> IsQuantitiesSetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _is_quantities_set) ---
            */
            return default;
        }

        public async Task<TEntity> KeepNewValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _keep_new_vals) ---
            */
            return default;
        }

        public async Task<TEntity> LinkSameNonCashPaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object source_config) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _link_same_non_cash_payment_methods) ---
            */
            return default;
        }

        public async Task<TEntity> LoadDataAsync<TEntity>(IEnumerable<TEntity> entities, object models_to_load) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: load_data) ---
            */
            return default;
        }

        public async Task<TEntity> LoadDataParamsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: load_data_params) ---
            */
            return default;
        }

        public async Task<TEntity> LoadDemoDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: load_demo_data) ---
            */
            return default;
        }

        public async Task<TEntity> LoadOnboardingBakeryDemoDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _load_onboarding_bakery_demo_data) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadOnboardingBakeryScenarioAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: load_onboarding_bakery_scenario) ---
            */
            return default;
        }

        public async Task<TEntity> LoadOnboardingClothesDemoDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _load_onboarding_clothes_demo_data) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadOnboardingClothesScenarioAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: load_onboarding_clothes_scenario) ---
            */
            return default;
        }

        public async Task<TEntity> LoadOnboardingFurnitureDemoDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _load_onboarding_furniture_demo_data) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadOnboardingFurnitureScenarioAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: load_onboarding_furniture_scenario) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadOnboardingRetailScenarioAsync<TEntity>(IEnumerable<TEntity> entities, object with_demo_data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: load_onboarding_retail_scenario) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _load_pos_data_domain) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _load_pos_data_domain) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object config) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataModelsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object config) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _load_pos_data_models) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataReadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records, object config) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _load_pos_data_read) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataRelationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object fields) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _load_pos_data_relations) ---
            */
            return default;
        }

        public async Task<TEntity> LogPartnerMessageAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id, object action, object message_type) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: log_partner_message) ---
            */
            return default;
        }

        public async Task<TEntity> MarkupListMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _markup_list_message) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_bus_mixin.py, METHOD: _notify) ---
            */
            return default;
        }

        public async Task<TEntity> NotifySynchronisationAsync<TEntity>(IEnumerable<TEntity> entities, Guid session_id, object device_identifier, object records) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: notify_synchronisation) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAmountAllInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _onchange_amount_all) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeEpsonPrinterIpInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _onchange_epson_printer_ip) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _onchange_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> OpenExistingSessionCbAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: open_existing_session_cb) ---
            */
            return default;
        }

        public async Task<TEntity> OpenFrontendCbAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: open_frontend_cb) ---
            */
            return default;
        }

        public async Task<TEntity> OpenOpenedRescueSessionFormAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: open_opened_rescue_session_form) ---
            */
            return default;
        }

        public async Task<TEntity> OpenSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid session_id) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _open_session) ---
            */
            return default;
        }

        public async Task<TEntity> OpenUiAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: open_ui) ---
            */
            return default;
        }

        public async Task<TEntity> PosHasValidProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _pos_has_valid_product) ---
            */
            return default;
        }

        public async Task<TEntity> PostCashDetailsMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object state, object expected, object difference, object notes) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _post_cash_details_message) ---
            */
            return default;
        }

        public async Task<TEntity> PostCloseRegisterMessageAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: post_close_register_message) ---
            */
            return default;
        }

        public async Task<TEntity> PostClosingCashDetailsAsync<TEntity>(IEnumerable<TEntity> entities, object counted_cash) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: post_closing_cash_details) ---
            */
            return default;
        }

        public async Task<TEntity> PostStatementDifferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _post_statement_difference) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareAccountBankStatementLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object session, object sign, object amount, object reason, Guid partner_id, object extras) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _prepare_account_bank_statement_line_vals) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareAmlValuesListPerNatureInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_aml_values_list_per_nature) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareBalancingLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object imbalance_amount, object move, object balancing_account) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _prepare_balancing_line_vals) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoiceLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_type) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_invoice_lines) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoiceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_invoice_vals) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareMailValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, object ticket, object basic_ticket) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_mail_values) ---
            */
            return default;
        }

        public async Task<TEntity> PreparePosLogInternalAsync<TEntity>(IEnumerable<TEntity> entities, object body) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_pos_log) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareProductAmlDictInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line_vals, object update_base_line_vals, object rate, object sign) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_product_aml_dict) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareRefundValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object current_session) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_refund_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareStatementLineAmountValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object journal, object amount) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _prepare_statement_line_amount_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareTaxBaseLineValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_tax_base_line_values) ---
            */
            return default;
        }

        public async Task<TEntity> PreprocessX2manyValsFromSettingsViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _preprocess_x2many_vals_from_settings_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ProcessOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object existing_order) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _process_order) ---
            */
            return default;
        }

        public async Task<TEntity> ProcessPaymentLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object pos_order, object order, object pos_session, object draft) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _process_payment_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ProcessSavedOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object draft) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _process_saved_order) ---
            */
            return default;
        }

        public async Task<TEntity> ReadConfigOpenOrdersAsync<TEntity>(IEnumerable<TEntity> entities, object domain, List<Guid> record_ids) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: read_config_open_orders) ---
            */
            return default;
        }

        public async Task<TEntity> ReadPosDataAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: read_pos_data) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReadPosDataUuidAsync<TEntity>(IEnumerable<TEntity> entities, object uuid) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: read_pos_data_uuid) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReadPosOrdersAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: read_pos_orders) ---
            */
            return default;
        }

        public async Task<TEntity> ReconcileAccountMoveLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _reconcile_account_move_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ReconcileInvoicePaymentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object payment_moves) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _reconcile_invoice_payments) ---
            */
            return default;
        }

        public async Task<TEntity> RefundAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: refund) ---
            */
            return default;
        }

        public async Task<TEntity> RefundInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _refund) ---
            */
            return default;
        }

        public async Task<TEntity> RegisterNewDeviceIdentifierAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: register_new_device_identifier) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RemoveFromUiAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> server_ids) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: remove_from_ui) ---
            */
            return default;
        }

        public async Task<TEntity> RemoveTrustedConfigIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _remove_trusted_config_id) ---
            */
            return default;
        }

        public async Task<TEntity> ResetDefaultOnValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _reset_default_on_vals) ---
            */
            return default;
        }

        public async Task<TEntity> RoundAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amounts) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _round_amounts) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchPaidOrderIdsAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id, object domain, object limit, object offset) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: search_paid_order_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SendOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _send_order) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SetDefaultPosLoadLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _set_default_pos_load_limit) ---
            */
            return default;
        }

        public async Task<TEntity> SetFiscalPositionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _set_fiscal_position) ---
            */
            return default;
        }

        public async Task<TEntity> SetOpeningControlAsync<TEntity>(IEnumerable<TEntity> entities, int cashbox_value, string notes) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: set_opening_control) ---
            */
            return default;
        }

        public async Task<TEntity> SetOpeningControlDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, int cashbox_value, string notes) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _set_opening_control_data) ---
            */
            return default;
        }

        public async Task<TEntity> ShouldCreatePickingRealTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _should_create_picking_real_time) ---
            */
            return default;
        }

        public async Task<TEntity> ShowCashRegisterAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: show_cash_register) ---
            */
            return default;
        }

        public async Task<TEntity> ShowJournalItemsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: show_journal_items) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SyncFromUiAsync<TEntity>(IEnumerable<TEntity> entities, object orders) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: sync_from_ui) ---
            */
            return default;
        }

        public async Task<TEntity> TryCashInOutAsync<TEntity>(IEnumerable<TEntity> entities, object _type, object amount, object reason, Guid partner_id, object extras) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: try_cash_in_out) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptDraftOrCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _unlink_except_draft_or_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object old_amounts, object amounts_to_add, object date, object round, object force_company_currency) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _update_amounts) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateClosingControlStateSessionAsync<TEntity>(IEnumerable<TEntity> entities, object notes) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: update_closing_control_state_session) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateCustomerDisplayAsync<TEntity>(IEnumerable<TEntity> entities, object order, object device_uuid) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: update_customer_display) ---
            */
            return default;
        }

        public async Task<TEntity> UpdatePreparationPrintersMenuitemVisibilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: _update_preparation_printers_menuitem_visibility) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateSequenceNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object session, object values) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _update_sequence_number) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object balancing_account, object amount_to_balance, object bank_payment_method_diffs) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _validate_session) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPosBusMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_config.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: write) ---
            */
            return default;
        }
    }
}