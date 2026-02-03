using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IProjectProjectAppService : IGenericApplicationService<ProjectProject>
    {
        Task<ProjectProject> BillableTimeButtonAsync(Guid[] ids);
        Task<ProjectProject> CheckFeaturesEnabledAsync(ProjectProjectCheckFeaturesEnabledRequestDto input);
        Task<ProjectProject> CopyDataAsync(ProjectProjectCopyDataRequestDto input);
        Task<ProjectProject> CreateFromTemplateAsync(ProjectProjectCreateFromTemplateRequestDto input);
        Task<ProjectProject> CreateInvoiceAsync(Guid[] ids);
        Task<ProjectProject> CreateTemplateFromProjectAsync(Guid[] ids);
        Task<ProjectProject> CreateTemplateFromProjectUndoCallbackAsync(ProjectProjectCreateTemplateFromProjectUndoCallbackRequestDto input);
        Task<ProjectProject> CustomerPreviewAsync(Guid[] ids);
        Task<ProjectProject> GetCreateEditProjectIdsAsync(Guid[] ids);
        Task<ProjectProject> GetLastUpdateOrDefaultAsync(Guid[] ids);
        Task<ProjectProject> GetListViewAsync(Guid[] ids);
        Task<ProjectProject> GetMilestonesAsync(Guid[] ids);
        Task<ProjectProject> GetPanelDataAsync(Guid[] ids);
        Task<ProjectProject> GetSaleItemsDataAsync(ProjectProjectGetSaleItemsDataRequestDto input);
        Task<ProjectProject> GetTemplateTasksAsync(Guid[] ids);
        Task<ProjectProject> MapTasksAsync(ProjectProjectMapTasksRequestDto input);
        Task<ProjectProject> MessageSubscribeAsync(ProjectProjectMessageSubscribeRequestDto input);
        Task<ProjectProject> MessageUnsubscribeAsync(ProjectProjectMessageUnsubscribeRequestDto input);
        Task<ProjectProject> OpenAllPickingsAsync(Guid[] ids);
        Task<ProjectProject> OpenAnalyticItemsAsync(Guid[] ids);
        Task<ProjectProject> OpenDeliveriesAsync(Guid[] ids);
        Task<ProjectProject> OpenProjectExpensesAsync(Guid[] ids);
        Task<ProjectProject> OpenProjectInvoicesAsync(Guid[] ids);
        Task<ProjectProject> OpenProjectPurchaseOrdersAsync(Guid[] ids);
        Task<ProjectProject> OpenProjectVendorBillsAsync(Guid[] ids);
        Task<ProjectProject> OpenReceiptsAsync(Guid[] ids);
        Task<ProjectProject> OpenShareProjectWizardAsync(Guid[] ids);
        Task<ProjectProject> ProfitabilityItemsAsync(ProjectProjectProfitabilityItemsRequestDto input);
        Task<ProjectProject> ProjectTaskBurndownChartReportAsync(Guid[] ids);
        Task<ProjectProject> ProjectTimesheetsAsync(Guid[] ids);
        Task<ProjectProject> ProjectUpdateAllActionAsync(Guid[] ids);
        Task<ProjectProject> TemplateToProjectConfirmationCallbackAsync(ProjectProjectTemplateToProjectConfirmationCallbackRequestDto input);
        Task<ProjectProject> ToggleFavoriteAsync(Guid[] ids);
        Task<ProjectProject> ToggleProjectTemplateModeAsync(Guid[] ids);
        Task<ProjectProject> UndoConvertToTemplateAsync(Guid[] ids);
        Task<ProjectProject> ViewAllRatingAsync(Guid[] ids);
        Task<ProjectProject> ViewMrpBomAsync(Guid[] ids);
        Task<ProjectProject> ViewMrpProductionAsync(Guid[] ids);
        Task<ProjectProject> ViewSolsAsync(Guid[] ids);
        Task<ProjectProject> ViewSosAsync(Guid[] ids);
        Task<ProjectProject> ViewTasksAnalysisAsync(Guid[] ids);
        Task<ProjectProject> ViewTasksAsync(Guid[] ids);
        Task<ProjectProject> ViewTasksFromProjectMilestoneAsync(Guid[] ids);
        Task<ProjectProject> ViewTimesheetAsync(Guid[] ids);
    }
}