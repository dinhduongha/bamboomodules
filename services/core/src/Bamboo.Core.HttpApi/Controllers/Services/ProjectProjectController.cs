using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/services/ProjectProject")]
    public partial class ProjectProjectController : AbpController
    {
        protected readonly IProjectProjectAppService _appService;
        public ProjectProjectController(IProjectProjectAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-billable-time-button")]
        public async Task<IActionResult> BillableTimeButtonAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.BillableTimeButtonAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-from-template")]
        public async Task<IActionResult> CreateFromTemplateAsync([FromBody] ProjectProjectCreateFromTemplateRequestDto input)
        {
            var result = await _appService.CreateFromTemplateAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-invoice")]
        public async Task<IActionResult> CreateInvoiceAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateInvoiceAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-create-template-from-project")]
        public async Task<IActionResult> CreateTemplateFromProjectAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CreateTemplateFromProjectAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-customer-preview")]
        public async Task<IActionResult> CustomerPreviewAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.CustomerPreviewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-get-list-view")]
        public async Task<IActionResult> GetListViewAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetListViewAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-all-pickings")]
        public async Task<IActionResult> OpenAllPickingsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenAllPickingsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-analytic-items")]
        public async Task<IActionResult> OpenAnalyticItemsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenAnalyticItemsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-deliveries")]
        public async Task<IActionResult> OpenDeliveriesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenDeliveriesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-project-expenses")]
        public async Task<IActionResult> OpenProjectExpensesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenProjectExpensesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-project-invoices")]
        public async Task<IActionResult> OpenProjectInvoicesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenProjectInvoicesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-project-purchase-orders")]
        public async Task<IActionResult> OpenProjectPurchaseOrdersAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenProjectPurchaseOrdersAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-project-vendor-bills")]
        public async Task<IActionResult> OpenProjectVendorBillsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenProjectVendorBillsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-receipts")]
        public async Task<IActionResult> OpenReceiptsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenReceiptsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-share-project-wizard")]
        public async Task<IActionResult> OpenShareProjectWizardAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenShareProjectWizardAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-profitability-items")]
        public async Task<IActionResult> ProfitabilityItemsAsync([FromBody] ProjectProjectProfitabilityItemsRequestDto input)
        {
            var result = await _appService.ProfitabilityItemsAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-project-task-burndown-chart-report")]
        public async Task<IActionResult> ProjectTaskBurndownChartReportAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ProjectTaskBurndownChartReportAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-project-timesheets")]
        public async Task<IActionResult> ProjectTimesheetsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ProjectTimesheetsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-toggle-project-template-mode")]
        public async Task<IActionResult> ToggleProjectTemplateModeAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ToggleProjectTemplateModeAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-undo-convert-to-template")]
        public async Task<IActionResult> UndoConvertToTemplateAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.UndoConvertToTemplateAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-all-rating")]
        public async Task<IActionResult> ViewAllRatingAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewAllRatingAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mrp-bom")]
        public async Task<IActionResult> ViewMrpBomAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewMrpBomAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-mrp-production")]
        public async Task<IActionResult> ViewMrpProductionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewMrpProductionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sols")]
        public async Task<IActionResult> ViewSolsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewSolsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-sos")]
        public async Task<IActionResult> ViewSosAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewSosAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-tasks")]
        public async Task<IActionResult> ViewTasksAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewTasksAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-tasks-analysis")]
        public async Task<IActionResult> ViewTasksAnalysisAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewTasksAnalysisAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-tasks-from-project-milestone")]
        public async Task<IActionResult> ViewTasksFromProjectMilestoneAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewTasksFromProjectMilestoneAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-view-timesheet")]
        public async Task<IActionResult> ViewTimesheetAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ViewTimesheetAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("check-features-enabled")]
        public async Task<IActionResult> CheckFeaturesEnabledAsync([FromBody] ProjectProjectCheckFeaturesEnabledRequestDto input)
        {
            var result = await _appService.CheckFeaturesEnabledAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("copy-data")]
        public async Task<IActionResult> CopyDataAsync([FromBody] ProjectProjectCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("create-template-from-project-undo-callback")]
        public async Task<IActionResult> CreateTemplateFromProjectUndoCallbackAsync([FromBody] ProjectProjectCreateTemplateFromProjectUndoCallbackRequestDto input)
        {
            var result = await _appService.CreateTemplateFromProjectUndoCallbackAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-create-edit-project-ids")]
        public async Task<IActionResult> GetCreateEditProjectIdsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetCreateEditProjectIdsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-last-update-or-default")]
        public async Task<IActionResult> GetLastUpdateOrDefaultAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetLastUpdateOrDefaultAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-milestones")]
        public async Task<IActionResult> GetMilestonesAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetMilestonesAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-panel-data")]
        public async Task<IActionResult> GetPanelDataAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetPanelDataAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-sale-items-data")]
        public async Task<IActionResult> GetSaleItemsDataAsync([FromBody] ProjectProjectGetSaleItemsDataRequestDto input)
        {
            var result = await _appService.GetSaleItemsDataAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-template-tasks")]
        public async Task<IActionResult> GetTemplateTasksAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetTemplateTasksAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("map-tasks")]
        public async Task<IActionResult> MapTasksAsync([FromBody] ProjectProjectMapTasksRequestDto input)
        {
            var result = await _appService.MapTasksAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-subscribe")]
        public async Task<IActionResult> MessageSubscribeAsync([FromBody] ProjectProjectMessageSubscribeRequestDto input)
        {
            var result = await _appService.MessageSubscribeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("message-unsubscribe")]
        public async Task<IActionResult> MessageUnsubscribeAsync([FromBody] ProjectProjectMessageUnsubscribeRequestDto input)
        {
            var result = await _appService.MessageUnsubscribeAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("project-update-all-action")]
        public async Task<IActionResult> ProjectUpdateAllActionAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ProjectUpdateAllActionAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("template-to-project-confirmation-callback")]
        public async Task<IActionResult> TemplateToProjectConfirmationCallbackAsync([FromBody] ProjectProjectTemplateToProjectConfirmationCallbackRequestDto input)
        {
            var result = await _appService.TemplateToProjectConfirmationCallbackAsync(input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("toggle-favorite")]
        public async Task<IActionResult> ToggleFavoriteAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.ToggleFavoriteAsync(ids);
            return Ok(result);
        }
    }
    
}