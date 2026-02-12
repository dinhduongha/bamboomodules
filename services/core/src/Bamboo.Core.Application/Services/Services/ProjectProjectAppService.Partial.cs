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
    public partial class ProjectProjectAppService
    {

        protected async Task<ProjectProject> AddCollaboratorsInternalAsync(object partners, object limited_access)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _add_collaborators) ---
            */
            return default;
        }

        protected async Task<ProjectProject> AddFollowersInternalAsync(object partners)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _add_followers) ---
            */
            return default;
        }

        protected async Task<ProjectProject> AddInvoiceItemsInternalAsync(object domain, object profitability_items, object with_action)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _add_invoice_items) ---
            */
            return default;
        }

        protected async Task<ProjectProject> AddPurchaseItemsInternalAsync(object profitability_items, object with_action)
        {
            /*
            --- METHOD SOURCE (MODULE: project_account, FILE: project_project.py, METHOD: _add_purchase_items) ---
            --- METHOD SOURCE (MODULE: project_purchase, FILE: project_project.py, METHOD: _add_purchase_items) ---
            */
            return default;
        }

        protected async Task<ProjectProject> AliasGetCreationValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _alias_get_creation_values) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ChangePrivacyVisibilityInternalAsync(object new_visibility)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _change_privacy_visibility) ---
            */
            return default;
        }

        protected async Task<ProjectProject> CheckAccountIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _check_account_id) ---
            */
            return default;
        }

        protected async Task<ProjectProject> CheckAllowTimesheetInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py, METHOD: _check_allow_timesheet) ---
            */
            return default;
        }

        protected async Task<ProjectProject> CheckProjectGroupAtRemovalInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _check_project_group_at_removal) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectProject> CheckProjectGroupWithFieldInternalAsync(object field_name, object group_name)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _check_project_group_with_field) ---
            */
            return default;
        }

        protected async Task<ProjectProject> CheckProjectSharingAccessInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _check_project_sharing_access) ---
            */
            return default;
        }

        protected async Task<ProjectProject> CheckSaleLineTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: _check_sale_line_type) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeAccessInstructionMessageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_access_instruction_message) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeAccessUrlInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_access_url) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeAllowTimesheetsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py, METHOD: _compute_allow_timesheets) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeBillingTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: _compute_billing_type) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeBomCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_mrp, FILE: project_project.py, METHOD: _compute_bom_count) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeClosedTaskCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_closed_task_count) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeCollaboratorCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_collaborator_count) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_company_id) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeCurrencyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_currency_id) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeDisplayNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py, METHOD: _compute_display_name) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeDisplaySalesStatButtonsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _compute_display_sales_stat_buttons) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeEncodeUomInDaysInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py, METHOD: _compute_encode_uom_in_days) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeHasAnySoToInvoiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _compute_has_any_so_to_invoice) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeHasAnySoWithNothingToInvoiceInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _compute_has_any_so_with_nothing_to_invoice) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeInvoiceCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _compute_invoice_count) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeIsFavoriteInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_is_favorite) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeIsInternalProjectInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py, METHOD: _compute_is_internal_project) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeIsMilestoneExceededInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_is_milestone_exceeded) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeLastUpdateColorInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_last_update_color) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeLastUpdateStatusInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_last_update_status) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeMilestoneCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_milestone_count) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeMilestoneReachedCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_milestone_reached_count) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeNextMilestoneIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_next_milestone_id) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeOpenTaskCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_open_task_count) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputePartnerIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _compute_partner_id) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: _compute_partner_id) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputePricingTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: _compute_pricing_type) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputePrivacyVisibilityWarningInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_privacy_visibility_warning) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeProductionCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_mrp, FILE: project_project.py, METHOD: _compute_production_count) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputePurchaseOrdersCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_purchase, FILE: project_project.py, METHOD: _compute_purchase_orders_count) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeRemainingHoursInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py, METHOD: _compute_remaining_hours) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeResourceCalendarIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_resource_calendar_id) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeSaleLineIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _compute_sale_line_id) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: _compute_sale_line_id) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeSaleOrderCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _compute_sale_order_count) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: _compute_sale_order_count) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeShowRatingsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_show_ratings) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeTaskCompletionPercentageInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_task_completion_percentage) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeTaskCountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_task_count) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeTimesheetEncodeUomIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py, METHOD: _compute_timesheet_encode_uom_id) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeTimesheetProductIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: _compute_timesheet_product_id) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeTotalTimesheetTimeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py, METHOD: _compute_total_timesheet_time) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeTotalUpdateIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _compute_total_update_ids) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ComputeWarningEmployeeRateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: _compute_warning_employee_rate) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ConvertProjectUomToTimesheetEncodeUomInternalAsync(object time)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py, METHOD: _convert_project_uom_to_timesheet_encode_uom) ---
            */
            return default;
        }

        protected async Task<ProjectProject> CopyEmbeddedActionsConfigInternalAsync(object new_projects, object shared_embedded_actions_mapping)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _copy_embedded_actions_config) ---
            */
            return default;
        }

        protected async Task<ProjectProject> CopySharedEmbeddedActionsInternalAsync(object new_projects)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _copy_shared_embedded_actions) ---
            */
            return default;
        }

        protected async Task<ProjectProject> CreateAnalyticAccountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _create_analytic_account) ---
            */
            return default;
        }

        protected async Task<ProjectProject> DefaultStageIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _default_stage_id) ---
            */
            return default;
        }

        protected async Task<ProjectProject> DefaultTimesheetProductIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: _default_timesheet_product_id) ---
            */
            return default;
        }

        protected async Task<ProjectProject> DomainSaleLineIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _domain_sale_line_id) ---
            */
            return default;
        }

        protected async Task<ProjectProject> EnsureSaleOrderLinkedInternalAsync(List<Guid> sol_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _ensure_sale_order_linked) ---
            */
            return default;
        }

        protected async Task<ProjectProject> EnsureStageHasSameCompanyInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _ensure_stage_has_same_company) ---
            */
            return default;
        }

        protected async Task<ProjectProject> FetchProductsLinkedToTemplateInternalAsync(object limit)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _fetch_products_linked_to_template) ---
            */
            return default;
        }

        protected async Task<ProjectProject> FetchSaleOrderItemIdsInternalAsync(object domain_per_model, object limit, object offset)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _fetch_sale_order_item_ids) ---
            */
            return default;
        }

        protected async Task<ProjectProject> FetchSaleOrderItemsInternalAsync(object domain_per_model, object limit, object offset)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _fetch_sale_order_items) ---
            */
            return default;
        }

        protected async Task<ProjectProject> FetchSaleOrderItemsPerProjectIdInternalAsync(object domain_per_model)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _fetch_sale_order_items_per_project_id) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetAccountNodeContextInternalAsync(object plan)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_account_node_context) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetActionForProfitabilitySectionInternalAsync(List<Guid> record_ids, object name)
        {
            /*
            --- METHOD SOURCE (MODULE: project_account, FILE: project_project.py, METHOD: _get_action_for_profitability_section) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetAddPurchaseItemsDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_account, FILE: project_project.py, METHOD: _get_add_purchase_items_domain) ---
            --- METHOD SOURCE (MODULE: project_hr_expense, FILE: project_project.py, METHOD: _get_add_purchase_items_domain) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetAlreadyIncludedProfitabilityInvoiceLineIdsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_already_included_profitability_invoice_line_ids) ---
            --- METHOD SOURCE (MODULE: project_hr_expense, FILE: project_project.py, METHOD: _get_already_included_profitability_invoice_line_ids) ---
            --- METHOD SOURCE (MODULE: project_sale_expense, FILE: project_project.py, METHOD: _get_already_included_profitability_invoice_line_ids) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetCostsItemsFromPurchaseInternalAsync(object domain, object profitability_items, object with_action)
        {
            /*
            --- METHOD SOURCE (MODULE: project_account, FILE: project_project.py, METHOD: _get_costs_items_from_purchase) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetDomainAalWithNoMoveLineInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_account, FILE: project_project.py, METHOD: _get_domain_aal_with_no_move_line) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: _get_domain_aal_with_no_move_line) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetDomainFromSectionIdInternalAsync(Guid section_id)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _get_domain_from_section_id) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: _get_domain_from_section_id) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetExpenseActionInternalAsync(object domain, List<Guid> expense_ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project_hr_expense, FILE: project_project.py, METHOD: _get_expense_action) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetExpensesProfitabilityItemsInternalAsync(object with_action)
        {
            /*
            --- METHOD SOURCE (MODULE: project_hr_expense, FILE: project_project.py, METHOD: _get_expenses_profitability_items) ---
            --- METHOD SOURCE (MODULE: project_sale_expense, FILE: project_project.py, METHOD: _get_expenses_profitability_items) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetFoldableSectionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _get_foldable_section) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: _get_foldable_section) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetHidePartnerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_hide_partner) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _get_hide_partner) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetItemsFromAalInternalAsync(object with_action)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_items_from_aal) ---
            --- METHOD SOURCE (MODULE: project_account, FILE: project_project.py, METHOD: _get_items_from_aal) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetItemsFromAalPickingInternalAsync(object with_action)
        {
            /*
            --- METHOD SOURCE (MODULE: project_stock_account, FILE: project_project.py, METHOD: _get_items_from_aal_picking) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetItemsFromInvoicesDomainInternalAsync(object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _get_items_from_invoices_domain) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetItemsFromInvoicesInternalAsync(List<Guid> excluded_move_line_ids, object with_action)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _get_items_from_invoices) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetMilestonesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_milestones) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetNewCollaboratorsInternalAsync(object partners)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_new_collaborators) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetPickingActionInternalAsync(object action_name, object picking_type)
        {
            /*
            --- METHOD SOURCE (MODULE: project_stock, FILE: project_project.py, METHOD: _get_picking_action) ---
            --- METHOD SOURCE (MODULE: sale_project_stock, FILE: project_project.py, METHOD: _get_picking_action) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetPlanDomainInternalAsync(object plan)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_plan_domain) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetProfitabilityAalDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_profitability_aal_domain) ---
            --- METHOD SOURCE (MODULE: project_hr_expense, FILE: project_project.py, METHOD: _get_profitability_aal_domain) ---
            --- METHOD SOURCE (MODULE: project_mrp_account, FILE: project_project.py, METHOD: _get_profitability_aal_domain) ---
            --- METHOD SOURCE (MODULE: project_purchase, FILE: project_project.py, METHOD: _get_profitability_aal_domain) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: _get_profitability_aal_domain) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetProfitabilityItemsFromAalInternalAsync(object profitability_items, object with_action)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: _get_profitability_items_from_aal) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetProfitabilityItemsInternalAsync(object with_action)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_profitability_items) ---
            --- METHOD SOURCE (MODULE: project_hr_expense, FILE: project_project.py, METHOD: _get_profitability_items) ---
            --- METHOD SOURCE (MODULE: project_mrp_account, FILE: project_project.py, METHOD: _get_profitability_items) ---
            --- METHOD SOURCE (MODULE: project_purchase, FILE: project_project.py, METHOD: _get_profitability_items) ---
            --- METHOD SOURCE (MODULE: project_stock_account, FILE: project_project.py, METHOD: _get_profitability_items) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _get_profitability_items) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: _get_profitability_items) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetProfitabilityLabelsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_profitability_labels) ---
            --- METHOD SOURCE (MODULE: project_account, FILE: project_project.py, METHOD: _get_profitability_labels) ---
            --- METHOD SOURCE (MODULE: project_hr_expense, FILE: project_project.py, METHOD: _get_profitability_labels) ---
            --- METHOD SOURCE (MODULE: project_mrp_account, FILE: project_project.py, METHOD: _get_profitability_labels) ---
            --- METHOD SOURCE (MODULE: project_purchase, FILE: project_project.py, METHOD: _get_profitability_labels) ---
            --- METHOD SOURCE (MODULE: project_stock_account, FILE: project_project.py, METHOD: _get_profitability_labels) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _get_profitability_labels) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: _get_profitability_labels) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetProfitabilitySaleOrderItemsDomainInternalAsync(object domain)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _get_profitability_sale_order_items_domain) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetProfitabilitySequencePerInvoiceTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_profitability_sequence_per_invoice_type) ---
            --- METHOD SOURCE (MODULE: project_account, FILE: project_project.py, METHOD: _get_profitability_sequence_per_invoice_type) ---
            --- METHOD SOURCE (MODULE: project_hr_expense, FILE: project_project.py, METHOD: _get_profitability_sequence_per_invoice_type) ---
            --- METHOD SOURCE (MODULE: project_mrp_account, FILE: project_project.py, METHOD: _get_profitability_sequence_per_invoice_type) ---
            --- METHOD SOURCE (MODULE: project_purchase, FILE: project_project.py, METHOD: _get_profitability_sequence_per_invoice_type) ---
            --- METHOD SOURCE (MODULE: project_stock_account, FILE: project_project.py, METHOD: _get_profitability_sequence_per_invoice_type) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _get_profitability_sequence_per_invoice_type) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: _get_profitability_sequence_per_invoice_type) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetProfitabilityValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_profitability_values) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _get_profitability_values) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetProjectFeaturesMappingInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_project_features_mapping) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetProjectToTemplateWarningsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: _get_project_to_template_warnings) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetProjectsForInvoiceStatusInternalAsync(object invoice_status)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _get_projects_for_invoice_status) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetProjectsToMakeBillableDomainInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_projects_to_make_billable_domain) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _get_projects_to_make_billable_domain) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetRevenuesItemsFromSolInternalAsync(object domain, object with_action)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _get_revenues_items_from_sol) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetSaleItemsDomainInternalAsync(object additional_domain)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _get_sale_items_domain) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetSaleOrderItemsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _get_sale_order_items) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetSaleOrderItemsQueryInternalAsync(object domain_per_model)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _get_sale_order_items_query) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: _get_sale_order_items_query) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetSaleOrdersDomainInternalAsync(object all_sale_orders)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _get_sale_orders_domain) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetSaleOrdersInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _get_sale_orders) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetServicePolicyToInvoiceTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _get_service_policy_to_invoice_type) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: _get_service_policy_to_invoice_type) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetStatButtonsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py, METHOD: _get_stat_buttons) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_stat_buttons) ---
            --- METHOD SOURCE (MODULE: project_mrp, FILE: project_project.py, METHOD: _get_stat_buttons) ---
            --- METHOD SOURCE (MODULE: project_purchase, FILE: project_project.py, METHOD: _get_stat_buttons) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _get_stat_buttons) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetTemplateDefaultContextWhitelistInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_template_default_context_whitelist) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _get_template_default_context_whitelist) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: _get_template_default_context_whitelist) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectProject> GetTemplateFieldBlacklistInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_template_field_blacklist) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetTemplateFromProjectUndoCallbacksInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_template_from_project_undo_callbacks) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetTemplateToProjectConfirmationCallbacksInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_template_to_project_confirmation_callbacks) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _get_template_to_project_confirmation_callbacks) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetTemplateToProjectWarningsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_template_to_project_warnings) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _get_template_to_project_warnings) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetUserValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_user_values) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectProject> GetValuesAnalyticAccountBatchInternalAsync(object project_vals_list)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _get_values_analytic_account_batch) ---
            */
            return default;
        }

        protected async Task<ProjectProject> GetViewActionInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _get_view_action) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectProject> GetViewInternalAsync(Guid view_id, object view_type)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: _get_view) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectProject> InitDataAnalyticAccountInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py, METHOD: _init_data_analytic_account) ---
            */
            return default;
        }

        protected async Task<ProjectProject> InverseAllowMilestonesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _inverse_allow_milestones) ---
            */
            return default;
        }

        protected async Task<ProjectProject> InverseAllowRecurringTasksInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _inverse_allow_recurring_tasks) ---
            */
            return default;
        }

        protected async Task<ProjectProject> InverseAllowTaskDependenciesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _inverse_allow_task_dependencies) ---
            */
            return default;
        }

        protected async Task<ProjectProject> InverseCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _inverse_company_id) ---
            */
            return default;
        }

        protected async Task<ProjectProject> MailGetMessageSubtypesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _mail_get_message_subtypes) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectProject> MapTasksDefaultValuesInternalAsync(object project)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _map_tasks_default_values) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _map_tasks_default_values) ---
            */
            return default;
        }

        protected async Task<ProjectProject> NotifyGetRecipientsGroupsInternalAsync(object message, object model_description, object msg_vals)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _notify_get_recipients_groups) ---
            */
            return default;
        }

        protected async Task<ProjectProject> OnchangeCompanyIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _onchange_company_id) ---
            */
            return default;
        }

        protected async Task<ProjectProject> OnchangeReinvoicedSaleOrderIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _onchange_reinvoiced_sale_order_id) ---
            */
            return default;
        }

        protected async Task<ProjectProject> OnchangeSaleLineIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _onchange_sale_line_id) ---
            */
            return default;
        }

        protected async Task<ProjectProject> OrderFieldToSqlInternalAsync(object @alias, object field_name, object direction, object nulls, object query)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _order_field_to_sql) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectProject> SearchIsFavoriteInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _search_is_favorite) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectProject> SearchIsInternalProjectInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py, METHOD: _search_is_internal_project) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectProject> SearchIsMilestoneExceededInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _search_is_milestone_exceeded) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<ProjectProject> SearchIsProjectOvertimeInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py, METHOD: _search_is_project_overtime) ---
            */
            return default;
        }

        protected async Task<ProjectProject> SearchPricingTypeInternalAsync(object @operator, object @value)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: _search_pricing_type) ---
            */
            return default;
        }

        protected async Task<ProjectProject> SendSmsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project_sms, FILE: project_project.py, METHOD: _send_sms) ---
            */
            return default;
        }

        protected async Task<ProjectProject> SetFavoriteUserIdsInternalAsync(object is_favorite)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _set_favorite_user_ids) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ShowProfitabilityHelperInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _show_profitability_helper) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _show_profitability_helper) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ShowProfitabilityInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _show_profitability) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: _show_profitability) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ThreadToStoreInternalAsync(object store, object fields)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _thread_to_store) ---
            */
            return default;
        }

        protected async Task<ProjectProject> ToggleTemplateModeInternalAsync(object is_template)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py, METHOD: _toggle_template_mode) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _toggle_template_mode) ---
            */
            return default;
        }

        protected async Task<ProjectProject> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _track_subtype) ---
            */
            return default;
        }

        protected async Task<ProjectProject> TrackTemplateInternalAsync(object changes)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: _track_template) ---
            */
            return default;
        }

        protected async Task<ProjectProject> UnlinkExceptContainsEntriesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py, METHOD: _unlink_except_contains_entries) ---
            */
            return default;
        }

        protected async Task<ProjectProject> UpdateTimesheetsSaleLineIdInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: _update_timesheets_sale_line_id) ---
            */
            return default;
        }

        private async Task<ProjectProject> _ComputeTaskCountInternalAsync(object count_field, object additional_domain)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: __compute_task_count) ---
            */
            return default;
        }
    }
}