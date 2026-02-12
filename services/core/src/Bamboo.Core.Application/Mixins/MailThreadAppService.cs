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
    [Module("mail", Category = "Productivity", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public partial class MailThreadAppService : ApplicationService, IMailThreadAppService
    {

        public MailThreadAppService() 
        {

        }

        public async Task<TEntity> AcceptChallengeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: accept_challenge) ---
            */
            return default;
        }

        public async Task<TEntity> AccessibleBranchesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _accessible_branches) ---
            */
            return default;
        }

        public async Task<TEntity> AccountPeppolSendWelcomeEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _account_peppol_send_welcome_email) ---
            */
            return default;
        }

        public async Task<TEntity> AccumulateAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _accumulate_amounts) ---
            */
            return default;
        }

        public async Task<TEntity> ActShowLogCostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: act_show_log_cost) ---
            */
            return default;
        }

        public async Task<TEntity> ActionAcceptDriverChangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: action_accept_driver_change) ---
            */
            return default;
        }

        public async Task<TEntity> ActionAcknowledgeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_acknowledge) ---
            */
            return default;
        }

        public async Task<TEntity> ActionAddAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_blacklist.py, METHOD: action_add) ---
            --- METHOD SOURCE (MODULE: phone_validation, FILE: phone_blacklist.py, METHOD: action_add) ---
            */
            return default;
        }

        public async Task<TEntity> ActionAddEntirePacksAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> package_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_add_entire_packs) ---
            */
            return default;
        }

        public async Task<TEntity> ActionAddFromCatalogAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_add_from_catalog) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_add_from_catalog) ---
            */
            return default;
        }

        public async Task<TEntity> ActionAllCompanyBranchesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: action_all_company_branches) ---
            */
            return default;
        }

        public async Task<TEntity> ActionApproveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: action_approve) ---
            */
            return default;
        }

        public async Task<TEntity> ActionApproveOvertimeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: action_approve_overtime) ---
            */
            return default;
        }

        public async Task<TEntity> ActionArchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: action_archive) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py, METHOD: action_archive) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: action_archive) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: action_archive) ---
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_archive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionArchiveBankAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_bank.py, METHOD: action_archive_bank) ---
            */
            return default;
        }

        public async Task<TEntity> ActionAssignAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_assign) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_assign) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_assign) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: action_assign) ---
            */
            return default;
        }

        public async Task<TEntity> ActionBatchDetailedOperationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: action_batch_detailed_operations) ---
            */
            return default;
        }

        public async Task<TEntity> ActionBillMatchingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_bill_matching) ---
            */
            return default;
        }

        public async Task<TEntity> ActionBudgetCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py, METHOD: action_budget_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> ActionBudgetConfirmAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py, METHOD: action_budget_confirm) ---
            */
            return default;
        }

        public async Task<TEntity> ActionBudgetDoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py, METHOD: action_budget_done) ---
            */
            return default;
        }

        public async Task<TEntity> ActionBudgetDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py, METHOD: action_budget_draft) ---
            */
            return default;
        }

        public async Task<TEntity> ActionBudgetValidateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_budget, FILE: account_budget.py, METHOD: action_budget_validate) ---
            */
            return default;
        }

        public async Task<TEntity> ActionBuyCreditsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: iap, FILE: iap_account.py, METHOD: action_buy_credits) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: action_cancel) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_cancel) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_cancel) ---
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: action_cancel) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_cancel) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_cancel) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: action_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _action_cancel) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _action_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCheckAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: action_check) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ActionCheckHashIntegrityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _action_check_hash_integrity) ---
            */
            return default;
        }

        public async Task<TEntity> ActionClearLotProducingIdsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_clear_lot_producing_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCloseAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py, METHOD: action_close) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCloseStockValuationAsync<TEntity>(IEnumerable<TEntity> entities, object at_date, object auto_post) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: action_close_stock_valuation) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCloseStockValuationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object at_date) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: _action_close_stock_valuation) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCompareVersionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_compare_versions) ---
            */
            return default;
        }

        public async Task<TEntity> ActionComputeBomDaysAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: action_compute_bom_days) ---
            */
            return default;
        }

        public async Task<TEntity> ActionConfigureBankJournalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: action_configure_bank_journal) ---
            */
            return default;
        }

        public async Task<TEntity> ActionConfirmAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: action_confirm) ---
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py, METHOD: action_confirm) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_confirm) ---
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: action_confirm) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_confirm) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_confirm) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: action_confirm) ---
            */
            return default;
        }

        public async Task<TEntity> ActionConfirmInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _action_confirm) ---
            */
            return default;
        }

        public async Task<TEntity> ActionConfirmMoBackordersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _action_confirm_mo_backorders) ---
            */
            return default;
        }

        public async Task<TEntity> ActionConfirmOrdersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py, METHOD: action_confirm_orders) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCouponSendAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: action_coupon_send) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attachment_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_create_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateInvoicesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_create_invoices) ---
            */
            return default;
        }

        public async Task<TEntity> ActionCreateSaleOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_create_sale_order) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDetailedOperationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_detailed_operations) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDislikeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: action_dislike) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: action_done) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: action_done) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _action_done) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py, METHOD: action_draft) ---
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: action_draft) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_draft) ---
            */
            return default;
        }

        public async Task<TEntity> ActionDuplicateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_duplicate) ---
            */
            return default;
        }

        public async Task<TEntity> ActionEmployeeFromDepartmentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: action_employee_from_department) ---
            */
            return default;
        }

        public async Task<TEntity> ActionEndSessionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_end_session) ---
            */
            return default;
        }

        public async Task<TEntity> ActionExpireAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py, METHOD: action_expire) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ActionFetchFavoritesAsync<TEntity>(IEnumerable<TEntity> entities, object extra_domain) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_fetch_favorites) ---
            */
            return default;
        }

        public async Task<TEntity> ActionGenerateBackorderWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities, object show_transfers) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _action_generate_backorder_wizard) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _action_generate_backorder_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionGenerateBomAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_generate_bom) ---
            */
            return default;
        }

        public async Task<TEntity> ActionGenerateConsumptionWizardInternalAsync<TEntity>(IEnumerable<TEntity> entities, object consumption_issues) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _action_generate_consumption_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionGenerateSerialAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_generate_serial) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_generate_serial) ---
            */
            return default;
        }

        public async Task<TEntity> ActionGetStockMoveLinesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: action_get_stock_move_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ActionGetStockPickingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: action_get_stock_picking) ---
            */
            return default;
        }

        public async Task<TEntity> ActionInAttendanceMapsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: action_in_attendance_maps) ---
            */
            return default;
        }

        public async Task<TEntity> ActionInvalidateCacheAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: action_invalidate_cache) ---
            */
            return default;
        }

        public async Task<TEntity> ActionJoinMeetingAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: action_join_meeting) ---
            */
            return default;
        }

        public async Task<TEntity> ActionJoinVideoCallAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: action_join_video_call) ---
            */
            return default;
        }

        public async Task<TEntity> ActionLaunchAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_launch) ---
            */
            return default;
        }

        public async Task<TEntity> ActionLikeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: action_like) ---
            */
            return default;
        }

        public async Task<TEntity> ActionLockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_lock) ---
            */
            return default;
        }

        public async Task<TEntity> ActionLotOpenQuantsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: action_lot_open_quants) ---
            */
            return default;
        }

        public async Task<TEntity> ActionLotOpenTransfersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: action_lot_open_transfers) ---
            */
            return default;
        }

        public async Task<TEntity> ActionLoyaltyUpdateBalanceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: action_loyalty_update_balance) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMarkCompletedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: action_mark_completed) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMarkCompletedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _action_mark_completed) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMarkUncompletedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: action_mark_uncompleted) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMassArchiveAsync<TEntity>(IEnumerable<TEntity> entities, object recurrence_update_setting) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: action_mass_archive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMassDeletionAsync<TEntity>(IEnumerable<TEntity> entities, object recurrence_update_setting) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: action_mass_deletion) ---
            */
            return default;
        }

        public async Task<TEntity> ActionMergeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_merge) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_merge) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: action_merge) ---
            */
            return default;
        }

        public async Task<TEntity> ActionModelVehicleAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py, METHOD: action_model_vehicle) ---
            */
            return default;
        }

        public async Task<TEntity> ActionNextTransferAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_next_transfer) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenAllocationWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner_bank.py, METHOD: action_open_allocation_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py, METHOD: action_open) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenAutomationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: ir_actions_server.py, METHOD: action_open_automation) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenBusinessDocAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_open_business_doc) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_open_business_doc) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenCalendarEventAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: action_open_calendar_event) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenComposerAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: action_open_composer) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenDiscountWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_open_discount_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenDocumentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: action_open_documents) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: action_open_documents) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenKioskModeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: res_company.py, METHOD: _action_open_kiosk_mode) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenLabelLayoutAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_open_label_layout) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: action_open_label_layout) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: action_open_label_layout) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_open_label_layout) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: action_open_label_layout) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenLabelTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_open_label_type) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_open_label_type) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenOdometerReportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: action_open_odometer_report) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenOperationFormAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: action_open_operation_form) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py, METHOD: action_open_operation_form) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenParentActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: action_open_parent_action) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenPricelistReportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: action_open_pricelist_report) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenRegistrationWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: iap_account.py, METHOD: action_open_registration_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenRelatedTaxesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: action_open_related_taxes) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenScheduledActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: action_open_scheduled_action) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenSenderNameWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: iap_account.py, METHOD: action_open_sender_name_wizard) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenSessionManagerAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_open_session_manager) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenSlotCalendarAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: action_open_slot_calendar) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenSmsTwilioAccountManageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sms_twilio, FILE: res_company.py, METHOD: _action_open_sms_twilio_account_manage) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenVersionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: action_open_version) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOpenViewChildDepartmentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: action_open_view_child_departments) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ActionOpenWebsiteThemeSelectorAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_company.py, METHOD: action_open_website_theme_selector) ---
            */
            return default;
        }

        public async Task<TEntity> ActionOutAttendanceMapsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: action_out_attendance_maps) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPickingMoveTreeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_picking_move_tree) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPlanFromDepartmentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: action_plan_from_department) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPlanWithComponentsAvailabilityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_plan_with_components_availability) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPosOrderCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_pos_order_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPosOrderInvoiceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_pos_order_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPosOrderPaidAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_pos_order_paid) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPosSessionCloseAsync<TEntity>(IEnumerable<TEntity> entities, object balancing_account, object amount_to_balance, object bank_payment_method_diffs) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: action_pos_session_close) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPosSessionClosingControlAsync<TEntity>(IEnumerable<TEntity> entities, object balancing_account, object amount_to_balance, object bank_payment_method_diffs) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: action_pos_session_closing_control) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPosSessionOpenAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: action_pos_session_open) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPosSessionValidateAsync<TEntity>(IEnumerable<TEntity> entities, object balancing_account, object amount_to_balance, object bank_payment_method_diffs) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: action_pos_session_validate) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPostConfirmInternalAsync<TEntity>(IEnumerable<TEntity> entities, object write_vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py, METHOD: _action_post_confirm) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPreviewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: action_preview) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPreviewSaleOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_preview_sale_order) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPrimaryChannelButtonAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: action_primary_channel_button) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPrintAnswersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: action_print_answers) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPrintAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: action_print) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPrintSurveyAsync<TEntity>(IEnumerable<TEntity> entities, object answer) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_print_survey) ---
            */
            return default;
        }

        public async Task<TEntity> ActionProductForecastReportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_product_forecast_report) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPurchaseComparisonAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_purchase_comparison) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPutInPackAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_put_in_pack) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: action_put_in_pack) ---
            */
            return default;
        }

        public async Task<TEntity> ActionPutInQueueAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_put_in_queue) ---
            */
            return default;
        }

        public async Task<TEntity> ActionQuotationSendAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_quotation_send) ---
            */
            return default;
        }

        public async Task<TEntity> ActionQuotationSentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_quotation_sent) ---
            */
            return default;
        }

        public async Task<TEntity> ActionReconcileStatAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py, METHOD: action_reconcile_stat) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRedirectToAttemptsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: action_redirect_to_attempts) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRefuseAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: action_refuse) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRefuseOvertimeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: action_refuse_overtime) ---
            */
            return default;
        }

        public async Task<TEntity> ActionReloadAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_reload) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRemoveFavoriteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_remove_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRepairCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_repair_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRepairCancelDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_repair_cancel_draft) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRepairConfirmInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _action_repair_confirm) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRepairDoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_repair_done) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRepairEndAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_repair_end) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRepairStartAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_repair_start) ---
            */
            return default;
        }

        public async Task<TEntity> ActionReportProgressAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: action_report_progress) ---
            */
            return default;
        }

        public async Task<TEntity> ActionResendAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: action_resend) ---
            */
            return default;
        }

        public async Task<TEntity> ActionResultSurveyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_result_survey) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRetryFailedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_retry_failed) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRfqSendAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_rfq_send) ---
            */
            return default;
        }

        public async Task<TEntity> ActionRotateWebhookUuidAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: action_rotate_webhook_uuid) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSaveOnboardingCompanyDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: action_save_onboarding_company_data) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSaveOnboardingSaleTaxAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: action_save_onboarding_sale_tax) ---
            */
            return default;
        }

        public async Task<TEntity> ActionScheduleAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_schedule) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSeeMoveScrapAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_see_move_scrap) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_see_move_scrap) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSeePackageHistoriesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_see_package_histories) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSeePackagesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_see_packages) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: action_see_packages) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSeeReturnsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_see_returns) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSelectAsWinnerAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_select_as_winner) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendBadgeEmailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: action_send_badge_email) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendEmailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: action_send_email) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendMailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_send_mail) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_send_mail) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> res_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _action_send_mail) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendOrdersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py, METHOD: action_send_orders) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendReceiptAsync<TEntity>(IEnumerable<TEntity> entities, object email, object ticket_image, object basic_image) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_send_receipt) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _action_send_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendSurveyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_send_survey) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendWinnerMailingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_send_winner_mailing) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSendmailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: action_sendmail) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetAutoReconcileAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py, METHOD: action_set_auto_reconcile) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetBomOnOrderpointAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: action_set_bom_on_orderpoint) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetDoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: action_set_done) ---
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: action_set_done) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: action_set_draft) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetFavoriteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_set_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetManualAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py, METHOD: action_set_manual) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetQuizDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities, object completed) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _action_set_quiz_done) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetViewedAsync<TEntity>(IEnumerable<TEntity> entities, object quiz_attempts_inc) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: action_set_viewed) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSetViewedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partner, object quiz_attempts_inc) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _action_set_viewed) ---
            */
            return default;
        }

        public async Task<TEntity> ActionShareAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: action_share) ---
            */
            return default;
        }

        public async Task<TEntity> ActionShareGetDefaultBodyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _action_share_get_default_body) ---
            */
            return default;
        }

        public async Task<TEntity> ActionShowOperationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: action_show_operations) ---
            */
            return default;
        }

        public async Task<TEntity> ActionShowPaymentsListAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: action_show_payments_list) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSplitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_split) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSplitTransferAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_split_transfer) ---
            */
            return default;
        }

        public async Task<TEntity> ActionStartAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: action_start) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_start) ---
            */
            return default;
        }

        public async Task<TEntity> ActionStartSessionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_start_session) ---
            */
            return default;
        }

        public async Task<TEntity> ActionStartSurveyAsync<TEntity>(IEnumerable<TEntity> entities, object answer) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_start_survey) ---
            */
            return default;
        }

        public async Task<TEntity> ActionStockPickingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_stock_picking) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: action_stock_picking) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSurveyPreviewCertificationTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_survey_preview_certification_template) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSurveyUserInputAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_survey_user_input) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSurveyUserInputCertifiedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_survey_user_input_certified) ---
            */
            return default;
        }

        public async Task<TEntity> ActionSurveyUserInputCompletedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_survey_user_input_completed) ---
            */
            return default;
        }

        public async Task<TEntity> ActionTalentPoolAddTalentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_talent_pool.py, METHOD: action_talent_pool_add_talents) ---
            */
            return default;
        }

        public async Task<TEntity> ActionTestAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_test) ---
            */
            return default;
        }

        public async Task<TEntity> ActionTestSurveyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_test_survey) ---
            */
            return default;
        }

        public async Task<TEntity> ActionToggleIsLockedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_toggle_is_locked) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_toggle_is_locked) ---
            */
            return default;
        }

        public async Task<TEntity> ActionTryKioskAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: action_try_kiosk) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnarchiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: action_unarchive) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py, METHOD: action_unarchive) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: action_unarchive) ---
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: action_unarchive) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnbuildAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: action_unbuild) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnfollowAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: action_unfollow) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnfollowInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object guest, object post_leave_message) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _action_unfollow) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnlinkEventAsync<TEntity>(IEnumerable<TEntity> entities, Guid attendee_id, object recurrence) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: action_unlink_event) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnlockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_unlock) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnmergeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: action_unmerge) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnmergeGetUserConfirmationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _action_unmerge_get_user_confirmation) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnmergeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _action_unmerge) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUnreserveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_unreserve) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUpdateBomAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_update_bom) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUpdatePricesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_update_prices) ---
            */
            return default;
        }

        public async Task<TEntity> ActionUpdateTaxesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_update_taxes) ---
            */
            return default;
        }

        public async Task<TEntity> ActionValidateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: action_validate) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_validate) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: action_validate) ---
            */
            return default;
        }

        public async Task<TEntity> ActionValidateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _action_validate) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewBouncedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_bounced) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewCardsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: action_view_cards) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewCardsClickedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: action_view_cards_clicked) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewCardsSharedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: action_view_cards_shared) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewClickedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_clicked) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewDeliveredAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_delivered) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewDocumentsFilteredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view_filter) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _action_view_documents_filtered) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewEmbedsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: action_view_embeds) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewInvoiceAsync<TEntity>(IEnumerable<TEntity> entities, object invoices) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_view_invoice) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: action_view_invoice) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: action_view_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewLinkTrackersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_link_trackers) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewMailingContactsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_mailing_contacts) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewMailingsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: action_view_mailings) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewMoDeliveryAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_view_mo_delivery) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewMrpProductionBackordersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_view_mrp_production_backorders) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewMrpProductionChildsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_view_mrp_production_childs) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewMrpProductionSourcesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_view_mrp_production_sources) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewMrpProductionUnbuildsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_view_mrp_production_unbuilds) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewOpenedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_opened) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: action_view_order) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewReceptionReportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_view_reception_report) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: action_view_reception_report) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: action_view_reception_report) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewRefundOrdersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_view_refund_orders) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewRefundedOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: action_view_refunded_order) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewRepliedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_replied) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewSaleOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: action_view_sale_order) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewSerialNumbersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: action_view_serial_numbers) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: action_view_tasks) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesCanceledAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_traces_canceled) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesFailedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_traces_failed) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesFilteredInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view_filter) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _action_view_traces_filtered) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesProcessAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_traces_process) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesScheduledAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_traces_scheduled) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewTracesSentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_traces_sent) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewUsersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: action_view_users) ---
            */
            return default;
        }

        public async Task<TEntity> ActionViewWebhookLogsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: action_view_webhook_logs) ---
            */
            return default;
        }

        public async Task<TEntity> ActionVoteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object upvote) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _action_vote) ---
            */
            return default;
        }

        public async Task<TEntity> ActionWorkOrderAlternativesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: action_work_order_alternatives) ---
            */
            return default;
        }

        public async Task<TEntity> ActionWorkOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: action_work_order) ---
            */
            return default;
        }

        public async Task<TEntity> ActivateOrCreatePricelistsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: res_company.py, METHOD: _activate_or_create_pricelists) ---
            */
            return default;
        }

        public async Task<TEntity> ActivityUpdateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: activity_update) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AdaptPriceUnitToAnotherTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price_unit, object product, object original_taxes, object new_taxes, object product_uom) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _adapt_price_unit_to_another_taxes) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AddAccountingDataInBaseLinesTaxDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company, object include_caba_tags) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _add_accounting_data_in_base_lines_tax_details) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AddAccountingDataToBaseLineTaxDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line, object company, object include_caba_tags) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _add_accounting_data_to_base_line_tax_details) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AddAndRoundRawGrossTotalExcludedAndDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company, object precision_digits, object apply_strict_tolerance, object in_foreign_currency, object account_discount_base_lines) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _add_and_round_raw_gross_total_excluded_and_discount) ---
            */
            return default;
        }

        public async Task<TEntity> AddAsync<TEntity>(IEnumerable<TEntity> entities, object number, object message) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: phone_blacklist.py, METHOD: add) ---
            */
            return default;
        }

        public async Task<TEntity> AddBaseLinesForEarlyPaymentDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _add_base_lines_for_early_payment_discount) ---
            */
            return default;
        }

        public async Task<TEntity> AddDaysToAllocationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object current_level, object current_level_maximum_leave, object leaves_taken, object period_start, object period_end) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _add_days_to_allocation) ---
            */
            return default;
        }

        public async Task<TEntity> AddFollowerAsync<TEntity>(IEnumerable<TEntity> entities, Guid employee_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: add_follower) ---
            */
            return default;
        }

        public async Task<TEntity> AddInternalAsync<TEntity>(IEnumerable<TEntity> entities, object numbers, object message) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_blacklist.py, METHOD: _add) ---
            --- METHOD SOURCE (MODULE: phone_validation, FILE: phone_blacklist.py, METHOD: _add) ---
            */
            return default;
        }

        public async Task<TEntity> AddLastcallsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _add_lastcalls) ---
            */
            return default;
        }

        public async Task<TEntity> AddMembersAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids, List<Guid> guest_ids, object invite_to_rtc_call, object post_joined_message) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: add_members) ---
            */
            return default;
        }

        public async Task<TEntity> AddMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _add_members) ---
            */
            return default;
        }

        public async Task<TEntity> AddMembersToFavoritesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _add_members_to_favorites) ---
            */
            return default;
        }

        public async Task<TEntity> AddPaymentAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: add_payment) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AddPostmortemInternalAsync<TEntity>(IEnumerable<TEntity> entities, object e) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _add_postmortem) ---
            */
            return default;
        }

        public async Task<TEntity> AddReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reference) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _add_reference) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _add_reference) ---
            */
            return default;
        }

        public async Task<TEntity> AddSupplierToProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _add_supplier_to_product) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AddTaxDetailsInBaseLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line, object company, object rounding_method) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _add_tax_details_in_base_line) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AddTaxDetailsInBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _add_tax_details_in_base_lines) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AggregateBaseLineTaxDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line, object grouping_function) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _aggregate_base_line_tax_details) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AggregateBaseLinesAggregatedValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines_aggregated_values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _aggregate_base_lines_aggregated_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AggregateBaseLinesTaxDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object grouping_function) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _aggregate_base_lines_tax_details) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AlertOldSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _alert_old_session) ---
            */
            return default;
        }

        public async Task<TEntity> AliasGetCreationValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _alias_get_creation_values) ---
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _alias_get_creation_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AliasPrepareAliasNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object alias_name, object name, object code, object jtype, object company) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _alias_prepare_alias_name) ---
            */
            return default;
        }

        public async Task<TEntity> AllBranchesSelectedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _all_branches_selected) ---
            */
            return default;
        }

        public async Task<TEntity> AllTagsAsync<TEntity>(IEnumerable<TEntity> entities, object @join, object min_limit) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: all_tags) ---
            */
            return default;
        }

        public async Task<TEntity> AllowInviteByEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _allow_invite_by_email) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> AllowPublishRatingStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: _allow_publish_rating_stats) ---
            */
            return default;
        }

        public async Task<TEntity> AmountAllInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _amount_all) ---
            */
            return default;
        }

        public async Task<TEntity> AmountConverterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount, object date, object round) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _amount_converter) ---
            */
            return default;
        }

        public async Task<TEntity> AmountResidualInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _amount_residual) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ApplyBaseLinesManualAmountsToReachInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company, object target_base_amount_currency, object target_base_amount, object target_tax_amounts_mapping) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _apply_base_lines_manual_amounts_to_reach) ---
            */
            return default;
        }

        public async Task<TEntity> ApplyDiffOnAccountPaymentMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object account_payment, object payment_method, object diff_amount) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _apply_diff_on_account_payment_move) ---
            */
            return default;
        }

        public async Task<TEntity> ApplyRecurrenceValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values, object future) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _apply_recurrence_values) ---
            */
            return default;
        }

        public async Task<TEntity> ApprovalAllowedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _approval_allowed) ---
            */
            return default;
        }

        public async Task<TEntity> AreFinishedSerialsAlreadyProducedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object lots, object excluded_sml) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _are_finished_serials_already_produced) ---
            */
            return default;
        }

        public async Task<TEntity> AreMovesAutoMergeableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object num_of_moves) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _are_moves_auto_mergeable) ---
            */
            return default;
        }

        public async Task<TEntity> ArePickingsAutoMergeableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object num_of_pickings) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _are_pickings_auto_mergeable) ---
            */
            return default;
        }

        public async Task<TEntity> AssertPhoneFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: mail_thread_phone.py, METHOD: _assert_phone_field) ---
            */
            return default;
        }

        public async Task<TEntity> AssertPrimaryEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_blacklist.py, METHOD: _assert_primary_email) ---
            */
            return default;
        }

        public async Task<TEntity> AssertTwilioSidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sms_twilio, FILE: res_company.py, METHOD: _assert_twilio_sid) ---
            */
            return default;
        }

        public async Task<TEntity> AttachSignInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _attach_sign) ---
            */
            return default;
        }

        public async Task<TEntity> AttendeesValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner_commands) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _attendees_values) ---
            */
            return default;
        }

        public async Task<TEntity> AutoProductionChecksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _auto_production_checks) ---
            */
            return default;
        }

        public async Task<TEntity> AutoconfirmPickingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _autoconfirm_picking) ---
            */
            return default;
        }

        public async Task<TEntity> AutoconfirmProductionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _autoconfirm_production) ---
            */
            return default;
        }

        public async Task<TEntity> AutoprintGeneratedLotInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid lot_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _autoprint_generated_lot) ---
            */
            return default;
        }

        public async Task<TEntity> AutoprintMassGeneratedLotsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _autoprint_mass_generated_lots) ---
            */
            return default;
        }

        public async Task<TEntity> AvailableOnDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py, METHOD: _available_on_date) ---
            */
            return default;
        }

        public async Task<TEntity> BaseDomainItemIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _base_domain_item_ids) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _base_domain_item_ids) ---
            */
            return default;
        }

        public async Task<TEntity> BatchForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object special_mode, object filter_tax_function) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _batch_for_taxes_computation) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> BomFindDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products, object picking_type, Guid company_id, object bom_type) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _bom_find_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> BomFindInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products, object picking_type, Guid company_id, object bom_type) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _bom_find) ---
            */
            return default;
        }

        public async Task<TEntity> BreakRecurrenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object future) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _break_recurrence) ---
            */
            return default;
        }

        public async Task<TEntity> BroadcastInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _broadcast) ---
            */
            return default;
        }

        public async Task<TEntity> BuildQrCodeBase64Async<TEntity>(IEnumerable<TEntity> entities, object amount, object free_communication, object structured_communication, object currency, object debtor_partner, object qr_method, object silent_errors) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: build_qr_code_base64) ---
            */
            return default;
        }

        public async Task<TEntity> BuildQrCodeUrlAsync<TEntity>(IEnumerable<TEntity> entities, object amount, object free_communication, object structured_communication, object currency, object debtor_partner, object qr_method, object silent_errors) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: build_qr_code_url) ---
            */
            return default;
        }

        public async Task<TEntity> BuildQrCodeValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount, object free_communication, object structured_communication, object currency, object debtor_partner, object qr_method, object silent_errors) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _build_qr_code_vals) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonApproveAsync<TEntity>(IEnumerable<TEntity> entities, object force) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: button_approve) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonCancelAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: button_cancel) ---
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py, METHOD: button_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonConfirmAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: button_confirm) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: button_draft) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonFetchInEinvoicesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: button_fetch_in_einvoices) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonLockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: button_lock) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonMarkDoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: button_mark_done) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonMarkDoneSanityChecksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _button_mark_done_sanity_checks) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonPlanAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: button_plan) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonRefreshOutEinvoicesStatusAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: button_refresh_out_einvoices_status) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonScrapAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: button_scrap) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: button_scrap) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonUnbuildAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: button_unbuild) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonUnlockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: button_unlock) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonUnplanAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: button_unplan) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonUnsubscribeFromInvoiceNotificationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: button_unsubscribe_from_invoice_notifications) ---
            */
            return default;
        }

        public async Task<TEntity> ButtonValidateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: button_validate) ---
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py, METHOD: button_validate) ---
            */
            return default;
        }

        public async Task<TEntity> CacheInvalidationFieldsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: cache_invalidation_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CalPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object consumed_moves) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _cal_price) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CalculateDateCategoryAsync<TEntity>(IEnumerable<TEntity> entities, object datetime) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: calculate_date_category) ---
            */
            return default;
        }

        public async Task<TEntity> CanBeDiscountedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _can_be_discounted) ---
            */
            return default;
        }

        public async Task<TEntity> CanBeEditedOnPortalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _can_be_edited_on_portal) ---
            */
            return default;
        }

        public async Task<TEntity> CanExecuteActionOnRecordsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _can_execute_action_on_records) ---
            */
            return default;
        }

        public async Task<TEntity> CanGoBackInternalAsync<TEntity>(IEnumerable<TEntity> entities, object answer, object page_or_question) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _can_go_back) ---
            */
            return default;
        }

        public async Task<TEntity> CanGrantBadgeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_badge.py, METHOD: _can_grant_badge) ---
            */
            return default;
        }

        public async Task<TEntity> CanProduceSerialNumbersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sns) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _can_produce_serial_numbers) ---
            */
            return default;
        }

        public async Task<TEntity> CanReturnContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object access_token) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _can_return_content) ---
            */
            return default;
        }

        public async Task<TEntity> CanReturnInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _can_return) ---
            */
            return default;
        }

        public async Task<TEntity> CancelFutureDaysInternalAsync<TEntity>(IEnumerable<TEntity> entities, object weekdays) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py, METHOD: _cancel_future_days) ---
            */
            return default;
        }

        public async Task<TEntity> CannotCloseSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bank_payment_method_diffs) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _cannot_close_session) ---
            */
            return default;
        }

        public async Task<TEntity> CartesianProductInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_template_attribute_values_per_line, object parent_combination) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _cartesian_product) ---
            */
            return default;
        }

        public async Task<TEntity> ChangeAttendeeStatusAsync<TEntity>(IEnumerable<TEntity> entities, object status, object recurrence_update_setting) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: change_attendee_status) ---
            */
            return default;
        }

        public async Task<TEntity> ChangeProducingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _change_producing) ---
            */
            return default;
        }

        public async Task<TEntity> ChannelChangeDescriptionAsync<TEntity>(IEnumerable<TEntity> entities, object description) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: channel_change_description) ---
            */
            return default;
        }

        public async Task<TEntity> ChannelFetchedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: channel_fetched) ---
            */
            return default;
        }

        public async Task<TEntity> ChannelJoinAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: channel_join) ---
            */
            return default;
        }

        public async Task<TEntity> ChannelPinAsync<TEntity>(IEnumerable<TEntity> entities, object pinned) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: channel_pin) ---
            */
            return default;
        }

        public async Task<TEntity> ChannelRenameAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: channel_rename) ---
            */
            return default;
        }

        public async Task<TEntity> ChannelSetCustomNameAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: channel_set_custom_name) ---
            */
            return default;
        }

        public async Task<TEntity> ChartTemplateSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _chart_template_selection) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAccessRightDynamicTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _check_access_right_dynamic_template) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAccountCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _check_account_code) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAccountIsBankJournalBankAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _check_account_is_bank_journal_bank_account) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAccountPeppolPhoneNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _check_account_peppol_phone_number) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAccountTypeSalesPurchaseJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _check_account_type_sales_purchase_journal) ---
            */
            return default;
        }

        public async Task<TEntity> CheckActionServerModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _check_action_server_model) ---
            */
            return default;
        }

        public async Task<TEntity> CheckActionUnmergePossibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _check_action_unmerge_possible) ---
            */
            return default;
        }

        public async Task<TEntity> CheckActiveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_company.py, METHOD: _check_active) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _check_active) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAllowOutPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _check_allow_out_payment) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAlternativeWorkcenterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _check_alternative_workcenter) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAnswerCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user, object partner, object email, object test_entry, object check_attempts, object invite_token) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _check_answer_creation) ---
            */
            return default;
        }

        public async Task<TEntity> CheckApprovalUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object state, object raise_if_not_possible) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _check_approval_update) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAuditTrailRestrictionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _check_audit_trail_restriction) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAutoPostDraftEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _check_auto_post_draft_entries) ---
            */
            return default;
        }

        public async Task<TEntity> CheckAvailableQtyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: check_available_qty) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBackorderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _check_backorder) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBankAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _check_bank_account) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBarcodeUniquenessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _check_barcode_uniqueness) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _check_barcode_uniqueness) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBomCycleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _check_bom_cycle) ---
            */
            return default;
        }

        public async Task<TEntity> CheckBomLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _check_bom_lines) ---
            */
            return default;
        }

        public async Task<TEntity> CheckByproductsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _check_byproducts) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCalendarPrivacyWritePermissionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _check_calendar_privacy_write_permissions) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCanUpdateMessageContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object messages) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _check_can_update_message_content) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _check_can_update_message_content) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCanValidateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py, METHOD: _check_can_validate) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCategoryRecursionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_category.py, METHOD: _check_category_recursion) ---
            */
            return default;
        }

        public async Task<TEntity> CheckChallengeRewardInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: _check_challenge_reward) ---
            */
            return default;
        }

        public async Task<TEntity> CheckChildrenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _check_children) ---
            */
            return default;
        }

        public async Task<TEntity> CheckChildrenScopeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _check_children_scope) ---
            */
            return default;
        }

        public async Task<TEntity> CheckClosingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _check_closing_date) ---
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _check_closing_date) ---
            */
            return default;
        }

        public async Task<TEntity> CheckComboIdsNotEmptyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _check_combo_ids_not_empty) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCompanyConsistencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _check_company_consistency) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _check_company_consistency) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _check_company_consistency) ---
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_account.py, METHOD: _check_company_consistency) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _check_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckContractFinishedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: check_contract_finished) ---
            */
            return default;
        }

        public async Task<TEntity> CheckCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _check_create) ---
            */
            return default;
        }

        public async Task<TEntity> CheckDateFromDateToInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _check_date_from_date_to) ---
            */
            return default;
        }

        public async Task<TEntity> CheckDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _check_dates) ---
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: _check_dates) ---
            */
            return default;
        }

        public async Task<TEntity> CheckDuplicatedPackagingBarcodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object barcodes_within_company, Guid company_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _check_duplicated_packaging_barcodes) ---
            */
            return default;
        }

        public async Task<TEntity> CheckDuplicatedProductBarcodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object barcodes_within_company, Guid company_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _check_duplicated_product_barcodes) ---
            */
            return default;
        }

        public async Task<TEntity> CheckEntirePackInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _check_entire_pack) ---
            */
            return default;
        }

        public async Task<TEntity> CheckEventSlotInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _check_event_slot) ---
            */
            return default;
        }

        public async Task<TEntity> CheckEventTicketInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _check_event_ticket) ---
            */
            return default;
        }

        public async Task<TEntity> CheckEventUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _check_event_url) ---
            */
            return default;
        }

        public async Task<TEntity> CheckFiscalyearLastDayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _check_fiscalyear_last_day) ---
            */
            return default;
        }

        public async Task<TEntity> CheckForPublicationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _check_for_publication) ---
            */
            return default;
        }

        public async Task<TEntity> CheckForQrCodeErrorsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object qr_method, object amount, object currency, object debtor_partner, object free_communication, object structured_communication) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _check_for_qr_code_errors) ---
            */
            return default;
        }

        public async Task<TEntity> CheckGrantingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_badge.py, METHOD: check_granting) ---
            */
            return default;
        }

        public async Task<TEntity> CheckHashIntegrityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _check_hash_integrity) ---
            */
            return default;
        }

        public async Task<TEntity> CheckHrPresenceControlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object at_install) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: res_company.py, METHOD: _check_hr_presence_control) ---
            */
            return default;
        }

        public async Task<TEntity> CheckIbanAsync<TEntity>(IEnumerable<TEntity> entities, object iban) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_iban, FILE: res_partner_bank.py, METHOD: check_iban) ---
            */
            return default;
        }

        public async Task<TEntity> CheckIbanInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_iban, FILE: res_partner_bank.py, METHOD: _check_iban) ---
            */
            return default;
        }

        public async Task<TEntity> CheckIfNoDraftOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _check_if_no_draft_orders) ---
            */
            return default;
        }

        public async Task<TEntity> CheckIncomingEinvoiceNotificationEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _check_incoming_einvoice_notification_email) ---
            */
            return default;
        }

        public async Task<TEntity> CheckInternalAsync<TEntity>(IEnumerable<TEntity> entities, object automatic, object use_new_cursor) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _check) ---
            */
            return default;
        }

        public async Task<TEntity> CheckInternalProjectIdCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: res_company.py, METHOD: _check_internal_project_id_company) ---
            */
            return default;
        }

        public async Task<TEntity> CheckInvoicesArePostedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _check_invoices_are_posted) ---
            */
            return default;
        }

        public async Task<TEntity> CheckJournalConsistencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _check_journal_consistency) ---
            */
            return default;
        }

        public async Task<TEntity> CheckJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _check_journal_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckKitHasNotOrderpointAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: check_kit_has_not_orderpoint) ---
            */
            return default;
        }

        public async Task<TEntity> CheckLotProducingIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _check_lot_producing_ids) ---
            */
            return default;
        }

        public async Task<TEntity> CheckMailingFilterModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _check_mailing_filter_model) ---
            */
            return default;
        }

        public async Task<TEntity> CheckMatchLabelParamInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py, METHOD: _check_match_label_param) ---
            */
            return default;
        }

        public async Task<TEntity> CheckMoveLinesMapQuantPackageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object package) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _check_move_lines_map_quant_package) ---
            */
            return default;
        }

        public async Task<TEntity> CheckNoCyclicDependenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py, METHOD: _check_no_cyclic_dependencies) ---
            */
            return default;
        }

        public async Task<TEntity> CheckOrderLineCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _check_order_line_company_id) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _check_order_line_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckOrganizerValidationConditionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _check_organizer_validation_conditions) ---
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: _check_parent_id) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _check_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPaymentMethodLineIdsMultiplicityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _check_payment_method_line_ids_multiplicity) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPeppolEndpointInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _check_peppol_endpoint) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPeppolEndpointNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object warning) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _check_peppol_endpoint_number) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPeppolPurchaseJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _check_peppol_purchase_journal_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckPhonenumbersImportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _check_phonenumbers_import) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPosConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _check_pos_config) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPrepaymentPercentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _check_prepayment_percent) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPrivateEventConditionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _check_private_event_conditions) ---
            */
            return default;
        }

        public async Task<TEntity> CheckProductLimitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _check_product_limit) ---
            */
            return default;
        }

        public async Task<TEntity> CheckProrataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _check_prorata) ---
            */
            return default;
        }

        public async Task<TEntity> CheckPythonCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _check_python_code) ---
            */
            return default;
        }

        public async Task<TEntity> CheckReconcileInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _check_reconcile) ---
            */
            return default;
        }

        public async Task<TEntity> CheckRepartitionLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object lines) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _check_repartition_lines) ---
            */
            return default;
        }

        public async Task<TEntity> CheckRootDelegatedFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _check_root_delegated_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSaleComboIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _check_sale_combo_ids) ---
            */
            return default;
        }

        public async Task<TEntity> CheckScoringAfterPageAvailabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _check_scoring_after_page_availability) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSeatsAvailabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _check_seats_availability) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSetAccountPriceIncludeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _check_set_account_price_include) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSlotsDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _check_slots_dates) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSnUniquenessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _check_sn_uniqueness) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSsnidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _check_ssnid) ---
            */
            return default;
        }

        public async Task<TEntity> CheckStartDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _check_start_date) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSumInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py, METHOD: _check_sum) ---
            */
            return default;
        }

        public async Task<TEntity> CheckSurveyResponsibleAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _check_survey_responsible_access) ---
            */
            return default;
        }

        public async Task<TEntity> CheckTaxReturnConfigurationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _check_tax_return_configuration) ---
            */
            return default;
        }

        public async Task<TEntity> CheckTimeTriggerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _check_time_trigger) ---
            */
            return default;
        }

        public async Task<TEntity> CheckTriggerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _check_trigger_fields) ---
            */
            return default;
        }

        public async Task<TEntity> CheckTriggerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _check_trigger) ---
            */
            return default;
        }

        public async Task<TEntity> CheckTriggerStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _check_trigger_state) ---
            */
            return default;
        }

        public async Task<TEntity> CheckTypeDefaultAccountIdTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _check_type_default_account_id_type) ---
            */
            return default;
        }

        public async Task<TEntity> CheckUniqueLotInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _check_unique_lot) ---
            */
            return default;
        }

        public async Task<TEntity> CheckUsedAsJournalDefaultDebitCreditAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _check_used_as_journal_default_debit_credit_account) ---
            */
            return default;
        }

        public async Task<TEntity> CheckValidBatchSizeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _check_valid_batch_size) ---
            */
            return default;
        }

        public async Task<TEntity> CheckValidityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: check_validity) ---
            */
            return default;
        }

        public async Task<TEntity> CheckValidityCheckInCheckOutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _check_validity_check_in_check_out) ---
            */
            return default;
        }

        public async Task<TEntity> CheckValidityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _check_validity) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CheckValuesToSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _check_values_to_sync) ---
            */
            return default;
        }

        public async Task<TEntity> CleanEmptyMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _clean_empty_message) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _clean_empty_message) ---
            */
            return default;
        }

        public async Task<TEntity> CleanPaymentLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _clean_payment_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ClearInactiveConditionalAnswersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _clear_inactive_conditional_answers) ---
            */
            return default;
        }

        public async Task<TEntity> ClearVideocallLocationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: clear_videocall_location) ---
            */
            return default;
        }

        public async Task<TEntity> CloseAsync<TEntity>(IEnumerable<TEntity> entities, Guid reason_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: close) ---
            */
            return default;
        }

        public async Task<TEntity> CloseSessionActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount_to_balance) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _close_session_action) ---
            */
            return default;
        }

        public async Task<TEntity> CloseSessionFromUiAsync<TEntity>(IEnumerable<TEntity> entities, object bank_payment_method_diff_pairs) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: close_session_from_ui) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CompleteInverseExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object exclusions) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _complete_inverse_exclusions) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CompleteValuesFromSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object session, object values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _complete_values_from_session) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAbTestingDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_ab_testing_description) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAbTestingIsWinnerMailingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_ab_testing_is_winner_mailing) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_bank.py, METHOD: _compute_acc_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccessUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_access_url) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_access_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccountEnabledTaxCountryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_account_enabled_tax_country_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccountFiscalCountryGroupCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_account_fiscal_country_group_codes) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccountGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_account_group) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccountHolderNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_bank.py, METHOD: _compute_account_holder_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccountPeppolContactEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _compute_account_peppol_contact_email) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccountPeppolEdiUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _compute_account_peppol_edi_user) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccountPeppolPhoneNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _compute_account_peppol_phone_number) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccountRootInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_account_root) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccountStornoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_account_storno) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccountTagsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_account_tags) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccountTaxFiscalCountryAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: compute_account_tax_fiscal_country) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccountTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_account_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccountingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_accounting_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAccrualPlanIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_accrual_plan_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeActionServerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_action_server_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeActivityInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _compute_activity_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeActivityUserInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _compute_activity_user_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAddressInlineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_address_inline) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_address) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAddressSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_address_search) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllAsync<TEntity>(IEnumerable<TEntity> entities, object price_unit, object currency, object quantity, object product, object partner, object is_refund, object handle_price_include, object include_caba_tags, object rounding_method) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: compute_all) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllProductTagIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_all_product_tag_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllowedCountryStateIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_allowed_country_state_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllowedLotIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_allowed_lot_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllowedPickingIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _compute_allowed_picking_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllowedStatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_allowed_states) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllowedSurveyTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_allowed_survey_types) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllowedUomIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_allowed_uom_ids) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_allowed_uom_ids) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: _compute_allowed_uom_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAllowedUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_job.py, METHOD: _compute_allowed_user_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_amount_invoiced) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountPaidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_amount_paid) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_amount_paid) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountToInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_amount_to_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountTotalCcInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_amount_total_cc) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountUndiscountedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_amount_undiscounted) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_amounts) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAnswerDurationAvgInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_answer_duration_avg) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAttemptsInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _compute_attempts_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAttendanceKioskUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: res_company.py, METHOD: _compute_attendance_kiosk_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAttendeesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_attendees_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAuthorizedTransactionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_authorized_transaction_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailabilityBooleanInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_availability_boolean) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailableInvoiceTemplatePdfReportIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_available_invoice_template_pdf_report_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailableModelIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _compute_available_model_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailablePaymentMethodIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_available_payment_method_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvailableTodayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py, METHOD: _compute_available_today) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar128InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_avatar_128) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatarCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_avatar_cache_key) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBackgroundImageUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_background_image_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBlacklistedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: mail_thread_phone.py, METHOD: _compute_blacklisted) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBlockedTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_blocked_time) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBlogPostCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_blog_post_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBoardAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object sequence, object residual_amount, object amount_to_depr, object undone_dotation_number, List<Guid> posted_depreciation_line_ids, object total_days, object depreciation_date) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _compute_board_amount) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBoardUndoneDotationNbInternalAsync<TEntity>(IEnumerable<TEntity> entities, object depreciation_date, object total_days) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _compute_board_undone_dotation_nb) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_bom_id) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: _compute_bom_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBounceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_company.py, METHOD: _compute_bounce) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeBulkWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_bulk_weight) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeButtonsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py, METHOD: _compute_buttons) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCalendarDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_calendar_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanApproveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_can_approve) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanBeMarkedAsDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: _compute_can_be_marked_as_done) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanBeProposedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py, METHOD: _compute_can_be_proposed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanImage1024BeZoomedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_can_image_1024_be_zoomed) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_can_image_1024_be_zoomed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanImageVariant1024BeZoomedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_can_image_variant_1024_be_zoomed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanModerateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_can_moderate) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanPublishInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_can_publish) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanRefuseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_can_refuse) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCanValidateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_can_validate) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCardStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _compute_card_stats) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCashBalanceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _compute_cash_balance) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCashControlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _compute_cash_control) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCashJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _compute_cash_journal) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCatchallInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_company.py, METHOD: _compute_catchall) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryCompletedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_category_completed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryCompletionTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_category_completion_time) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_category_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_category) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCertificationGiveBadgeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_certification_give_badge) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCertificationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_certification) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeChannelNameMemberIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_channel_name_member_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeChannelPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_channel_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeChildCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_child_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeClicksRatioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_clicks_ratio) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCo2EmissionUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_co2_emission_unit) ---
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py, METHOD: _compute_co2_emission_unit) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCo2InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_co2) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCo2StandardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_co2_standard) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_code) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_color) ---
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _compute_color) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCombinationIndicesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_combination_indices) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCommentsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_comments_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_company_currency_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyFiscalCountryCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_company_fiscal_country_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_company_id) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _compute_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _compute_company_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_company_registry_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyVatPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_company_vat_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: _compute_complete_name) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_category.py, METHOD: _compute_complete_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeComponentsAvailabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_components_availability) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContactDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_contact_details) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContactEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py, METHOD: _compute_contact_email) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_contact_email) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContactNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py, METHOD: _compute_contact_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContactPhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py, METHOD: _compute_contact_phone) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_contact_phone) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContractNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py, METHOD: _compute_contract_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContractReminderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_contract_reminder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeContractWageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_contract_wage) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCostCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_cost_currency_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py, METHOD: _compute_cost) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCountAllInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_count_all) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCountFlaggedPostsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_count_flagged_posts) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCountPostsWaitingValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_count_posts_waiting_validation) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCountryFlagUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_country_flag_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCountryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_country_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCountryProxyKeysInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py, METHOD: _compute_country_proxy_keys) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCrudRelationsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_crud_relations) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCtaTimeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_cta_time_data) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_currency_id) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_currency_id) ---
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: _compute_currency_id) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyRateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_currency_rate) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_currency_rate) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_currency_rate) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrentAttendeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_current_attendee) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrentBalanceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_current_balance) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDashboardButtonNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _compute_dashboard_button_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateCalendarStartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_date_calendar_start) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateClosedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _compute_date_closed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateDeadlineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_date_deadline) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_date_deadline) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_date_finished) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _compute_date) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDatePlannedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_date_planned) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateRangeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _compute_date_range) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDateTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_date_tz) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_dates) ---
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_dates) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDaysLeftInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py, METHOD: _compute_days_left) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDebitCreditBalanceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_account.py, METHOD: _compute_debit_credit_balance) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDefaultAccountTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_default_account_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_default_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDelayAlertDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_delay_alert_date) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_delay_alert_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDeliveryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _compute_delivery_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDepartmentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_department_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDepreciationBoardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: compute_depreciation_board) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_description) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDescriptionValidityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_description_validity) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayAccountStornoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_display_account_storno) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayAccountWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _compute_display_account_warning) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayAliasFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_display_alias_fields) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayAlternativeTaxesFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_display_alternative_taxes_field) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayCompleteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _compute_display_complete) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_display_description) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_account.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_category.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_display_name) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayQrSettingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py, METHOD: _compute_display_qr_setting) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_display_time) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDomesticFiscalPositionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_domestic_fiscal_position_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDoorsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_doors) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDuplicateBankPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _compute_duplicate_bank_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDuplicatedOrderIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_duplicated_order_ids) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_duplicated_order_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDurationDisplayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_duration_display) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDurationExpectedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_duration_expected) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDurationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_duration) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_duration) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeDurationTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_tracking_duration_mixin.py, METHOD: _compute_duration_tracking) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEffectivePrivacyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_effective_privacy) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeElectricAssistanceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_electric_assistance) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailFormattedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_company.py, METHOD: _compute_email_formatted) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailFromInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_email_from) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _compute_email) ---
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_email) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailNormalizedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_blacklist.py, METHOD: _compute_email_normalized) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmbedCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_embed_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmbedCountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_embed_counts) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner_bank.py, METHOD: _compute_employee_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_job.py, METHOD: _compute_employees) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEmptyCompanyDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_empty_company_details) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEndDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_end_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date, object group_entries) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _compute_entries) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEquipmentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _compute_equipment) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEstimatedShippingCapacityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _compute_estimated_shipping_capacity) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventBeginDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _compute_event_begin_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventEndDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _compute_event_end_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventMailIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_mail_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_registrations_open) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsSoldOutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_registrations_sold_out) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventRegistrationsStartedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_registrations_started) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventShareUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_share_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventSlotCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_slot_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventTicketIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_ticket_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeEventUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_event_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeExpectedDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_expected_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeExpectedHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _compute_expected_hours) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFavoriteCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_favorite_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFavoriteDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_favorite_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFeedCacheInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _compute_feed_cache) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFieldIsOneDayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_field_is_one_day) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_field_is_one_day) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFieldValueInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_field_value) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _compute_field_value) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_field_value) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFilterDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_filter_domain) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFilterPreDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_filter_pre_domain) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFiscalPositionIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_fiscal_position_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFiscalyearDatesAsync<TEntity>(IEnumerable<TEntity> entities, object current_date) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: compute_fiscalyear_dates) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFollowersInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _compute_followers_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFollowersTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _compute_followers_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeForceRestrictiveAuditTrailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_force_restrictive_audit_trail) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeForecastedIssueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_forecasted_issue) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeForumStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_forum_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeFuelTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_fuel_type) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ComputeGeneratedEntriesAsync<TEntity>(IEnumerable<TEntity> entities, object date, object asset_type) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: compute_generated_entries) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeGoogleDriveIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_google_drive_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeGroupPublicIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_group_public_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasActivePricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_has_active_pricelist) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasArchivedProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_has_archived_products) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasConditionalQuestionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_has_conditional_questions) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasConfigurableAttributesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_has_configurable_attributes) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasDeadlineIssueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_has_deadline_issue) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasInvalidStatementsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_has_invalid_statements) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _compute_has_message) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasNegativeFactorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_has_negative_factor) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasOpenContractInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py, METHOD: _compute_has_open_contract) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasPendingPostInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_has_pending_post) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasRefundableLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_has_refundable_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasRoutingLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_has_routing_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_has_tracking) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasUncompleteMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_has_uncomplete_moves) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHasValidatedAnswerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_has_validated_answer) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHolidayStatusIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_holiday_status_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHorsepowerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_horsepower) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeHorsepowerTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_horsepower_tax) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeImage1024InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_image_1024) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeImage128InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_image_128) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeImage1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_image_1920) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_image_1920) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeImage256InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_image_256) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeImage512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_image_512) ---
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_image_512) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeImagePreviewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _compute_image_preview) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInboundPaymentMethodLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_inbound_payment_method_line_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIncludeInitialBalanceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_include_initial_balance) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIncomingEinvoiceNotificationEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_incoming_einvoice_notification_email) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInternalGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_internal_group) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvalidEmailPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_invalid_email_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvitationUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_invitation_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvitedMemberIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_invited_member_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceRepartitionLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_invoice_repartition_line_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_invoice_status) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_invoice_status) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoiceTermsHtmlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_invoice_terms_html) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsAbTestSentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_is_ab_test_sent) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsAttemptsLimitedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_is_attempts_limited) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py, METHOD: _compute_is_available) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsBlacklistedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_blacklist.py, METHOD: _compute_is_blacklisted) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsBodyEmptyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_is_body_empty) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsCurrentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_is_current) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsCustomJobTitleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_is_custom_job_title) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsDateEditableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_is_date_editable) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsDeadlineExceededInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: _compute_is_deadline_exceeded) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsDeadlineFutureInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: _compute_is_deadline_future) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsDelayedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_is_delayed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsDomesticInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_is_domestic) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsDynamicallyCreatedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_is_dynamically_created) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsEditableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_is_editable) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsEditedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_is_edited) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsExpiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_is_expired) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _compute_is_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_is_finished) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFlexibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_is_flexible) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsFutureInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_is_future) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsHighlightedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_is_highlighted) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsInCompanyCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _compute_is_in_company_currency) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsInContractInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_is_in_contract) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsInOpeningHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_is_in_opening_hours) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_is_invoiced) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsManagerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _compute_is_manager) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_is_member) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMembershipMultiInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _compute_is_membership_multi) ---
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team_member.py, METHOD: _compute_is_membership_multi) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsNewSlideInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_is_new_slide) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsOfficerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_is_officer) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsOngoingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_is_ongoing) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsOrganizerAloneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_is_organizer_alone) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPastInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_is_past) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPlannedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_is_planned) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_is_product_variant) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_is_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsReminderOnInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_is_reminder_on) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsSignedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_is_signed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsTotalCostComputedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_is_total_cost_computed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeIsUsedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_is_used) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeJobTitleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_job_title) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_journal_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeJsonPopoverInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_json_popover) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_json_popover) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeKanbanDashboardGraphInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_kanban_dashboard_graph) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeKanbanStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_kanban_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeKanbanStateLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_kanban_state_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeKmHomeWorkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_km_home_work) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLandedCostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py, METHOD: compute_landed_cost) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLangIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _compute_lang_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLastPostIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_last_post_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLeavesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_leaves) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLikeInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_like_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLinkTrackersCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_link_trackers_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLinkedOvertimeIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _compute_linked_overtime_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLocationIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: _compute_location_id) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_location_id) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_location_id) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: _compute_location_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLocationsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_locations) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLockTrustFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _compute_lock_trust_fields) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLogoWebInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_logo_web) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeLotIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: compute_lot_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailPostAutofollowInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _compute_mail_post_autofollow) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailPostMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _compute_mail_post_method) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailServerAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mail_server_available) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _compute_mailing_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mailing_domain) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingFilterCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mailing_filter_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingFilterIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mailing_filter_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingModelRealInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mailing_model_real) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingOnMailingListInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mailing_on_mailing_list) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMailingTypeDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_mailing_type_description) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeManagerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_manager_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMarginInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_margin) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMarkCompleteActionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_mark_complete_actions) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMasterDepartmentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: _compute_master_department_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMediumIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_medium_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMemberCompanyIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _compute_member_company_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMemberCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_member_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMemberIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _compute_member_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMemberWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _compute_member_warning) ---
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team_member.py, METHOD: _compute_member_warning) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMessageAttachmentCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _compute_message_attachment_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMessageCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_message_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMessageHasErrorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _compute_message_has_error) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMessageHasSmsErrorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: mail_thread.py, METHOD: _compute_message_has_sms_error) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMessageIsFollowerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _compute_message_is_follower) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMessageNeedactionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _compute_message_needaction) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMessagePartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _compute_message_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeModelYearInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_model_year) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMoneyTransferServiceNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _compute_money_transfer_service_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMoveByproductIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_move_byproduct_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMoveFinishedIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_move_finished_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMoveIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _compute_move_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMoveLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _compute_move_line_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMoveRawIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_move_raw_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMoveTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_move_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMrpProductionBackorderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_mrp_production_backorder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMrpProductionChildCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_mrp_production_child_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMrpProductionSourceCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_mrp_production_source_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeMultiVatForeignCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_multi_vat_foreign_country) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _compute_name) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _compute_name) ---
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNamePlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_name_placeholder) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNextDepartureInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_next_departure) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNextYearDateAsync<TEntity>(IEnumerable<TEntity> entities, object strdate) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py, METHOD: compute_next_year_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNoteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_note) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_note) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNumberOfDaysDisplayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_number_of_days_display) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNumberOfDaysInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_number_of_days) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeNumberOfHoursDisplayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_number_of_hours_display) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_oee) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOnChangeFieldIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_on_change_field_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOpeningDebitCreditInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_opening_debit_credit) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOperationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _compute_operation_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOrderConfigIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_order_config_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOrderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _compute_order_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOrderDeadlinePassedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py, METHOD: _compute_order_deadline_passed) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOrderNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object session) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_order_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOrdersNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: _compute_orders_number) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOutboundPaymentMethodLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_outbound_payment_method_line_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOvertimeHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _compute_overtime_hours) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeOvertimeStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _compute_overtime_status) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePackagesCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_packages_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePageAndQuestionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_page_and_question_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeParentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_parent_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartOfDepartmentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_part_of_department) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerBiographyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_biography) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerCompanyNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_company_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerCreditWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_partner_credit_warning) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_email) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerFunctionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_function) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _compute_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerImageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_image) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerInvoiceIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_partner_invoice_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerMappingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py, METHOD: _compute_partner_mapping) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_phone) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerRefInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_partner_ref) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerShippingIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_partner_shipping_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerTagLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_partner_tag_line) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePartsAvailabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_parts_availability) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_payment_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePaymentTermIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_payment_term_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePeppolCanSendInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _compute_peppol_can_send) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePeppolParentCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _compute_peppol_parent_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePeppolPurchaseJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _compute_peppol_purchase_journal_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePeppolSelfBillingReceptionJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _compute_peppol_self_billing_reception_journal_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePerformanceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_performance) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _compute_phone) ---
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_phone) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePhoneSanitizedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: mail_thread_phone.py, METHOD: _compute_phone_sanitized) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePickingCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_picking_count) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _compute_picking_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePickingIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_picking_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePickingProductIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_picking_product_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePickingTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_picking_type_id) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_picking_type_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePickingTypeVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_picking_type_visible) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePickingWarningTextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_picking_warning_text) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePlaceholderCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_placeholder_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePlainContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_plain_content) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePlanCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: _compute_plan_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePointsDisplayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _compute_points_display) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePossibleProductTemplateAttributeValueIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _compute_possible_product_template_attribute_value_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePostDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_post_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePostKarmaRightsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_post_karma_rights) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePostsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_tag.py, METHOD: _compute_posts_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePowerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_power) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePreferredPaymentMethodLineIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_preferred_payment_method_line_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePrepaymentPercentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_prepayment_percent) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePriceIncludeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_price_include) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePriceRuleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products, object quantity) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _compute_price_rule) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePriceRuleMultiInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products, object quantity, object uom, object date) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _compute_price_rule_multi) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePricelistIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_pricelist_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePricelistRuleIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_pricelist_rule_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePricesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_prices) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_product_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_category.py, METHOD: _compute_product_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductDocumentCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_product_document_count) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_document_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_product_id) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: _compute_product_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductLocationDestIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_product_location_dest_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductLocationSrcIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_product_location_src_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductLstPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_product_lst_price) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductPriceExtraInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_product_price_extra) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_product_qty) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: _compute_product_qty) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_product_qty) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_tooltip) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductUomAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: compute_product_uom) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: _compute_product_uom_id) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: _compute_product_uom_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductUomQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_product_uom_qty) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductVariantCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_variant_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductVariantIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_product_variant_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductionCapacityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_production_capacity) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductionLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_production_location) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductiveTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_productive_time) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProductsAvailabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_products_availability) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeProjectAllowMilestonesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: _compute_project_allow_milestones) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseOkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_purchase_ok) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaseWarningTextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_purchase_warning_text) ---
            */
            return default;
        }

        public async Task<TEntity> ComputePurchaserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_services.py, METHOD: _compute_purchaser_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuestionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_question_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuestionTimeLimitReachedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _compute_question_time_limit_reached) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuestionsCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_questions_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeQuizInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_partner, object quiz_done) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_quiz_info) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRangeUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_range_unit) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRatingAvgTextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: _compute_rating_avg_text) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRatingLastValueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: _compute_rating_last_value) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRatingSatisfactionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: _compute_rating_satisfaction) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRatingStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: _compute_rating_stats) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeReachedDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: _compute_reached_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeReceiptReminderEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_receipt_reminder_email) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeReconcileInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_reconcile) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurrenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_recurrence) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRecycleLocationIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_recycle_location_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRefundRelatedFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_refund_related_fields) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRefundRepartitionLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_refund_repartition_line_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRefundSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_refund_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRelatedTaxesAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_related_taxes_amount) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRelevancyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_relevancy) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRenderModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _compute_render_model) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_render_model) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRepartitionLinesStrInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_repartition_lines_str) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeReplyToInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_reply_to) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeReplyToModeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_reply_to_mode) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRequirePaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_require_payment) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRequireSignatureInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_require_signature) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeResModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _compute_res_model) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeReservationStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_reservation_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeReturnCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_return_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRottingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_tracking_duration_mixin.py, METHOD: _compute_rotting) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeRruleTypeUiInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_rrule_type_ui) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSalaryAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner_bank.py, METHOD: _compute_salary_amount) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSaleWarningTextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_sale_warning_text) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSanitizedAccNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_bank.py, METHOD: _compute_sanitized_acc_number) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeScheduleDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_schedule_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeScheduledDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_scheduled_date) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _compute_scheduled_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeScoringMaxObtainableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_scoring_max_obtainable) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeScoringSuccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _compute_scoring_success) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeScoringTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_scoring_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeScoringValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _compute_scoring_values) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeScrapLocationIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: _compute_scrap_location_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeScrapMoveCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_scrap_move_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeScrapQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: _compute_scrap_qty) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_seats) ---
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_seats) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsLimitedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_seats_limited) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSeatsMaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_seats_max) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSelectedPaymentMethodCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_selected_payment_method_codes) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSelfMemberIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _compute_self_member_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSelfReplyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_self_reply) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSerialNumbersCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_serial_numbers_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeServiceActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_service_activity) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeServiceTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_service_tracking) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSessionAnswerCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_session_answer_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSessionAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_session_available) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSessionCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_session_code) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSessionLinkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_session_link) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSessionQuestionAnswerCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_session_question_answer_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSessionShowLeaderboardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_session_show_leaderboard) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShippingVolumeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_shipping_volume) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShippingWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_shipping_weight) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShouldShowStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_should_show_status) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowAllocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_show_allocation) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_show_allocation) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _compute_show_allocation) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowCheckAvailabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_show_check_availability) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowCodeHistoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_show_code_history) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowComparisonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_show_comparison) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowFetchInEinvoicesButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_show_fetch_in_einvoices_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowGenerateBomInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_show_generate_bom) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowLockInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_show_lock) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowLotIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_show_lot_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowLotsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_show_lots) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowLotsTextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_show_lots_text) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _compute_show_lots_text) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowNextPickingsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_show_next_pickings) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowProduceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_show_produce) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowRefreshOutEinvoicesStatusButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_show_refresh_out_einvoices_status_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeShowSetBomButtonInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _compute_show_set_bom_button) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSingleLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _compute_single_location) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideIconClassInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_slide_icon_class) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_slide_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlideViewsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_slide_views) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSlidesStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_slides_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSmsMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: ir_actions_server.py, METHOD: _compute_sms_method) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSmsTemplateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: ir_actions_server.py, METHOD: _compute_sms_template_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_standard_price) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStartSaleDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_start_sale_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_state) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _compute_state) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _compute_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStopInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_stop) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeStructureTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _compute_structure_type_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ComputeSubsetBaseLinesTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_subset_base_lines_total) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSurveyStatisticInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_survey_statistic) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSurveyTimeLimitReachedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _compute_survey_time_limit_reached) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeSuspenseAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _compute_suspense_account_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTagIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_tag_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTagIdsUsageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_tag_ids_usage) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTalentCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_talent_pool.py, METHOD: _compute_talent_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: _compute_task_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxCountryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_tax_country_id) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_tax_country_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxGroupIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_tax_group_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_tax_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _compute_tax_label) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTaxTotalsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _compute_tax_totals) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_tax_totals) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTeamIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_team_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTeaserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_teaser) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTemplateFieldFromVariantFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname, object @default) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_template_field_from_variant_field) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTemplateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _compute_template_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTicketInstructionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_ticket_instructions) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTimeComputedOnInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py, METHOD: _compute_time_computed_on) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTimeCycleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py, METHOD: _compute_time_cycle) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTodoRequestsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _compute_todo_requests) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py, METHOD: _compute_total_amount) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalCostAtSessionClosingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stock_moves) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_total_cost_at_session_closing) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalCostInRealTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _compute_total_cost_in_real_time) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: _compute_total_employee) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_total) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_total) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalPaymentsAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _compute_total_payments_amount) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTrackTimeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_track_time_data) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTrailerHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_trailer_hook) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTransmissionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_transmission) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTrgDateCalendarIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_trg_date_calendar_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTrgDateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_trg_date_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTrgDateRangeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_trg_date_range_data) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTrgFieldRefInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_trg_field_ref) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTrgFieldRefModelNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_trg_field_ref_model_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTrgSelectionFieldIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_trg_selection_field_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTriggerFieldIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_trigger_field_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTriggerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_trigger) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTypeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_type_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeTypeRequestUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _compute_type_request_unit) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUidHasAnsweredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_uid_has_answered) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUnavailablePartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_unavailable_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUnbuildCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_unbuild_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUninstalledL10nModuleIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_uninstalled_l10n_module_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUnreserveVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_unreserve_visible) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _compute_unreserve_visible) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_uom_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _compute_url) ---
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_url) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _compute_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUseBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _compute_use_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUseCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _compute_use_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUsedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _compute_used) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserCanEditInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_user_can_edit) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserCompanyIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team_member.py, METHOD: _compute_user_company_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: _compute_user_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserFavouriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_user_favourite) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserFiscalyearLockDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_user_fiscalyear_lock_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserHardLockDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_user_hard_lock_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserHasGroupValidateBankAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _compute_user_has_group_validate_bank_account) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_user_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserInTeamsIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team_member.py, METHOD: _compute_user_in_teams_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserMembershipIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_user_membership_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserPurchaseLockDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_user_purchase_lock_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserSaleLockDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_user_sale_lock_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserTaxLockDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _compute_user_tax_lock_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUserVoteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_user_vote) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUsersCanSignupInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _compute_users_can_signup) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeUsesDefaultLogoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _compute_uses_default_logo) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeValidProductTemplateAttributeLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_valid_product_template_attribute_line_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeValidatedOvertimeHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _compute_validated_overtime_hours) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeValidityDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _compute_validity_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeValueFieldToShowInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_value_field_to_show) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVehicleCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py, METHOD: _compute_vehicle_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVehicleNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_vehicle_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVehicleRangeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _compute_vehicle_range) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVideoSourceTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_video_source_type) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVideocallLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_videocall_location) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVideocallSourceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _compute_videocall_source) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVimeoIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_vimeo_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVolumeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_volume) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVolumeUomNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_volume_uom_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeVoteCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_vote_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_warning) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWarningMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _compute_warning_message) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebhookSamplePayloadInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _compute_webhook_sample_payload) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteAbsoluteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_website_absolute_url) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_website_absolute_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_website_description) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_company.py, METHOD: _compute_website_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteImageUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_website_image_url) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_website_image_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteShareUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_website_share_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_tag.py, METHOD: _compute_website_url) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_website_url) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_weight) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWeightUomNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _compute_weight_uom_name) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWishlistVisitorIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _compute_wishlist_visitor_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkedHoursInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _compute_worked_hours) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkingStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_working_state) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkorderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py, METHOD: _compute_workorder_count) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _compute_workorder_count) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkorderIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _compute_workorder_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeWriteDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _compute_write_date) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeXmlIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_actions_server.py, METHOD: _compute_xml_id) ---
            */
            return default;
        }

        public async Task<TEntity> ComputeYoutubeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _compute_youtube_id) ---
            */
            return default;
        }

        public async Task<TEntity> ConfirmationErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _confirmation_error_message) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _confirmation_error_message) ---
            */
            return default;
        }

        public async Task<TEntity> ConstrainsCashBasisTransitionAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _constrains_cash_basis_transition_account) ---
            */
            return default;
        }

        public async Task<TEntity> ConstrainsCompanyMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _constrains_company_members) ---
            */
            return default;
        }

        public async Task<TEntity> ConstrainsCompanyMembershipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team_member.py, METHOD: _constrains_company_membership) ---
            */
            return default;
        }

        public async Task<TEntity> ConstrainsMembershipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team_member.py, METHOD: _constrains_membership) ---
            */
            return default;
        }

        public async Task<TEntity> ConstrainsNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _constrains_name) ---
            */
            return default;
        }

        public async Task<TEntity> ConstrainsReconcileInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _constrains_reconcile) ---
            */
            return default;
        }

        public async Task<TEntity> ConstraintFromMessageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _constraint_from_message_id) ---
            */
            return default;
        }

        public async Task<TEntity> ConstraintGroupIdChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _constraint_group_id_channel) ---
            */
            return default;
        }

        public async Task<TEntity> ConstraintParentChannelIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _constraint_parent_channel_id) ---
            */
            return default;
        }

        public async Task<TEntity> ConstraintPartnersChatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _constraint_partners_chat) ---
            */
            return default;
        }

        public async Task<TEntity> ContrainsCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _contrains_code) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertAnswerToCommentAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: convert_answer_to_comment) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ConvertCommentToAnswerAsync<TEntity>(IEnumerable<TEntity> entities, Guid message_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: convert_comment_to_answer) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertInlineImagesToUrlsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object html_content) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _convert_inline_images_to_urls) ---
            */
            return default;
        }

        public async Task<TEntity> ConvertLinksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: convert_links) ---
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: copy) ---
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: copy) ---
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: copy) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: copy) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: copy) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: copy) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: copy) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: copy) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: copy) ---
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: copy) ---
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_account.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: hr, FILE: hr_job.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_category.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: copy_data) ---
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: copy_data) ---
            */
            return default;
        }

        public async Task<TEntity> CopyExistingOperationsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py, METHOD: copy_existing_operations) ---
            */
            return default;
        }

        public async Task<TEntity> CopyToBomAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py, METHOD: copy_to_bom) ---
            */
            return default;
        }

        public async Task<TEntity> CopyTranslationsAsync<TEntity>(IEnumerable<TEntity> entities, object @new, object excluded) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: copy_translations) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAbTestingUtmCampaignsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _create_ab_testing_utm_campaigns) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAccountInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice_vals_list, object final) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _create_account_invoices) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAccountMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object balancing_account, object amount_to_balance, object bank_payment_method_diffs) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_account_move) ---
            */
            return default;
        }

        public async Task<TEntity> CreateActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: create_action) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAnswerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user, object partner, object email, object test_entry, object check_attempts) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _create_answer) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_services.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_badge_user.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr, FILE: hr_job.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_blacklist.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: phone_validation, FILE: phone_blacklist.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team_member.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_tag.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: create) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAttachmentsForPostInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values_list, object extra_list) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _create_attachments_for_post) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _create_attachments_for_post) ---
            */
            return default;
        }

        public async Task<TEntity> CreateAttachmentsFromInlineImagesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object b64images) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _create_attachments_from_inline_images) ---
            */
            return default;
        }

        public async Task<TEntity> CreateBackorderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object backorder_moves) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _create_backorder) ---
            */
            return default;
        }

        public async Task<TEntity> CreateBackorderPickingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _create_backorder_picking) ---
            */
            return default;
        }

        public async Task<TEntity> CreateBalancingLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object balancing_account, object amount_to_balance) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_balancing_line) ---
            */
            return default;
        }

        public async Task<TEntity> CreateBankPaymentMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_bank_payment_moves) ---
            */
            return default;
        }

        public async Task<TEntity> CreateCashStatementLinesAndCashMoveLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_cash_statement_lines_and_cash_move_lines) ---
            */
            return default;
        }

        public async Task<TEntity> CreateCertificationBadgeTriggerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _create_certification_badge_trigger) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, Guid group_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _create_channel) ---
            */
            return default;
        }

        public async Task<TEntity> CreateCombineAccountPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_method, object amounts, object diff_amount) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_combine_account_payment) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateDefaultAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object journal_type, object vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _create_default_account) ---
            */
            return default;
        }

        public async Task<TEntity> CreateDiffAccountMoveForSplitPaymentMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_method, object diff_amount) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_diff_account_move_for_split_payment_method) ---
            */
            return default;
        }

        public async Task<TEntity> CreateDocumentFromAttachmentAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attachment_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: create_document_from_attachment) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: create_document_from_attachment) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: create_document_from_attachment) ---
            */
            return default;
        }

        public async Task<TEntity> CreateDocumentFromAttachmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attachment_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _create_document_from_attachment) ---
            */
            return default;
        }

        public async Task<TEntity> CreateDownPaymentLinesFromBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object down_payment_base_lines) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _create_down_payment_lines_from_base_lines) ---
            */
            return default;
        }

        public async Task<TEntity> CreateDownPaymentSectionLineIfNeededInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _create_down_payment_section_line_if_needed) ---
            */
            return default;
        }

        public async Task<TEntity> CreateDownpaymentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _create_downpayments) ---
            */
            return default;
        }

        public async Task<TEntity> CreateDriverHistoryAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: create_driver_history) ---
            */
            return default;
        }

        public async Task<TEntity> CreateDropshipPickingTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py, METHOD: _create_dropship_picking_type) ---
            */
            return default;
        }

        public async Task<TEntity> CreateDropshipRuleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py, METHOD: _create_dropship_rule) ---
            */
            return default;
        }

        public async Task<TEntity> CreateDropshipSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py, METHOD: _create_dropship_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> CreateFirstProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object log_warning) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _create_first_product_variant) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners_to, object default_display_mode, object name) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _create_group) ---
            */
            return default;
        }

        public async Task<TEntity> CreateInternalProjectTaskInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: res_company.py, METHOD: _create_internal_project_task) ---
            --- METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: res_company.py, METHOD: _create_internal_project_task) ---
            */
            return default;
        }

        public async Task<TEntity> CreateInventoryLossLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: _create_inventory_loss_location) ---
            */
            return default;
        }

        public async Task<TEntity> CreateInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _create_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> CreateInvoiceReceivableLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_invoice_receivable_lines) ---
            */
            return default;
        }

        public async Task<TEntity> CreateInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object grouped, object final, object date) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _create_invoices) ---
            */
            return default;
        }

        public async Task<TEntity> CreateMiscReversalMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_moves) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _create_misc_reversal_move) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateMissingDropshipPickingTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py, METHOD: create_missing_dropship_picking_type) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateMissingDropshipRuleAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py, METHOD: create_missing_dropship_rule) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateMissingDropshipSequenceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py, METHOD: create_missing_dropship_sequence) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateMissingInventoryLossLocationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: create_missing_inventory_loss_location) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateMissingProductionLocationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: create_missing_production_location) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateMissingScrapLocationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: create_missing_scrap_location) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateMissingScrapSequenceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: create_missing_scrap_sequence) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateMissingSubcontractingDropshippingPickingTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py, METHOD: _create_missing_subcontracting_dropshipping_picking_type) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateMissingSubcontractingDropshippingRulesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py, METHOD: _create_missing_subcontracting_dropshipping_rules) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateMissingSubcontractingDropshippingSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py, METHOD: _create_missing_subcontracting_dropshipping_sequence) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateMissingSubcontractingLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_company.py, METHOD: _create_missing_subcontracting_location) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateMissingTransitLocationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: create_missing_transit_location) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateMissingUnbuildSequencesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: res_company.py, METHOD: create_missing_unbuild_sequences) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CreateMissingWarehouseAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: create_missing_warehouse) ---
            */
            return default;
        }

        public async Task<TEntity> CreateNonReconciliableMoveLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_non_reconciliable_move_lines) ---
            */
            return default;
        }

        public async Task<TEntity> CreateOrderPickingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _create_order_picking) ---
            */
            return default;
        }

        public async Task<TEntity> CreatePayLaterReceivableLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_pay_later_receivable_lines) ---
            */
            return default;
        }

        public async Task<TEntity> CreatePerCompanyLocationsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_company.py, METHOD: _create_per_company_locations) ---
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: _create_per_company_locations) ---
            */
            return default;
        }

        public async Task<TEntity> CreatePerCompanyPickingTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py, METHOD: _create_per_company_picking_types) ---
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: _create_per_company_picking_types) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py, METHOD: _create_per_company_picking_types) ---
            */
            return default;
        }

        public async Task<TEntity> CreatePerCompanyRulesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py, METHOD: _create_per_company_rules) ---
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: _create_per_company_rules) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py, METHOD: _create_per_company_rules) ---
            */
            return default;
        }

        public async Task<TEntity> CreatePerCompanySequencesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: res_company.py, METHOD: _create_per_company_sequences) ---
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py, METHOD: _create_per_company_sequences) ---
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: _create_per_company_sequences) ---
            --- METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py, METHOD: _create_per_company_sequences) ---
            */
            return default;
        }

        public async Task<TEntity> CreatePickingAtEndOfSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_picking_at_end_of_session) ---
            */
            return default;
        }

        public async Task<TEntity> CreatePmChangeLogInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _create_pm_change_log) ---
            */
            return default;
        }

        public async Task<TEntity> CreateProductVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object log_warning) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _create_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> CreateProductionLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: _create_production_location) ---
            */
            return default;
        }

        public async Task<TEntity> CreateResourceCalendarInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: res_company.py, METHOD: _create_resource_calendar) ---
            */
            return default;
        }

        public async Task<TEntity> CreateScrapLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: _create_scrap_location) ---
            */
            return default;
        }

        public async Task<TEntity> CreateScrapSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: _create_scrap_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> CreateSplitAccountPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment, object amounts) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_split_account_payment) ---
            */
            return default;
        }

        public async Task<TEntity> CreateStockValuationLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _create_stock_valuation_lines) ---
            */
            return default;
        }

        public async Task<TEntity> CreateSubChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid from_message_id, object name) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _create_sub_channel) ---
            */
            return default;
        }

        public async Task<TEntity> CreateSubcontractingDropshippingPickingTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py, METHOD: _create_subcontracting_dropshipping_picking_type) ---
            */
            return default;
        }

        public async Task<TEntity> CreateSubcontractingDropshippingRulesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py, METHOD: _create_subcontracting_dropshipping_rules) ---
            */
            return default;
        }

        public async Task<TEntity> CreateSubcontractingDropshippingSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py, METHOD: _create_subcontracting_dropshipping_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> CreateSubcontractingLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_company.py, METHOD: _create_subcontracting_location) ---
            */
            return default;
        }

        public async Task<TEntity> CreateTransitLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: _create_transit_location) ---
            */
            return default;
        }

        public async Task<TEntity> CreateUnbuildSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: res_company.py, METHOD: _create_unbuild_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> CreateUpdateDateActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_dates) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _create_update_date_activity) ---
            */
            return default;
        }

        public async Task<TEntity> CreateUpdateMoveFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _create_update_move_finished) ---
            */
            return default;
        }

        public async Task<TEntity> CreateUpsellActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _create_upsell_activity) ---
            */
            return default;
        }

        public async Task<TEntity> CreateVariantIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _create_variant_ids) ---
            */
            return default;
        }

        public async Task<TEntity> CreateVideocallChannelIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _create_videocall_channel_id) ---
            */
            return default;
        }

        public async Task<TEntity> CreateVideocallChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _create_videocall_channel) ---
            */
            return default;
        }

        public async Task<TEntity> CreationMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _creation_message) ---
            */
            return default;
        }

        public async Task<TEntity> CreationSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _creation_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> CreditAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partial_move_line_vals, object amount, object amount_converted, object force_company_currency) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _credit_amounts) ---
            */
            return default;
        }

        public async Task<TEntity> CronAbsenceDetectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _cron_absence_detection) ---
            */
            return default;
        }

        public async Task<TEntity> CronAutoCheckOutInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _cron_auto_check_out) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CronGenerateEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _cron_generate_entries) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CronPostStockValuationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: _cron_post_stock_valuation) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CronProcessTimeBasedActionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _cron_process_time_based_actions) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CronSendPendingEmailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _cron_send_pending_emails) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> CronUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object ids, object commit) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: _cron_update) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DateCategoryToDomainAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object date_category) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: date_category_to_domain) ---
            */
            return default;
        }

        public async Task<TEntity> DebitAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partial_move_line_vals, object amount, object amount_converted, object force_company_currency) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _debit_amounts) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultAccountJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py, METHOD: _default_account_journal_id) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultAliasDomainIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: res_company.py, METHOD: _default_alias_domain_id) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultCardTemplateIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _default_card_template_id) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultCompanyTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: res_company.py, METHOD: _default_company_token) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultConfirmationMailTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: _default_confirmation_mail_template) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultConfirmationSmsPickingTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_sms, FILE: res_company.py, METHOD: _default_confirmation_sms_picking_template) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _default_content) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _default_currency_id) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _default_description) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultDisplayInvoiceTemplatePdfReportIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _default_display_invoice_template_pdf_report_id) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _default_employee) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultEventMailIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _default_event_mail_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: default_get) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultHolidayStatusIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _default_holiday_status_id) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultInboundPaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _default_inbound_payment_methods) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultInvoiceReferenceModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _default_invoice_reference_model) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultOrderLineValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object child_field) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _default_order_line_values) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _default_order_line_values) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _default_order_line_values) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _default_order_line_values) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _default_order_line_values) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultOutboundPaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _default_outbound_payment_methods) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _default_partners) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultPickingTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _default_picking_type_id) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _default_picking_type_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultProjectTimeModeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: res_company.py, METHOD: _default_project_time_mode_id) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultQuestionIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _default_question_ids) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultSalaryStructureInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _default_salary_structure) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _default_sequence) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultSponsorTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _default_sponsor_type_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultStartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _default_start) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultStopInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _default_stop) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultTeamIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _default_team_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultTimesheetEncodeUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: res_company.py, METHOD: _default_timesheet_encode_uom_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DefaultUpdatePathInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _default_update_path) ---
            */
            return default;
        }

        public async Task<TEntity> DefaultWebsiteMetaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _default_website_meta) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _default_website_meta) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _default_website_meta) ---
            */
            return default;
        }

        public async Task<TEntity> DeleteCashInOutAsync<TEntity>(IEnumerable<TEntity> entities, Guid absl_id, Guid partner_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: delete_cash_in_out) ---
            */
            return default;
        }

        public async Task<TEntity> DeleteOpeningControlSessionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: delete_opening_control_session) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DemoConfigureVariantsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _demo_configure_variants) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DetectIsBounceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object message_dict) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _detect_is_bounce) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DetectLoopHeadersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _detect_loop_headers) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DetectLoopSenderDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_from_normalized) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _detect_loop_sender_domain) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_blacklist.py, METHOD: _detect_loop_sender_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DetectLoopSenderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object message_dict, object routes) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _detect_loop_sender) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DetectWriteToCatchallInternalAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _detect_write_to_catchall) ---
            */
            return default;
        }

        public async Task<TEntity> DiscardChallengeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: discard_challenge) ---
            */
            return default;
        }

        public async Task<TEntity> DiscardTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _discard_tracking) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DispatchGlobalDiscountLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _dispatch_global_discount_lines) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DispatchReturnOfMerchandiseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _dispatch_return_of_merchandise_lines) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DispatchTaxesIntoNewBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company, object exclude_function) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _dispatch_taxes_into_new_base_lines) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> DistributeDeltaAmountSmoothlyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object precision_digits, object delta_amount, object target_factors) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _distribute_delta_amount_smoothly) ---
            */
            return default;
        }

        public async Task<TEntity> DoPrintPickingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: do_print_picking) ---
            */
            return default;
        }

        public async Task<TEntity> DoReplenishAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: do_replenish) ---
            */
            return default;
        }

        public async Task<TEntity> DoScrapAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: do_scrap) ---
            */
            return default;
        }

        public async Task<TEntity> DoUnreserveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: do_unreserve) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: do_unreserve) ---
            */
            return default;
        }

        public async Task<TEntity> DomainEmployeeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _domain_employee_id) ---
            */
            return default;
        }

        public async Task<TEntity> DomainHolidayStatusIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _domain_holiday_status_id) ---
            */
            return default;
        }

        public async Task<TEntity> DomainItemIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _domain_item_ids) ---
            */
            return default;
        }

        public async Task<TEntity> DomainPricelistRuleIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _domain_pricelist_rule_ids) ---
            */
            return default;
        }

        public async Task<TEntity> EmbedIncrementInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _embed_increment) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> EncodeLinkInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_link, object @params) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _encode_link) ---
            */
            return default;
        }

        public async Task<TEntity> EnrichExtractM2oIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object iap_data, object m2o_fields) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_company.py, METHOD: _enrich_extract_m2o_id) ---
            */
            return default;
        }

        public async Task<TEntity> EnrichInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_company.py, METHOD: _enrich) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureCodeIsUniqueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _ensure_code_is_unique) ---
            */
            return default;
        }

        public async Task<TEntity> EnsureToKeepLastPreparationChangeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _ensure_to_keep_last_preparation_change) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> EnsureUniqueAliasInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object company) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _ensure_unique_alias) ---
            */
            return default;
        }

        public async Task<TEntity> EntryCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _entry_count) ---
            */
            return default;
        }

        public async Task<TEntity> EvalTaxAmountFixedAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object batch, object raw_base, object evaluation_context) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _eval_tax_amount_fixed_amount) ---
            */
            return default;
        }

        public async Task<TEntity> EvalTaxAmountPriceExcludedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object batch, object raw_base, object evaluation_context) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _eval_tax_amount_price_excluded) ---
            */
            return default;
        }

        public async Task<TEntity> EvalTaxAmountPriceIncludedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object batch, object raw_base, object evaluation_context) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _eval_tax_amount_price_included) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> EvalTaxesComputationPrepareProductDefaultValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _eval_taxes_computation_prepare_product_default_values) ---
            */
            return default;
        }

        public async Task<TEntity> EvalTaxesComputationPrepareProductFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _eval_taxes_computation_prepare_product_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> EvalTaxesComputationPrepareProductUomDefaultValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _eval_taxes_computation_prepare_product_uom_default_values) ---
            */
            return default;
        }

        public async Task<TEntity> EvalTaxesComputationPrepareProductUomFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _eval_taxes_computation_prepare_product_uom_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> EvalTaxesComputationPrepareProductUomValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object default_product_uom_values, object product_uom) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _eval_taxes_computation_prepare_product_uom_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> EvalTaxesComputationPrepareProductValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object default_product_values, object product) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _eval_taxes_computation_prepare_product_values) ---
            */
            return default;
        }

        public async Task<TEntity> EvalTaxesComputationTurnToProductUomValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product_uom) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _eval_taxes_computation_turn_to_product_uom_values) ---
            */
            return default;
        }

        public async Task<TEntity> EvalTaxesComputationTurnToProductValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _eval_taxes_computation_turn_to_product_values) ---
            */
            return default;
        }

        public async Task<TEntity> EvalValueInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _eval_value) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ExcludeTaxGroupsFromTaxTotalsSummaryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_totals, object ids_to_exclude) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _exclude_tax_groups_from_tax_totals_summary) ---
            */
            return default;
        }

        public async Task<TEntity> ExecuteCommandHelpAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: execute_command_help) ---
            */
            return default;
        }

        public async Task<TEntity> ExecuteCommandHelpMessageExtraInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _execute_command_help_message_extra) ---
            */
            return default;
        }

        public async Task<TEntity> ExecuteCommandLeaveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: execute_command_leave) ---
            */
            return default;
        }

        public async Task<TEntity> ExecuteCommandWhoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: execute_command_who) ---
            */
            return default;
        }

        public async Task<TEntity> ExecuteWebhookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payload) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _execute_webhook) ---
            */
            return default;
        }

        public async Task<bool> ExistingAccountingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _existing_accounting) ---
            */
            return default;
        }

        public async Task<TEntity> ExplodeAsync<TEntity>(IEnumerable<TEntity> entities, object product, object quantity, object picking_type, object never_attribute_values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: explode) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ExportBaseLineExtraTaxDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _export_base_line_extra_tax_data) ---
            */
            return default;
        }

        public async Task<TEntity> FallbackLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _fallback_lang) ---
            */
            return default;
        }

        public async Task<TEntity> FetchDuplicateOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _fetch_duplicate_orders) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _fetch_duplicate_orders) ---
            */
            return default;
        }

        public async Task<TEntity> FetchExternalMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _fetch_external_metadata) ---
            */
            return default;
        }

        public async Task<TEntity> FetchGoogleDriveMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _fetch_google_drive_metadata) ---
            */
            return default;
        }

        public async Task<TEntity> FetchOrCreatePreviewCardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _fetch_or_create_preview_card) ---
            */
            return default;
        }

        public async Task<TEntity> FetchQueryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object query, object fields) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _fetch_query) ---
            */
            return default;
        }

        public async Task<TEntity> FetchVimeoMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _fetch_vimeo_metadata) ---
            */
            return default;
        }

        public async Task<TEntity> FetchYoutubeMetadataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object image_url_only) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _fetch_youtube_metadata) ---
            */
            return default;
        }

        public async Task<object> FieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, string @alias, string field_expr, object query) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _field_to_sql) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FillMissingValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object protected_codes) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _fill_missing_values) ---
            */
            return default;
        }

        public async Task<TEntity> FilterCombinationsImpossibleByConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination_tuples, object ignore_no_variant) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _filter_combinations_impossible_by_config) ---
            */
            return default;
        }

        public async Task<TEntity> FilterLocalDataAsync<TEntity>(IEnumerable<TEntity> entities, object models_to_filter) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: filter_local_data) ---
            */
            return default;
        }

        public async Task<TEntity> FilterPostExportDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records, object feedback) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _filter_post_export_domain) ---
            */
            return default;
        }

        public async Task<TEntity> FilterPostInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records, object feedback) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _filter_post) ---
            */
            return default;
        }

        public async Task<TEntity> FilterPreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records, object feedback) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _filter_pre) ---
            */
            return default;
        }

        public async Task<TEntity> FilterProductDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object documents) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _filter_product_documents) ---
            */
            return default;
        }

        public async Task<TEntity> FilterTaxesByCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _filter_taxes_by_company) ---
            */
            return default;
        }

        public async Task<TEntity> FilterToUnlinkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _filter_to_unlink) ---
            */
            return default;
        }

        public async Task<TEntity> FindDeliveryIdsByLotInternalAsync<TEntity>(IEnumerable<TEntity> entities, object lot_path, object delivery_by_lot) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _find_delivery_ids_by_lot) ---
            */
            return default;
        }

        public async Task<TEntity> FindDeliveryIdsByLotIterativeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _find_delivery_ids_by_lot_iterative) ---
            */
            return default;
        }

        public async Task<TEntity> FindMailTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _find_mail_template) ---
            */
            return default;
        }

        public async Task<TEntity> FindOrCreateMemberForSelfInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _find_or_create_member_for_self) ---
            */
            return default;
        }

        public async Task<TEntity> FindOrCreatePersonaForChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object guest_name, object timezone, object country_code, object create_member_params, object post_joined_message) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _find_or_create_persona_for_channel) ---
            */
            return default;
        }

        public async Task<TEntity> FindPartnerCustomerAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: find_partner_customer) ---
            */
            return default;
        }

        public async Task<TEntity> FindProductByBarcodeAsync<TEntity>(IEnumerable<TEntity> entities, object barcode, Guid config_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: find_product_by_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> FixAttachmentOwnershipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _fix_attachment_ownership) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FixBaseLinesTaxDetailsOnManualTaxAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company, object filter_function) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _fix_base_lines_tax_details_on_manual_tax_amounts) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FixTaxIncludedPriceCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price, object prod_taxes, object line_taxes, Guid company_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _fix_tax_included_price_company) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FixTaxIncludedPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price, object prod_taxes, object line_taxes) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _fix_tax_included_price) ---
            */
            return default;
        }

        public async Task<TEntity> FlagInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _flag) ---
            */
            return default;
        }

        public async Task<TEntity> FlattenTaxesAndSortThemInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _flatten_taxes_and_sort_them) ---
            */
            return default;
        }

        public async Task<TEntity> FlattenTaxesHierarchyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: flatten_taxes_hierarchy) ---
            */
            return default;
        }

        public async Task<TEntity> ForceLinesToInvoicePolicyOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _force_lines_to_invoice_policy_order) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FormatLockDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object lock_dates) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _format_lock_dates) ---
            */
            return default;
        }

        public async Task<TEntity> FormatPointsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object points) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _format_points) ---
            */
            return default;
        }

        public async Task<TEntity> GcMarkEventsDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _gc_mark_events_done) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateActionNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _generate_action_name) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateAvatarInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _generate_avatar) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GenerateCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _generate_code) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateConsumeMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: _generate_consume_moves) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateDownpaymentInvoicesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _generate_downpayment_invoices) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateGoalsFromChallengeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: _generate_goals_from_challenge) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GenerateInviteTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _generate_invite_token) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GenerateLotNamesAsync<TEntity>(IEnumerable<TEntity> entities, object first_lot, object count) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: generate_lot_names) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateMailingRecipientTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid document_id, object email) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _generate_mailing_recipient_token) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateMailingReportTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _generate_mailing_report_token) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateMoveFromBomLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product, object product_uom, object quantity, Guid bom_line_id, Guid byproduct_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: _generate_move_from_bom_line) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateMoveFromExistingMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object factor, Guid location_id, Guid location_dest_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: _generate_move_from_existing_move) ---
            */
            return default;
        }

        public async Task<TEntity> GeneratePosOrderInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _generate_pos_order_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateProduceMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: _generate_produce_moves) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GenerateRandomTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _generate_random_token) ---
            */
            return default;
        }

        public async Task<TEntity> GenerateSessionCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object code_count, object excluded_codes) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _generate_session_codes) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GenerateTrackingMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object return_line) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _generate_tracking_message) ---
            */
            return default;
        }

        public async Task<TEntity> GetAbTestingDescriptionModifyingFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_ab_testing_description_modifying_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetAbTestingDescriptionValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_ab_testing_description_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetAbTestingSiblingsMailingsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_ab_testing_siblings_mailings) ---
            */
            return default;
        }

        public async Task<TEntity> GetAbTestingWinnerSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_ab_testing_winner_selection) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccessActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid, object force_website) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_access_action) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _get_access_action) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _get_access_action) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _get_access_action) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAccountIdAsync<TEntity>(IEnumerable<TEntity> entities, object service_name) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: iap, FILE: iap_account.py, METHOD: get_account_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid account_id, object balance, object information) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: iap, FILE: iap_account.py, METHOD: _get_account_info) ---
            --- METHOD SOURCE (MODULE: sms, FILE: iap_account.py, METHOD: _get_account_info) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountInformationFromIapInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: iap, FILE: iap_account.py, METHOD: _get_account_information_from_iap) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccountsByProductInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: _get_accounts_by_product) ---
            */
            return default;
        }

        public async Task<TEntity> GetAccrualPlanLevelWorkEntryProrataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object level, object start_period, object start_date, object end_period, object end_date) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _get_accrual_plan_level_work_entry_prorata) ---
            */
            return default;
        }

        public async Task<TEntity> GetAcknowledgeUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: get_acknowledge_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetActionAddFromCatalogExtraContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _get_action_add_from_catalog_extra_context) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_action_add_from_catalog_extra_context) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_action_add_from_catalog_extra_context) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetActionClickGraphAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: get_action_click_graph) ---
            */
            return default;
        }

        public async Task<TEntity> GetActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object action_xmlid) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _get_action) ---
            */
            return default;
        }

        public async Task<TEntity> GetActionLinkParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object link_type) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _get_action_link_params) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetActionPickingTreeIncomingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: get_action_picking_tree_incoming) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetActionPickingTreeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: get_action_picking_tree_internal) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetActionPickingTreeOutgoingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: get_action_picking_tree_outgoing) ---
            */
            return default;
        }

        public async Task<TEntity> GetActionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records, object triggers) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _get_actions) ---
            */
            return default;
        }

        public async Task<TEntity> GetActivePeppolParentCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _get_active_peppol_parent_company) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetActivityDeadlineFromStartInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object allday) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_activity_deadline_from_start) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetActivityExcludedModelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_activity_excluded_models) ---
            */
            return default;
        }

        public async Task<TEntity> GetAdditionalDataFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object comment) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py, METHOD: _get_additional_data_field) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAllowedAccessParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _get_allowed_access_params) ---
            --- METHOD SOURCE (MODULE: portal, FILE: mail_thread.py, METHOD: _get_allowed_access_params) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAllowedChannelMemberCreateParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_allowed_channel_member_create_params) ---
            */
            return default;
        }

        public async Task<TEntity> GetAllowedMessageParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_allowed_message_params) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _get_allowed_message_params) ---
            --- METHOD SOURCE (MODULE: rating, FILE: mail_thread.py, METHOD: _get_allowed_message_params) ---
            */
            return default;
        }

        public async Task<TEntity> GetAllowedMessagePartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_allowed_message_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetAnalyticNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _get_analytic_name) ---
            */
            return default;
        }

        public async Task<TEntity> GetApplicableRulesDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products, object date) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _get_applicable_rules_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetApplicableRulesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products, object date) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _get_applicable_rules) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetArchiveValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_archive_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetAssetStyleB64InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: _get_asset_style_b64) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAsync<TEntity>(IEnumerable<TEntity> entities, object service_name, object force_create) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: iap, FILE: iap_account.py, METHOD: get) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttendanceByPeriodsByEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _get_attendance_by_periods_by_employee) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object parent_name, List<Guid> combination_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_attribute_exclusions) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttributesByPtalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_attributes_by_ptal_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetAttributesExtraPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _get_attributes_extra_price) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_attributes_extra_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetAutoprintDoneReportActionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_autoprint_done_report_actions) ---
            */
            return default;
        }

        public async Task<TEntity> GetAutoprintReportActionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _get_autoprint_report_actions) ---
            */
            return default;
        }

        public async Task<TEntity> GetAvailablePaymentMethodLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_type) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_available_payment_method_lines) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAvailableQrMethodsInSequenceAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: get_available_qr_methods_in_sequence) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetAvailableQrMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _get_available_qr_methods) ---
            */
            return default;
        }

        public async Task<TEntity> GetAvailableUomsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_available_uoms) ---
            */
            return default;
        }

        public async Task<TEntity> GetBackendMenuIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: get_backend_menu_id) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: get_backend_menu_id) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: get_backend_menu_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetBackorderMoValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_backorder_mo_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetBadgeUserStatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_badge.py, METHOD: _get_badge_user_stats) ---
            */
            return default;
        }

        public async Task<TEntity> GetBalancingAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_balancing_account) ---
            */
            return default;
        }

        public async Task<TEntity> GetBankStatementsAvailableSourcesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_bank_statements_available_sources) ---
            */
            return default;
        }

        public async Task<TEntity> GetBarcodeSearchDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object barcodes_within_company, Guid company_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _get_barcode_search_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetBarcodesByCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _get_barcodes_by_company) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetBaseLineFieldValueFromRecordInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field, object extra_values, object fallback, object from_base_line) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _get_base_line_field_value_from_record) ---
            */
            return default;
        }

        public async Task<TEntity> GetBaseUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: get_base_url) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: get_base_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetBbanAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_iban, FILE: res_partner_bank.py, METHOD: get_bban) ---
            */
            return default;
        }

        public async Task<TEntity> GetBomValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object ratio) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_bom_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetBouncedMessageDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object message_dict) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _get_bounced_message_data) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCalendarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object automation, object record) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _get_calendar) ---
            */
            return default;
        }

        public async Task<TEntity> GetCallNotificationTagInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_call_notification_tag) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCanPublishErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _get_can_publish_error_message) ---
            */
            return default;
        }

        public async Task<TEntity> GetCapacityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product, object unit, object default_capacity) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _get_capacity) ---
            */
            return default;
        }

        public async Task<TEntity> GetCapturedPaymentsDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_captured_payments_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetCardElementValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _get_card_element_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetCarryoverDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _get_carryover_date) ---
            */
            return default;
        }

        public async Task<TEntity> GetCashInOutListAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: get_cash_in_out_list) ---
            */
            return default;
        }

        public async Task<TEntity> GetChallengerUsersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: _get_challenger_users) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetChannelsAsMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_channels_as_member) ---
            */
            return default;
        }

        public async Task<TEntity> GetChartOfAccountsOrFailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: get_chart_of_accounts_or_fail) ---
            */
            return default;
        }

        public async Task<TEntity> GetChildrenDepartmentIdsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: get_children_department_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetChildrenDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: ir_actions_server.py, METHOD: _get_children_domain) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_children_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetChildrenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_children) ---
            */
            return default;
        }

        public async Task<TEntity> GetClosedOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_closed_orders) ---
            */
            return default;
        }

        public async Task<TEntity> GetClosestParentAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object accounts_to_process, object field_name, object default_value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _get_closest_parent_account) ---
            */
            return default;
        }

        public async Task<TEntity> GetClosestPossibleCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_closest_possible_combination) ---
            */
            return default;
        }

        public async Task<TEntity> GetClosestPossibleCombinationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_closest_possible_combinations) ---
            */
            return default;
        }

        public async Task<TEntity> GetClosingControlDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: get_closing_control_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetCombineReceivableValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_method, object amount, object amount_converted) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_combine_receivable_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetCombineStatementLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object journal, object amount, object payment_method) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_combine_statement_line_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompanyAddressFieldNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_company_address_field_names) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompanyAddressUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_company_address_update) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompanyDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_company.py, METHOD: _get_company_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompanyInfoOnPeppolInternalAsync<TEntity>(IEnumerable<TEntity> entities, object edi_identification) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _get_company_info_on_peppol) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompanyRootDelegatedFieldNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _get_company_root_delegated_field_names) ---
            */
            return default;
        }

        public async Task<TEntity> GetCompletionTimePdfInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data_bytes) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _get_completion_time_pdf) ---
            */
            return default;
        }

        public async Task<TEntity> GetConditionalMapsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _get_conditional_maps) ---
            */
            return default;
        }

        public async Task<TEntity> GetConditionalValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _get_conditional_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetConfigAccountUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: iap, FILE: iap_account.py, METHOD: get_config_account_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetConfirmUrlAsync<TEntity>(IEnumerable<TEntity> entities, object confirm_type) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: get_confirm_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetConfirmationTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_confirmation_template) ---
            */
            return default;
        }

        public async Task<TEntity> GetConsumptionIssuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_consumption_issues) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetContactDetailsDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object organizer, object partners) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_contact_details_description) ---
            */
            return default;
        }

        public async Task<TEntity> GetContextualDiscountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _get_contextual_discount) ---
            */
            return default;
        }

        public async Task<TEntity> GetContextualPriceAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: get_contextual_price) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_contextual_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetContextualPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _get_contextual_price) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_contextual_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetContextualPricelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_contextual_pricelist) ---
            */
            return default;
        }

        public async Task<TEntity> GetContinentalRealtimeVariationValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object accounts_by_product, object at_date, object extra_aml_vals_list) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: _get_continental_realtime_variation_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetContractWageFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _get_contract_wage_field) ---
            */
            return default;
        }

        public async Task<TEntity> GetContractWageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _get_contract_wage) ---
            */
            return default;
        }

        public async Task<TEntity> GetCopiableOrderLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_copiable_order_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetCrc16InternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object poly, object init) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py, METHOD: _get_crc16) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCreditsAsync<TEntity>(IEnumerable<TEntity> entities, object service_name) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: iap, FILE: iap_account.py, METHOD: get_credits) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCreditsUrlAsync<TEntity>(IEnumerable<TEntity> entities, object service_name, object account_token) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: iap, FILE: iap_account.py, METHOD: get_credits_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetCronIntervalInternalAsync<TEntity>(IEnumerable<TEntity> entities, object automations) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _get_cron_interval) ---
            */
            return default;
        }

        public async Task<TEntity> GetCurrentAccrualPlanLevelIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date, List<Guid> level_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _get_current_accrual_plan_level_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetCurrentOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object state) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py, METHOD: _get_current_orders) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetCustomFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_custom_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetCustomerDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_customer_description) ---
            */
            return default;
        }

        public async Task<TEntity> GetCustomerInformationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _get_customer_information) ---
            */
            return default;
        }

        public async Task<TEntity> GetCustomerSummaryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_customer_summary) ---
            */
            return default;
        }

        public async Task<TEntity> GetDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: _get_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetDataListInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: _get_data_list) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDateFormatsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_date_formats) ---
            */
            return default;
        }

        public async Task<TEntity> GetDateRangeStrInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_datetime, object lang_code) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_date_range_str) ---
            */
            return default;
        }

        public async Task<TEntity> GetDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _get_dates) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDayStartAndDayInternalAsync<TEntity>(IEnumerable<TEntity> entities, object employee, object dt) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _get_day_start_and_day) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultAbTestingCampaignValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_default_ab_testing_campaign_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _get_default_access_token) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultAccountDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_default_account_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultAddressIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _get_default_address_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultBoothCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_type_booth.py, METHOD: _get_default_booth_category) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_talent_pool.py, METHOD: _get_default_color) ---
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _get_default_color) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultCreateSectionValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_default_create_section_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultDateFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_default_date_finished) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultDateStartInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_default_date_start) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultDurationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: get_default_duration) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultFavoriteUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _get_default_favorite_user_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultIsLockedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_default_is_locked) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultMailServerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_default_mail_server_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultMailingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_default_mailing_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultNomenclatureInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: barcodes, FILE: res_company.py, METHOD: _get_default_nomenclature) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultOpeningMoveValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _get_default_opening_move_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultPaymentLinkValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_default_payment_link_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultPickingTypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_default_picking_type_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultPricelistValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: res_company.py, METHOD: _get_default_pricelist_vals) ---
            --- METHOD SOURCE (MODULE: website_sale, FILE: res_company.py, METHOD: _get_default_pricelist_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultPrivacyDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_default_privacy_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultProductUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _get_default_product_uom_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultProjectIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: _get_default_project_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_default_stage_id) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_default_stage_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _get_default_state) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultTeamIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id, object domain) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _get_default_team_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _get_default_template) ---
            */
            return default;
        }

        public async Task<TEntity> GetDefaultUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_default_uom_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultWelcomeMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _get_default_welcome_message) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDeltaAmountToReachTargetInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_amount, object target_currency, object raw_current_amount, object raw_current_amount_precision_digits) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _get_delta_amount_to_reach_target) ---
            */
            return default;
        }

        public async Task<TEntity> GetDepartmentHierarchyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: get_department_hierarchy) ---
            */
            return default;
        }

        public async Task<TEntity> GetDescriptionPlaintextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _get_description_plaintext) ---
            */
            return default;
        }

        public async Task<TEntity> GetDiffAccountMoveRefInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_method) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_diff_account_move_ref) ---
            */
            return default;
        }

        public async Task<TEntity> GetDiffValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid payment_method_id, object diff_amount, object outstanding_account) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_diff_vals) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDiscussVideocallLocationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: get_discuss_videocall_location) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDisplayTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop, object zduration, object zallday) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_display_time) ---
            */
            return default;
        }

        public async Task<TEntity> GetDisplayTimeTzAsync<TEntity>(IEnumerable<TEntity> entities, object tz) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: get_display_time_tz) ---
            */
            return default;
        }

        public async Task<TEntity> GetDisposalMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _get_disposal_moves) ---
            */
            return default;
        }

        public async Task<TEntity> GetDocumentIterateKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid move_raw_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_document_iterate_key) ---
            */
            return default;
        }

        public async Task<TEntity> GetDomainIsLateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_domain_is_late) ---
            */
            return default;
        }

        public async Task<TEntity> GetDriverHistoryDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _get_driver_history_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetDurationFromTrackingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object trackings) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_tracking_duration_mixin.py, METHOD: _get_duration_from_tracking) ---
            */
            return default;
        }

        public async Task<TEntity> GetDurationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_duration) ---
            */
            return default;
        }

        public async Task<TEntity> GetEdiBuildersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_edi_builders) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_edi_builders) ---
            */
            return default;
        }

        public async Task<TEntity> GetEmployeeCalendarInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _get_employee_calendar) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_message) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: get_empty_list_help) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: get_empty_list_help) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: get_empty_list_help) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_empty_list_help) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: get_empty_list_help) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: get_empty_list_help) ---
            */
            return default;
        }

        public async Task<TEntity> GetEntirePackLocationDestInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> move_line_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _get_entire_pack_location_dest) ---
            */
            return default;
        }

        public async Task<TEntity> GetErrorMessagesForQrInternalAsync<TEntity>(IEnumerable<TEntity> entities, object qr_method, object debtor_partner, object currency) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _get_error_messages_for_qr) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEvalContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object action) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _get_eval_context) ---
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _get_eval_context) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetEventBoothFieldsWhitelistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_type_booth.py, METHOD: _get_event_booth_fields_whitelist) ---
            --- METHOD SOURCE (MODULE: event_booth_sale, FILE: event_type_booth.py, METHOD: _get_event_booth_fields_whitelist) ---
            */
            return default;
        }

        public async Task<TEntity> GetEventTrackVisitorsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_create) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_event_track_visitors) ---
            */
            return default;
        }

        public async Task<TEntity> GetExternalDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_external_description) ---
            */
            return default;
        }

        public async Task<TEntity> GetExternalDescriptionUrlEncodedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_external_description_url_encoded) ---
            */
            return default;
        }

        public async Task<TEntity> GetExtraAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _get_extra_attachments) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetExtraBalanceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: _get_extra_balance) ---
            */
            return default;
        }

        public async Task<TEntity> GetFeedProductDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _get_feed_product_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetFeedProductsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _get_feed_products) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetFieldsToExportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: _get_fields_to_export) ---
            */
            return default;
        }

        public async Task<TEntity> GetFilteredSellersInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id, object quantity, object date, Guid uom_id, object @params) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _get_filtered_sellers) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstAvailableSlotInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_datetime, object duration, object forward, object leaves_to_ignore, object extra_leaves_slots) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _get_first_available_slot) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstPossibleCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object necessary_values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_first_possible_combination) ---
            */
            return default;
        }

        public async Task<TEntity> GetFirstPossibleVariantIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_first_possible_variant_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetFiscalDatesAsync<TEntity>(IEnumerable<TEntity> entities, object payload) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: spreadsheet_account, FILE: res_company.py, METHOD: get_fiscal_dates) ---
            */
            return default;
        }

        public async Task<TEntity> GetFormviewActionAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: get_formview_action) ---
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: get_formview_action) ---
            */
            return default;
        }

        public async Task<TEntity> GetFutureLeavesOnInternalAsync<TEntity>(IEnumerable<TEntity> entities, object accrual_date) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _get_future_leaves_on) ---
            */
            return default;
        }

        public async Task<TEntity> GetHrResponsibleDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _get_hr_responsible_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetIcsFileInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_ics_file) ---
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_ics_file) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_ics_file) ---
            */
            return default;
        }

        public async Task<TEntity> GetImageB64InternalAsync<TEntity>(IEnumerable<TEntity> entities, object record) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _get_image_b64) ---
            */
            return default;
        }

        public async Task<TEntity> GetImageByUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object url, object session) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_image_by_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetImpactedPickingsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _get_impacted_pickings) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: get_import_templates) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: get_import_templates) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: get_import_templates) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_import_templates) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: get_import_templates) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: get_import_templates) ---
            */
            return default;
        }

        public async Task<TEntity> GetInactiveConditionalQuestionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _get_inactive_conditional_questions) ---
            */
            return default;
        }

        public async Task<TEntity> GetInternalGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object account_type) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _get_internal_group) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceGroupingKeysInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_invoice_grouping_keys) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetInvoiceLinesValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line_values, object pos_line, object move_type) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_invoice_lines_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePolicyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _get_invoice_policy) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoicePostContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_invoice_post_context) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceReceivableValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount, object amount_converted) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_invoice_receivable_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceTotalListInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_invoice_total_list) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoiceableLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object final) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_invoiceable_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_invoiced) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_invoiced) ---
            */
            return default;
        }

        public async Task<TEntity> GetJournalBankAccountBalanceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_journal_bank_account_balance) ---
            */
            return default;
        }

        public async Task<TEntity> GetJournalInboundOutstandingPaymentAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_journal_inbound_outstanding_payment_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> GetJournalNotificationUnsubscribeScopeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_journal_notification_unsubscribe_scope) ---
            */
            return default;
        }

        public async Task<TEntity> GetJournalOutboundOutstandingPaymentAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_journal_outbound_outstanding_payment_accounts) ---
            */
            return default;
        }

        public async Task<TEntity> GetJournalsPaymentMethodInformationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_journals_payment_method_information) ---
            */
            return default;
        }

        public async Task<TEntity> GetKioskUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: get_kiosk_url) ---
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: get_kiosk_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_lang) ---
            */
            return default;
        }

        public async Task<TEntity> GetLastClosingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: _get_last_closing_date) ---
            */
            return default;
        }

        public async Task<TEntity> GetLastMessagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_last_messages) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetLengthUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_length_uom_id_from_ir_config_parameter) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetLengthUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_length_uom_name_from_ir_config_parameter) ---
            */
            return default;
        }

        public async Task<TEntity> GetLineAnswerValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object question, object answer, object answer_type) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _get_line_answer_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetLineCommentValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object question, object comment) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _get_line_comment_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetLinkTrackerValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_link_tracker_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetListPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_list_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetLocalizedDatePlannedAsync<TEntity>(IEnumerable<TEntity> entities, object date_planned) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: get_localized_date_planned) ---
            */
            return default;
        }

        public async Task<TEntity> GetLocalizedTimesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _get_localized_times) ---
            */
            return default;
        }

        public async Task<TEntity> GetLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _get_location) ---
            */
            return default;
        }

        public async Task<TEntity> GetLocationValuationValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object at_date, object location_domain) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: _get_location_valuation_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetLockDateViolationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object accounting_date, object fiscalyear, object sale, object purchase, object tax, object hard) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _get_lock_date_violations) ---
            */
            return default;
        }

        public async Task<TEntity> GetLogoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_logo) ---
            */
            return default;
        }

        public async Task<TEntity> GetLotMoveLinesForSanityCheckInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> none_done_picking_ids, object separate_pickings) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _get_lot_move_lines_for_sanity_check) ---
            */
            return default;
        }

        public async Task<TEntity> GetMailAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object ticket, object basic_ticket) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_mail_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> GetMailAuthorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _get_mail_author) ---
            */
            return default;
        }

        public async Task<TEntity> GetMailThreadDataAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _get_mail_thread_data_attachments) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _get_mail_thread_data_attachments) ---
            */
            return default;
        }

        public async Task<TEntity> GetMailTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_mail_tz) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMainCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_main_company) ---
            */
            return default;
        }

        public async Task<TEntity> GetMappedAttributeNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_mapped_attribute_names) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMaritalStatusSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _get_marital_status_selection) ---
            */
            return default;
        }

        public async Task<TEntity> GetMassMailingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_mass_mailing_context) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMentionSuggestionsAsync<TEntity>(IEnumerable<TEntity> entities, object search, object limit) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: get_mention_suggestions) ---
            */
            return default;
        }

        public async Task<TEntity> GetMerchantAccountInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py, METHOD: _get_merchant_account_info) ---
            */
            return default;
        }

        public async Task<TEntity> GetMerchantCategoryCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py, METHOD: _get_merchant_category_code) ---
            */
            return default;
        }

        public async Task<TEntity> GetMergedBatchValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _get_merged_batch_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetMessageCreateIgnoreFieldNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _get_message_create_ignore_field_names) ---
            --- METHOD SOURCE (MODULE: rating, FILE: mail_thread.py, METHOD: _get_message_create_ignore_field_names) ---
            */
            return default;
        }

        public async Task<TEntity> GetMessageCreateValidFieldNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _get_message_create_valid_field_names) ---
            */
            return default;
        }

        public async Task<TEntity> GetMicrodataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _get_microdata) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetModelDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model_name) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _get_model_description) ---
            */
            return default;
        }

        public async Task<TEntity> GetModelSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _get_model_selection) ---
            */
            return default;
        }

        public async Task<TEntity> GetMoneyTransferServicesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _get_money_transfer_services) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMostFrequentAccountForPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, Guid partner_id, object move_type) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _get_most_frequent_account_for_partner) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetMostFrequentAccountsForPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, Guid partner_id, object move_type, object filter_never_user_accounts, object limit) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _get_most_frequent_accounts_for_partner) ---
            */
            return default;
        }

        public async Task<TEntity> GetMoveFinishedValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid product_id, object product_uom_qty, object product_uom, Guid operation_id, Guid byproduct_id, object cost_share) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_move_finished_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetMoveRawValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product, object product_uom_qty, object product_uom, Guid operation_id, object bom_line) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_move_raw_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetMovesFinishedValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_moves_finished_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetMovesRawValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_moves_raw_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetMovesToBackorderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _get_moves_to_backorder) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetNameBackorderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name, object sequence) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_name_backorder) ---
            */
            return default;
        }

        public async Task<TEntity> GetNamePortalContentViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_name_portal_content_view) ---
            */
            return default;
        }

        public async Task<TEntity> GetNameTaxTotalsViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_name_tax_totals_view) ---
            */
            return default;
        }

        public async Task<TEntity> GetNewAccountCodeAsync<TEntity>(IEnumerable<TEntity> entities, object current_code, object old_prefix, object new_prefix) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: get_new_account_code) ---
            */
            return default;
        }

        public async Task<TEntity> GetNewCatalogLineValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid product_id, object quantity) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_new_catalog_line_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetNextAlarmDateAsync<TEntity>(IEnumerable<TEntity> entities, object events_by_alarm) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: get_next_alarm_date) ---
            */
            return default;
        }

        public async Task<TEntity> GetNextBatchPaymentCommunicationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: get_next_batch_payment_communication) ---
            */
            return default;
        }

        public async Task<TEntity> GetNextCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _get_next_category) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetNextJournalDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object journal_type, object company, object cache, object protected_codes) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _get_next_journal_default_code) ---
            */
            return default;
        }

        public async Task<TEntity> GetNextPageOrQuestionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user_input, Guid page_or_question_id, object go_back) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _get_next_page_or_question) ---
            */
            return default;
        }

        public async Task<TEntity> GetNextReportDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: _get_next_report_date) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetNextSerialInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object product) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _get_next_serial) ---
            */
            return default;
        }

        public async Task<TEntity> GetNextSkippedPageOrQuestionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _get_next_skipped_page_or_question) ---
            */
            return default;
        }

        public async Task<TEntity> GetNextStatesByStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _get_next_states_by_state) ---
            */
            return default;
        }

        public async Task<TEntity> GetNextTransfersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _get_next_transfers) ---
            */
            return default;
        }

        public async Task<TEntity> GetNoVariantAttributesPriceExtraInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _get_no_variant_attributes_price_extra) ---
            */
            return default;
        }

        public async Task<TEntity> GetNormalizedWageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _get_normalized_wage) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetNoteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_note_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetNotifyValidParametersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_notify_valid_parameters) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _get_notify_valid_parameters) ---
            --- METHOD SOURCE (MODULE: sms, FILE: mail_thread.py, METHOD: _get_notify_valid_parameters) ---
            */
            return default;
        }

        public async Task<TEntity> GetNumberOfAttemptsLeftsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object email, object invite_token) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _get_number_of_attempts_lefts) ---
            */
            return default;
        }

        public async Task<TEntity> GetOdometerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _get_odometer) ---
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_services.py, METHOD: _get_odometer) ---
            */
            return default;
        }

        public async Task<TEntity> GetOpenOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_open_order) ---
            */
            return default;
        }

        public async Task<TEntity> GetOptOutListInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_opt_out_list) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetOrCreateChatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners_to, object pin) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_or_create_chat) ---
            */
            return default;
        }

        public async Task<TEntity> GetOrderLinesToReportInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
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

        public async Task<TEntity> GetOrderTimezoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: get_order_timezone) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetOrdersToRemindInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_orders_to_remind) ---
            */
            return default;
        }

        public async Task<TEntity> GetOriginInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_origin) ---
            */
            return default;
        }

        public async Task<TEntity> GetOtherRelatedMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_other_related_moves) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetOutgoingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _get_outgoing_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetOvertimesToUpdateDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _get_overtimes_to_update_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetOwnAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> combination_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_own_attribute_exclusions) ---
            */
            return default;
        }

        public async Task<TEntity> GetOwnersInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_badge.py, METHOD: _get_owners_info) ---
            */
            return default;
        }

        public async Task<TEntity> GetPackagesForPrintInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _get_packages_for_print) ---
            */
            return default;
        }

        public async Task<TEntity> GetPagesAndQuestionsToShowInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _get_pages_and_questions_to_show) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPagesOrQuestionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user_input) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _get_pages_or_questions) ---
            */
            return default;
        }

        public async Task<TEntity> GetParentAttributeExclusionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_parent_attribute_exclusions) ---
            */
            return default;
        }

        public async Task<TEntity> GetParentFieldOnChildModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_parent_field_on_child_model) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_parent_field_on_child_model) ---
            */
            return default;
        }

        public async Task<TEntity> GetParentMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _get_parent_message) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnerBankIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_partner_bank_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPricelistMultiFilterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _get_partner_pricelist_multi_filter_hook) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPartnerPricelistMultiInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _get_partner_pricelist_multi) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPricelistMultiSearchDomainHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _get_partner_pricelist_multi_search_domain_hook) ---
            */
            return default;
        }

        public async Task<TEntity> GetPartnersDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_partners_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetPeppolEdiModeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object temporary_eas) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _get_peppol_edi_mode) ---
            */
            return default;
        }

        public async Task<TEntity> GetPeppolWebhookEndpointInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _get_peppol_webhook_endpoint) ---
            */
            return default;
        }

        public async Task<TEntity> GetPickingTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _get_picking_type) ---
            */
            return default;
        }

        public async Task<TEntity> GetPlaceholderFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _get_placeholder_filename) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_placeholder_filename) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _get_placeholder_filename) ---
            */
            return default;
        }

        public async Task<TEntity> GetPortalLastTransactionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: get_portal_last_transaction) ---
            */
            return default;
        }

        public async Task<TEntity> GetPortalReturnActionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_portal_return_action) ---
            */
            return default;
        }

        public async Task<TEntity> GetPosAngloSaxonPriceUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product, Guid partner_id, object quantity) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_pos_anglo_saxon_price_unit) ---
            */
            return default;
        }

        public async Task<TEntity> GetPosUiProductPricelistItemByProductAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> product_tmpl_ids, List<Guid> product_ids, Guid config_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: get_pos_ui_product_pricelist_item_by_product) ---
            */
            return default;
        }

        public async Task<TEntity> GetPossibleCombinationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination, object necessary_values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_possible_combinations) ---
            */
            return default;
        }

        public async Task<TEntity> GetPossibleVariantsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_possible_variants) ---
            */
            return default;
        }

        public async Task<TEntity> GetPreparationChangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: get_preparation_change) ---
            */
            return default;
        }

        public async Task<TEntity> GetPrepaymentRequiredAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_prepayment_required_amount) ---
            */
            return default;
        }

        public async Task<TEntity> GetPrettyMailingTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_pretty_mailing_type) ---
            */
            return default;
        }

        public async Task<TEntity> GetPricedLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_priced_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetPrintQuestionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _get_print_questions) ---
            */
            return default;
        }

        public async Task<TEntity> GetPrintUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: get_print_url) ---
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: get_print_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetProducedQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_produced_qty) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductCatalogDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_product_catalog_domain) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_product_catalog_domain) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _get_product_catalog_domain) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_product_catalog_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductCatalogOrderDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _get_product_catalog_order_data) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_product_catalog_order_data) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_product_catalog_order_data) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _get_product_catalog_order_data) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_product_catalog_order_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductCatalogRecordLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> product_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _get_product_catalog_record_lines) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_product_catalog_record_lines) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_product_catalog_record_lines) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _get_product_catalog_record_lines) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_product_catalog_record_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductDocumentDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_product_document_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_product_documents) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductMultilineDescriptionSaleAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: get_product_multiline_description_sale) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductPlaceholderFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _get_product_placeholder_filename) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_product_placeholder_filename) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductPriceAndDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _get_product_price_and_data) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_product_price_and_data) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_product_price_and_data) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _get_product_price_and_data) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductPriceContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _get_product_price_context) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_product_price_context) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _get_product_price) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductPriceRuleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _get_product_price_rule) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductRuleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _get_product_rule) ---
            */
            return default;
        }

        public async Task<TEntity> GetProductsPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object products) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _get_products_price) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetPublicFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_public_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetPublicUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_public_user) ---
            */
            return default;
        }

        public async Task<TEntity> GetQrCodeBase64InternalAsync<TEntity>(IEnumerable<TEntity> entities, object qr_method, object amount, object currency, object debtor_partner, object free_communication, object structured_communication) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _get_qr_code_base64) ---
            */
            return default;
        }

        public async Task<TEntity> GetQrCodeGenerationParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object qr_method, object amount, object currency, object debtor_partner, object free_communication, object structured_communication) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _get_qr_code_generation_params) ---
            */
            return default;
        }

        public async Task<TEntity> GetQrCodeUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object qr_method, object amount, object currency, object debtor_partner, object free_communication, object structured_communication) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _get_qr_code_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetQrCodeValsListInternalAsync<TEntity>(IEnumerable<TEntity> entities, object qr_method, object amount, object currency, object debtor_partner, object free_communication, object structured_communication) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py, METHOD: _get_qr_code_vals_list) ---
            */
            return default;
        }

        public async Task<TEntity> GetQrValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object qr_method, object amount, object currency, object debtor_partner, object free_communication, object structured_communication) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: _get_qr_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetQuantityProducedIssuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_quantity_produced_issues) ---
            */
            return default;
        }

        public async Task<TEntity> GetQuantityToBackorderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_quantity_to_backorder) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetRandomBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _get_random_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> GetRatioBetweenMoAndBomQuantitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bom) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_ratio_between_mo_and_bom_quantities) ---
            */
            return default;
        }

        public async Task<TEntity> GetReadableFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_readable_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetReadyToProduceStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_ready_to_produce_state) ---
            */
            return default;
        }

        public async Task<TEntity> GetReceivableAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_method) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_receivable_account) ---
            */
            return default;
        }

        public async Task<TEntity> GetRecipientsDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_recipients_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_recipients) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetRecurrenceParamsByDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object event_date) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_recurrence_params_by_date) ---
            */
            return default;
        }

        public async Task<TEntity> GetRecurrenceParamsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_recurrence_params) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetRecurrentFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_recurrent_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetRedirectSuggestedCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _get_redirect_suggested_company) ---
            */
            return default;
        }

        public async Task<TEntity> GetReferenceLastPartAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: get_reference_last_part) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetRefundedOrdersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_refunded_orders) ---
            */
            return default;
        }

        public async Task<TEntity> GetRegistrationSummaryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _get_registration_summary) ---
            */
            return default;
        }

        public async Task<TEntity> GetRelatedAccountMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_related_account_moves) ---
            */
            return default;
        }

        public async Task<TEntity> GetRelatedFieldsVariantTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_related_fields_variant_template) ---
            */
            return default;
        }

        public async Task<TEntity> GetRelatedPostsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object limit) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _get_related_posts) ---
            */
            return default;
        }

        public async Task<TEntity> GetRelationChainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object searched_field_name) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_relation_chain) ---
            */
            return default;
        }

        public async Task<TEntity> GetRemainingRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_remaining_recipients) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetRemoveSyncIdValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_remove_sync_id_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetRenderFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _get_render_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetReportBaseFilenameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _get_report_base_filename) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_report_base_filename) ---
            */
            return default;
        }

        public async Task<TEntity> GetReportLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _get_report_lang) ---
            */
            return default;
        }

        public async Task<TEntity> GetReportTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: _get_report_template) ---
            */
            return default;
        }

        public async Task<TEntity> GetRequestUnitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _get_request_unit) ---
            */
            return default;
        }

        public async Task<TEntity> GetResponsibleForApprovalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _get_responsible_for_approval) ---
            */
            return default;
        }

        public async Task<TEntity> GetRottingDependsFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_tracking_duration_mixin.py, METHOD: _get_rotting_depends_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetRottingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_tracking_duration_mixin.py, METHOD: _get_rotting_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetRoundedAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount, object force_round) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_rounded_amount) ---
            */
            return default;
        }

        public async Task<TEntity> GetRoundingDifferenceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount, object amount_converted) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_rounding_difference_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetRunnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _get_runner) ---
            */
            return default;
        }

        public async Task<TEntity> GetSalaryCostsFactorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _get_salary_costs_factor) ---
            */
            return default;
        }

        public async Task<TEntity> GetSaleKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_sale_key) ---
            */
            return default;
        }

        public async Task<TEntity> GetSaleValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object key, object sale_vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_sale_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetSeatsAvailabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slot_tickets) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_seats_availability) ---
            */
            return default;
        }

        public async Task<TEntity> GetSeenListExtraInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_seen_list_extra) ---
            */
            return default;
        }

        public async Task<TEntity> GetSeenListInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_seen_list) ---
            */
            return default;
        }

        public async Task<TEntity> GetSelectedSuggestedAnswersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _get_selected_suggested_answers) ---
            */
            return default;
        }

        public async Task<TEntity> GetSerializedChallengeLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user, object restrict_goals, object restrict_top) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: _get_serialized_challenge_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetSessionMostVotedAnswersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _get_session_most_voted_answers) ---
            */
            return default;
        }

        public async Task<TEntity> GetSessionNextQuestionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object go_back) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _get_session_next_question) ---
            */
            return default;
        }

        public async Task<TEntity> GetSessionOrdersAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: get_session_orders) ---
            */
            return default;
        }

        public async Task<TEntity> GetShowAllocationInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid picking_type_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _get_show_allocation) ---
            */
            return default;
        }

        public async Task<TEntity> GetSignatureInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _get_signature) ---
            */
            return default;
        }

        public async Task<TEntity> GetSingleProductVariantAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: get_single_product_variant) ---
            */
            return default;
        }

        public async Task<TEntity> GetSkippedQuestionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _get_skipped_questions) ---
            */
            return default;
        }

        public async Task<TEntity> GetSmsApiClassInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: res_company.py, METHOD: _get_sms_api_class) ---
            --- METHOD SOURCE (MODULE: sms_twilio, FILE: res_company.py, METHOD: _get_sms_api_class) ---
            */
            return default;
        }

        public async Task<TEntity> GetSocialMediaLinksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: res_company.py, METHOD: _get_social_media_links) ---
            --- METHOD SOURCE (MODULE: website_mass_mailing, FILE: res_company.py, METHOD: _get_social_media_links) ---
            */
            return default;
        }

        public async Task<TEntity> GetSourceFromRefInternalAsync<TEntity>(IEnumerable<TEntity> entities, object source_ref) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _get_source_from_ref) ---
            */
            return default;
        }

        public async Task<TEntity> GetSourcesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _get_sources) ---
            */
            return default;
        }

        public async Task<TEntity> GetSplitReceivableValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment, object amount, object amount_converted) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_split_receivable_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetSplitStatementLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object journal, object amount, object payment) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_split_statement_line_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetStartDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_start_date) ---
            */
            return default;
        }

        public async Task<TEntity> GetStartShortUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: get_start_short_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetStartUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: get_start_url) ---
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: get_start_url) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetStateSelectionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: get_state_selections) ---
            */
            return default;
        }

        public async Task<TEntity> GetStockExpenseValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object exp_account, object amount, object amount_converted) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_stock_expense_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetStockValuationAccountValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object accounts_by_product, object at_date, object extra_aml_vals_list) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: _get_stock_valuation_account_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetStockValuationValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stock_val_account, object amount, object amount_converted) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_stock_valuation_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetStoreMessageUpdateExtraFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _get_store_message_update_extra_fields) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _get_store_message_update_extra_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetStructuredDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object post_type) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _get_structured_data) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetSupportedAccountTypesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_bank.py, METHOD: get_supported_account_types) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetSupportedAccountTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_iban, FILE: res_partner_bank.py, METHOD: _get_supported_account_types) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_bank.py, METHOD: _get_supported_account_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetSupportedLangCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _get_supported_lang_codes) ---
            */
            return default;
        }

        public async Task<TEntity> GetSurveyQuestionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object answer, Guid page_id, Guid question_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _get_survey_questions) ---
            */
            return default;
        }

        public async Task<TEntity> GetTagsFirstCharInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tags) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _get_tags_first_char) ---
            */
            return default;
        }

        public async Task<TEntity> GetTargetedMoveIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py, METHOD: _get_targeted_move_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetTaxDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price_unit, object quantity, object precision_rounding, object rounding_method, object product, object product_uom, object special_mode, object manual_tax_amounts, object filter_tax_function) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _get_tax_details) ---
            */
            return default;
        }

        public async Task<TEntity> GetTaxTagsAsync<TEntity>(IEnumerable<TEntity> entities, object is_refund, object repartition_type) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: get_tax_tags) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTaxTotalsSummaryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object currency, object company, object cash_rounding) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _get_tax_totals_summary) ---
            */
            return default;
        }

        public async Task<TEntity> GetTaxValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object key, object amount, object amount_converted, object base_amount_converted) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_tax_vals) ---
            */
            return default;
        }

        public async Task<TEntity> GetTextValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object confirmation_type) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: _get_text_validation) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetThreadWithAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid thread_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _get_thread_with_access) ---
            --- METHOD SOURCE (MODULE: portal, FILE: mail_thread.py, METHOD: _get_thread_with_access) ---
            */
            return default;
        }

        public async Task<TEntity> GetTicketsAccessHashInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> registration_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _get_tickets_access_hash) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetTimeFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_time_fields) ---
            */
            return default;
        }

        public async Task<TEntity> GetTimeUpdateDictInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_event, object time_values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_time_update_dict) ---
            */
            return default;
        }

        public async Task<TEntity> GetTitleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _get_title) ---
            */
            return default;
        }

        public async Task<TEntity> GetTopNUsersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object n) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: _get_topN_users) ---
            */
            return default;
        }

        public async Task<TEntity> GetTotalDiscountAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: get_total_discount) ---
            */
            return default;
        }

        public async Task<TEntity> GetTotalInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _get_total_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> GetTrackCalendarDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_track_calendar_description) ---
            */
            return default;
        }

        public async Task<TEntity> GetTrackCalendarReminderDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_track_calendar_reminder_dates) ---
            */
            return default;
        }

        public async Task<TEntity> GetTrackCalendarReminderTimesWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_track_calendar_reminder_times_warning) ---
            */
            return default;
        }

        public async Task<TEntity> GetTrackCalendarUrlsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_track_calendar_urls) ---
            */
            return default;
        }

        public async Task<TEntity> GetTrackSuggestionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object restrict_domain, object limit) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _get_track_suggestions) ---
            */
            return default;
        }

        public async Task<TEntity> GetTriggerAlarmTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_trigger_alarm_types) ---
            */
            return default;
        }

        public async Task<TEntity> GetTriggerSpecificFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _get_trigger_specific_field) ---
            */
            return default;
        }

        public async Task<TEntity> GetTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _get_tz) ---
            */
            return default;
        }

        public async Task<TEntity> GetUnaffectedEarningsAccountAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: get_unaffected_earnings_account) ---
            */
            return default;
        }

        public async Task<TEntity> GetUnavailabilityIntervalsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_datetime, object end_datetime) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _get_unavailability_intervals) ---
            */
            return default;
        }

        public async Task<TEntity> GetUnreconciledStatementLinesDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object last_date) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _get_unreconciled_statement_lines_domain) ---
            */
            return default;
        }

        public async Task<TEntity> GetUnreconciledStatementLinesRedirectActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object unreconciled_statement_lines) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _get_unreconciled_statement_lines_redirect_action) ---
            */
            return default;
        }

        public async Task<TEntity> GetUnsubscribeOneclickUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_to, Guid res_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_unsubscribe_oneclick_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetUnsubscribeUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_to, Guid res_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_unsubscribe_url) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetUpdateFutureEventsValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_update_future_events_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetUpdatePricesLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _get_update_prices_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetUpdateUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: get_update_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetUpdatedRecurrenceValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_start_date) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _get_updated_recurrence_values) ---
            */
            return default;
        }

        public async Task<TEntity> GetUrlFromResIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid res_id, object suffix) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _get_url_from_res_id) ---
            */
            return default;
        }

        public async Task<TEntity> GetUsedAccountIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _get_used_account_ids) ---
            */
            return default;
        }

        public async Task<TEntity> GetUserFiscalLockDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object journal, object ignore_exceptions) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _get_user_fiscal_lock_date) ---
            */
            return default;
        }

        public async Task<TEntity> GetUserLockDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object soft_lock_date_field, object ignore_exceptions) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _get_user_lock_date) ---
            */
            return default;
        }

        public async Task<TEntity> GetValidEmployeeForUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _get_valid_employee_for_user) ---
            */
            return default;
        }

        public async Task<TEntity> GetValidSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _get_valid_session) ---
            */
            return default;
        }

        public async Task<TEntity> GetValuationLinesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py, METHOD: get_valuation_lines) ---
            */
            return default;
        }

        public async Task<TEntity> GetValuesFromContractTemplateAsync<TEntity>(IEnumerable<TEntity> entities, Guid contract_template_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: get_values_from_contract_template) ---
            */
            return default;
        }

        public async Task<TEntity> GetVariantForCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_variant_for_combination) ---
            */
            return default;
        }

        public async Task<TEntity> GetVariantIdForCombinationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object filtered_combination) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_variant_id_for_combination) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_company.py, METHOD: _get_view) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _get_view) ---
            */
            return default;
        }

        public async Task<TEntity> GetViewUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_to, Guid res_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _get_view_url) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewsAsync<TEntity>(IEnumerable<TEntity> entities, object views, object options) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: get_views) ---
            */
            return default;
        }

        public async Task<TEntity> GetViolatedLockDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object accounting_date, object has_tax, object journal) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _get_violated_lock_dates) ---
            */
            return default;
        }

        public async Task<TEntity> GetViolatedSoftLockDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object soft_lock_date_field, object date) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _get_violated_soft_lock_date) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetVolumeUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_volume_uom_id_from_ir_config_parameter) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetVolumeUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_volume_uom_name_from_ir_config_parameter) ---
            */
            return default;
        }

        public async Task<TEntity> GetWarningMessagesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _get_warning_messages) ---
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_actions_server.py, METHOD: _get_website_url) ---
            */
            return default;
        }

        public async Task<TEntity> GetWeekDateRangeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _get_week_date_range) ---
            */
            return default;
        }

        public async Task<TEntity> GetWeekRangeAndFirstLastDaysInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _get_week_range_and_first_last_days) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetWeightUomIdFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_weight_uom_id_from_ir_config_parameter) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetWeightUomNameFromIrConfigParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _get_weight_uom_name_from_ir_config_parameter) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetWhitelistFieldsFromTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _get_whitelist_fields_from_template) ---
            */
            return default;
        }

        public async Task<TEntity> GetWithoutQuantitiesErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _get_without_quantities_error_message) ---
            */
            return default;
        }

        public async Task<TEntity> GetWorkcenterLoadPerWeekInternalAsync<TEntity>(IEnumerable<TEntity> entities, object week_range, object date_start, object date_stop) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _get_workcenter_load_per_week) ---
            */
            return default;
        }

        public async Task<TEntity> GetYearSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _get_year_selection) ---
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py, METHOD: _get_year_selection) ---
            */
            return default;
        }

        public async Task<TEntity> GoToWebsiteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: go_to_website) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: go_to_website) ---
            */
            return default;
        }

        public async Task<TEntity> GoogleMapImgAsync<TEntity>(IEnumerable<TEntity> entities, object zoom, object width, object height) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_company.py, METHOD: google_map_img) ---
            */
            return default;
        }

        public async Task<TEntity> GoogleMapLinkAsync<TEntity>(IEnumerable<TEntity> entities, object zoom) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: res_company.py, METHOD: google_map_link) ---
            */
            return default;
        }

        public async Task<TEntity> HandleCertificationBadgesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _handle_certification_badges) ---
            */
            return default;
        }

        public async Task<TEntity> HasAttemptsLeftInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object email, object invite_token) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _has_attempts_left) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> HasDemoDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: has_demo_data) ---
            */
            return default;
        }

        public async Task<TEntity> HasDynamicAttributesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: has_dynamic_attributes) ---
            */
            return default;
        }

        public async Task<bool> HasMultipleUomsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _has_multiple_uoms) ---
            */
            return default;
        }

        public async Task<TEntity> HasScrapMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _has_scrap_move) ---
            */
            return default;
        }

        public async Task<TEntity> HasSourceOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _has_source_order) ---
            */
            return default;
        }

        public async Task<TEntity> HasToBePaidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _has_to_be_paid) ---
            */
            return default;
        }

        public async Task<TEntity> HasToBeSignedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _has_to_be_signed) ---
            */
            return default;
        }

        public async Task<TEntity> HasTriggerOnchangeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _has_trigger_onchange) ---
            */
            return default;
        }

        public async Task<TEntity> HasWorkordersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _has_workorders) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> HashIapTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object key) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: iap, FILE: iap_account.py, METHOD: _hash_iap_token) ---
            */
            return default;
        }

        public async Task<TEntity> HaveUnauthorizedPeppolParentCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _have_unauthorized_peppol_parent_company) ---
            */
            return default;
        }

        public async Task<TEntity> HistoryWizardActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: history_wizard_action) ---
            */
            return default;
        }

        public async Task<TEntity> HookComputeIsUsedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_to_compute) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _hook_compute_is_used) ---
            */
            return default;
        }

        public async Task<TEntity> IapEnrichAutoAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_company.py, METHOD: iap_enrich_auto) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ImportBaseLineExtraTaxDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line, object extra_tax_data) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _import_base_line_extra_tax_data) ---
            */
            return default;
        }

        public async Task<TEntity> InitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: mail_thread_phone.py, METHOD: init) ---
            */
            return default;
        }

        public async Task<TEntity> InitColumnInternalAsync<TEntity>(IEnumerable<TEntity> entities, object column_name) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: res_company.py, METHOD: _init_column) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> InitDataResourceCalendarInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: res_company.py, METHOD: _init_data_resource_calendar) ---
            */
            return default;
        }

        public async Task<TEntity> InitiateAccountOnboardingsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _initiate_account_onboardings) ---
            */
            return default;
        }

        public async Task<TEntity> InstallL10nModulesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: install_l10n_modules) ---
            */
            return default;
        }

        public async Task<TEntity> InverseAccrualPlanIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _inverse_accrual_plan_id) ---
            */
            return default;
        }

        public async Task<TEntity> InverseChannelPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _inverse_channel_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> InverseCityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_city) ---
            */
            return default;
        }

        public async Task<TEntity> InverseCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _inverse_code) ---
            */
            return default;
        }

        public async Task<TEntity> InverseColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_color) ---
            */
            return default;
        }

        public async Task<TEntity> InverseCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_country) ---
            */
            return default;
        }

        public async Task<TEntity> InverseDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _inverse_date) ---
            */
            return default;
        }

        public async Task<TEntity> InverseDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _inverse_dates) ---
            */
            return default;
        }

        public async Task<TEntity> InverseEndDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _inverse_end_date) ---
            */
            return default;
        }

        public async Task<TEntity> InverseIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _inverse_is_favorite) ---
            */
            return default;
        }

        public async Task<TEntity> InverseJobTitleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _inverse_job_title) ---
            */
            return default;
        }

        public async Task<TEntity> InverseKmHomeWorkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _inverse_km_home_work) ---
            */
            return default;
        }

        public async Task<TEntity> InverseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _inverse_lines) ---
            */
            return default;
        }

        public async Task<TEntity> InverseMemberIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _inverse_member_ids) ---
            */
            return default;
        }

        public async Task<TEntity> InverseMessagePartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _inverse_message_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> InverseModelNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _inverse_model_name) ---
            */
            return default;
        }

        public async Task<TEntity> InversePeppolPurchaseJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _inverse_peppol_purchase_journal_id) ---
            */
            return default;
        }

        public async Task<TEntity> InversePeppolSelfBillingReceptionJournalIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _inverse_peppol_self_billing_reception_journal_id) ---
            */
            return default;
        }

        public async Task<TEntity> InversePricelistRuleIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _inverse_pricelist_rule_ids) ---
            */
            return default;
        }

        public async Task<TEntity> InverseResourceCalendarIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _inverse_resource_calendar_id) ---
            */
            return default;
        }

        public async Task<TEntity> InverseStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_state) ---
            */
            return default;
        }

        public async Task<TEntity> InverseStreet2InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_street2) ---
            */
            return default;
        }

        public async Task<TEntity> InverseStreetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_street) ---
            */
            return default;
        }

        public async Task<TEntity> InverseZipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _inverse_zip) ---
            */
            return default;
        }

        public async Task<TEntity> InviteByEmailAsync<TEntity>(IEnumerable<TEntity> entities, object emails) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: invite_by_email) ---
            */
            return default;
        }

        public async Task<TEntity> IsCombinationPossibleByConfigInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object ignore_no_variant) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _is_combination_possible_by_config) ---
            */
            return default;
        }

        public async Task<TEntity> IsCombinationPossibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination, object parent_combination, object ignore_no_variant) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _is_combination_possible) ---
            */
            return default;
        }

        public async Task<TEntity> IsConfirmationAmountReachedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _is_confirmation_amount_reached) ---
            */
            return default;
        }

        public async Task<TEntity> IsDisplayStockInCatalogInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _is_display_stock_in_catalog) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _is_display_stock_in_catalog) ---
            */
            return default;
        }

        public async Task<TEntity> IsEventOverInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _is_event_over) ---
            */
            return default;
        }

        public async Task<TEntity> IsFirstPageOrQuestionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object page_or_question) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _is_first_page_or_question) ---
            */
            return default;
        }

        public async Task<TEntity> IsFullyFlexibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _is_fully_flexible) ---
            */
            return default;
        }

        public async Task<TEntity> IsInContractInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _is_in_contract) ---
            */
            return default;
        }

        public async Task<TEntity> IsLastPageOrQuestionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user_input, object page_or_question) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _is_last_page_or_question) ---
            */
            return default;
        }

        public async Task<TEntity> IsLastSkippedPageOrQuestionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object page_or_question) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _is_last_skipped_page_or_question) ---
            */
            return default;
        }

        public async Task<TEntity> IsLineAutoMergeableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object num_of_moves, object num_of_pickings, object weight) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _is_line_auto_mergeable) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> IsNotificationScheduledInternalAsync<TEntity>(IEnumerable<TEntity> entities, object notify_scheduled_date) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _is_notification_scheduled) ---
            */
            return default;
        }

        public async Task<TEntity> IsOverlappingPeriodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _is_overlapping_period) ---
            */
            return default;
        }

        public async Task<TEntity> IsPaidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _is_paid) ---
            */
            return default;
        }

        public async Task<TEntity> IsPartnerUnavailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object partner_events) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _is_partner_unavailable) ---
            */
            return default;
        }

        public async Task<TEntity> IsPaymentMethodAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_method_code, object complete_domain) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _is_payment_method_available) ---
            */
            return default;
        }

        public async Task<TEntity> IsPickingAutoMergeableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object picking) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _is_picking_auto_mergeable) ---
            */
            return default;
        }

        public async Task<TEntity> IsPosOrderPaidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _is_pos_order_paid) ---
            */
            return default;
        }

        public async Task<TEntity> IsReadonlyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _is_readonly) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _is_readonly) ---
            */
            return default;
        }

        public async Task<TEntity> IsRecomputeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _is_recompute) ---
            */
            return default;
        }

        public async Task<TEntity> IsRottingFeatureEnabledInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_tracking_duration_mixin.py, METHOD: _is_rotting_feature_enabled) ---
            */
            return default;
        }

        public async Task<TEntity> IsSingleTransferInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _is_single_transfer) ---
            */
            return default;
        }

        public async Task<TEntity> IsStructFromCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country_code) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _is_struct_from_country) ---
            */
            return default;
        }

        public async Task<TEntity> IsToExternalLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _is_to_external_location) ---
            */
            return default;
        }

        public async Task<TEntity> IsVariantPossibleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_combination) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _is_variant_possible) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LangGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _lang_get) ---
            */
            return default;
        }

        public async Task<TEntity> LazyLoadMembersChannelTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _lazy_load_members_channel_types) ---
            */
            return default;
        }

        public async Task<TEntity> LessQuantitiesThanExpectedAddDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves, object documents) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _less_quantities_than_expected_add_documents) ---
            */
            return default;
        }

        public async Task<TEntity> LinkBomInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bom) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _link_bom) ---
            */
            return default;
        }

        public async Task<TEntity> LinkWorkordersAndMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _link_workorders_and_moves) ---
            */
            return default;
        }

        public async Task<TEntity> LinkedOvertimesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _linked_overtimes) ---
            */
            return default;
        }

        public async Task<TEntity> LoadDataAsync<TEntity>(IEnumerable<TEntity> entities, object models_to_load) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: load_data) ---
            */
            return default;
        }

        public async Task<TEntity> LoadDataParamsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: load_data_params) ---
            */
            return default;
        }

        public async Task<TEntity> LoadDemoDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _load_demo_data) ---
            */
            return default;
        }

        public async Task<TEntity> LoadFieldsFromModelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields_to_load) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _load_fields_from_model) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _load_pos_data_domain) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _load_pos_data_domain) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object config) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _load_pos_data_fields) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataModelsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object config) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _load_pos_data_models) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPosDataRelationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object model, object fields) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _load_pos_data_relations) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> LoadPrecommitUpdateOpeningMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _load_precommit_update_opening_move) ---
            */
            return default;
        }

        public async Task<TEntity> LoadRecordsWriteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _load_records_write) ---
            */
            return default;
        }

        public async Task<TEntity> LogActivityGetDocumentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object orig_obj_changes, object stream_field, object stream, object groupby_method) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _log_activity_get_documents) ---
            */
            return default;
        }

        public async Task<TEntity> LogActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object render_method, object documents) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _log_activity) ---
            */
            return default;
        }

        public async Task<TEntity> LogDownsideManufacturedQuantityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves_modification, object cancel) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _log_downside_manufactured_quantity) ---
            */
            return default;
        }

        public async Task<TEntity> LogLessQuantitiesThanExpectedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _log_less_quantities_than_expected) ---
            */
            return default;
        }

        public async Task<TEntity> LogManufactureExceptionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object documents, object cancel) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _log_manufacture_exception) ---
            */
            return default;
        }

        public async Task<TEntity> LogPartnerMessageAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id, object action, object message_type) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: log_partner_message) ---
            */
            return default;
        }

        public async Task<TEntity> MailActionBlacklistRemoveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_blacklist.py, METHOD: mail_action_blacklist_remove) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_blacklist.py, METHOD: mail_action_blacklist_remove) ---
            */
            return default;
        }

        public async Task<TEntity> MailCcSanitizedRawDictInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cc_string) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_cc.py, METHOD: _mail_cc_sanitized_raw_dict) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MailFindPartnerFromEmailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object emails, object records, object force_create, object extra_domain) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _mail_find_partner_from_emails) ---
            */
            return default;
        }

        public async Task<TEntity> MailFindUserForGatewayInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_value, object @alias) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _mail_find_user_for_gateway) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetOperationForMailMessageOperationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message_operation) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _mail_get_operation_for_mail_message_operation) ---
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _mail_get_operation_for_mail_message_operation) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _mail_get_operation_for_mail_message_operation) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_badge_user.py, METHOD: _mail_get_partner_fields) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _mail_get_partner_fields) ---
            */
            return default;
        }

        public async Task<TEntity> MailGetTimezoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _mail_get_timezone) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MailTemplateDefaultValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _mail_template_default_values) ---
            */
            return default;
        }

        public async Task<TEntity> MarkAsOffensiveBatchAsync<TEntity>(IEnumerable<TEntity> entities, object key, object values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: mark_as_offensive_batch) ---
            */
            return default;
        }

        public async Task<TEntity> MarkAsOffensiveInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid reason_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _mark_as_offensive) ---
            */
            return default;
        }

        public async Task<TEntity> MarkByproductsAsProducedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _mark_byproducts_as_produced) ---
            */
            return default;
        }

        public async Task<TEntity> MarkDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _mark_done) ---
            */
            return default;
        }

        public async Task<TEntity> MarkInProgressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _mark_in_progress) ---
            */
            return default;
        }

        public async Task<TEntity> MarkupListMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _markup_list_message) ---
            */
            return default;
        }

        public async Task<TEntity> MemberBasedNamingChannelTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _member_based_naming_channel_types) ---
            */
            return default;
        }

        public async Task<TEntity> MergeAlternativePoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object rfqs) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _merge_alternative_po) ---
            */
            return default;
        }

        public async Task<TEntity> MergeMethodInternalAsync<TEntity>(IEnumerable<TEntity> entities, object destination, object source) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _merge_method) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MergeTaxDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_details_1, object tax_details_2) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _merge_tax_details) ---
            */
            return default;
        }

        public async Task<TEntity> MessageAddDefaultRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _message_add_default_recipients) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _message_add_default_recipients) ---
            */
            return default;
        }

        public async Task<TEntity> MessageAddSuggestedRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_primary_email) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_cc.py, METHOD: _message_add_suggested_recipients) ---
            */
            return default;
        }

        public async Task<TEntity> MessageAutoSubscribeFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_values, List<Guid> default_subtype_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_auto_subscribe_followers) ---
            */
            return default;
        }

        public async Task<TEntity> MessageAutoSubscribeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_values, object followers_existing_policy) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_auto_subscribe) ---
            */
            return default;
        }

        public async Task<TEntity> MessageAutoSubscribeNotifyInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids, object template) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_auto_subscribe_notify) ---
            */
            return default;
        }

        public async Task<TEntity> MessageChangeThreadAsync<TEntity>(IEnumerable<TEntity> entities, object new_thread, object new_parent_message) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: message_change_thread) ---
            */
            return default;
        }

        public async Task<TEntity> MessageComputeAuthorInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid author_id, object email_from) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_compute_author) ---
            */
            return default;
        }

        public async Task<TEntity> MessageComputeParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid parent_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_compute_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> MessageComputeRealAuthorInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid author_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_compute_real_author) ---
            */
            return default;
        }

        public async Task<TEntity> MessageComputeSubjectInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _message_compute_subject) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_compute_subject) ---
            */
            return default;
        }

        public async Task<TEntity> MessageCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values_list) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_create) ---
            */
            return default;
        }

        public async Task<TEntity> MessageFollowersToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, object after, object limit, object filter_recipients, object reset) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_followers_to_store) ---
            */
            return default;
        }

        public async Task<TEntity> MessageGetFollowersAsync<TEntity>(IEnumerable<TEntity> entities, object after, object limit, object filter_recipients) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: message_get_followers) ---
            */
            return default;
        }

        public async Task<TEntity> MessageLogBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object bodies, object subject, Guid author_id, object email_from, object message_type, List<Guid> partner_ids, List<Guid> attachment_ids, List<Guid> tracking_value_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_log_batch) ---
            */
            return default;
        }

        public async Task<TEntity> MessageLogInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _message_log) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_log) ---
            */
            return default;
        }

        public async Task<TEntity> MessageLogRepartitionLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object old_values_str, object new_values_str) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _message_log_repartition_lines) ---
            */
            return default;
        }

        public async Task<TEntity> MessageLogWithViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view_ref, object render_values, object message_type) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_log_with_view) ---
            */
            return default;
        }

        public async Task<TEntity> MessageMailAfterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mails) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_mail_after_hook) ---
            */
            return default;
        }

        public async Task<TEntity> MessageMailWithSourceAsync<TEntity>(IEnumerable<TEntity> entities, object source_ref) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: message_mail_with_source) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mail_thread.py, METHOD: message_mail_with_source) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MessageNewAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object custom_values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: message_new) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_cc.py, METHOD: message_new) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mail_thread.py, METHOD: message_new) ---
            */
            return default;
        }

        public async Task<TEntity> MessageNotifyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: message_notify) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MessageParseAsync<TEntity>(IEnumerable<TEntity> entities, object message, object save_original) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: message_parse) ---
            */
            return default;
        }

        public async Task<TEntity> MessageParseExtractBounceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_message, object message_dict) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_parse_extract_bounce) ---
            */
            return default;
        }

        public async Task<TEntity> MessageParseExtractFromParentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parent_message) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_parse_extract_from_parent) ---
            */
            return default;
        }

        public async Task<TEntity> MessageParseExtractPayloadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, Dictionary<string, object> message_dict, bool save_original) where TEntity : IEntity<Guid>, IMailThreadable
        {
            #if PYTHON_CODE
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_parse_extract_payload) ---
            #endif
            return default;
        }

        public async Task<TEntity> MessageParseExtractPayloadPostprocessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object payload_dict) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_parse_extract_payload_postprocess) ---
            */
            return default;
        }

        public async Task<TEntity> MessageParsePostProcessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object message_dict, object routes) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_parse_post_process) ---
            */
            return default;
        }

        public async Task<TEntity> MessagePostAfterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _message_post_after_hook) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _message_post_after_hook) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_post_after_hook) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_main_attachment.py, METHOD: _message_post_after_hook) ---
            --- METHOD SOURCE (MODULE: rating, FILE: mail_thread.py, METHOD: _message_post_after_hook) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _message_post_after_hook) ---
            */
            return default;
        }

        public async Task<TEntity> MessagePostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: message_post) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: message_post) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: message_post) ---
            --- METHOD SOURCE (MODULE: rating, FILE: mail_thread.py, METHOD: message_post) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: message_post) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: message_post) ---
            --- METHOD SOURCE (MODULE: sms, FILE: mail_thread.py, METHOD: message_post) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: message_post) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: message_post) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: message_post) ---
            */
            return default;
        }

        public async Task<TEntity> MessagePostWithSourceAsync<TEntity>(IEnumerable<TEntity> entities, object source_ref) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: message_post_with_source) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mail_thread.py, METHOD: message_post_with_source) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MessageProcessAsync<TEntity>(IEnumerable<TEntity> entities, object model, object message, object custom_values, object save_original, object strip_attachments, Guid thread_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: message_process) ---
            */
            return default;
        }

        public async Task<TEntity> MessageReceiveBounceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, object partner) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _message_receive_bounce) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_receive_bounce) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_blacklist.py, METHOD: _message_receive_bounce) ---
            */
            return default;
        }

        public async Task<TEntity> MessageResetBounceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_reset_bounce) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_blacklist.py, METHOD: _message_reset_bounce) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MessageRouteAsync<TEntity>(IEnumerable<TEntity> entities, object message, object message_dict, object model, Guid thread_id, object custom_values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: message_route) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MessageRouteProcessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object message_dict, object routes) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_route_process) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mail_thread.py, METHOD: _message_route_process) ---
            */
            return default;
        }

        public async Task<TEntity> MessageSetMainAttachmentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachments, object force, object filter_xml) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_main_attachment.py, METHOD: _message_set_main_attachment_id) ---
            */
            return default;
        }

        public async Task<TEntity> MessageSmsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object body, Guid subtype_id, List<Guid> partner_ids, object number_field, object sms_numbers, object sms_pid_to_number) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: mail_thread.py, METHOD: _message_sms) ---
            */
            return default;
        }

        public async Task<TEntity> MessageSmsScheduleMassInternalAsync<TEntity>(IEnumerable<TEntity> entities, object body, object template) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: mail_thread.py, METHOD: _message_sms_schedule_mass) ---
            */
            return default;
        }

        public async Task<TEntity> MessageSmsWithTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template, object template_xmlid, object template_fallback, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: mail_thread.py, METHOD: _message_sms_with_template) ---
            */
            return default;
        }

        public async Task<TEntity> MessageSubscribeAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids, List<Guid> subtype_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: message_subscribe) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: message_subscribe) ---
            */
            return default;
        }

        public async Task<TEntity> MessageSubscribeInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids, List<Guid> subtype_ids, List<Guid> customer_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _message_subscribe) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_subscribe) ---
            */
            return default;
        }

        public async Task<TEntity> MessageTrackInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields_iter, object initial_values_dict) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_track) ---
            */
            return default;
        }

        public async Task<TEntity> MessageTrackPostTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changes) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_track_post_template) ---
            */
            return default;
        }

        public async Task<TEntity> MessageUnsubscribeAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: message_unsubscribe) ---
            */
            return default;
        }

        public async Task<TEntity> MessageUpdateAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object update_vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: message_update) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_cc.py, METHOD: message_update) ---
            */
            return default;
        }

        protected async Task<object> MessageUpdateContentInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _message_update_content) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _message_update_content) ---
            --- METHOD SOURCE (MODULE: rating, FILE: mail_thread.py, METHOD: _message_update_content) ---
            */
            return default;
        }

        public async Task<TEntity> MultipleChoiceQuestionAnswerResultInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user_input_lines, object question_correct_suggested_answers) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _multiple_choice_question_answer_result) ---
            */
            return default;
        }

        public async Task<TEntity> MustDeleteDatePlannedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _must_delete_date_planned) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NameCreateAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: name_create) ---
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: name_create) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: name_create) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_category.py, METHOD: name_create) ---
            */
            return default;
        }

        public async Task<TEntity> NameDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _name_depends) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NameSearchAsync<TEntity>(IEnumerable<TEntity> entities, object name, object domain, object @operator, object limit) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: name_search) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: name_search) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: name_search) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: name_search) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NormalizeTargetFactorsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_factors) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _normalize_target_factors) ---
            */
            return default;
        }

        public async Task<TEntity> NothingToInvoiceErrorMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _nothing_to_invoice_error_message) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyAdminInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_cron.py, METHOD: _notify_admin) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailGetBaseMailValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object recipients_data, object additional_values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _notify_by_email_get_base_mail_values) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailGetBaseNotificationValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _notify_by_email_get_base_notification_values) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailGetFinalMailValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> recipient_ids, object mail_values, object additional_values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _notify_by_email_get_final_mail_values) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailPrepareRenderingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals, object model_description, object force_email_company, object force_email_lang, object force_record_name) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _notify_by_email_prepare_rendering_context) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _notify_by_email_prepare_rendering_context) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _notify_by_email_prepare_rendering_context) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailRenderLayoutInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object recipients_group, object msg_vals, object render_values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _notify_by_email_render_layout) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyByWebPushPreparePayloadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals, object force_record_name) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _notify_by_web_push_prepare_payload) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _notify_by_web_push_prepare_payload) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> NotifyCancelByTypeAsync<TEntity>(IEnumerable<TEntity> entities, object notification_type) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: notify_cancel_by_type) ---
            --- METHOD SOURCE (MODULE: sms, FILE: mail_thread.py, METHOD: notify_cancel_by_type) ---
            --- METHOD SOURCE (MODULE: snailmail, FILE: mail_thread.py, METHOD: notify_cancel_by_type) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyCancelByTypeGenericInternalAsync<TEntity>(IEnumerable<TEntity> entities, object notification_type) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _notify_cancel_by_type_generic) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyCancelSnailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: snailmail, FILE: mail_thread.py, METHOD: _notify_cancel_snail) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyEinvoicesReceivedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object moves) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _notify_einvoices_received) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetActionLinkInternalAsync<TEntity>(IEnumerable<TEntity> entities, object link_type) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _notify_get_action_link) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetClassifiedRecipientsIteratorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object recipients_data, object msg_vals, object model_description, object force_email_company, object force_email_lang, object force_record_name, object subtitles) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _notify_get_classified_recipients_iterator) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsClassifyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object recipients_data, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _notify_get_recipients_classify) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsForExtraNotificationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object recipients_data, object msg_vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _notify_get_recipients_for_extra_notifications) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsFillupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object groups, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _notify_get_recipients_groups_fillup) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_badge_user.py, METHOD: _notify_get_recipients_groups) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _notify_get_recipients_groups) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _notify_get_recipients_groups) ---
            --- METHOD SOURCE (MODULE: portal, FILE: mail_thread.py, METHOD: _notify_get_recipients_groups) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _notify_get_recipients_groups) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _notify_get_recipients_groups) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _notify_get_recipients_groups) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _notify_get_recipients_groups) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _notify_get_recipients) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _notify_get_recipients) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyInvoiceSubscribersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object mail_params) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _notify_invoice_subscribers) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyNewParticipationSubscribersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _notify_new_participation_subscribers) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyStateUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _notify_state_update) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyThreadByEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object recipients_data) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _notify_thread_by_email) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyThreadByInboxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object recipients_data, object msg_vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _notify_thread_by_inbox) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _notify_thread_by_inbox) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _notify_thread_by_inbox) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyThreadBySmsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object recipients_data, object msg_vals, object sms_content, object sms_numbers, object sms_pid_to_number, object put_in_queue) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: mail_thread.py, METHOD: _notify_thread_by_sms) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyThreadByWebPushInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object recipients_data, object msg_vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _notify_thread_by_web_push) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _notify_thread_by_web_push) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyThreadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _notify_thread) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _notify_thread) ---
            --- METHOD SOURCE (MODULE: sms, FILE: mail_thread.py, METHOD: _notify_thread) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyThreadWithOutOfOfficeGetAdditionalUsersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object recipients_data, object ooo_author, object msg_vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _notify_thread_with_out_of_office_get_additional_users) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyThreadWithOutOfOfficeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object recipients_data, object msg_vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _notify_thread_with_out_of_office) ---
            */
            return default;
        }

        public async Task<TEntity> NotifyWebsiteManagerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _notify_website_manager) ---
            */
            return default;
        }

        public async Task<TEntity> OnChangeDocumentBinaryContentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _on_change_document_binary_content) ---
            */
            return default;
        }

        public async Task<TEntity> OnChangeSlideCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _on_change_slide_category) ---
            */
            return default;
        }

        public async Task<TEntity> OnChangeUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _on_change_url) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAccountAssetAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: onchange_account_asset) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAccountTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _onchange_account_type) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAllocationTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _onchange_allocation_type) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAmountAllInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _onchange_amount_all) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAmountAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: onchange_amount) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAmountTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: onchange_amount_type) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeAsync<TEntity>(IEnumerable<TEntity> entities, object values, object field_names, object fields_spec) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: onchange) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: onchange) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: onchange) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeBomStructureAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: onchange_bom_structure) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCategoryIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: onchange_category_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCategoryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _onchange_category_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCategoryIdValuesAsync<TEntity>(IEnumerable<TEntity> entities, Guid category_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: onchange_category_id_values) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCommitmentDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_commitment_date) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: onchange_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_company_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_company_id_warning) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeCountryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _onchange_country_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeDateFirstDepreciationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: onchange_date_first_depreciation) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeDateFromInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _onchange_date_from) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _onchange_date) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeDatePlannedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: onchange_date_planned) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _onchange_default_code) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_default_code) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _onchange_domain) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeEventInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _onchange_event) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeEventUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _onchange_event_url) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeFposIdShowUpdateFposInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_fpos_id_show_update_fpos) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeIncomingEinvoiceNotificationEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _onchange_incoming_einvoice_notification_email) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeLocationIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _onchange_location_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeLocationPickingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _onchange_location_picking) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeLotProducingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _onchange_lot_producing) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeMethodTimeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: onchange_method_time) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeMethodTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _onchange_method_time) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _onchange_name) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _onchange_name) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeOrderLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_order_line) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _onchange_parent_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePartnerIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: onchange_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _onchange_partner_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePhoneValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _onchange_phone_validation) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePickingTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _onchange_picking_type) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePrepaymentPercentInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_prepayment_percent) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePriceIncludeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: onchange_price_include) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangePricelistIdShowUpdatePricesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _onchange_pricelist_id_show_update_prices) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeProductIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _onchange_product_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeProductTmplIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: onchange_product_tmpl_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeProductUomAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: onchange_product_uom) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeQtyProducingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _onchange_qty_producing) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeRestrictUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _onchange_restrict_user_ids) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeScheduledDateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: onchange_scheduled_date) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeSeatsMaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _onchange_seats_max) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeSerialNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: _onchange_serial_number) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeSessionSpeedRatingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _onchange_session_speed_rating) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _onchange_standard_price) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_standard_price) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: _onchange_state) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeSurveyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _onchange_survey_type) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTargetModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py, METHOD: _onchange_target_model) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTrgDateRangeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _onchange_trg_date_range_data) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTriggerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _onchange_trigger) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTriggerOrActionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _onchange_trigger_or_actions) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: onchange_type) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _onchange_type) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_type) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeUomIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _onchange_uom_id) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _onchange_uom_id) ---
            */
            return default;
        }

        public async Task<TEntity> OnchangeVendorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: _onchange_vendor) ---
            */
            return default;
        }

        public async Task<TEntity> OpenAssignationLogsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: open_assignation_logs) ---
            */
            return default;
        }

        public async Task<TEntity> OpenEntriesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: open_entries) ---
            */
            return default;
        }

        public async Task<TEntity> OpenFrontendCbAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: open_frontend_cb) ---
            */
            return default;
        }

        public async Task<TEntity> OpenProductTemplateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: open_product_template) ---
            */
            return default;
        }

        public async Task<TEntity> OpenTrackSpeakersListAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: open_track_speakers_list) ---
            */
            return default;
        }

        public async Task<TEntity> OpeningMovePostedAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: opening_move_posted) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> OrderAccountsByFrequencyForPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid company_id, Guid partner_id, object move_type) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _order_accounts_by_frequency_for_partner) ---
            */
            return default;
        }

        public async Task<object> OrderToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, string order, object query, object @alias, bool reverse) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _order_to_sql) ---
            */
            return default;
        }

        public async Task<TEntity> ParseMailingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _parse_mailing_domain) ---
            */
            return default;
        }

        protected async Task<object> ParseNameSearchInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _parse_name_search) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PartitionBaseLinesTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object partition_function) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _partition_base_lines_taxes) ---
            */
            return default;
        }

        public async Task<TEntity> PartnerFindFromEmailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records_emails, object avoid_alias, object ban_emails, object filter_found, object additional_values, object no_create) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _partner_find_from_emails) ---
            */
            return default;
        }

        public async Task<TEntity> PartnerFindFromEmailsSingleInternalAsync<TEntity>(IEnumerable<TEntity> entities, object emails, object avoid_alias, object ban_emails, object filter_found, object additional_values, object no_create) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _partner_find_from_emails_single) ---
            */
            return default;
        }

        public async Task<TEntity> PaymentActionCaptureAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: payment_action_capture) ---
            */
            return default;
        }

        public async Task<TEntity> PaymentActionVoidAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: payment_action_void) ---
            */
            return default;
        }

        public async Task<TEntity> PeppolModulesDocumentTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _peppol_modules_document_types) ---
            */
            return default;
        }

        public async Task<TEntity> PeppolSupportedDocumentTypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _peppol_supported_document_types) ---
            */
            return default;
        }

        public async Task<TEntity> PhoneActionBlacklistRemoveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: mail_thread_phone.py, METHOD: phone_action_blacklist_remove) ---
            --- METHOD SOURCE (MODULE: phone_validation, FILE: phone_blacklist.py, METHOD: phone_action_blacklist_remove) ---
            */
            return default;
        }

        public async Task<TEntity> PhoneGetNumberFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _phone_get_number_fields) ---
            */
            return default;
        }

        public async Task<TEntity> PhoneGetSanitizeTriggersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: mail_thread_phone.py, METHOD: _phone_get_sanitize_triggers) ---
            */
            return default;
        }

        public async Task<TEntity> PhoneResetBlacklistedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: mail_thread_phone.py, METHOD: _phone_reset_blacklisted) ---
            */
            return default;
        }

        public async Task<TEntity> PhoneSetBlacklistedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: mail_thread_phone.py, METHOD: _phone_set_blacklisted) ---
            */
            return default;
        }

        public async Task<TEntity> PlanWorkordersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object replan) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _plan_workorders) ---
            */
            return default;
        }

        public async Task<TEntity> PortalGetParentHashTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object pid) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: portal, FILE: mail_thread.py, METHOD: _portal_get_parent_hash_token) ---
            */
            return default;
        }

        public async Task<TEntity> PosHasValidProductInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _pos_has_valid_product) ---
            */
            return default;
        }

        public async Task<TEntity> PostCashDetailsMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object state, object expected, object difference, object notes) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _post_cash_details_message) ---
            */
            return default;
        }

        public async Task<TEntity> PostCloseRegisterMessageAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: post_close_register_message) ---
            */
            return default;
        }

        public async Task<TEntity> PostClosingCashDetailsAsync<TEntity>(IEnumerable<TEntity> entities, object counted_cash) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: post_closing_cash_details) ---
            */
            return default;
        }

        public async Task<TEntity> PostConfirmationMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py, METHOD: _post_confirmation_message) ---
            */
            return default;
        }

        public async Task<TEntity> PostInventoryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object cancel_backorder) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _post_inventory) ---
            */
            return default;
        }

        public async Task<TEntity> PostPublicationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _post_publication) ---
            */
            return default;
        }

        public async Task<TEntity> PostRunManufactureInternalAsync<TEntity>(IEnumerable<TEntity> entities, object post_production_values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _post_run_manufacture) ---
            */
            return default;
        }

        public async Task<TEntity> PostStatementDifferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _post_statement_difference) ---
            */
            return default;
        }

        public async Task<TEntity> PreActionDoneHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _pre_action_done_hook) ---
            */
            return default;
        }

        public async Task<TEntity> PreActionSplitMergeHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object merge, object split) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _pre_action_split_merge_hook) ---
            */
            return default;
        }

        public async Task<TEntity> PreButtonMarkDoneAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: pre_button_mark_done) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareAccountBankStatementLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object session, object sign, object amount, object reason, Guid partner_id, object extras) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _prepare_account_bank_statement_line_vals) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareAmlValuesListPerNatureInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_aml_values_list_per_nature) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareAnalyticAccountDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object prefix) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _prepare_analytic_account_data) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareBalancingLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object imbalance_amount, object move, object balancing_account) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _prepare_balancing_line_vals) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareBaseLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _prepare_base_line_for_taxes_computation) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareBaseLineGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _prepare_base_line_grouping_key) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareBaseLineTaxRepartitionGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line, object base_line_grouping_key, object tax_data, object tax_rep_data) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _prepare_base_line_tax_repartition_grouping_key) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareBaseLinesForDownPaymentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company, object exclude_function) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _prepare_base_lines_for_down_payment) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareChallengeCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _prepare_challenge_category) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareConfirmationValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _prepare_confirmation_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareCreditAccountValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object code, object vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _prepare_credit_account_vals) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareDiscountableBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company, object exclude_function) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _prepare_discountable_base_lines) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareDownPaymentLineSectionValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _prepare_down_payment_line_section_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareDownPaymentLineValuesFromBaseLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _prepare_down_payment_line_values_from_base_line) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareDownPaymentLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company, object amount_type, object amount, object computation_key, object grouping_function) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _prepare_down_payment_lines) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareDownPaymentSectionLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _prepare_down_payment_section_line) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareDownPaymentSectionValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _prepare_down_payment_section_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareEntirePackMoveLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object packages) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _prepare_entire_pack_move_line_vals) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareFinishedExtraValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _prepare_finished_extra_vals) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareFinishedMoveLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object finished_move) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: _prepare_finished_move_line_vals) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareGlobalDiscountLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company, object amount_type, object amount, object computation_key, object grouping_function) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _prepare_global_discount_lines) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareGmcAdditionalInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _prepare_gmc_additional_info) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareGmcIdentifierInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _prepare_gmc_identifier) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareGmcImageLinksInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product, object base_url) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _prepare_gmc_image_links) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareGmcItemsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _prepare_gmc_items) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareGmcPriceInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _prepare_gmc_price_info) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareGmcStockInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object _product) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _prepare_gmc_stock_info) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareGraphDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object load_data, object week_range) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: _prepare_graph_data) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareGroupedDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object rfq) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _prepare_grouped_data) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareInventoryAmlValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object debit_acc, object credit_acc, object balance, object @ref, Guid product_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: _prepare_inventory_aml_vals) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _prepare_invoice) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _prepare_invoice) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoiceLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move_type) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_invoice_lines) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareInvoiceValsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_invoice_vals) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareLeaderboardValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _prepare_leaderboard_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareLiquidityAccountValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object code, object vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _prepare_liquidity_account_vals) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareLogginValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _prepare_loggin_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareMailValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, object ticket, object basic_ticket) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_mail_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareMergeOrigLinksInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _prepare_merge_orig_links) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareMoveLineValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object move, object origin_move_line, object taken_quantity) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: _prepare_move_line_vals) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareMoveValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: _prepare_move_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object picking_type, object sequence_code, Guid company_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _prepare_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PreparePartnerContactDetailsHtmlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object section_title, object partner) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _prepare_partner_contact_details_html) ---
            */
            return default;
        }

        public async Task<TEntity> PreparePosLogInternalAsync<TEntity>(IEnumerable<TEntity> entities, object body) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_pos_log) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareProductAmlDictInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line_vals, object update_base_line_vals, object rate, object sign) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_product_aml_dict) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareRefundValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object current_session) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_refund_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareResourceCalendarValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: resource, FILE: res_company.py, METHOD: _prepare_resource_calendar_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareSellersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @params) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _prepare_sellers) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareStatementLineAmountValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object journal, object amount) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _prepare_statement_line_amount_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareStatisticsEmailValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _prepare_statistics_email_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _prepare_statistics) ---
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _prepare_statistics) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareStockLotValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _prepare_stock_lot_values) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareSupplierInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object line, object price, object currency) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _prepare_supplier_info) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareTaxBaseLineValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _prepare_tax_base_line_values) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareTaxLineForTaxesComputationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _prepare_tax_line_for_taxes_computation) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareTaxLineRepartitionGroupingKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax_line) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _prepare_tax_line_repartition_grouping_key) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PrepareTaxLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company, object tax_lines) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _prepare_tax_lines) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareTooltipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _prepare_tooltip) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareUserInputPredefinedQuestionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _prepare_user_input_predefined_questions) ---
            */
            return default;
        }

        public async Task<TEntity> PrepareVariantValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object combination) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _prepare_variant_values) ---
            */
            return default;
        }

        public async Task<TEntity> PriceComputeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object price_type, object uom, object currency, object company, object date) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _price_compute) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _price_compute) ---
            */
            return default;
        }

        public async Task<TEntity> PriceGetInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product, object quantity) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _price_get) ---
            */
            return default;
        }

        public async Task<TEntity> PrintQuotationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: print_quotation) ---
            */
            return default;
        }

        public async Task<TEntity> PrintRepairOrderAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: print_repair_order) ---
            */
            return default;
        }

        public async Task<TEntity> ProcessAccrualPlanLevelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object level, object start_period, object start_date, object end_period, object end_date) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _process_accrual_plan_level) ---
            */
            return default;
        }

        public async Task<TEntity> ProcessAccrualPlansInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_to, object force_period, object log) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _process_accrual_plans) ---
            */
            return default;
        }

        public async Task<TEntity> ProcessAttachmentsForPostInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attachments, List<Guid> attachment_ids, object message_values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _process_attachments_for_post) ---
            */
            return default;
        }

        public async Task<TEntity> ProcessAttachmentsForTemplatePostInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_template) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _process_attachments_for_template_post) ---
            */
            return default;
        }

        public async Task<TEntity> ProcessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records, object domain_post) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _process) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ProcessMassMailingQueueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: _process_mass_mailing_queue) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ProcessOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order, object existing_order) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _process_order) ---
            */
            return default;
        }

        public async Task<TEntity> ProcessPaymentLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object pos_order, object order, object pos_session, object draft) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _process_payment_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ProcessReferenceForSaleOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order_reference) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _process_reference_for_sale_order) ---
            */
            return default;
        }

        public async Task<TEntity> ProcessSavedOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object draft) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _process_saved_order) ---
            */
            return default;
        }

        public async Task<TEntity> ProductQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _product_qty) ---
            */
            return default;
        }

        public async Task<TEntity> PropagateExtraTaxesBaseInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tax, object taxes_data, object special_mode) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _propagate_extra_taxes_base) ---
            */
            return default;
        }

        public async Task<TEntity> RaiseForInvalidParametersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object parameter_names, object forbidden_names, object restricting_names) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _raise_for_invalid_parameters) ---
            */
            return default;
        }

        public async Task<TEntity> RangeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _range) ---
            */
            return default;
        }

        public async Task<TEntity> RatingApplyAsync<TEntity>(IEnumerable<TEntity> entities, object rate, object token, object rating, object feedback, object subtype_xmlid, object notify_delay_send) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: mail_thread.py, METHOD: rating_apply) ---
            */
            return default;
        }

        public async Task<TEntity> RatingApplyGetDefaultSubtypeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: mail_thread.py, METHOD: _rating_apply_get_default_subtype_id) ---
            */
            return default;
        }

        public async Task<TEntity> RatingDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: _rating_domain) ---
            */
            return default;
        }

        public async Task<TEntity> RatingGetAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: mail_thread.py, METHOD: _rating_get_access_token) ---
            */
            return default;
        }

        public async Task<TEntity> RatingGetGradesAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: rating_get_grades) ---
            */
            return default;
        }

        public async Task<TEntity> RatingGetOperatorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: mail_thread.py, METHOD: _rating_get_operator) ---
            */
            return default;
        }

        public async Task<TEntity> RatingGetParentFieldNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: _rating_get_parent_field_name) ---
            */
            return default;
        }

        public async Task<TEntity> RatingGetPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: mail_thread.py, METHOD: _rating_get_partner) ---
            */
            return default;
        }

        public async Task<TEntity> RatingGetRepartitionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object add_stats, object domain) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: _rating_get_repartition) ---
            */
            return default;
        }

        public async Task<TEntity> RatingGetStatsAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: rating_get_stats) ---
            */
            return default;
        }

        public async Task<TEntity> RatingGetStatsPerRecordInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: _rating_get_stats_per_record) ---
            */
            return default;
        }

        public async Task<TEntity> RatingSendRequestAsync<TEntity>(IEnumerable<TEntity> entities, object template, object lang, object force_send) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: mail_thread.py, METHOD: rating_send_request) ---
            */
            return default;
        }

        public async Task<TEntity> ReadGroupCategIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object categories, object domain) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _read_group_categ_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReadGroupCategoryIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object categories, object domain) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _read_group_category_ids) ---
            */
            return default;
        }

        public async Task<TEntity> ReadGroupEmployeeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object resources, object domain) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _read_group_employee_id) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<List<object>> ReadGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object groupby, object aggregates, object having, object offset, object limit, object order) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _read_group) ---
            */
            return default;
        }

        public async Task<TEntity> ReadGroupLocationIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object locations, object domain) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _read_group_location_id) ---
            */
            return default;
        }

        public async Task<TEntity> ReadGroupPostprocessAggregateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object aggregate_spec, object raw_values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_account.py, METHOD: _read_group_postprocess_aggregate) ---
            */
            return default;
        }

        public async Task<TEntity> ReadGroupSelectInternalAsync<TEntity>(IEnumerable<TEntity> entities, object aggregate_spec, object query) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_account.py, METHOD: _read_group_select) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<List<object>> ReadGroupingSetsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object grouping_sets, object aggregates, object order) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _read_grouping_sets) ---
            */
            return default;
        }

        public async Task<TEntity> ReadPosDataAsync<TEntity>(IEnumerable<TEntity> entities, object data, object config) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: read_pos_data) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReadPosDataUuidAsync<TEntity>(IEnumerable<TEntity> entities, object uuid) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: read_pos_data_uuid) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReadPosOrdersAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: read_pos_orders) ---
            */
            return default;
        }

        public async Task<TEntity> RecNamesSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _rec_names_search) ---
            */
            return default;
        }

        public async Task<TEntity> RecomputeChallengeUsersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: _recompute_challenge_users) ---
            */
            return default;
        }

        public async Task<TEntity> RecomputePricesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _recompute_prices) ---
            */
            return default;
        }

        public async Task<TEntity> RecomputeTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _recompute_taxes) ---
            */
            return default;
        }

        public async Task<TEntity> ReconcileAccountMoveLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _reconcile_account_move_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ReconcileInvoicePaymentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object invoice, object payment_moves) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _reconcile_invoice_payments) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReduceBaseLinesToTargetAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company, object amount_type, object amount, object computation_key, object grouping_function, object aggregate_function) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _reduce_base_lines_to_target_amount) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReduceBaseLinesWithGroupingFunctionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object grouping_function, object aggregate_function, object computation_key) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _reduce_base_lines_with_grouping_function) ---
            */
            return default;
        }

        public async Task<TEntity> ReflectCodePrefixChangeAsync<TEntity>(IEnumerable<TEntity> entities, object old_code, object new_code) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: reflect_code_prefix_change) ---
            */
            return default;
        }

        public async Task<TEntity> RefundAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: refund) ---
            */
            return default;
        }

        public async Task<TEntity> RefundInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _refund) ---
            */
            return default;
        }

        public async Task<TEntity> RefuseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _refuse) ---
            */
            return default;
        }

        public async Task<TEntity> RegenerateAttendanceKioskKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: res_company.py, METHOD: _regenerate_attendance_kiosk_key) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RegisterAttendeeAsync<TEntity>(IEnumerable<TEntity> entities, object barcode, Guid event_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: register_attendee) ---
            */
            return default;
        }

        public async Task<TEntity> RegisterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _register_hook) ---
            */
            return default;
        }

        public async Task<TEntity> RemainingSendingCalcInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_badge.py, METHOD: _remaining_sending_calc) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RemoveAccentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @string) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py, METHOD: _remove_accents) ---
            */
            return default;
        }

        public async Task<TEntity> RemoveAsync<TEntity>(IEnumerable<TEntity> entities, object number, object message) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: phone_blacklist.py, METHOD: remove) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RemoveFromUiAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> server_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: remove_from_ui) ---
            */
            return default;
        }

        public async Task<TEntity> RemoveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object numbers, object message) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_blacklist.py, METHOD: _remove) ---
            --- METHOD SOURCE (MODULE: phone_validation, FILE: phone_blacklist.py, METHOD: _remove) ---
            */
            return default;
        }

        public async Task<TEntity> RemoveReferenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reference) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _remove_reference) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _remove_reference) ---
            */
            return default;
        }

        public async Task<TEntity> RenderAndCacheCompressedGmcFeedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _render_and_cache_compressed_gmc_feed) ---
            */
            return default;
        }

        public async Task<TEntity> RenderGmcFeedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_sale, FILE: product_feed.py, METHOD: _render_gmc_feed) ---
            */
            return default;
        }

        public async Task<TEntity> ReopenAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: reopen) ---
            */
            return default;
        }

        public async Task<TEntity> ReportProgressAsync<TEntity>(IEnumerable<TEntity> entities, object users, object subset_goals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: report_progress) ---
            */
            return default;
        }

        public async Task<TEntity> ResequenceWorkordersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _resequence_workorders) ---
            */
            return default;
        }

        public async Task<TEntity> ResetAttendeesStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _reset_attendees_status) ---
            */
            return default;
        }

        public async Task<TEntity> ResetPeppolConfigurationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object soft) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _reset_peppol_configuration) ---
            */
            return default;
        }

        public async Task<TEntity> RestrictExpirationOnLoyaltyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _restrict_expiration_on_loyalty) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RetrieveAccTypeAsync<TEntity>(IEnumerable<TEntity> entities, object acc_number) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_iban, FILE: res_partner_bank.py, METHOD: retrieve_acc_type) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_bank.py, METHOD: retrieve_acc_type) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RetrieveDashboardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: retrieve_dashboard) ---
            */
            return default;
        }

        public async Task<TEntity> ReturnActionToOpenAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: return_action_to_open) ---
            */
            return default;
        }

        public async Task<TEntity> ReturnDisposalViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> move_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: _return_disposal_view) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReverseQuantityBaseLineExtraTaxDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object extra_tax_data) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _reverse_quantity_base_line_extra_tax_data) ---
            */
            return default;
        }

        public async Task<TEntity> RewardUserInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user, object badge) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: _reward_user) ---
            */
            return default;
        }

        public async Task<TEntity> RewriteRecurrenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values, object time_values, object recurrence_values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _rewrite_recurrence) ---
            */
            return default;
        }

        public async Task<TEntity> RoundAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amounts) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _round_amounts) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RoundBaseLinesTaxDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company, object tax_lines) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _round_base_lines_tax_details) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RoundLastLineDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities, object lines_done) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _round_last_line_done) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RoundRawTaxAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines_aggregated_values, object company, object precision_digits, object apply_strict_tolerance, object in_foreign_currency) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _round_raw_tax_amounts) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RoundRawTotalExcludedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company, object precision_digits, object apply_strict_tolerance, object in_foreign_currency) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _round_raw_total_excluded) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RoundTaxDetailsBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company, object mode) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _round_tax_details_base_lines) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RoundTaxDetailsTaxAmountsFromTaxLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company, object tax_lines) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _round_tax_details_tax_amounts_from_tax_lines) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RoundTaxDetailsTaxAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company, object mode) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _round_tax_details_tax_amounts) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RoutingCheckRouteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object message_dict, object route, object raise_exception) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _routing_check_route) ---
            */
            return default;
        }

        public async Task<TEntity> RoutingCreateBounceEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_from, object body_html, object message) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _routing_create_bounce_email) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RoutingHandleBounceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_message, object message_dict) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _routing_handle_bounce) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mail_thread.py, METHOD: _routing_handle_bounce) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> RoutingResetBounceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_message, object message_dict) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _routing_reset_bounce) ---
            */
            return default;
        }

        public async Task<TEntity> RoutingWarnInternalAsync<TEntity>(IEnumerable<TEntity> entities, object error_message, Guid message_id, object route, object raise_exception) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _routing_warn) ---
            */
            return default;
        }

        public async Task<TEntity> RtcCancelInvitationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> member_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _rtc_cancel_invitations) ---
            */
            return default;
        }

        public async Task<TEntity> RunActionCodeMultiInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website, FILE: ir_actions_server.py, METHOD: _run_action_code_multi) ---
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _run_action_code_multi) ---
            */
            return default;
        }

        public async Task<TEntity> RunActionFollowersMultiInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _run_action_followers_multi) ---
            */
            return default;
        }

        public async Task<TEntity> RunActionMailPostMultiInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _run_action_mail_post_multi) ---
            */
            return default;
        }

        public async Task<TEntity> RunActionMultiInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _run_action_multi) ---
            */
            return default;
        }

        public async Task<TEntity> RunActionNextActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _run_action_next_activity) ---
            */
            return default;
        }

        public async Task<TEntity> RunActionObjectCopyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _run_action_object_copy) ---
            */
            return default;
        }

        public async Task<TEntity> RunActionObjectCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _run_action_object_create) ---
            */
            return default;
        }

        public async Task<TEntity> RunActionObjectWriteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _run_action_object_write) ---
            */
            return default;
        }

        public async Task<TEntity> RunActionRemoveFollowersMultiInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _run_action_remove_followers_multi) ---
            */
            return default;
        }

        public async Task<TEntity> RunActionSmsMultiInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: ir_actions_server.py, METHOD: _run_action_sms_multi) ---
            */
            return default;
        }

        public async Task<TEntity> RunActionWebhookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object eval_context) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _run_action_webhook) ---
            */
            return default;
        }

        public async Task<TEntity> RunAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: run) ---
            */
            return default;
        }

        public async Task<TEntity> RunInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records, object eval_context) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _run) ---
            */
            return default;
        }

        public async Task<TEntity> RunSchedulerAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py, METHOD: run_scheduler) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SanitizePeppolEndpointInValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _sanitize_peppol_endpoint_in_values) ---
            */
            return default;
        }

        public async Task<TEntity> SanitizePeppolPhoneNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object phone_number) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py, METHOD: _sanitize_peppol_phone_number) ---
            */
            return default;
        }

        public async Task<TEntity> SanitizeValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _sanitize_vals) ---
            */
            return default;
        }

        public async Task<TEntity> SanityCheckInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _sanity_check) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _sanity_check) ---
            */
            return default;
        }

        public async Task<TEntity> SaveClosingIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid move_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: _save_closing_id) ---
            */
            return default;
        }

        public async Task<TEntity> SaveLineChoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object question, object old_answers, object answers, object comment) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _save_line_choice) ---
            */
            return default;
        }

        public async Task<TEntity> SaveLineMatrixInternalAsync<TEntity>(IEnumerable<TEntity> entities, object question, object old_answers, object answers, object comment) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _save_line_matrix) ---
            */
            return default;
        }

        public async Task<TEntity> SaveLineSimpleAnswerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object question, object old_answers, object answer) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _save_line_simple_answer) ---
            */
            return default;
        }

        public async Task<TEntity> SaveLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object question, object answer, object comment, object overwrite_existing) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _save_lines) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SchedulerManageContractExpirationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py, METHOD: scheduler_manage_contract_expiration) ---
            */
            return default;
        }

        public async Task<TEntity> SearchAccNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_bank.py, METHOD: _search_acc_number) ---
            */
            return default;
        }

        public async Task<TEntity> SearchAccountRootInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _search_account_root) ---
            */
            return default;
        }

        public async Task<TEntity> SearchAddressSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _search_address_search) ---
            */
            return default;
        }

        public async Task<TEntity> SearchAllProductTagIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _search_all_product_tag_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchAvailableTodayInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py, METHOD: _search_available_today) ---
            */
            return default;
        }

        public async Task<TEntity> SearchBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _search_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> SearchCanViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _search_can_view) ---
            */
            return default;
        }

        public async Task<TEntity> SearchChannelPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _search_channel_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _search_code) ---
            */
            return default;
        }

        public async Task<TEntity> SearchCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: _search_complete_name) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchComponentsAvailabilityStateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _search_components_availability_state) ---
            */
            return default;
        }

        public async Task<TEntity> SearchContractRenewalDueSoonInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _search_contract_renewal_due_soon) ---
            */
            return default;
        }

        public async Task<TEntity> SearchCurrentAttendeeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _search_current_attendee) ---
            */
            return default;
        }

        public async Task<TEntity> SearchDateCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _search_date_category) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _search_date_category) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _search_date_category) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchDelayAlertDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _search_delay_alert_date) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _search_delay_alert_date) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _search_display_name) ---
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py, METHOD: _search_display_name) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _search_display_name) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _search_display_name) ---
            */
            return default;
        }

        public async Task<TEntity> SearchEmployeeIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner_bank.py, METHOD: _search_employee_id) ---
            */
            return default;
        }

        public async Task<TEntity> SearchEndDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _search_end_date) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchEventBeginDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _search_event_begin_date) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchEventEndDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _search_event_end_date) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchGetDetailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website, object order, object options) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_tag.py, METHOD: _search_get_detail) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _search_get_detail) ---
            */
            return default;
        }

        public async Task<TEntity> SearchGetOverdueContractReminderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _search_get_overdue_contract_reminder) ---
            */
            return default;
        }

        public async Task<TEntity> SearchHasMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _search_has_message) ---
            */
            return default;
        }

        public async Task<TEntity> SearchHasReadAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: _search_has_read_access) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIncludeInitialBalanceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _search_include_initial_balance) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _search) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_blacklist.py, METHOD: _search) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _search) ---
            */
            return default;
        }

        public async Task<TEntity> SearchInternalGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _search_internal_group) ---
            */
            return default;
        }

        public async Task<TEntity> SearchInvoiceIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _search_invoice_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py, METHOD: _search_is_available) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchIsBlacklistedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_blacklist.py, METHOD: _search_is_blacklisted) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsDelayedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _search_is_delayed) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _search_is_finished) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsInSelectedSectionOfOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _search_is_in_selected_section_of_order) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsLateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _search_is_late) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _search_is_member) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsOngoingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _search_is_ongoing) ---
            */
            return default;
        }

        public async Task<TEntity> SearchIsRottingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_tracking_duration_mixin.py, METHOD: _search_is_rotting) ---
            */
            return default;
        }

        public async Task<TEntity> SearchMemberIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _search_member_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchMessageHasErrorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _search_message_has_error) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchMessageHasSmsErrorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sms, FILE: mail_thread.py, METHOD: _search_message_has_sms_error) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchMessageIsFollowerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _search_message_is_follower) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchMessageNeedactionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _search_message_needaction) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchMessagePartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _search_message_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchMoveLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _search_move_line_ids) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchNewAccountCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_code, object cache) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _search_new_account_code) ---
            */
            return default;
        }

        public async Task<TEntity> SearchNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: phone_blacklist.py, METHOD: _search_number) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchPaidOrderIdsAsync<TEntity>(IEnumerable<TEntity> entities, Guid config_id, object domain, object limit, object offset) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: search_paid_order_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchPanelDomainImageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object domain, object set_count, object limit) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _search_panel_domain_image) ---
            */
            return default;
        }

        public async Task<TEntity> SearchPartOfDepartmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _search_part_of_department) ---
            */
            return default;
        }

        public async Task<TEntity> SearchPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _search_partner_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SearchPhoneMobileSearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: mail_thread_phone.py, METHOD: _search_phone_mobile_search) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchPhoneSanitizedBlacklistedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: phone_validation, FILE: mail_thread_phone.py, METHOD: _search_phone_sanitized_blacklisted) ---
            */
            return default;
        }

        public async Task<TEntity> SearchPlaceholderCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _search_placeholder_code) ---
            */
            return default;
        }

        public async Task<TEntity> SearchPriceIncludeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _search_price_include) ---
            */
            return default;
        }

        public async Task<TEntity> SearchProductQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _search_product_qty) ---
            */
            return default;
        }

        public async Task<TEntity> SearchProductsAvailabilityStateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _search_products_availability_state) ---
            */
            return default;
        }

        public async Task<TEntity> SearchProjectAllowMilestonesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: _search_project_allow_milestones) ---
            */
            return default;
        }

        public async Task<TEntity> SearchRatingAvgInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: _search_rating_avg) ---
            */
            return default;
        }

        public async Task<TEntity> SearchRenderResultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fetch_fields, object mapping, object icon, object limit) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _search_render_results) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _search_render_results) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _search_render_results) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _search_render_results) ---
            */
            return default;
        }

        public async Task<TEntity> SearchStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _search_standard_price) ---
            */
            return default;
        }

        public async Task<TEntity> SearchStartDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _search_start_date) ---
            */
            return default;
        }

        public async Task<TEntity> SearchTimeBasedAutomationRecordsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _search_time_based_automation_records) ---
            */
            return default;
        }

        public async Task<TEntity> SearchUsedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _search_used) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchVehicleCountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py, METHOD: _search_vehicle_count) ---
            */
            return default;
        }

        public async Task<TEntity> SearchWishlistVisitorIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _search_wishlist_visitor_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SelectExpectedDateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object expected_dates) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _select_expected_date) ---
            */
            return default;
        }

        public async Task<TEntity> SelectSellerInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid partner_id, object quantity, object date, Guid uom_id, object ordered_by, object @params) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _select_seller) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SelectionTargetModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _selection_target_model) ---
            */
            return default;
        }

        public async Task<TEntity> SendAutoEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py, METHOD: _send_auto_email) ---
            */
            return default;
        }

        public async Task<TEntity> SendBadgeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_badge_user.py, METHOD: _send_badge) ---
            */
            return default;
        }

        public async Task<TEntity> SendConfirmationEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _send_confirmation_email) ---
            */
            return default;
        }

        public async Task<TEntity> SendCreationCommunicationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_send) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _send_creation_communication) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SendErrorNotificationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object title) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: iap_mail, FILE: iap_account.py, METHOD: _send_error_notification) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SendNoCreditNotificationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object service_name, object title) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: iap_mail, FILE: iap_account.py, METHOD: _send_no_credit_notification) ---
            */
            return default;
        }

        public async Task<TEntity> SendOrderConfirmationMailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _send_order_confirmation_mail) ---
            */
            return default;
        }

        public async Task<TEntity> SendOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _send_order) ---
            */
            return default;
        }

        public async Task<TEntity> SendOrderNotificationMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object mail_template, object allow_deferred_sending) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _send_order_notification_mail) ---
            */
            return default;
        }

        public async Task<TEntity> SendPaymentSucceededForOrderMailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _send_payment_succeeded_for_order_mail) ---
            */
            return default;
        }

        public async Task<TEntity> SendPointsReachCommunicationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object points_changes) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: _send_points_reach_communication) ---
            */
            return default;
        }

        public async Task<TEntity> SendReminderMailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object send_single) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _send_reminder_mail) ---
            */
            return default;
        }

        public async Task<TEntity> SendReminderOpenComposerInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid template_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _send_reminder_open_composer) ---
            */
            return default;
        }

        public async Task<TEntity> SendReminderPreviewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: send_reminder_preview) ---
            */
            return default;
        }

        public async Task<TEntity> SendShareEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, object fullscreen) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: _send_share_email) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SendStatusNotificationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object status, object title) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: iap_mail, FILE: iap_account.py, METHOD: _send_status_notification) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SendSuccessNotificationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object title) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: iap_mail, FILE: iap_account.py, METHOD: _send_success_notification) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SerializeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object header, object @value) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account_qr_code_emv, FILE: res_bank.py, METHOD: _serialize) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<List<object>> ServiceTrackingBlacklistInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _service_tracking_blacklist) ---
            */
            return default;
        }

        public async Task<TEntity> SessionOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: _session_open) ---
            */
            return default;
        }

        public async Task<TEntity> SetBankAccountAsync<TEntity>(IEnumerable<TEntity> entities, object acc_number, Guid bank_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: set_bank_account) ---
            */
            return default;
        }

        public async Task<TEntity> SetBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_barcode) ---
            */
            return default;
        }

        public async Task<TEntity> SetCategoryDefaultsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _set_category_defaults) ---
            */
            return default;
        }

        public async Task<TEntity> SetCrudModelIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _set_crud_model_id) ---
            */
            return default;
        }

        public async Task<TEntity> SetDefaultCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_default_code) ---
            */
            return default;
        }

        public async Task<TEntity> SetDefaultFaqInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _set_default_faq) ---
            */
            return default;
        }

        public async Task<TEntity> SetDiscussVideocallLocationAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: set_discuss_videocall_location) ---
            */
            return default;
        }

        public async Task<TEntity> SetDiscussVideocallLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _set_discuss_videocall_location) ---
            */
            return default;
        }

        public async Task<TEntity> SetImage1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _set_image_1920) ---
            */
            return default;
        }

        public async Task<TEntity> SetMessagePinAsync<TEntity>(IEnumerable<TEntity> entities, Guid message_id, object pinned) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: set_message_pin) ---
            */
            return default;
        }

        public async Task<TEntity> SetMoveByproductIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _set_move_byproduct_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SetMoveLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _set_move_line_ids) ---
            */
            return default;
        }

        public async Task<TEntity> SetOdometerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _set_odometer) ---
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_services.py, METHOD: _set_odometer) ---
            */
            return default;
        }

        public async Task<TEntity> SetOpeningBalanceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _set_opening_balance) ---
            */
            return default;
        }

        public async Task<TEntity> SetOpeningControlAsync<TEntity>(IEnumerable<TEntity> entities, int cashbox_value, string notes) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: set_opening_control) ---
            */
            return default;
        }

        public async Task<TEntity> SetOpeningControlDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, int cashbox_value, string notes) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _set_opening_control_data) ---
            */
            return default;
        }

        public async Task<TEntity> SetOpeningCreditInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _set_opening_credit) ---
            */
            return default;
        }

        public async Task<TEntity> SetOpeningDebitCreditInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amount, object field) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _set_opening_debit_credit) ---
            */
            return default;
        }

        public async Task<TEntity> SetOpeningDebitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _set_opening_debit) ---
            */
            return default;
        }

        public async Task<TEntity> SetOutdatedBomInProductionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _set_outdated_bom_in_productions) ---
            */
            return default;
        }

        public async Task<TEntity> SetPerCompanyInterCompanyLocationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object inter_company_location) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: res_company.py, METHOD: _set_per_company_inter_company_locations) ---
            */
            return default;
        }

        public async Task<TEntity> SetPostDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _set_post_date) ---
            */
            return default;
        }

        public async Task<TEntity> SetProductLstPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _set_product_lst_price) ---
            */
            return default;
        }

        public async Task<TEntity> SetProductVariantFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_product_variant_field) ---
            */
            return default;
        }

        public async Task<TEntity> SetQtyProducingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: set_qty_producing) ---
            */
            return default;
        }

        public async Task<TEntity> SetQtyProducingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object pick_manual_consumption_moves) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _set_qty_producing) ---
            */
            return default;
        }

        public async Task<TEntity> SetQuantitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _set_quantities) ---
            */
            return default;
        }

        public async Task<TEntity> SetResourceRefInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _set_resource_ref) ---
            */
            return default;
        }

        public async Task<TEntity> SetScheduledDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _set_scheduled_date) ---
            */
            return default;
        }

        public async Task<TEntity> SetSelectionValueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _set_selection_value) ---
            */
            return default;
        }

        public async Task<TEntity> SetSingleLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: _set_single_location) ---
            */
            return default;
        }

        public async Task<TEntity> SetStandardPriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_standard_price) ---
            */
            return default;
        }

        public async Task<TEntity> SetTeaserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: _set_teaser) ---
            */
            return default;
        }

        public async Task<TEntity> SetTemplateFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_field, object variant_field) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _set_template_field) ---
            */
            return default;
        }

        public async Task<TEntity> SetToCloseAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: set_to_close) ---
            */
            return default;
        }

        public async Task<TEntity> SetToDraftAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: set_to_draft) ---
            */
            return default;
        }

        public async Task<TEntity> SetTzContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _set_tz_context) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SetVideocallLocationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _set_videocall_location) ---
            */
            return default;
        }

        public async Task<TEntity> SetViewedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _set_viewed) ---
            */
            return default;
        }

        public async Task<TEntity> SetVolumeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_volume) ---
            */
            return default;
        }

        public async Task<TEntity> SetWeightInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: _set_weight) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SettingInitBankAccountActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: setting_init_bank_account_action) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SettingInitCreditCardAccountActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: setting_init_credit_card_account_action) ---
            */
            return default;
        }

        public async Task<TEntity> SetupAlarmsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _setup_alarms) ---
            */
            return default;
        }

        public async Task<TEntity> SetupEventRecurrentAlarmsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object events_by_alarm) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _setup_event_recurrent_alarms) ---
            */
            return default;
        }

        public async Task<TEntity> ShouldBeLockedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _should_be_locked) ---
            */
            return default;
        }

        public async Task<TEntity> ShouldCheckAvailableQtyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: _should_check_available_qty) ---
            */
            return default;
        }

        public async Task<TEntity> ShouldCreatePickingRealTimeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _should_create_picking_real_time) ---
            */
            return default;
        }

        public async Task<TEntity> ShouldIgnoreBackordersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _should_ignore_backorders) ---
            */
            return default;
        }

        public async Task<TEntity> ShouldInviteMembersToJoinCallInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _should_invite_members_to_join_call) ---
            */
            return default;
        }

        public async Task<TEntity> ShouldPostponeDateFinishedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_finished) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _should_postpone_date_finished) ---
            */
            return default;
        }

        public async Task<TEntity> ShouldPrintDeliveryAddressAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: should_print_delivery_address) ---
            */
            return default;
        }

        public async Task<TEntity> ShouldReturnRecordsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _should_return_records) ---
            */
            return default;
        }

        public async Task<TEntity> ShouldShowTransfersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: _should_show_transfers) ---
            */
            return default;
        }

        public async Task<TEntity> ShowCashRegisterAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: show_cash_register) ---
            */
            return default;
        }

        public async Task<TEntity> ShowJournalItemsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: show_journal_items) ---
            */
            return default;
        }

        public async Task<TEntity> SignTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object pid) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: portal, FILE: mail_thread.py, METHOD: _sign_token) ---
            */
            return default;
        }

        public async Task<TEntity> SimpleChoiceQuestionAnswerResultInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user_input_line, object question_correct_suggested_answers, object question_incorrect_scored_answers) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _simple_choice_question_answer_result) ---
            */
            return default;
        }

        public async Task<TEntity> SimpleQuestionAnswerResultInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user_input_line) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py, METHOD: _simple_question_answer_result) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SkipForNoVariantInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product, object bom_attribule_values, object never_attribute_values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _skip_for_no_variant) ---
            */
            return default;
        }

        public async Task<TEntity> SkipOperationLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object product, object never_attribute_values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py, METHOD: _skip_operation_line) ---
            */
            return default;
        }

        public async Task<TEntity> SkipSendMailStatusUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _skip_send_mail_status_update) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SplitBaseLineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line, object company, object target_factors, object populate_function) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _split_base_line) ---
            */
            return default;
        }

        public async Task<TEntity> SplitCodeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object code_name) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _split_code_name) ---
            */
            return default;
        }

        public async Task<TEntity> SplitProductionsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object amounts, object cancel_remaining_qty, object set_consumed_qty) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _split_productions) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SplitTaxDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line, object tax_data, object company, object target_factors) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _split_tax_data) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SplitTaxDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line, object company, object target_factors) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _split_tax_details) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SquashGlobalDiscountLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _squash_global_discount_lines) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SquashReturnOfMerchandiseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _squash_return_of_merchandise_lines) ---
            */
            return default;
        }

        public async Task<TEntity> StockAccountingValueAsync<TEntity>(IEnumerable<TEntity> entities, object accounts_by_product, object at_date) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: stock_accounting_value) ---
            */
            return default;
        }

        public async Task<TEntity> StockValueAsync<TEntity>(IEnumerable<TEntity> entities, object accounts_by_product, object at_date) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: stock_account, FILE: res_company.py, METHOD: stock_value) ---
            */
            return default;
        }

        public async Task<TEntity> SubscribeUsersAutomaticallyGetMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _subscribe_users_automatically_get_members) ---
            */
            return default;
        }

        public async Task<TEntity> SubscribeUsersAutomaticallyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _subscribe_users_automatically) ---
            */
            return default;
        }

        public async Task<TEntity> SyncActivitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _sync_activities) ---
            */
            return default;
        }

        public async Task<TEntity> SyncCronInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py, METHOD: _sync_cron) ---
            */
            return default;
        }

        public async Task<TEntity> SyncFieldNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _sync_field_names) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SyncFromUiAsync<TEntity>(IEnumerable<TEntity> entities, object orders) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: sync_from_ui) ---
            */
            return default;
        }

        public async Task<TEntity> SynchronizeMembershipsInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> user_team_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team_member.py, METHOD: _synchronize_memberships) ---
            */
            return default;
        }

        public async Task<TEntity> SynchronizePartnerValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object fnames) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _synchronize_partner_values) ---
            */
            return default;
        }

        public async Task<TEntity> SynchronizeWithPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py, METHOD: _synchronize_with_partner) ---
            */
            return default;
        }

        public async Task<TEntity> SynchronizeWithStageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stage) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _synchronize_with_stage) ---
            */
            return default;
        }

        public async Task<TEntity> TagToWriteValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tags) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: _tag_to_write_vals) ---
            */
            return default;
        }

        public async Task<TEntity> ThreadToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, object fields) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _thread_to_store) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread_main_attachment.py, METHOD: _thread_to_store) ---
            */
            return default;
        }

        public async Task<TEntity> ToStoreDefaultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _to_store_defaults) ---
            */
            return default;
        }

        public async Task<TEntity> ToStoreInternalAsync<TEntity>(IEnumerable<TEntity> entities, object store, object fields) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _to_store) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleIsReachedAsync<TEntity>(IEnumerable<TEntity> entities, object is_reached) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_milestone.py, METHOD: toggle_is_reached) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleReconcileToFalseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _toggle_reconcile_to_false) ---
            */
            return default;
        }

        public async Task<TEntity> ToggleReconcileToTrueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _toggle_reconcile_to_true) ---
            */
            return default;
        }

        public async Task<TEntity> TrackDiscardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _track_discard) ---
            */
            return default;
        }

        public async Task<TEntity> TrackFilterForDisplayInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tracking_values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _track_filter_for_display) ---
            */
            return default;
        }

        public async Task<TEntity> TrackFinalizeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _track_finalize) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _track_finalize) ---
            */
            return default;
        }

        public async Task<TEntity> TrackGetDefaultLogMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tracked_fields) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _track_get_default_log_message) ---
            */
            return default;
        }

        public async Task<TEntity> TrackGetFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _track_get_fields) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _track_get_fields) ---
            */
            return default;
        }

        public async Task<TEntity> TrackPostTemplateFinalizeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _track_post_template_finalize) ---
            */
            return default;
        }

        public async Task<TEntity> TrackPrepareInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields_iter) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _track_prepare) ---
            */
            return default;
        }

        public async Task<TEntity> TrackSetAuthorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object author) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _track_set_author) ---
            */
            return default;
        }

        public async Task<TEntity> TrackSetLogMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _track_set_log_message) ---
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _track_subtype) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        public async Task<TEntity> TrackTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changes) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _track_template) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: _track_template) ---
            */
            return default;
        }

        public async Task<TEntity> TraversePathInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: _traverse_path) ---
            */
            return default;
        }

        public async Task<TEntity> TriggerUomWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _trigger_uom_warning) ---
            */
            return default;
        }

        protected async Task<object> TruncatePayloadGetMaxPayloadLengthInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _truncate_payload_get_max_payload_length) ---
            */
            return default;
        }

        public async Task<TEntity> TryCashInOutAsync<TEntity>(IEnumerable<TEntity> entities, object _type, object amount, object reason, Guid partner_id, object extras) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: try_cash_in_out) ---
            */
            return default;
        }

        public async Task<TEntity> TurnBaseLineIsRefundFlagOffInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_line) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _turn_base_line_is_refund_flag_off) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> TurnBaseLinesIsRefundFlagOffInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _turn_base_lines_is_refund_flag_off) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> TurnRemovedTaxesIntoNewBaseLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object base_lines, object company, object grouping_function, object aggregate_function) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _turn_removed_taxes_into_new_base_lines) ---
            */
            return default;
        }

        public async Task<TEntity> TypesAllowingSeenInfosInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _types_allowing_seen_infos) ---
            */
            return default;
        }

        public async Task<TEntity> TypesAllowingUnfollowInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _types_allowing_unfollow) ---
            */
            return default;
        }

        public async Task<TEntity> UnblockAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: unblock) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_actions.py, METHOD: unlink_action) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: rating, FILE: mail_thread.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: stock_landed_costs, FILE: stock_landed_cost.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: unlink) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkCommentAsync<TEntity>(IEnumerable<TEntity> entities, Guid message_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: unlink_comment) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptAllEmployeeChannelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: _unlink_except_all_employee_channel) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptConfirmedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _unlink_except_confirmed) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptContainsJournalItemsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _unlink_except_contains_journal_items) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptDefaultInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: _unlink_except_default) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _unlink_except_done) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_unbuild.py, METHOD: _unlink_except_done) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_scrap.py, METHOD: _unlink_except_done) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptDraftOrCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _unlink_except_draft_or_cancel) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _unlink_except_draft_or_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptLastVersionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: _unlink_except_last_version) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptLinkedToFiscalPositionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _unlink_except_linked_to_fiscal_position) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptLinkedToTaxRepartitionLineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: _unlink_except_linked_to_tax_repartition_line) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptRunningMoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _unlink_except_running_mo) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptUsedAsRuleBaseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: _unlink_except_used_as_rule_base) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkIfCancelledInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _unlink_if_cancelled) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkIfCorrectStatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _unlink_if_correct_states) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkIfDraftOrCancelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: _unlink_if_draft_or_cancel) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkIfEnoughKarmaInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _unlink_if_enough_karma) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkIfNoLeavesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _unlink_if_no_leaves) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkIfNotDoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _unlink_if_not_done) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: _unlink_if_not_done) ---
            */
            return default;
        }

        public async Task<TEntity> UnlinkOrArchiveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object check_access) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _unlink_or_archive) ---
            */
            return default;
        }

        public async Task<TEntity> UnregisterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _unregister_hook) ---
            */
            return default;
        }

        public async Task<TEntity> UnsubscribeInvoiceNotificationEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_to_remove) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: _unsubscribe_invoice_notification_email) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateAccountsInAnalyticLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_fname, object current_fname, object accounts) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_account.py, METHOD: _update_accounts_in_analytic_lines) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> UpdateAccrualInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: _update_accrual) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateAllInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: _update_all) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateAmountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object old_amounts, object amounts_to_add, object date, object round, object force_company_currency) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _update_amounts) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateAssetStyleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: web, FILE: models.py, METHOD: _update_asset_style) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateCardsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object auto_commit) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: _update_cards) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateCatalogLineQuantityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, object quantity) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _update_catalog_line_quantity) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateClosingControlStateSessionAsync<TEntity>(IEnumerable<TEntity> entities, object notes) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: update_closing_control_state_session) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object content, Guid forum_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _update_content) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateCronInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _update_cron) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateDatePlannedForLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_dates) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _update_date_planned_for_lines) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateEmployeeManagerInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid manager_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: _update_employee_manager) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateFutureEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values, object time_values, object recurrence_values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: _update_future_events) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateLastActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: _update_last_activity) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateMailSchedulersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: _update_mail_schedulers) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateOpeningMoveInternalAsync<TEntity>(IEnumerable<TEntity> entities, object to_update) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _update_opening_move) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateOrderLineInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid product_id, object quantity) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: _update_order_line_info) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _update_order_line_info) ---
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _update_order_line_info) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _update_order_line_info) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _update_order_line_info) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateOvertimeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object attendance_domain) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: _update_overtime) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateRawMovesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object factor) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: _update_raw_moves) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateRegistryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: _update_registry) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateSaleOrderLinePriceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: _update_sale_order_line_price) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateSequenceNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object session, object values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: _update_sequence_number) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateUomInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid to_uom_id) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: _update_uom) ---
            */
            return default;
        }

        public async Task<TEntity> UpdateUpdateDateActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object updated_dates, object activity) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: purchase, FILE: purchase_order.py, METHOD: _update_update_date_activity) ---
            */
            return default;
        }

        public async Task<TEntity> ValidFieldParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object name) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _valid_field_parameter) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: validate) ---
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: validate) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateFiscalyearLockInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: om_fiscal_year, FILE: res_company.py, METHOD: _validate_fiscalyear_lock) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateLockDatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: res_company.py, METHOD: validate_lock_dates) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateLocksInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _validate_locks) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: _validate_order) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateRepartitionLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: _validate_repartition_lines) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateSessionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object balancing_account, object amount_to_balance, object bank_payment_method_diffs) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: _validate_session) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateTaxGroupIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: validate_tax_group_id) ---
            */
            return default;
        }

        public async Task<TEntity> ValidateWarningAlertsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: iap, FILE: iap_account.py, METHOD: validate_warning_alerts) ---
            */
            return default;
        }

        public async Task<TEntity> VerifySeatsAvailabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object slot_tickets) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_event.py, METHOD: _verify_seats_availability) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ViewHeaderGetAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: view_header_get) ---
            */
            return default;
        }

        public async Task<TEntity> VoteAsync<TEntity>(IEnumerable<TEntity> entities, object upvote) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: vote) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> WarningDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: ir_actions_server.py, METHOD: _warning_depends) ---
            */
            return default;
        }

        public async Task<TEntity> WebPushGetPartnersParametersInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _web_push_get_partners_parameters) ---
            */
            return default;
        }

        public async Task<TEntity> WebPushSendNotificationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object devices, object private_key, object public_key, object payload_by_lang, object payload) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _web_push_send_notification) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> WebPushTruncatePayloadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payload) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: _web_push_truncate_payload) ---
            */
            return default;
        }

        public async Task<List<Dictionary<string, object>>> WebReadAsync<TEntity>(IEnumerable<TEntity> entities, object specification) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_account.py, METHOD: web_read) ---
            */
            return default;
        }

        public async Task<TEntity> WebSaveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: iap, FILE: iap_account.py, METHOD: web_save) ---
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> WithLockedRecordsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records, object allow_raising) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: _with_locked_records) ---
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_account.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: account, FILE: account_tax.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: account, FILE: company.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: analytic, FILE: analytic_account.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: base_automation, FILE: base_automation.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_event.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: event, FILE: event_registration.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: event_booth, FILE: event_booth.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_log_contract.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr, FILE: hr_department.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr, FILE: hr_job.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr, FILE: hr_version.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_attendance, FILE: hr_attendance.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: hr_holidays, FILE: hr_leave_allocation.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: loyalty, FILE: loyalty_card.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: lunch, FILE: lunch_supplier.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mail, FILE: discuss_channel.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_blacklist.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mail, FILE: mail_thread.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: marketing_card, FILE: card_campaign.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_bom.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_production.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_routing.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: mrp, FILE: mrp_workcenter.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: phone_validation, FILE: phone_blacklist.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_order.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: point_of_sale, FILE: pos_session.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_pricelist.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_product.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: product, FILE: product_template.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: purchase_requisition, FILE: purchase_requisition.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: rating, FILE: rating_mixin.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: repair, FILE: repair.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sale, FILE: sale_order.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sales_team, FILE: crm_team_member.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_lot.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: stock, FILE: stock_picking.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: stock_picking_batch, FILE: stock_picking_batch.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: survey, FILE: survey_survey.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_blog, FILE: website_blog.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_event_track, FILE: event_track.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_forum.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_forum, FILE: forum_post.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: website_slides, FILE: slide_slide.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: om_account_asset, FILE: account_asset.py, METHOD: write) ---
            */
            return default;
        }

        public async Task<TEntity> _AccessibleBranchesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_company.py, METHOD: __accessible_branches) ---
            */
            return default;
        }

        public async Task<TEntity> _GetBankStatementsAvailableSourcesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailThreadable
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: account_journal.py, METHOD: __get_bank_statements_available_sources) ---
            */
            return default;
        }
    }
}