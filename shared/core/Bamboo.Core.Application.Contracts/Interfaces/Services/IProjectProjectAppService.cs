using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IProjectProjectAppService : IGenericApplicationService<ProjectProject>
    {
        Task<ProjectProject> BillableTimeButtonAsync(Guid id);
        Task<ProjectProject> CopyDataAsync(Guid id, ProjectProjectCopyDataRequestDto input);
        Task<ProjectProject> CreateInvoiceAsync(Guid id);
        Task<ProjectProject> CustomerPreviewAsync(Guid id);
        Task<ProjectProject> GetCreateEditProjectIdsAsync(Guid id);
        Task<ProjectProject> GetLastUpdateOrDefaultAsync(Guid id);
        Task<ProjectProject> GetListViewAsync(Guid id);
        Task<ProjectProject> GetMilestonesAsync(Guid id);
        Task<ProjectProject> GetPanelDataAsync(Guid id);
        Task<ProjectProject> GetSaleItemsDataAsync(Guid id, ProjectProjectGetSaleItemsDataRequestDto input);
        Task<ProjectProject> MapTasksAsync(Guid id, ProjectProjectMapTasksRequestDto input);
        Task<ProjectProject> MessageSubscribeAsync(Guid id, ProjectProjectMessageSubscribeRequestDto input);
        Task<ProjectProject> MessageUnsubscribeAsync(Guid id, ProjectProjectMessageUnsubscribeRequestDto input);
        Task<ProjectProject> OpenAllPickingsAsync(Guid id);
        Task<ProjectProject> OpenAnalyticItemsAsync(Guid id);
        Task<ProjectProject> OpenDeliveriesAsync(Guid id);
        Task<ProjectProject> OpenProjectExpensesAsync(Guid id);
        Task<ProjectProject> OpenProjectInvoicesAsync(Guid id);
        Task<ProjectProject> OpenProjectPurchaseOrdersAsync(Guid id);
        Task<ProjectProject> OpenProjectVendorBillsAsync(Guid id);
        Task<ProjectProject> OpenReceiptsAsync(Guid id);
        Task<ProjectProject> OpenShareProjectWizardAsync(Guid id);
        Task<ProjectProject> ProfitabilityItemsAsync(Guid id, ProjectProjectProfitabilityItemsRequestDto input);
        Task<ProjectProject> ProjectTaskBurndownChartReportAsync(Guid id);
        Task<ProjectProject> ProjectTimesheetsAsync(Guid id);
        Task<ProjectProject> ProjectUpdateAllActionAsync(Guid id);
        Task<ProjectProject> ToggleFavoriteAsync(Guid id);
        Task<ProjectProject> ViewAllRatingAsync(Guid id);
        Task<ProjectProject> ViewMrpBomAsync(Guid id);
        Task<ProjectProject> ViewMrpProductionAsync(Guid id);
        Task<ProjectProject> ViewSolsAsync(Guid id);
        Task<ProjectProject> ViewSosAsync(Guid id);
        Task<ProjectProject> ViewTasksAnalysisAsync(Guid id);
        Task<ProjectProject> ViewTasksAsync(Guid id);
        Task<ProjectProject> ViewTimesheetAsync(Guid id);
    }
}