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
    public interface IStockPickingTypeAppService : IGenericApplicationService<StockPickingType>
    {
        Task<StockPickingType> BatchAsync(Guid[] ids);
        Task<StockPickingType> CopyDataAsync(StockPickingTypeCopyDataRequestDto input);
        Task<StockPickingType> GetMrpStockPickingPickingTypeAsync(Guid[] ids);
        Task<StockPickingType> GetPickingTreeBackorderAsync(Guid[] ids);
        Task<StockPickingType> GetPickingTreeLateAsync(Guid[] ids);
        Task<StockPickingType> GetPickingTreeReadyAsync(Guid[] ids);
        Task<StockPickingType> GetPickingTreeWaitingAsync(Guid[] ids);
        Task<StockPickingType> GetPickingTypeMovesAnalysisAsync(Guid[] ids);
        Task<StockPickingType> GetPickingTypeReadyMovesAsync(Guid[] ids);
        Task<StockPickingType> GetRepairStockPickingPickingTypeAsync(Guid[] ids);
        Task<StockPickingType> GetStockPickingPickingTypeAsync(Guid[] ids);
        Task<StockPickingType> RedirectToBarcodeInstallationAsync(Guid[] ids);
        Task<StockPickingType> WaveAsync(Guid[] ids);
    }
}