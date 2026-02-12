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
    [Module("portal", Category = "Misc", Depends = new[] { "web", "html_editor", "http_routing", "mail", "auth_signup" })]
    public partial class PortalMixinAppService : ApplicationService, IPortalMixinAppService
    {

        public PortalMixinAppService() 
        {

        }

        public async Task<TEntity> ActionAcknowledgeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_acknowledge) ---
            */
            return default;
        }

        public async Task<TEntity> ActionActivateCurrencyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_activate_currency) ---
            */
            return default;
        }

        public async Task<TEntity> ActionAddFromCatalogAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_add_from_catalog) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_add_from_catalog) ---
            */
            return default;
        }

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_archive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionBillMatchingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_bill_matching) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _action_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> ActionConfigureBankJournalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: action_configure_bank_journal) ---
            */
            return default;
        }

        public async Task<TEntity> ActionConfirmAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_confirm) ---
            */
            return default;
        }

        public async Task<TEntity> ActionConfirmInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _action_confirm) ---
            */
            return default;
        }

        public async Task<TEntity> ActionConvertToSubtaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_convert_to_subtask) ---
            */
            return default;
        }

        public async Task<TEntity> ActionConvertToTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_convert_to_template) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateFromTemplateAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_create_from_template) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_create_from_template) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attachment_ids) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_create_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateInvoicesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_create_invoices) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateTemplateFromProjectAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_create_template_from_project) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDependentTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_dependent_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_draft) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDuplicateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_duplicate) ---
            */
            return default;
        }

        public async Task<TEntity> ActionForceRegisterPaymentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_force_register_payment) ---
            */
            return default;
        }

        public async Task<TEntity> ActionGetListViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_get_list_view) ---
            */
            return default;
        }

        public async Task<TEntity> ActionInvoiceDownloadPdfAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_invoice_download_pdf) ---
            */
            return default;
        }

        public async Task<TEntity> ActionInvoiceReadyToBeSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _action_invoice_ready_to_be_sent) ---
            */
            return default;
        }

        public async Task<TEntity> ActionInvoiceSentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_invoice_sent) ---
            */
            return default;
        }

        public async Task<TEntity> ActionLockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_lock) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMergeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_merge) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMoveDownloadAllAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_move_download_all) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenBusinessDocAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_open_business_doc) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_open_business_doc) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_open_business_doc) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenDiscountWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_open_discount_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenParentTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_open_parent_task) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenRatingsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_open_ratings) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenShareProjectWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_open_share_project_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_open_task) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPosOrderCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_pos_order_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPosOrderInvoiceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_pos_order_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPosOrderPaidAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_pos_order_paid) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_post) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPreviewSaleOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_preview_sale_order) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPrintPdfAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_print_pdf) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProfitabilityItemsAsync<TEntity>(IEnumerable<TEntity> entities, object section_name, object domain, Guid res_id) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_profitability_items) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingOpenBlockingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_project_sharing_open_blocking) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingOpenSubtasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_project_sharing_open_subtasks) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingOpenTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_project_sharing_open_task) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingRecurringTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_project_sharing_recurring_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProjectSharingViewParentTaskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_project_sharing_view_parent_task) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProjectTaskBurndownChartReportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_project_task_burndown_chart_report) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPurchaseComparisonAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_purchase_comparison) ---
            */
            return default;
        }

        public async Task<TEntity> ActionQuotationSendAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_quotation_send) ---
            */
            return default;
        }

        public async Task<TEntity> ActionQuotationSentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_quotation_sent) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRecurringTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_recurring_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToProjectTaskFormAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_redirect_to_project_task_form) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRegisterPaymentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_register_payment) ---
            */
            return default;
        }

        public async Task<TEntity> ActionReverseAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_reverse) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRfqSendAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_rfq_send) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendAndPrintAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_send_and_print) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendMailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_send_mail) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendReceiptAsync<TEntity>(IEnumerable<TEntity> entities, object email, object ticket_image, object basic_image) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_send_receipt) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ActionShareAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: portal, FILE: portal_mixin.py, METHOD: action_share) ---
            */
            return default;
        }

        public async Task<TEntity> ActionStockPickingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_stock_picking) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSwitchMoveTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_switch_move_type) ---
            */
            return default;
        }

        public async Task<TEntity> ActionToggleBlockPaymentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_toggle_block_payment) ---
            */
            return default;
        }

        public async Task<TEntity> ActionToggleProjectTemplateModeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_toggle_project_template_mode) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUndoConvertToTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_undo_convert_to_template) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_undo_convert_to_template) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnlinkRecurrenceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: action_unlink_recurrence) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnlockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_unlock) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUpdateFposValuesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_update_fpos_values) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUpdatePricesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_update_prices) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUpdateTaxesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_update_taxes) ---
            */
            return default;
        }

        public async Task<TEntity> ActionValidateMovesWithConfirmationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: action_validate_moves_with_confirmation) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewAllRatingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_view_all_rating) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, object invoices) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_view_invoice) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_view_invoice) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_view_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewRefundOrdersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_view_refund_orders) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewRefundedOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_view_refunded_order) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTasksAnalysisAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_view_tasks_analysis) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_view_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTasksFromProjectMilestoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_view_tasks_from_project_milestone) ---
            */
            return default;
        }

        public async Task<TEntity> AddBaseLinesForEarlyPaymentDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _add_base_lines_for_early_payment_discount) ---
            */
            return default;
        }

        public async Task<TEntity> AddCollaboratorsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners, object limited_access) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _add_collaborators) ---
            */
            return default;
        }

        public async Task<TEntity> AddFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _add_followers) ---
            */
            return default;
        }

        public async Task<TEntity> AddPaymentAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: add_payment) ---
            */
            return default;
        }

        public async Task<TEntity> AddSupplierToProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _add_supplier_to_product) ---
            */
            return default;
        }

        public async Task<TEntity> AffectTaxReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _affect_tax_report) ---
            */
            return default;
        }

        public async Task<TEntity> AliasGetCreationValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _alias_get_creation_values) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _alias_get_creation_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AliasPrepareAliasNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object alias_name, object name, object code, object jtype, object company) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _alias_prepare_alias_name) ---
            */
            return default;
        }

        public async Task<TEntity> AmountAllInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _amount_all) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ApplyDeltaRecurringEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date, object date_origin, object period) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _apply_delta_recurring_entries) ---
            */
            return default;
        }

        public async Task<TEntity> ApprovalAllowedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _approval_allowed) ---
            */
            return default;
        }

        public async Task<TEntity> AutoInitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _auto_init) ---
            */
            return default;
        }

        public async Task<TEntity> AutopostBillInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _autopost_bill) ---
            */
            return default;
        }

        public async Task<TEntity> AutopostDraftEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object batch_size) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _autopost_draft_entries) ---
            */
            return default;
        }

        public async Task<TEntity> BuildCreditWarningMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object current_amount, object exclude_current, object exclude_amount) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _build_credit_warning_message) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonApproveAsync<TEntity>(IEnumerable<TEntity> entities, object force) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: button_approve) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: button_cancel) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: button_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonConfirmAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: button_confirm) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: button_draft) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: button_draft) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonFetchInEinvoicesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: button_fetch_in_einvoices) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonHashAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: button_hash) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonLockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: button_lock) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonRefreshOutEinvoicesStatusAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: button_refresh_out_einvoices_status) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonRequestCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: button_request_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonSetCheckedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: button_set_checked) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonUnlockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: button_unlock) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonUnsubscribeFromInvoiceNotificationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: button_unsubscribe_from_invoice_notifications) ---
            */
            return default;
        }

        public async Task<TEntity> CalculateHashesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object previous_hash) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _calculate_hashes) ---
            */
            return default;
        }

        public async Task<TEntity> CanBeEditedOnPortalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _can_be_edited_on_portal) ---
            */
            return default;
        }

        public async Task<TEntity> CanBeUnlinkedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _can_be_unlinked) ---
            */
            return default;
        }

        protected async Task<object> CanCommitInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _can_commit) ---
            */
            return default;
        }

        public async Task<TEntity> CanForceCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _can_force_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> ChangePrivacyVisibilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_visibility) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _change_privacy_visibility) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _check_account_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAutoPostDraftEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _check_auto_post_draft_entries) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBalancedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _check_balanced) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBankAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _check_bank_account) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCompanyConsistencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _check_company_consistency) ---
            */
            return default;
        }

        public async Task<TEntity> CheckDraftableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _check_draftable) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckFeaturesEnabledAsync<TEntity>(IEnumerable<TEntity> entities, object updated_features) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: check_features_enabled) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckFieldAccessRightsAsync<TEntity>(IEnumerable<TEntity> entities, object operation, object field_names) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: check_field_access_rights) ---
            */
            return default;
        }

        public async Task<TEntity> CheckFiscalLockDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _check_fiscal_lock_dates) ---
            */
            return default;
        }

        public async Task<TEntity> CheckIncomingEinvoiceNotificationEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _check_incoming_einvoice_notification_email) ---
            */
            return default;
        }

        public async Task<TEntity> CheckInvoiceCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _check_invoice_currency_rate) ---
            */
            return default;
        }

        public async Task<TEntity> CheckJournalMoveTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _check_journal_move_type) ---
            */
            return default;
        }

        public async Task<TEntity> CheckMoveSequenceChainAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: check_move_sequence_chain) ---
            */
            return default;
        }

        public async Task<TEntity> CheckNoCyclicDependenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _check_no_cyclic_dependencies) ---
            */
            return default;
        }

        public async Task<TEntity> CheckOrderLineCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _check_order_line_company_id) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _check_order_line_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _check_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPaymentMethodLineIdsMultiplicityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _check_payment_method_line_ids_multiplicity) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPrepaymentPercentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _check_prepayment_percent) ---
            */
            return default;
        }

        public async Task<TEntity> CheckProjectGroupAtRemovalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _check_project_group_at_removal) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckProjectGroupWithFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object group_name) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _check_project_group_with_field) ---
            */
            return default;
        }

        public async Task<TEntity> CheckProjectSharingAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _check_project_sharing_access) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSelectedMovesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: check_selected_moves) ---
            */
            return default;
        }

        public async Task<TEntity> CheckTotalAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount_total) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _check_total_amount) ---
            */
            return default;
        }

        public async Task<TEntity> CheckTypeDefaultAccountIdTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _check_type_default_account_id_type) ---
            */
            return default;
        }

        public async Task<TEntity> CleanPaymentLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _clean_payment_lines) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CleanupWriteOrmValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object vals) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _cleanup_write_orm_values) ---
            */
            return default;
        }

        public async Task<TEntity> CollectTaxCashBasisValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _collect_tax_cash_basis_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CompleteValuesFromSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object session, object values) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _complete_values_from_session) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAbnormalWarningsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_abnormal_warnings) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccessInstructionMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_access_instruction_message) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccessUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_access_url) ---
            --- METHOD SOURCE (MODULE: portal, FILE: portal_mixin.py, METHOD: _compute_access_url) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_access_url) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_access_url) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_access_url) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_access_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccessWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: portal, FILE: portal_mixin.py, METHOD: _compute_access_warning) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccountingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_accounting_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAdjustingEntriesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_adjusting_entries_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAdjustingEntryOriginLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_adjusting_entry_origin_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAdjustingEntryOriginMovesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_adjusting_entry_origin_moves_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAlertsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_alerts) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAlwaysTaxExigibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_always_tax_exigible) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_amount) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_amount_invoiced) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountPaidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_amount_paid) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_amount_paid) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountToInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_amount_to_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountTotalCcInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_amount_total_cc) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountTotalWordsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_amount_total_words) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountUndiscountedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_amount_undiscounted) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_amounts) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAttachmentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_attachment_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAuthorizedTransactionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_authorized_transaction_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAutoPostUntilInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_auto_post_until) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailableInvoiceTemplatePdfReportIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_available_invoice_template_pdf_report_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailablePaymentMethodIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_available_payment_method_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBankPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_bank_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCheckedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_checked) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeClosedTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_closed_task_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCollaboratorCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_collaborator_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_commercial_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_company_id) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_company_id) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContactDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_contact_details) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_currency_id) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_currency_id) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_currency_id) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_currency_rate) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_currency_rate) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_currency_rate) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrentUserSameCompanyPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_current_user_same_company_partner) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateCalendarStartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_date_calendar_start) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDatePlannedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_date_planned) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDefaultAccountTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_default_account_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDeliveryDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_delivery_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDependOnCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_depend_on_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDependentTasksCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_dependent_tasks_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDirectionSignInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_direction_sign) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayAliasFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_display_alias_fields) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayFollowButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_display_follow_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayInProjectInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_display_in_project) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayInactiveCurrencyWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_display_inactive_currency_warning) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayLinkQrCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_display_link_qr_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayParentTaskButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_display_parent_task_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayQrCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_display_qr_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplaySendButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_display_send_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDuplicatedOrderIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_duplicated_order_ids) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_duplicated_order_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDuplicatedRefIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_duplicated_ref_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeElapsedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_elapsed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeExpectedCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_expected_currency_rate) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeExpectedDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_expected_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFieldValueInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_field_value) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFiscalPositionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_fiscal_position_id) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_fiscal_position_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasActivePricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_has_active_pricelist) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasArchivedProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_has_archived_products) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasInvalidStatementsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_has_invalid_statements) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasLateAndUnreachedMilestoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_has_late_and_unreached_milestone) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasReconciledEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_has_reconciled_entries) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasRefundableLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_has_refundable_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasTemplateAncestorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_has_template_ancestor) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHidePostButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_hide_post_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHighestNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_highest_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHighlightSendButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_highlight_send_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInboundPaymentMethodLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_inbound_payment_method_line_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIncomingEinvoiceNotificationEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_incoming_einvoice_notification_email) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIncotermInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_incoterm) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIncotermLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_incoterm_location) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_currency_rate) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceDateDueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_date_due) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceDefaultSalePersonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_default_sale_person) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceFilterTypeDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_filter_type_domain) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceHasOutstandingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_has_outstanding) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceIncotermPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_incoterm_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoicePartnerDisplayInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_partner_display_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoicePaymentTermIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_invoice_payment_term_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_invoice_status) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_invoice_status) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsBeingSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_is_being_sent) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_is_closed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsEditedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_is_edited) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsExpiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_is_expired) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_is_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_is_invoiced) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMilestoneExceededInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_is_milestone_exceeded) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsSaleInstalledInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_is_sale_installed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsStornoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_is_storno) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsTotalCostComputedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_is_total_cost_computed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_journal_id) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_journal_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLastUpdateColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_last_update_color) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLastUpdateStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_last_update_status) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLinkPreviewNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_link_preview_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLinkedAttachmentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachment_field, object binary_field) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_linked_attachment_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMadeSequenceGapInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_made_sequence_gap) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMarginInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_margin) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMilestoneCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_milestone_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMilestoneIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_milestone_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMilestoneReachedCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_milestone_reached_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMoveSentValuesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: compute_move_sent_values) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNamePlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_name_placeholder) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_name_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNarrationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_narration) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNeedCancelRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_need_cancel_request) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNeededTermsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_needed_terms) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNextMilestoneIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_next_milestone_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNextPaymentDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_next_payment_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNoFollowupInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_no_followup) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNoteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_note) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOpenTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_open_task_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOrderConfigIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_order_config_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOrderNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object session) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_order_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOutboundPaymentMethodLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_outbound_payment_method_line_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerBankIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_partner_bank_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerCreditWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_partner_credit_warning) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_partner_credit_warning) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerInvoiceIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_partner_invoice_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_partner_phone) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerShippingIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_partner_shipping_id) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_partner_shipping_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_payment_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_payment_reference) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_payment_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_payment_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentTermDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_payment_term_details) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentTermIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_payment_term_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentsWidgetReconciledInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_payments_widget_reconciled_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentsWidgetToReconcileInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_payments_widget_to_reconcile_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePersonalStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_personal_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePickingCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_picking_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePortalUserNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_portal_user_names) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePreferredPaymentMethodLineIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_preferred_payment_method_line_id) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_preferred_payment_method_line_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePrepaymentPercentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_prepayment_percent) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePricelistIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_pricelist_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePricesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_prices) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePrivacyVisibilityWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_privacy_visibility_warning) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProjectIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_project_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseWarningTextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_purchase_warning_text) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuickEditModeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_quick_edit_mode) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuickEncodingValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_quick_encoding_vals) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeReceiptReminderEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_receipt_reminder_email) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeReconciledPaymentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_reconciled_payment_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_recurring_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRefundRelatedFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_refund_related_fields) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRefundSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_refund_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRepeatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_repeat) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRequirePaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_require_payment) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRequireSignatureInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_require_signature) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeResourceCalendarIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_resource_calendar_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSaleWarningTextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_sale_warning_text) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSecuredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_secured) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSelectedPaymentMethodCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_selected_payment_method_codes) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowComparisonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_show_comparison) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowDeliveryDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_show_delivery_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowFetchInEinvoicesButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_show_fetch_in_einvoices_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_show_journal) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowPaymentTermDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_show_payment_term_details) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowRatingsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_show_ratings) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowRefreshOutEinvoicesStatusButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_show_refresh_out_einvoices_status_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowResetToDraftButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_show_reset_to_draft_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowTaxableSupplyDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_show_taxable_supply_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStatusInPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_status_in_payment) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSubtaskAllocatedHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_subtask_allocated_hours) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSubtaskCompletionPercentageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_subtask_completion_percentage) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSubtaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _compute_subtask_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSuitableJournalIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_suitable_journal_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSuspenseAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_suspense_account_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaskCompletionPercentageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_task_completion_percentage) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_task_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxCountryCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_tax_country_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxCountryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_tax_country_id) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_tax_country_id) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_tax_country_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_tax_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxLockDateMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_tax_lock_date_message) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxTotalsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_tax_totals) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_tax_totals) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_tax_totals) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxableSupplyDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_taxable_supply_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxableSupplyDatePlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_taxable_supply_date_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxesLegalNotesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_taxes_legal_notes) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTeamIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_team_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalCostAtSessionClosingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stock_moves) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_total_cost_at_session_closing) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalCostInRealTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_total_cost_in_real_time) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalUpdateIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_total_update_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTypeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _compute_type_name) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_type_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_user_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeValidityDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_validity_date) ---
            */
            return default;
        }

        public async Task<TEntity> ConditionalAddToComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname, object condition) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _conditional_add_to_compute) ---
            */
            return default;
        }

        public async Task<TEntity> ConfirmationErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _confirmation_error_message) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _confirmation_error_message) ---
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: copy) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: copy) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: copy) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: copy) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CopyEmbeddedActionsConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_projects, object shared_embedded_actions_mapping) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _copy_embedded_actions_config) ---
            */
            return default;
        }

        public async Task<TEntity> CopyRecurringEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _copy_recurring_entries) ---
            */
            return default;
        }

        public async Task<TEntity> CopySharedEmbeddedActionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_projects) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _copy_shared_embedded_actions) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAccountInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_vals_list, object final) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _create_account_invoices) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAnalyticAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _create_analytic_account) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: create) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateDefaultAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object journal_type, object vals) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _create_default_account) ---
            */
            return default;
        }

        public async Task<TEntity> CreateDocumentFromAttachmentAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attachment_ids) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: create_document_from_attachment) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: create_document_from_attachment) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: create_document_from_attachment) ---
            */
            return default;
        }

        public async Task<TEntity> CreateDocumentFromAttachmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attachment_ids) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _create_document_from_attachment) ---
            */
            return default;
        }

        public async Task<TEntity> CreateDownPaymentLinesFromBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object down_payment_base_lines) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _create_down_payment_lines_from_base_lines) ---
            */
            return default;
        }

        public async Task<TEntity> CreateDownPaymentSectionLineIfNeededInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _create_down_payment_section_line_if_needed) ---
            */
            return default;
        }

        public async Task<TEntity> CreateDownpaymentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_vals) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _create_downpayments) ---
            */
            return default;
        }

        public async Task<TEntity> CreateInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_vals) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _create_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> CreateInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object grouped, object final, object date) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _create_invoices) ---
            */
            return default;
        }

        public async Task<TEntity> CreateMiscReversalMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_moves) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _create_misc_reversal_move) ---
            */
            return default;
        }

        public async Task<TEntity> CreateOrderPickingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _create_order_picking) ---
            */
            return default;
        }

        public async Task<TEntity> CreatePmChangeLogInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _create_pm_change_log) ---
            */
            return default;
        }

        public async Task<TEntity> CreateTaskMappingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object copied_tasks) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _create_task_mapping) ---
            */
            return default;
        }

        public async Task<TEntity> CreateTemplateFromProjectUndoCallbackAsync<TEntity>(IEnumerable<TEntity> entities, object callbacks) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: create_template_from_project_undo_callback) ---
            */
            return default;
        }

        public async Task<TEntity> CreateUpdateDateActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_dates) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _create_update_date_activity) ---
            */
            return default;
        }

        public async Task<TEntity> CreateUpsellActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _create_upsell_activity) ---
            */
            return default;
        }

        public async Task<TEntity> CreationMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _creation_message) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _creation_message) ---
            */
            return default;
        }

        public async Task<TEntity> CreationSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _creation_subtype) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _creation_subtype) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CronAccountMoveSendInternalAsync<TEntity>(IEnumerable<TEntity> entities, object job_count) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _cron_account_move_send) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CronSendPendingEmailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _cron_send_pending_emails) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _default_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultDisplayInvoiceTemplatePdfReportIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _default_display_invoice_template_pdf_report_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: default_get) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultInboundPaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _default_inbound_payment_methods) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultInvoiceReferenceModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _default_invoice_reference_model) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultOrderLineValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object child_field) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _default_order_line_values) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _default_order_line_values) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _default_order_line_values) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultOutboundPaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _default_outbound_payment_methods) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _default_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultTeamIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _default_team_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _default_user_ids) ---
            */
            return default;
        }

        public async Task<TEntity> DetachAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _detach_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> DisableDiscountPrecisionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _disable_discount_precision) ---
            */
            return default;
        }

        public async Task<TEntity> DisableRecursionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container, object key, object @default, object target) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _disable_recursion) ---
            */
            return default;
        }

        public async Task<TEntity> DiscardTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _discard_tracking) ---
            */
            return default;
        }

        public async Task<TEntity> EarlyPaymentDiscountMoveTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _early_payment_discount_move_types) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureCompanyConsistencyWithPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _ensure_company_consistency_with_partner) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureFieldsWriteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object defaults) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _ensure_fields_write) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureStageHasSameCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _ensure_stage_has_same_company) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureSuperTaskIsNotPrivateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _ensure_super_task_is_not_private) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureToKeepLastPreparationChangeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _ensure_to_keep_last_preparation_change) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> EnsureUniqueAliasInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object company) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _ensure_unique_alias) ---
            */
            return default;
        }

        public async Task<TEntity> ExtendWithAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object files_data, object @new) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _extend_with_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> ExtractPriorityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _extract_priority) ---
            */
            return default;
        }

        public async Task<TEntity> ExtractTagsAndUsersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _extract_tags_and_users) ---
            */
            return default;
        }

        public async Task<TEntity> FetchDuplicateOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _fetch_duplicate_orders) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _fetch_duplicate_orders) ---
            */
            return default;
        }

        public async Task<TEntity> FetchDuplicateReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object matching_states) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _fetch_duplicate_reference) ---
            */
            return default;
        }

        public async Task<object> FieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, string @alias, string fname, object query) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _field_to_sql) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FieldWillChangeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object vals, object field_name) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _field_will_change) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FillMissingValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object protected_codes) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _fill_missing_values) ---
            */
            return default;
        }

        public async Task<TEntity> FilterProductDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object documents) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _filter_product_documents) ---
            */
            return default;
        }

        public async Task<TEntity> FindAndSetPurchaseOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object po_references, Guid partner_id, object amount_total, object from_ocr, object timeout) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _find_and_set_purchase_orders) ---
            */
            return default;
        }

        public async Task<TEntity> FindInternalUsersFromAddressMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object emails, Guid project_id) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _find_internal_users_from_address_mail) ---
            */
            return default;
        }

        public async Task<TEntity> FindMailTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _find_mail_template) ---
            */
            return default;
        }

        public async Task<TEntity> ForceLinesToInvoicePolicyOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _force_lines_to_invoice_policy_order) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateAndSendInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_synchronous, object allow_fallback_pdf) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _generate_and_send) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateDownpaymentInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _generate_downpayment_invoices) ---
            */
            return default;
        }

        public async Task<TEntity> GeneratePortalPaymentQrInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _generate_portal_payment_qr) ---
            */
            return default;
        }

        public async Task<TEntity> GeneratePosOrderInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _generate_pos_order_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateQrCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object silent_errors) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _generate_qr_code) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccessActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid, object force_website) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: portal, FILE: portal_mixin.py, METHOD: _get_access_action) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountNodeContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object plan) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_account_node_context) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_date, object has_tax, object lock_dates) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_accounting_date) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountingDateSourceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_accounting_date_source) ---
            */
            return default;
        }

        public async Task<TEntity> GetAcknowledgeUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: get_acknowledge_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetActionAddFromCatalogExtraContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_action_add_from_catalog_extra_context) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_action_add_from_catalog_extra_context) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_action_add_from_catalog_extra_context) ---
            */
            return default;
        }

        public async Task<TEntity> GetActionWithBaseDocumentLayoutConfiguratorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object report_action) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_action_with_base_document_layout_configurator) ---
            */
            return default;
        }

        public async Task<TEntity> GetAlertsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_alerts) ---
            */
            return default;
        }

        public async Task<TEntity> GetAllReconciledInvoicePartialsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_all_reconciled_invoice_partials) ---
            */
            return default;
        }

        public async Task<TEntity> GetAllSubtasksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_all_subtasks) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAllowedAccessParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_allowed_access_params) ---
            */
            return default;
        }

        public async Task<TEntity> GetAlreadyIncludedProfitabilityInvoiceLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_already_included_profitability_invoice_line_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttachmentsSearchDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_attachments_search_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetAutomaticBalancingAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_automatic_balancing_account) ---
            */
            return default;
        }

        public async Task<TEntity> GetAvailableActionReportsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object is_invoice_report) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_available_action_reports) ---
            */
            return default;
        }

        public async Task<TEntity> GetAvailableInvoiceTemplatePdfReportIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_available_invoice_template_pdf_report_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetAvailablePaymentMethodLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_type) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_available_payment_method_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetBankStatementsAvailableSourcesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_bank_statements_available_sources) ---
            */
            return default;
        }

        public async Task<TEntity> GetCannotStartWithPatternsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_cannot_start_with_patterns) ---
            */
            return default;
        }

        public async Task<TEntity> GetChainInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_hash, object include_pre_last_hash, object early_stop) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_chain_info) ---
            */
            return default;
        }

        public async Task<TEntity> GetChainsToHashInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_hash, object raise_if_gap, object raise_if_no_document, object include_pre_last_hash, object early_stop) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_chains_to_hash) ---
            */
            return default;
        }

        public async Task<TEntity> GetConfirmUrlAsync<TEntity>(IEnumerable<TEntity> entities, object confirm_type) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: get_confirm_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetConfirmationTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_confirmation_template) ---
            */
            return default;
        }

        public async Task<TEntity> GetCopiableOrderLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_copiable_order_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetCopyMessageContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_copy_message_content) ---
            */
            return default;
        }

        public async Task<TEntity> GetCurrencyRateAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, Guid to_currency_id, object date) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_currency_rate) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultAccountDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_default_account_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultCreateSectionValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_default_create_section_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object project, object parent) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_default_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultPaymentLinkValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_default_payment_link_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultPersonalStageCreateValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_default_personal_stage_create_vals) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultReadFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_default_read_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_default_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetDiscountAllocationAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_discount_allocation_account) ---
            */
            return default;
        }

        public async Task<TEntity> GetDomainIsLateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_domain_is_late) ---
            */
            return default;
        }

        public async Task<TEntity> GetEdiBuildersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_edi_builders) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_edi_builders) ---
            */
            return default;
        }

        public async Task<TEntity> GetEdiCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_edi_creation) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_message) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: get_empty_list_help) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: get_empty_list_help) ---
            */
            return default;
        }

        public async Task<TEntity> GetExtraPrintItemsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_extra_print_items) ---
            */
            return default;
        }

        public async Task<TEntity> GetFieldsToCopyRecurringEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_fields_to_copy_recurring_entries) ---
            */
            return default;
        }

        public async Task<TEntity> GetFieldsToDetachInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_fields_to_detach) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetFrequentAccountAndTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, Guid partner_id, object move_type) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_frequent_account_and_taxes) ---
            */
            return default;
        }

        public async Task<TEntity> GetGroupPatternInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_group_pattern) ---
            */
            return default;
        }

        public async Task<TEntity> GetGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_groups) ---
            */
            return default;
        }

        public async Task<TEntity> GetGroupsPatternsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_groups_patterns) ---
            */
            return default;
        }

        public async Task<TEntity> GetHidePartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_hide_partner) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_import_templates) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: get_import_templates) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: get_import_templates) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: get_import_templates) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInboundTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_inbound_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetInstallmentsDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_installments_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetIntegrityHashFieldsAndSubfieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_integrity_hash_fields_and_subfields) ---
            */
            return default;
        }

        public async Task<TEntity> GetIntegrityHashFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_integrity_hash_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceComputedReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_computed_reference) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvoiceCounterpartAmlsForEarlyPaymentDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object aml_values_list, object open_balance) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_counterpart_amls_for_early_payment_discount) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceCounterpartAmlsForEarlyPaymentDiscountPerPaymentTermLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_counterpart_amls_for_early_payment_discount_per_payment_term_line) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceCurrencyRateDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_currency_rate_date) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvoiceFilterTypeDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_type) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_filter_type_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceGroupingKeysInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_invoice_grouping_keys) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvoiceInPaymentStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_in_payment_state) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLegalDocumentsAllInternalAsync<TEntity>(IEnumerable<TEntity> entities, object allow_fallback) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_legal_documents_all) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceLegalDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filetype, object allow_fallback) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_legal_documents) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvoiceLinesValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_values, object pos_line, object move_type) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_invoice_lines_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvoiceLocalisationFieldsRequiredToInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, Guid country_id) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_invoice_localisation_fields_required_to_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceNextPaymentValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object custom_amount) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_next_payment_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePdfProformaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_pdf_proforma) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePortalExtraValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object custom_amount) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_portal_extra_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePostContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_invoice_post_context) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceProformaPdfReportFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_proforma_pdf_report_filename) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceEuroInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_reference_euro_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceEuroPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_reference_euro_partner) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceNumberInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_reference_number_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceNumberPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_reference_number_partner) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceOdooInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_reference_odoo_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReferenceOdooPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_reference_odoo_partner) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReportFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object extension, object report) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_invoice_report_filename) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvoiceTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_invoice_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceableLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object final) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_invoiceable_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_invoiced) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_invoiced) ---
            */
            return default;
        }

        public async Task<TEntity> GetItemsFromAalInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_action) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_items_from_aal) ---
            */
            return default;
        }

        public async Task<TEntity> GetJournalBankAccountBalanceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_journal_bank_account_balance) ---
            */
            return default;
        }

        public async Task<TEntity> GetJournalInboundOutstandingPaymentAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_journal_inbound_outstanding_payment_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> GetJournalNotificationUnsubscribeScopeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_journal_notification_unsubscribe_scope) ---
            */
            return default;
        }

        public async Task<TEntity> GetJournalOutboundOutstandingPaymentAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_journal_outbound_outstanding_payment_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> GetJournalsPaymentMethodInformationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_journals_payment_method_information) ---
            */
            return default;
        }

        public async Task<TEntity> GetLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_lang) ---
            */
            return default;
        }

        public async Task<TEntity> GetLastSequenceDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object relaxed) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_last_sequence_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetLastUpdateOrDefaultAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: get_last_update_or_default) ---
            */
            return default;
        }

        public async Task<TEntity> GetLinesOnchangeCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_lines_onchange_currency) ---
            */
            return default;
        }

        public async Task<TEntity> GetLocalizedDatePlannedAsync<TEntity>(IEnumerable<TEntity> entities, object date_planned) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: get_localized_date_planned) ---
            */
            return default;
        }

        public async Task<TEntity> GetLockDateMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_date, object has_tax) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_lock_date_message) ---
            */
            return default;
        }

        public async Task<TEntity> GetMailAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object ticket, object basic_ticket) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_mail_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> GetMailTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_mail_template) ---
            */
            return default;
        }

        public async Task<TEntity> GetMailThreadDataAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_mail_thread_data_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> GetMentionSuggestionsAsync<TEntity>(IEnumerable<TEntity> entities, object search, object limit) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: get_mention_suggestions) ---
            */
            return default;
        }

        public async Task<TEntity> GetMilestonesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: get_milestones) ---
            */
            return default;
        }

        public async Task<TEntity> GetMilestonesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_milestones) ---
            */
            return default;
        }

        public async Task<TEntity> GetMoveDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object show_ref) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_move_display_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMoveHashDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object common_domain, object force_hash) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_move_hash_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetMoveLinesToReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_move_lines_to_report) ---
            */
            return default;
        }

        public async Task<TEntity> GetMoveZipExportDocsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_move_zip_export_docs) ---
            */
            return default;
        }

        public async Task<TEntity> GetMovesRequiringConfirmationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_moves_requiring_confirmation) ---
            */
            return default;
        }

        public async Task<TEntity> GetNameInvoiceReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_name_invoice_report) ---
            */
            return default;
        }

        public async Task<TEntity> GetNamePortalContentViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_name_portal_content_view) ---
            */
            return default;
        }

        public async Task<TEntity> GetNameTaxTotalsViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_name_tax_totals_view) ---
            */
            return default;
        }

        public async Task<TEntity> GetNewCollaboratorsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_new_collaborators) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetNextJournalDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object journal_type, object company, object cache, object protected_codes) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_next_journal_default_code) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetNoteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_note_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetOpenOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_open_order) ---
            */
            return default;
        }

        public async Task<TEntity> GetOrderLinesToReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_order_lines_to_report) ---
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

        public async Task<TEntity> GetOrderTimezoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: get_order_timezone) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetOrdersToRemindInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_orders_to_remind) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetOutboundTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_outbound_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetPanelDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: get_panel_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetParentFieldOnChildModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_parent_field_on_child_model) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_parent_field_on_child_model) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_parent_field_on_child_model) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnerBankIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_partner_bank_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnerCreditWarningExcludeAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_partner_credit_warning_exclude_amount) ---
            */
            return default;
        }

        public async Task<TEntity> GetPlanDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object plan) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_plan_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetPortalLastTransactionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: get_portal_last_transaction) ---
            */
            return default;
        }

        public async Task<TEntity> GetPortalPaymentLinkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_portal_payment_link) ---
            */
            return default;
        }

        public async Task<TEntity> GetPortalReturnActionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_portal_return_action) ---
            */
            return default;
        }

        public async Task<TEntity> GetPortalUrlAsync<TEntity>(IEnumerable<TEntity> entities, object suffix, object report_type, object download, object query_string, object anchor) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: portal, FILE: portal_mixin.py, METHOD: get_portal_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetPosAngloSaxonPriceUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product, Guid partner_id, object quantity) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_pos_anglo_saxon_price_unit) ---
            */
            return default;
        }

        public async Task<TEntity> GetPreparationChangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: get_preparation_change) ---
            */
            return default;
        }

        public async Task<TEntity> GetPrepaymentRequiredAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_prepayment_required_amount) ---
            */
            return default;
        }

        public async Task<TEntity> GetPricedLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_priced_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductCatalogDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_product_catalog_domain) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_product_catalog_domain) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_product_catalog_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductCatalogOrderDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_product_catalog_order_data) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_product_catalog_order_data) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_product_catalog_order_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductCatalogRecordLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> product_ids) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_product_catalog_record_lines) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_product_catalog_record_lines) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_product_catalog_record_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_product_documents) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductPriceAndDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_product_price_and_data) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_product_price_and_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilityAalDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_profitability_aal_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilityItemsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_action) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_profitability_items) ---
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilityLabelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_profitability_labels) ---
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilitySequencePerInvoiceTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_profitability_sequence_per_invoice_type) ---
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilityValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_profitability_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetProjectFeaturesMappingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_project_features_mapping) ---
            */
            return default;
        }

        public async Task<TEntity> GetProjectsToMakeBillableDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object additional_domain) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_projects_to_make_billable_domain) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_projects_to_make_billable_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetProtectedValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object records) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_protected_vals) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPurchaseTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_purchase_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetQuickEditSuggestionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_quick_edit_suggestions) ---
            */
            return default;
        }

        public async Task<TEntity> GetReconciledAmlsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_reconciled_amls) ---
            */
            return default;
        }

        public async Task<TEntity> GetReconciledInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_reconciled_invoices) ---
            */
            return default;
        }

        public async Task<TEntity> GetReconciledInvoicesPartialsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_reconciled_invoices_partials) ---
            */
            return default;
        }

        public async Task<TEntity> GetReconciledPaymentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_reconciled_payments) ---
            */
            return default;
        }

        public async Task<TEntity> GetReconciledStatementLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_reconciled_statement_lines) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetRecurrenceFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_recurrence_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetReferenceLastPartAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: get_reference_last_part) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetRefundedOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_refunded_orders) ---
            */
            return default;
        }

        public async Task<TEntity> GetReportBaseFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_report_base_filename) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_report_base_filename) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_report_base_filename) ---
            */
            return default;
        }

        public async Task<TEntity> GetRottingDependsFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_rotting_depends_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetRottingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_rotting_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetRoundedAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount, object force_round) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_rounded_amount) ---
            */
            return default;
        }

        public async Task<TEntity> GetRoundedBaseAndTaxLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object round_from_tax_lines) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_rounded_base_and_tax_lines) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetSaleTypesAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: get_sale_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetSequenceDateRangeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reset) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_sequence_date_range) ---
            */
            return default;
        }

        public async Task<TEntity> GetShareUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object redirect, object signup_partner, object pid, object share_token) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: portal, FILE: portal_mixin.py, METHOD: _get_share_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetStartingSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_starting_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> GetStatButtonsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_stat_buttons) ---
            */
            return default;
        }

        public async Task<TEntity> GetSubtaskIdsPerTaskIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_subtask_ids_per_task_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetSubtasksRecursivelyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_subtasks_recursively) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetSuitableJournalIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_type, object company) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_suitable_journal_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetSyncStackInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_sync_stack) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTemplateDefaultContextWhitelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_template_default_context_whitelist) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_template_default_context_whitelist) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTemplateFieldBlacklistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_template_field_blacklist) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_template_field_blacklist) ---
            */
            return default;
        }

        public async Task<TEntity> GetTemplateFromProjectUndoCallbacksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_template_from_project_undo_callbacks) ---
            */
            return default;
        }

        public async Task<TEntity> GetTemplateTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: get_template_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> GetTemplateToProjectConfirmationCallbacksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_template_to_project_confirmation_callbacks) ---
            */
            return default;
        }

        public async Task<TEntity> GetTemplateToProjectWarningsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_template_to_project_warnings) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetThreadWithAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid thread_id) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_thread_with_access) ---
            */
            return default;
        }

        public async Task<TEntity> GetUnbalancedMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_unbalanced_moves) ---
            */
            return default;
        }

        public async Task<TEntity> GetUnlinkLoggerMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_unlink_logger_message) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUnusualDaysAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: get_unusual_days) ---
            */
            return default;
        }

        public async Task<TEntity> GetUpdatePricesLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_update_prices_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetUpdateUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: get_update_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetUserValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_user_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetValidJournalTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_valid_journal_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetValidSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_valid_session) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetValuesAnalyticAccountBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object project_vals_list) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_values_analytic_account_batch) ---
            */
            return default;
        }

        public async Task<TEntity> GetVersionedFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_versioned_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _get_view_cache_key) ---
            */
            return default;
        }

        public async Task<TEntity> GetViolatedLockDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_date, object has_tax) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _get_violated_lock_dates) ---
            */
            return default;
        }

        public async Task<TEntity> HasFieldAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object operation) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _has_field_access) ---
            */
            return default;
        }

        public async Task<TEntity> HasToBePaidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _has_to_be_paid) ---
            */
            return default;
        }

        public async Task<TEntity> HasToBeSignedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _has_to_be_signed) ---
            */
            return default;
        }

        public async Task<TEntity> HashMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _hash_moves) ---
            */
            return default;
        }

        public async Task<TEntity> InverseAllowMilestonesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _inverse_allow_milestones) ---
            */
            return default;
        }

        public async Task<TEntity> InverseAllowRecurringTasksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _inverse_allow_recurring_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> InverseAllowTaskDependenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _inverse_allow_task_dependencies) ---
            */
            return default;
        }

        public async Task<TEntity> InverseAmountTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_amount_total) ---
            */
            return default;
        }

        public async Task<TEntity> InverseCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_company_id) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _inverse_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> InverseCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_currency_id) ---
            */
            return default;
        }

        public async Task<TEntity> InverseDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _inverse_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> InverseInvoicePaymentTermIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_invoice_payment_term_id) ---
            */
            return default;
        }

        public async Task<TEntity> InverseJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_journal_id) ---
            */
            return default;
        }

        public async Task<TEntity> InverseNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_name) ---
            */
            return default;
        }

        public async Task<TEntity> InverseNoFollowupInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_no_followup) ---
            */
            return default;
        }

        public async Task<TEntity> InverseParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _inverse_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> InversePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> InversePartnerPhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _inverse_partner_phone) ---
            */
            return default;
        }

        public async Task<TEntity> InversePaymentReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_payment_reference) ---
            */
            return default;
        }

        public async Task<TEntity> InverseStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _inverse_state) ---
            */
            return default;
        }

        public async Task<TEntity> InverseTaxTotalsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _inverse_tax_totals) ---
            */
            return default;
        }

        public async Task<TEntity> InvoicePaidHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _invoice_paid_hook) ---
            */
            return default;
        }

        public async Task<TEntity> IsActionReportAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object action_report, object is_invoice_report) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_action_report_available) ---
            */
            return default;
        }

        public async Task<TEntity> IsBlockedByDependencesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: is_blocked_by_dependences) ---
            */
            return default;
        }

        public async Task<TEntity> IsConfirmationAmountReachedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _is_confirmation_amount_reached) ---
            */
            return default;
        }

        public async Task<TEntity> IsDownpaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_downpayment) ---
            */
            return default;
        }

        public async Task<TEntity> IsEligibleForEarlyPaymentDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object currency, object reference_date) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_eligible_for_early_payment_discount) ---
            */
            return default;
        }

        public async Task<TEntity> IsEntryAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_entry) ---
            */
            return default;
        }

        public async Task<TEntity> IsInboundAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_inbound) ---
            */
            return default;
        }

        public async Task<TEntity> IsInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> IsLineValidForSectionLineCountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_line_valid_for_section_line_count) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> IsMoveRestrictedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object force_hash) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_move_restricted) ---
            */
            return default;
        }

        public async Task<TEntity> IsOutboundAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_outbound) ---
            */
            return default;
        }

        public async Task<TEntity> IsPaidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _is_paid) ---
            */
            return default;
        }

        public async Task<TEntity> IsPaymentMethodAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_method_code, object complete_domain) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _is_payment_method_available) ---
            */
            return default;
        }

        public async Task<TEntity> IsPosOrderPaidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _is_pos_order_paid) ---
            */
            return default;
        }

        public async Task<TEntity> IsProtectedByAuditTrailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_protected_by_audit_trail) ---
            */
            return default;
        }

        public async Task<TEntity> IsPurchaseDocumentAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts, object move_type) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_purchase_document) ---
            */
            return default;
        }

        public async Task<TEntity> IsReadonlyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_readonly) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _is_readonly) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _is_readonly) ---
            */
            return default;
        }

        public async Task<TEntity> IsReadyToBeSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_ready_to_be_sent) ---
            */
            return default;
        }

        public async Task<TEntity> IsReceiptAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_receipt) ---
            */
            return default;
        }

        public async Task<TEntity> IsRecurrenceValidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _is_recurrence_valid) ---
            */
            return default;
        }

        public async Task<TEntity> IsSaleDocumentAsync<TEntity>(IEnumerable<TEntity> entities, object include_receipts, object move_type) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: is_sale_document) ---
            */
            return default;
        }

        public async Task<TEntity> IsUserAbleToReviewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _is_user_able_to_review) ---
            */
            return default;
        }

        public async Task<TEntity> JsAssignOutstandingLineAsync<TEntity>(IEnumerable<TEntity> entities, Guid line_id) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: js_assign_outstanding_line) ---
            */
            return default;
        }

        public async Task<TEntity> JsRemoveOutstandingPartialAsync<TEntity>(IEnumerable<TEntity> entities, Guid partial_id) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: js_remove_outstanding_partial) ---
            */
            return default;
        }

        public async Task<TEntity> LinkBillOriginToPurchaseOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object timeout) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _link_bill_origin_to_purchase_orders) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        public async Task<TEntity> LoadRecordsCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _load_records_create) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetMessageSubtypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _mail_get_message_subtypes) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _mail_get_message_subtypes) ---
            */
            return default;
        }

        public async Task<TEntity> MailingGetDefaultDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mailing) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _mailing_get_default_domain) ---
            */
            return default;
        }

        public async Task<TEntity> MapTasksAsync<TEntity>(IEnumerable<TEntity> entities, Guid new_project_id) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: map_tasks) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MapTasksDefaultValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object project) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _map_tasks_default_values) ---
            */
            return default;
        }

        public async Task<TEntity> MarkupListMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _markup_list_message) ---
            */
            return default;
        }

        public async Task<TEntity> MergeAlternativePoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object rfqs) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _merge_alternative_po) ---
            */
            return default;
        }

        public async Task<TEntity> MessageAutoSubscribeFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_values, List<Guid> default_subtype_ids) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _message_auto_subscribe_followers) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MessageNewAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object custom_values) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: message_new) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: message_new) ---
            */
            return default;
        }

        public async Task<TEntity> MessagePostAfterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _message_post_after_hook) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _message_post_after_hook) ---
            #endif
            return default;
        }

        public async Task<TEntity> MessagePostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: message_post) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: message_post) ---
            */
            return default;
        }

        public async Task<TEntity> MessageSubscribeAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids, List<Guid> subtype_ids) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: message_subscribe) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: message_subscribe) ---
            */
            return default;
        }

        public async Task<TEntity> MessageUnsubscribeAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: message_unsubscribe) ---
            */
            return default;
        }

        public async Task<TEntity> MessageUpdateAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object update_vals) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: message_update) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MoveDictToPreviewValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_vals, Guid currency_id) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _move_dict_to_preview_vals) ---
            */
            return default;
        }

        public async Task<TEntity> MustCheckConstrainsDateSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _must_check_constrains_date_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> MustDeleteDatePlannedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _must_delete_date_planned) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NameCreateAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: name_create) ---
            */
            return default;
        }

        public async Task<TEntity> NeedCancelRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _need_cancel_request) ---
            */
            return default;
        }

        public async Task<TEntity> NothingToInvoiceErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _nothing_to_invoice_error_message) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailGetHeadersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object headers) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _notify_by_email_get_headers) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailPrepareRenderingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals, object model_description, object force_email_company, object force_email_lang, object force_record_name) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _notify_by_email_prepare_rendering_context) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _notify_by_email_prepare_rendering_context) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _notify_by_email_prepare_rendering_context) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _notify_by_email_prepare_rendering_context) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyEinvoicesReceivedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _notify_einvoices_received) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _notify_get_recipients_groups) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _notify_get_recipients_groups) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _notify_get_recipients_groups) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _notify_get_recipients_groups) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetReplyToInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @default, Guid author_id) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _notify_get_reply_to) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyInvoiceSubscribersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object mail_params) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _notify_invoice_subscribers) ---
            */
            return default;
        }

        public async Task<TEntity> OPENSTATESAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: OPEN_STATES) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAmountAllInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _onchange_amount_all) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAsync<TEntity>(IEnumerable<TEntity> entities, object values, object field_names, object fields_spec) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: onchange) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: onchange) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: onchange) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCommitmentDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_commitment_date) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _onchange_company_id) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_company_id_warning) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_date) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeDatePlannedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: onchange_date_planned) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeFposIdShowUpdateFposInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_fpos_id_show_update_fpos) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_fpos_id_show_update_fpos) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeIncomingEinvoiceNotificationEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _onchange_incoming_einvoice_notification_email) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeInvoiceCashRoundingIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_invoice_cash_rounding_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeInvoiceVendorBillInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_invoice_vendor_bill) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_journal_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeNameWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_name_warning) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeOrderLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_order_line) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePartnerIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: onchange_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_partner_id) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _onchange_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePrepaymentPercentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_prepayment_percent) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePricelistIdShowUpdatePricesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_pricelist_id_show_update_prices) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeProjectIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _onchange_project_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeQuickEditLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_quick_edit_line_ids) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeQuickEditTotalAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _onchange_quick_edit_total_amount) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTaskCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _onchange_task_company) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _onchange_type) ---
            */
            return default;
        }

        public async Task<TEntity> OpenAdjustingEntriesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: open_adjusting_entries) ---
            */
            return default;
        }

        public async Task<TEntity> OpenAdjustingEntryOriginMovesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: open_adjusting_entry_origin_moves) ---
            */
            return default;
        }

        public async Task<TEntity> OpenCreatedCabaEntriesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: open_created_caba_entries) ---
            */
            return default;
        }

        public async Task<TEntity> OpenPaymentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: open_payments) ---
            */
            return default;
        }

        public async Task<TEntity> OpenReconcileViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: open_reconcile_view) ---
            */
            return default;
        }

        public async Task<TEntity> OrderFieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @alias, object field_name, object direction, object nulls, object query) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _order_field_to_sql) ---
            */
            return default;
        }

        public async Task<TEntity> PaymentActionCaptureAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: payment_action_capture) ---
            */
            return default;
        }

        public async Task<TEntity> PaymentActionVoidAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: payment_action_void) ---
            */
            return default;
        }

        public async Task<TEntity> PhoneGetNumberFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _phone_get_number_fields) ---
            */
            return default;
        }

        public async Task<TEntity> PlanTaskInCalendarAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: plan_task_in_calendar) ---
            */
            return default;
        }

        public async Task<TEntity> PopulateMissingPersonalStagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _populate_missing_personal_stages) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PortalAccessibleFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _portal_accessible_fields) ---
            */
            return default;
        }

        public async Task<TEntity> PortalEnsureTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: portal, FILE: portal_mixin.py, METHOD: _portal_ensure_token) ---
            */
            return default;
        }

        public async Task<TEntity> PortalGetParentHashTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object pid) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _portal_get_parent_hash_token) ---
            */
            return default;
        }

        public async Task<TEntity> PostInternalAsync<TEntity>(IEnumerable<TEntity> entities, object soft) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _post) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareAmlValuesListPerNatureInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_aml_values_list_per_nature) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareAnalyticAccountDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object prefix) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _prepare_analytic_account_data) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareCashRoundingBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cash_rounding_line) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_cash_rounding_base_line_for_taxes_computation) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareConfirmationValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _prepare_confirmation_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareCreditAccountValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object code, object vals) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _prepare_credit_account_vals) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareDownPaymentLineSectionValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _prepare_down_payment_line_section_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareDownPaymentLineValuesFromBaseLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _prepare_down_payment_line_values_from_base_line) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareDownPaymentSectionLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _prepare_down_payment_section_line) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareDownPaymentSectionValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _prepare_down_payment_section_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareEdiValsToExportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_edi_vals_to_export) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareEpdBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object epd_line) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_epd_base_line_for_taxes_computation) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareEpdBaseLinesForTaxesComputationFromBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_epd_base_lines_for_taxes_computation_from_base_lines) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareGroupedDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object rfq) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _prepare_grouped_data) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoiceAggregatedTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filter_invl_to_apply, object filter_tax_values_to_apply, object grouping_key_generator, object round_from_tax_lines, object postfix_function) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_invoice_aggregated_taxes) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _prepare_invoice) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _prepare_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoiceLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_type) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_invoice_lines) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoiceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_invoice_vals) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareLiquidityAccountValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object code, object vals) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _prepare_liquidity_account_vals) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareMailValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, object ticket, object basic_ticket) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_mail_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareNonDeductibleBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object non_deductible_line) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_non_deductible_base_line_for_taxes_computation) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareNonDeductibleBaseLinesForTaxesComputationFromBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_non_deductible_base_lines_for_taxes_computation_from_base_lines) ---
            */
            return default;
        }

        public async Task<TEntity> PreparePatternGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _prepare_pattern_groups) ---
            */
            return default;
        }

        public async Task<TEntity> PreparePosLogInternalAsync<TEntity>(IEnumerable<TEntity> entities, object body) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_pos_log) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareProductAmlDictInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line_vals, object update_base_line_vals, object rate, object sign) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_product_aml_dict) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareProductBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_line) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_product_base_line_for_taxes_computation) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareRefundValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object current_session) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_refund_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareSupplierInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object line, object price, object currency) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _prepare_supplier_info) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareTaxBaseLineValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_tax_base_line_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareTaxLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_line) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_tax_line_for_taxes_computation) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareTaxLinesForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_amls, object round_from_tax_lines) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _prepare_tax_lines_for_taxes_computation) ---
            */
            return default;
        }

        public async Task<TEntity> PreviewInvoiceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: preview_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> PrintQuotationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: print_quotation) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ProcessOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object existing_order) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _process_order) ---
            */
            return default;
        }

        public async Task<TEntity> ProcessPaymentLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object pos_order, object order, object pos_session, object draft) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _process_payment_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ProcessReferenceForSaleOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order_reference) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _process_reference_for_sale_order) ---
            */
            return default;
        }

        public async Task<TEntity> ProcessSavedOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object draft) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _process_saved_order) ---
            */
            return default;
        }

        public async Task<TEntity> ProjectSharingToggleIsFollowerAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: project_sharing_toggle_is_follower) ---
            */
            return default;
        }

        public async Task<TEntity> ProjectUpdateAllActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: project_update_all_action) ---
            */
            return default;
        }

        public async Task<TEntity> QuickEditModeSuggestInvoiceDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _quick_edit_mode_suggest_invoice_date) ---
            */
            return default;
        }

        public async Task<TEntity> RatingApplyAsync<TEntity>(IEnumerable<TEntity> entities, object rate, object token, object rating, object feedback, object subtype_xmlid, object notify_delay_send) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: rating_apply) ---
            */
            return default;
        }

        public async Task<TEntity> RatingApplyGetDefaultSubtypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _rating_apply_get_default_subtype_id) ---
            */
            return default;
        }

        public async Task<TEntity> RatingGetOperatorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _rating_get_operator) ---
            */
            return default;
        }

        public async Task<TEntity> RatingGetParentFieldNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _rating_get_parent_field_name) ---
            */
            return default;
        }

        public async Task<TEntity> RatingGetPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _rating_get_partner) ---
            */
            return default;
        }

        public async Task<TEntity> ReadAsync<TEntity>(IEnumerable<TEntity> entities, object fields, object load) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: read) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<List<object>> ReadGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object groupby, object aggregates, object having, object offset, object limit, object order) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _read_group) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReadGroupPersonalStageTypeIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stages, object domain) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _read_group_personal_stage_type_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReadGroupStageIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stages, object domain) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _read_group_stage_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ReadPosDataAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: read_pos_data) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReadPosDataUuidAsync<TEntity>(IEnumerable<TEntity> entities, object uuid) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: read_pos_data_uuid) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReadPosOrdersAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: read_pos_orders) ---
            */
            return default;
        }

        public async Task<TEntity> ReasonCannotDecodeHasInvoiceLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _reason_cannot_decode_has_invoice_lines) ---
            */
            return default;
        }

        public async Task<TEntity> RecNamesSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _rec_names_search) ---
            */
            return default;
        }

        public async Task<TEntity> RecomputeCashRoundingLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _recompute_cash_rounding_lines) ---
            */
            return default;
        }

        public async Task<TEntity> RecomputePricesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _recompute_prices) ---
            */
            return default;
        }

        public async Task<TEntity> RecomputeTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _recompute_taxes) ---
            */
            return default;
        }

        public async Task<TEntity> ReconcileInvoicePaymentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object payment_moves) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _reconcile_invoice_payments) ---
            */
            return default;
        }

        public async Task<TEntity> ReconcileReversedMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reverse_moves, object move_reverse_cancel) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _reconcile_reversed_moves) ---
            */
            return default;
        }

        public async Task<TEntity> RefreshInvoiceCurrencyRateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: refresh_invoice_currency_rate) ---
            */
            return default;
        }

        public async Task<TEntity> RefundAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: refund) ---
            */
            return default;
        }

        public async Task<TEntity> RefundInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _refund) ---
            */
            return default;
        }

        public async Task<TEntity> RefundsOriginRequiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _refunds_origin_required) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RemoveFromUiAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> server_ids) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: remove_from_ui) ---
            */
            return default;
        }

        public async Task<TEntity> RequireBillDateForAutopostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _require_bill_date_for_autopost) ---
            */
            return default;
        }

        public async Task<TEntity> ResolveCopiedDependenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object copied_tasks) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _resolve_copied_dependencies) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RetrieveDashboardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: retrieve_dashboard) ---
            */
            return default;
        }

        public async Task<TEntity> ReverseMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object default_values_list, object cancel) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _reverse_moves) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RoutingCheckRouteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object message_dict, object route, object raise_exception) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _routing_check_route) ---
            */
            return default;
        }

        public async Task<TEntity> SanitizeValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sanitize_vals) ---
            */
            return default;
        }

        public async Task<TEntity> SearchDefaultJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _search_default_journal) ---
            */
            return default;
        }

        public async Task<TEntity> SearchHasLateAndUnreachedMilestoneInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_has_late_and_unreached_milestone) ---
            */
            return default;
        }

        public async Task<TEntity> SearchHasTemplateAncestorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_has_template_ancestor) ---
            */
            return default;
        }

        public async Task<TEntity> SearchInvoiceIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _search_invoice_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_is_closed) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _search_is_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsLateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _search_is_late) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsMilestoneExceededInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _search_is_milestone_exceeded) ---
            */
            return default;
        }

        public async Task<TEntity> SearchJournalGroupIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _search_journal_group_id) ---
            */
            return default;
        }

        public async Task<TEntity> SearchMoveSentValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _search_move_sent_values) ---
            */
            return default;
        }

        public async Task<TEntity> SearchNextPaymentDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _search_next_payment_date) ---
            */
            return default;
        }

        public async Task<TEntity> SearchOnComodelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field, object comodel, object additional_domain) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_on_comodel) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchPaidOrderIdsAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id, object domain, object limit, object offset) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: search_paid_order_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchPersonalStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_personal_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> SearchPortalUserNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _search_portal_user_names) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchReadAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object fields, object offset, object limit, object order) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: search_read) ---
            */
            return default;
        }

        public async Task<TEntity> SearchReconciledPaymentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _search_reconciled_payment_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchSecuredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _search_secured) ---
            */
            return default;
        }

        public async Task<TEntity> SelectExpectedDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expected_dates) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _select_expected_date) ---
            */
            return default;
        }

        public async Task<TEntity> SendEmailNotifyToCcInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners_to_notify) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _send_email_notify_to_cc) ---
            */
            return default;
        }

        public async Task<TEntity> SendOnlyWhenReadyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _send_only_when_ready) ---
            */
            return default;
        }

        public async Task<TEntity> SendOrderConfirmationMailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _send_order_confirmation_mail) ---
            */
            return default;
        }

        public async Task<TEntity> SendOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _send_order) ---
            */
            return default;
        }

        public async Task<TEntity> SendOrderNotificationMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_template, object allow_deferred_sending) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _send_order_notification_mail) ---
            */
            return default;
        }

        public async Task<TEntity> SendPaymentSucceededForOrderMailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _send_payment_succeeded_for_order_mail) ---
            */
            return default;
        }

        public async Task<TEntity> SendReminderMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object send_single) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _send_reminder_mail) ---
            */
            return default;
        }

        public async Task<TEntity> SendReminderOpenComposerInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid template_id) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _send_reminder_open_composer) ---
            */
            return default;
        }

        public async Task<TEntity> SendReminderPreviewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: send_reminder_preview) ---
            */
            return default;
        }

        public async Task<TEntity> SendTaskRatingMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_send) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _send_task_rating_mail) ---
            */
            return default;
        }

        public async Task<TEntity> SequenceFixedRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sequence_fixed_regex) ---
            */
            return default;
        }

        public async Task<TEntity> SequenceMonthlyRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sequence_monthly_regex) ---
            */
            return default;
        }

        public async Task<TEntity> SequenceYearRangeMonthlyRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sequence_year_range_monthly_regex) ---
            */
            return default;
        }

        public async Task<TEntity> SequenceYearRangeRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sequence_year_range_regex) ---
            */
            return default;
        }

        public async Task<TEntity> SequenceYearlyRegexInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sequence_yearly_regex) ---
            */
            return default;
        }

        public async Task<TEntity> SetBankAccountAsync<TEntity>(IEnumerable<TEntity> entities, object acc_number, Guid bank_id) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: set_bank_account) ---
            */
            return default;
        }

        public async Task<TEntity> SetFavoriteUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object is_favorite) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _set_favorite_user_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SetMovesCheckedAsync<TEntity>(IEnumerable<TEntity> entities, object is_checked) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: set_moves_checked) ---
            */
            return default;
        }

        public async Task<TEntity> SetNextMadeSequenceGapInternalAsync<TEntity>(IEnumerable<TEntity> entities, bool made_gap) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _set_next_made_sequence_gap) ---
            */
            return default;
        }

        public async Task<TEntity> SetReversedEntryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object credit_note) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _set_reversed_entry) ---
            */
            return default;
        }

        public async Task<TEntity> SetStageOnProjectFromTaskInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _set_stage_on_project_from_task) ---
            */
            return default;
        }

        public async Task<TEntity> ShouldBeLockedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _should_be_locked) ---
            */
            return default;
        }

        public async Task<TEntity> ShouldCreatePickingRealTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _should_create_picking_real_time) ---
            */
            return default;
        }

        public async Task<TEntity> ShowAutopostBillsWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _show_autopost_bills_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ShowProfitabilityHelperInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _show_profitability_helper) ---
            */
            return default;
        }

        public async Task<TEntity> ShowProfitabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _show_profitability) ---
            */
            return default;
        }

        public async Task<TEntity> StageFindAsync<TEntity>(IEnumerable<TEntity> entities, Guid section_id, object domain, object order) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: stage_find) ---
            */
            return default;
        }

        public async Task<TEntity> StolenMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _stolen_move) ---
            */
            return default;
        }

        public async Task<TEntity> SyncDynamicLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object existing_key_fname, object needed_vals_fname, object needed_dirty_fname, object line_type, object container) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_dynamic_line) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SyncDynamicLineNeededValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values_list) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_dynamic_line_needed_values) ---
            */
            return default;
        }

        public async Task<TEntity> SyncDynamicLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_dynamic_lines) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SyncFromUiAsync<TEntity>(IEnumerable<TEntity> entities, object orders) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: sync_from_ui) ---
            */
            return default;
        }

        public async Task<TEntity> SyncInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> SyncNonDeductibleBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_non_deductible_base_lines) ---
            */
            return default;
        }

        public async Task<TEntity> SyncRoundingLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_rounding_lines) ---
            */
            return default;
        }

        public async Task<TEntity> SyncTaxLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_tax_lines) ---
            */
            return default;
        }

        public async Task<TEntity> SyncUnbalancedLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object container) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _sync_unbalanced_lines) ---
            */
            return default;
        }

        public async Task<TEntity> SynchronizeBusinessModelsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changed_fields) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _synchronize_business_models) ---
            */
            return default;
        }

        public async Task<TEntity> TASKPORTALREADABLEFIELDSAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: TASK_PORTAL_READABLE_FIELDS) ---
            */
            return default;
        }

        public async Task<TEntity> TASKPORTALWRITABLEFIELDSAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: TASK_PORTAL_WRITABLE_FIELDS) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> TaskMessageAutoSubscribeNotifyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object users_per_task) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _task_message_auto_subscribe_notify) ---
            */
            return default;
        }

        public async Task<TEntity> TemplateToProjectConfirmationCallbackAsync<TEntity>(IEnumerable<TEntity> entities, object callbacks) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: template_to_project_confirmation_callback) ---
            */
            return default;
        }

        public async Task<TEntity> ThreadToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, object fields) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _thread_to_store) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleFavoriteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: toggle_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleTemplateModeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object is_template) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _toggle_template_mode) ---
            */
            return default;
        }

        public async Task<TEntity> TrackFinalizeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _track_finalize) ---
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> TrackTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changes) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _track_template) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _track_template) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAccountAuditTrailExceptOncePostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _unlink_account_audit_trail_except_once_post) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptDraftOrCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _unlink_except_draft_or_cancel) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _unlink_except_draft_or_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkForbidPartsOfChainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _unlink_forbid_parts_of_chain) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkIfCancelledInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _unlink_if_cancelled) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkOrReverseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _unlink_or_reverse) ---
            */
            return default;
        }

        public async Task<TEntity> UnsubscribeInvoiceNotificationEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_to_remove) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _unsubscribe_invoice_notification_email) ---
            */
            return default;
        }

        public async Task<TEntity> UnsubscribePortalUsersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: _unsubscribe_portal_users) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateDateEndAsync<TEntity>(IEnumerable<TEntity> entities, Guid stage_id) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: update_date_end) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateDatePlannedForLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_dates) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _update_date_planned_for_lines) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateOrderLineInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid product_id, object quantity) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _update_order_line_info) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _update_order_line_info) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _update_order_line_info) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateSequenceNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object session, object values) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _update_sequence_number) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateUpdateDateActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_dates, object activity) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _update_update_date_activity) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _validate_order) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateTaxesCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: _validate_taxes_country) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_move.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_task.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: write) ---
            */
            return default;
        }

        public async Task<TEntity> _ComputeTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object count_field, object additional_domain) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: __compute_task_count) ---
            */
            return default;
        }

        public async Task<TEntity> _GetBankStatementsAvailableSourcesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IPortalMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: __get_bank_statements_available_sources) ---
            */
            return default;
        }
    }
}