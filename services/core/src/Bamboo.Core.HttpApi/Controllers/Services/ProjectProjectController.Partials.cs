using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class ProjectProjectController
    {
        
        [HttpPost]
        [Route("action-billable-time-button")]
        public async Task<IActionResult> ActionBillableTimeButtonAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.BillableTimeButtonAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-from-template")]
        public async Task<IActionResult> ActionCreateFromTemplateAsync(ProjectProjectCreateFromTemplateRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CreateFromTemplateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-invoice")]
        public async Task<IActionResult> ActionCreateInvoiceAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreateInvoiceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-template-from-project")]
        public async Task<IActionResult> ActionCreateTemplateFromProjectAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CreateTemplateFromProjectAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-customer-preview")]
        public async Task<IActionResult> ActionCustomerPreviewAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.CustomerPreviewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-get-list-view")]
        public async Task<IActionResult> ActionGetListViewAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetListViewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-all-pickings")]
        public async Task<IActionResult> ActionOpenAllPickingsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenAllPickingsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-analytic-items")]
        public async Task<IActionResult> ActionOpenAnalyticItemsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenAnalyticItemsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-deliveries")]
        public async Task<IActionResult> ActionOpenDeliveriesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenDeliveriesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-project-expenses")]
        public async Task<IActionResult> ActionOpenProjectExpensesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenProjectExpensesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-project-invoices")]
        public async Task<IActionResult> ActionOpenProjectInvoicesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenProjectInvoicesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-project-purchase-orders")]
        public async Task<IActionResult> ActionOpenProjectPurchaseOrdersAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenProjectPurchaseOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-project-vendor-bills")]
        public async Task<IActionResult> ActionOpenProjectVendorBillsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenProjectVendorBillsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-receipts")]
        public async Task<IActionResult> ActionOpenReceiptsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenReceiptsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-share-project-wizard")]
        public async Task<IActionResult> ActionOpenShareProjectWizardAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenShareProjectWizardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-profitability-items")]
        public async Task<IActionResult> ActionProfitabilityItemsAsync(ProjectProjectProfitabilityItemsRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.ProfitabilityItemsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-project-task-burndown-chart-report")]
        public async Task<IActionResult> ActionProjectTaskBurndownChartReportAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ProjectTaskBurndownChartReportAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-project-timesheets")]
        public async Task<IActionResult> ActionProjectTimesheetsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ProjectTimesheetsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-toggle-project-template-mode")]
        public async Task<IActionResult> ActionToggleProjectTemplateModeAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ToggleProjectTemplateModeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-undo-convert-to-template")]
        public async Task<IActionResult> ActionUndoConvertToTemplateAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.UndoConvertToTemplateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-all-rating")]
        public async Task<IActionResult> ActionViewAllRatingAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewAllRatingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mrp-bom")]
        public async Task<IActionResult> ActionViewMrpBomAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewMrpBomAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mrp-production")]
        public async Task<IActionResult> ActionViewMrpProductionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewMrpProductionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sols")]
        public async Task<IActionResult> ActionViewSolsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewSolsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sos")]
        public async Task<IActionResult> ActionViewSosAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewSosAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-tasks")]
        public async Task<IActionResult> ActionViewTasksAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewTasksAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-tasks-analysis")]
        public async Task<IActionResult> ActionViewTasksAnalysisAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewTasksAnalysisAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-tasks-from-project-milestone")]
        public async Task<IActionResult> ActionViewTasksFromProjectMilestoneAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewTasksFromProjectMilestoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-timesheet")]
        public async Task<IActionResult> ActionViewTimesheetAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ViewTimesheetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-features-enabled")]
        public async Task<IActionResult> CheckFeaturesEnabledAsync(ProjectProjectCheckFeaturesEnabledRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CheckFeaturesEnabledAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync(ProjectProjectCopyDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-template-from-project-undo-callback")]
        public async Task<IActionResult> CreateTemplateFromProjectUndoCallbackAsync(ProjectProjectCreateTemplateFromProjectUndoCallbackRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.CreateTemplateFromProjectUndoCallbackAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-create-edit-project-ids")]
        public async Task<IActionResult> GetCreateEditProjectIdsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetCreateEditProjectIdsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-last-update-or-default")]
        public async Task<IActionResult> GetLastUpdateOrDefaultAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetLastUpdateOrDefaultAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-milestones")]
        public async Task<IActionResult> GetMilestonesAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetMilestonesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-panel-data")]
        public async Task<IActionResult> GetPanelDataAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetPanelDataAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-sale-items-data")]
        public async Task<IActionResult> GetSaleItemsDataAsync(ProjectProjectGetSaleItemsDataRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetSaleItemsDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-template-tasks")]
        public async Task<IActionResult> GetTemplateTasksAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetTemplateTasksAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("map-tasks")]
        public async Task<IActionResult> MapTasksAsync(ProjectProjectMapTasksRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MapTasksAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-subscribe")]
        public async Task<IActionResult> MessageSubscribeAsync(ProjectProjectMessageSubscribeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MessageSubscribeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-unsubscribe")]
        public async Task<IActionResult> MessageUnsubscribeAsync(ProjectProjectMessageUnsubscribeRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.MessageUnsubscribeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("project-update-all-action")]
        public async Task<IActionResult> ProjectUpdateAllActionAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ProjectUpdateAllActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("template-to-project-confirmation-callback")]
        public async Task<IActionResult> TemplateToProjectConfirmationCallbackAsync(ProjectProjectTemplateToProjectConfirmationCallbackRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.TemplateToProjectConfirmationCallbackAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("toggle-favorite")]
        public async Task<IActionResult> ToggleFavoriteAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.ToggleFavoriteAsync(ids);
            return Ok(result);
        }
    }
}