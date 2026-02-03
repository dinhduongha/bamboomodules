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
    public interface IMrpProductionAppService : IGenericApplicationService<MrpProduction>
    {
        Task<MrpProduction> AssignAsync(Guid[] ids);
        Task<MrpProduction> ButtonMarkDoneAsync(Guid[] ids);
        Task<MrpProduction> ButtonPlanAsync(Guid[] ids);
        Task<MrpProduction> ButtonScrapAsync(Guid[] ids);
        Task<MrpProduction> ButtonUnbuildAsync(Guid[] ids);
        Task<MrpProduction> ButtonUnplanAsync(Guid[] ids);
        Task<MrpProduction> CancelAsync(Guid[] ids);
        Task<MrpProduction> ClearLotProducingIdsAsync(Guid[] ids);
        Task<MrpProduction> ConfirmAsync(Guid[] ids);
        Task<MrpProduction> CopyDataAsync(MrpProductionCopyDataRequestDto input);
        Task<MrpProduction> DoUnreserveAsync(Guid[] ids);
        Task<MrpProduction> GenerateBomAsync(Guid[] ids);
        Task<MrpProduction> GenerateSerialAsync(MrpProductionGenerateSerialRequestDto input);
        Task<MrpProduction> GetEmptyListHelpAsync(MrpProductionGetEmptyListHelpRequestDto input);
        Task<MrpProduction> MergeAsync(Guid[] ids);
        Task<MrpProduction> OpenLabelLayoutAsync(Guid[] ids);
        Task<MrpProduction> OpenLabelTypeAsync(Guid[] ids);
        Task<MrpProduction> PlanWithComponentsAvailabilityAsync(Guid[] ids);
        Task<MrpProduction> PreButtonMarkDoneAsync(Guid[] ids);
        Task<MrpProduction> ProductForecastReportAsync(Guid[] ids);
        Task<MrpProduction> SeeMoveScrapAsync(Guid[] ids);
        Task<MrpProduction> SetQtyProducingAsync(Guid[] ids);
        Task<MrpProduction> SplitAsync(Guid[] ids);
        Task<MrpProduction> SplitSubcontractingAsync(Guid[] ids);
        Task<MrpProduction> StartAsync(Guid[] ids);
        Task<MrpProduction> ToggleIsLockedAsync(Guid[] ids);
        Task<MrpProduction> UpdateBomAsync(Guid[] ids);
        Task<MrpProduction> ViewAnalyticAccountsAsync(Guid[] ids);
        Task<MrpProduction> ViewMoDeliveryAsync(Guid[] ids);
        Task<MrpProduction> ViewMoveWipAsync(Guid[] ids);
        Task<MrpProduction> ViewMrpProductionBackordersAsync(Guid[] ids);
        Task<MrpProduction> ViewMrpProductionChildsAsync(Guid[] ids);
        Task<MrpProduction> ViewMrpProductionSourcesAsync(Guid[] ids);
        Task<MrpProduction> ViewMrpProductionUnbuildsAsync(Guid[] ids);
        Task<MrpProduction> ViewPurchaseOrdersAsync(Guid[] ids);
        Task<MrpProduction> ViewReceptionReportAsync(Guid[] ids);
        Task<MrpProduction> ViewRepairOrdersAsync(Guid[] ids);
        Task<MrpProduction> ViewSaleOrdersAsync(Guid[] ids);
        Task<MrpProduction> ViewSerialNumbersAsync(Guid[] ids);
    }
}