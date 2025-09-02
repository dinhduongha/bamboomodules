using Bamboo.Core.Application.Contracts.DTOs;
using Volo.Abp.Application.Services;
using System.Linq;
using System.Collections.Generic;
using System;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Models;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IMrpProductionAppService : IGenericApplicationService<MrpProduction>
    {
        Task<MrpProduction> AssignAsync(Guid id);
        Task<MrpProduction> ButtonMarkDoneAsync(Guid id);
        Task<MrpProduction> ButtonPlanAsync(Guid id);
        Task<MrpProduction> ButtonScrapAsync(Guid id);
        Task<MrpProduction> ButtonUnbuildAsync(Guid id);
        Task<MrpProduction> ButtonUnplanAsync(Guid id);
        Task<MrpProduction> CancelAsync(Guid id);
        Task<MrpProduction> ConfirmAsync(Guid id);
        Task<MrpProduction> CopyDataAsync(Guid id, MrpProductionCopyDataRequestDto input);
        Task<MrpProduction> DoUnreserveAsync(Guid id);
        Task<MrpProduction> GenerateBomAsync(Guid id);
        Task<MrpProduction> GenerateSerialAsync(Guid id);
        Task<MrpProduction> GetEmptyListHelpAsync(Guid id, MrpProductionGetEmptyListHelpRequestDto input);
        Task<MrpProduction> GetLinkedSaleOrdersAsync(Guid id);
        Task<MrpProduction> MassProduceAsync(Guid id);
        Task<MrpProduction> MergeAsync(Guid id);
        Task<MrpProduction> OpenLabelLayoutAsync(Guid id);
        Task<MrpProduction> OpenLabelTypeAsync(Guid id);
        Task<MrpProduction> PlanWithComponentsAvailabilityAsync(Guid id);
        Task<MrpProduction> PreButtonMarkDoneAsync(Guid id);
        Task<MrpProduction> ProductForecastReportAsync(Guid id);
        Task<MrpProduction> SeeMoveScrapAsync(Guid id);
        Task<MrpProduction> SetQtyProducingAsync(Guid id);
        Task<MrpProduction> SplitAsync(Guid id);
        Task<MrpProduction> StartAsync(Guid id);
        Task<MrpProduction> SubcontractingRecordComponentAsync(Guid id);
        Task<MrpProduction> ToggleIsLockedAsync(Guid id);
        Task<MrpProduction> UpdateBomAsync(Guid id);
        Task<MrpProduction> ViewAnalyticAccountsAsync(Guid id);
        Task<MrpProduction> ViewMoDeliveryAsync(Guid id);
        Task<MrpProduction> ViewMrpProductionBackordersAsync(Guid id);
        Task<MrpProduction> ViewMrpProductionChildsAsync(Guid id);
        Task<MrpProduction> ViewMrpProductionSourcesAsync(Guid id);
        Task<MrpProduction> ViewMrpProductionUnbuildsAsync(Guid id);
        Task<MrpProduction> ViewPurchaseOrdersAsync(Guid id);
        Task<MrpProduction> ViewReceptionReportAsync(Guid id);
        Task<MrpProduction> ViewRepairOrdersAsync(Guid id);
        Task<MrpProduction> ViewSaleOrdersAsync(Guid id);
        Task<MrpProduction> ViewStockValuationLayersAsync(Guid id);
    }
}