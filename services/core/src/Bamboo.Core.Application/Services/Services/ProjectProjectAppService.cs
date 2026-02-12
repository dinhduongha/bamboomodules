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
    [Module("Project", Category = "Services", Depends = new[] { "analytic", "base_setup", "mail", "portal", "rating", "resource", "web", "web_tour", "digest" })]
    public partial class ProjectProjectAppService : GenericAppService<ProjectProject>, IProjectProjectAppService
    {
        protected readonly IAnalyticPlanFieldsMixinAppService _analyticPlanFieldsMixinAppService;
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailAliasMixinAppService _mailAliasMixinAppService;
        protected readonly IMailTrackingDurationMixinAppService _mailTrackingDurationMixinAppService;
        protected readonly IPortalMixinAppService _portalMixinAppService;
        protected readonly IRatingParentMixinAppService _ratingParentMixinAppService;
        public ProjectProjectAppService(IRepository<ProjectProject, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IAnalyticPlanFieldsMixinAppService analyticPlanFieldsMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailAliasMixinAppService mailAliasMixinAppService, IMailTrackingDurationMixinAppService mailTrackingDurationMixinAppService, IPortalMixinAppService portalMixinAppService, IRatingParentMixinAppService ratingParentMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _analyticPlanFieldsMixinAppService = analyticPlanFieldsMixinAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailAliasMixinAppService = mailAliasMixinAppService;
            _mailTrackingDurationMixinAppService = mailTrackingDurationMixinAppService;
            _portalMixinAppService = portalMixinAppService;
            _ratingParentMixinAppService = ratingParentMixinAppService;
        }

        public async Task<ProjectProject> BillableTimeButtonAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: action_billable_time_button) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ProjectProject> CheckFeaturesEnabledAsync(ProjectProjectCheckFeaturesEnabledRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: check_features_enabled) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> CopyDataAsync(ProjectProjectCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<ProjectProject> CreateAsync(CreateRequestDto<ProjectProject> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: project_sms, FILE: project_project.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public async Task<ProjectProject> CreateFromTemplateAsync(ProjectProjectCreateFromTemplateRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_create_from_template) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> CreateInvoiceAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: action_create_invoice) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> CreateTemplateFromProjectAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_create_template_from_project) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> CreateTemplateFromProjectUndoCallbackAsync(ProjectProjectCreateTemplateFromProjectUndoCallbackRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: create_template_from_project_undo_callback) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> CustomerPreviewAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: action_customer_preview) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public override async Task<ProjectProject> DefaultGetAsync(DefaultGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: default_get) ---
            */
            return await base.DefaultGetAsync(input);
        }

        [ApiModel]
        public async Task<ProjectProject> GetCreateEditProjectIdsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py, METHOD: get_create_edit_project_ids) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> GetLastUpdateOrDefaultAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: get_last_update_or_default) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> GetListViewAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_get_list_view) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: action_get_list_view) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> GetMilestonesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: get_milestones) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> GetPanelDataAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: get_panel_data) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: get_panel_data) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: get_panel_data) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> GetSaleItemsDataAsync(ProjectProjectGetSaleItemsDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: get_sale_items_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> GetTemplateTasksAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: get_template_tasks) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> MapTasksAsync(ProjectProjectMapTasksRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: map_tasks) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> MessageSubscribeAsync(ProjectProjectMessageSubscribeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: message_subscribe) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> MessageUnsubscribeAsync(ProjectProjectMessageUnsubscribeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: message_unsubscribe) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> OpenAllPickingsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project_stock, FILE: project_project.py, METHOD: action_open_all_pickings) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> OpenAnalyticItemsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project_account, FILE: project_project.py, METHOD: action_open_analytic_items) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> OpenDeliveriesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project_stock, FILE: project_project.py, METHOD: action_open_deliveries) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> OpenProjectExpensesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project_hr_expense, FILE: project_project.py, METHOD: action_open_project_expenses) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> OpenProjectInvoicesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: action_open_project_invoices) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> OpenProjectPurchaseOrdersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project_purchase, FILE: project_project.py, METHOD: action_open_project_purchase_orders) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> OpenProjectVendorBillsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: action_open_project_vendor_bills) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> OpenReceiptsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project_stock, FILE: project_project.py, METHOD: action_open_receipts) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> OpenShareProjectWizardAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_open_share_project_wizard) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> ProfitabilityItemsAsync(ProjectProjectProfitabilityItemsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_profitability_items) ---
            --- METHOD SOURCE (MODULE: project_account, FILE: project_project.py, METHOD: action_profitability_items) ---
            --- METHOD SOURCE (MODULE: project_hr_expense, FILE: project_project.py, METHOD: action_profitability_items) ---
            --- METHOD SOURCE (MODULE: project_purchase, FILE: project_project.py, METHOD: action_profitability_items) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: action_profitability_items) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: action_profitability_items) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> ProjectTaskBurndownChartReportAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_project_task_burndown_chart_report) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> ProjectTimesheetsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py, METHOD: action_project_timesheets) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: action_project_timesheets) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> ProjectUpdateAllActionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: project_update_all_action) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> TemplateToProjectConfirmationCallbackAsync(ProjectProjectTemplateToProjectConfirmationCallbackRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: template_to_project_confirmation_callback) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: template_to_project_confirmation_callback) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> ToggleFavoriteAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: toggle_favorite) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> ToggleProjectTemplateModeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_toggle_project_template_mode) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> UndoConvertToTemplateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_undo_convert_to_template) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> ViewAllRatingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_view_all_rating) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> ViewMrpBomAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project_mrp, FILE: project_project.py, METHOD: action_view_mrp_bom) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> ViewMrpProductionAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project_mrp, FILE: project_project.py, METHOD: action_view_mrp_production) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> ViewSolsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: action_view_sols) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> ViewSosAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: action_view_sos) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> ViewTasksAnalysisAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_view_tasks_analysis) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> ViewTasksAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py, METHOD: action_view_tasks) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_view_tasks) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: action_view_tasks) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> ViewTasksFromProjectMilestoneAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: action_view_tasks_from_project_milestone) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ProjectProject> ViewTimesheetAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: action_view_timesheet) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<ProjectProject> input)
        {
            /*
            --- METHOD SOURCE (MODULE: hr_timesheet, FILE: project_project.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: project, FILE: project_project.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: project_sms, FILE: project_project.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sale_project, FILE: project_project.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: sale_timesheet, FILE: project_project.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}