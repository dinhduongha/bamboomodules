using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.DTOs;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Project
{
    public partial class ProjectProjectController
    {
        
        [HttpPost]
        [Route("{id}/action-billable-time-button")]
        public async Task<IActionResult> ActionBillableTimeButtonAsync(Guid id)
        {
            var result = await _appService.BillableTimeButtonAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-create-invoice")]
        public async Task<IActionResult> ActionCreateInvoiceAsync(Guid id)
        {
            var result = await _appService.CreateInvoiceAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-customer-preview")]
        public async Task<IActionResult> ActionCustomerPreviewAsync(Guid id)
        {
            var result = await _appService.CustomerPreviewAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-get-list-view")]
        public async Task<IActionResult> ActionGetListViewAsync(Guid id)
        {
            var result = await _appService.GetListViewAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-all-pickings")]
        public async Task<IActionResult> ActionOpenAllPickingsAsync(Guid id)
        {
            var result = await _appService.OpenAllPickingsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-analytic-items")]
        public async Task<IActionResult> ActionOpenAnalyticItemsAsync(Guid id)
        {
            var result = await _appService.OpenAnalyticItemsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-deliveries")]
        public async Task<IActionResult> ActionOpenDeliveriesAsync(Guid id)
        {
            var result = await _appService.OpenDeliveriesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-project-expenses")]
        public async Task<IActionResult> ActionOpenProjectExpensesAsync(Guid id)
        {
            var result = await _appService.OpenProjectExpensesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-project-invoices")]
        public async Task<IActionResult> ActionOpenProjectInvoicesAsync(Guid id)
        {
            var result = await _appService.OpenProjectInvoicesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-project-purchase-orders")]
        public async Task<IActionResult> ActionOpenProjectPurchaseOrdersAsync(Guid id)
        {
            var result = await _appService.OpenProjectPurchaseOrdersAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-project-vendor-bills")]
        public async Task<IActionResult> ActionOpenProjectVendorBillsAsync(Guid id)
        {
            var result = await _appService.OpenProjectVendorBillsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-receipts")]
        public async Task<IActionResult> ActionOpenReceiptsAsync(Guid id)
        {
            var result = await _appService.OpenReceiptsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-share-project-wizard")]
        public async Task<IActionResult> ActionOpenShareProjectWizardAsync(Guid id)
        {
            var result = await _appService.OpenShareProjectWizardAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-profitability-items")]
        public async Task<IActionResult> ActionProfitabilityItemsAsync(Guid id, [FromBody] ProjectProjectProfitabilityItemsRequestDto input)
        {
            var result = await _appService.ProfitabilityItemsAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-project-task-burndown-chart-report")]
        public async Task<IActionResult> ActionProjectTaskBurndownChartReportAsync(Guid id)
        {
            var result = await _appService.ProjectTaskBurndownChartReportAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-project-timesheets")]
        public async Task<IActionResult> ActionProjectTimesheetsAsync(Guid id)
        {
            var result = await _appService.ProjectTimesheetsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-all-rating")]
        public async Task<IActionResult> ActionViewAllRatingAsync(Guid id)
        {
            var result = await _appService.ViewAllRatingAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-mrp-bom")]
        public async Task<IActionResult> ActionViewMrpBomAsync(Guid id)
        {
            var result = await _appService.ViewMrpBomAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-mrp-production")]
        public async Task<IActionResult> ActionViewMrpProductionAsync(Guid id)
        {
            var result = await _appService.ViewMrpProductionAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-sols")]
        public async Task<IActionResult> ActionViewSolsAsync(Guid id)
        {
            var result = await _appService.ViewSolsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-sos")]
        public async Task<IActionResult> ActionViewSosAsync(Guid id)
        {
            var result = await _appService.ViewSosAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-tasks")]
        public async Task<IActionResult> ActionViewTasksAsync(Guid id)
        {
            var result = await _appService.ViewTasksAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-tasks-analysis")]
        public async Task<IActionResult> ActionViewTasksAnalysisAsync(Guid id)
        {
            var result = await _appService.ViewTasksAnalysisAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-view-timesheet")]
        public async Task<IActionResult> ActionViewTimesheetAsync(Guid id)
        {
            var result = await _appService.ViewTimesheetAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/copy-data")]
        public async Task<IActionResult> CopyDataAsync(Guid id, [FromBody] ProjectProjectCopyDataRequestDto input)
        {
            var result = await _appService.CopyDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-create-edit-project-ids")]
        public async Task<IActionResult> GetCreateEditProjectIdsAsync(Guid id)
        {
            var result = await _appService.GetCreateEditProjectIdsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-last-update-or-default")]
        public async Task<IActionResult> GetLastUpdateOrDefaultAsync(Guid id)
        {
            var result = await _appService.GetLastUpdateOrDefaultAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-milestones")]
        public async Task<IActionResult> GetMilestonesAsync(Guid id)
        {
            var result = await _appService.GetMilestonesAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-panel-data")]
        public async Task<IActionResult> GetPanelDataAsync(Guid id)
        {
            var result = await _appService.GetPanelDataAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-sale-items-data")]
        public async Task<IActionResult> GetSaleItemsDataAsync(Guid id, [FromBody] ProjectProjectGetSaleItemsDataRequestDto input)
        {
            var result = await _appService.GetSaleItemsDataAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/map-tasks")]
        public async Task<IActionResult> MapTasksAsync(Guid id, [FromBody] ProjectProjectMapTasksRequestDto input)
        {
            var result = await _appService.MapTasksAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/message-subscribe")]
        public async Task<IActionResult> MessageSubscribeAsync(Guid id, [FromBody] ProjectProjectMessageSubscribeRequestDto input)
        {
            var result = await _appService.MessageSubscribeAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/message-unsubscribe")]
        public async Task<IActionResult> MessageUnsubscribeAsync(Guid id, [FromBody] ProjectProjectMessageUnsubscribeRequestDto input)
        {
            var result = await _appService.MessageUnsubscribeAsync(id, input);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/project-update-all-action")]
        public async Task<IActionResult> ProjectUpdateAllActionAsync(Guid id)
        {
            var result = await _appService.ProjectUpdateAllActionAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/toggle-favorite")]
        public async Task<IActionResult> ToggleFavoriteAsync(Guid id)
        {
            var result = await _appService.ToggleFavoriteAsync(id);
            return Ok(result);
        }
    }
}