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
    public interface IStockQuantAppService : IGenericApplicationService<StockQuant>
    {
        Task<StockQuant> ApplyAllAsync(Guid[] ids);
        Task<StockQuant> ApplyInventoryAsync(StockQuantApplyInventoryRequestDto input);
        Task<StockQuant> CheckLocationIdAsync(Guid[] ids);
        Task<StockQuant> CheckLotIdAsync(Guid[] ids);
        Task<StockQuant> CheckProductIdAsync(Guid[] ids);
        Task<StockQuant> CheckQuantityAsync(Guid[] ids);
        Task<StockQuant> ClearInventoryQuantityAsync(Guid[] ids);
        Task<StockQuant> GetAggregateBarcodesAsync(Guid[] ids);
        Task<StockQuant> GetImportTemplatesAsync(Guid[] ids);
        Task<StockQuant> InventoryHistoryAsync(Guid[] ids);
        Task<StockQuant> MoveQuantsAsync(StockQuantMoveQuantsRequestDto input);
        Task<StockQuant> ResetAsync(Guid[] ids);
        Task<StockQuant> SetInventoryQuantityAsync(Guid[] ids);
        Task<StockQuant> SetInventoryQuantityZeroAsync(Guid[] ids);
        Task<StockQuant> StockQuantRelocateAsync(Guid[] ids);
        Task<StockQuant> ViewInventoryAsync(Guid[] ids);
        Task<StockQuant> ViewOrderpointsAsync(Guid[] ids);
        Task<StockQuant> ViewQuantsAsync(Guid[] ids);
        Task<StockQuant> ViewStockMovesAsync(Guid[] ids);
    }
}