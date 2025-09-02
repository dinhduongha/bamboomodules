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
    public interface IStockPickingTypeAppService : IGenericApplicationService<StockPickingType>
    {
        Task<StockPickingType> BatchAsync(Guid id);
        Task<StockPickingType> CopyDataAsync(Guid id, StockPickingTypeCopyDataRequestDto input);
        Task<StockPickingType> GetMrpStockPickingPickingTypeAsync(Guid id);
        Task<StockPickingType> GetPickingTreeBackorderAsync(Guid id);
        Task<StockPickingType> GetPickingTreeLateAsync(Guid id);
        Task<StockPickingType> GetPickingTreeReadyAsync(Guid id);
        Task<StockPickingType> GetPickingTreeWaitingAsync(Guid id);
        Task<StockPickingType> GetPickingTypeMovesAnalysisAsync(Guid id);
        Task<StockPickingType> GetPickingTypeReadyMovesAsync(Guid id);
        Task<StockPickingType> GetRepairStockPickingPickingTypeAsync(Guid id);
        Task<StockPickingType> GetStockPickingPickingTypeAsync(Guid id);
        Task<StockPickingType> RedirectToBarcodeInstallationAsync(Guid id);
        Task<StockPickingType> RepairOverviewAsync(Guid id);
    }
}