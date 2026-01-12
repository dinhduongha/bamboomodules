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
        Task<StockQuant> ApplyAllAsync(Guid id);
        Task<StockQuant> ApplyInventoryAsync(Guid id);
        Task<StockQuant> CheckLocationIdAsync(Guid id);
        Task<StockQuant> CheckLotIdAsync(Guid id);
        Task<StockQuant> CheckProductIdAsync(Guid id);
        Task<StockQuant> CheckQuantityAsync(Guid id);
        Task<StockQuant> ClearInventoryQuantityAsync(Guid id);
        Task<StockQuant> GetAggregateBarcodesAsync(Guid id);
        Task<StockQuant> GetImportTemplatesAsync(Guid id);
        Task<StockQuant> InventoryHistoryAsync(Guid id);
        Task<StockQuant> MoveQuantsAsync(Guid id, StockQuantMoveQuantsRequestDto input);
        Task<StockQuant> ResetAsync(Guid id);
        Task<StockQuant> SetInventoryQuantityAsync(Guid id);
        Task<StockQuant> SetInventoryQuantityZeroAsync(Guid id);
        Task<StockQuant> StockQuantRelocateAsync(Guid id);
        Task<StockQuant> ViewInventoryAsync(Guid id);
        Task<StockQuant> ViewOrderpointsAsync(Guid id);
        Task<StockQuant> ViewQuantsAsync(Guid id);
        Task<StockQuant> ViewStockMovesAsync(Guid id);
        Task<StockQuant> WarningDuplicatedSnAsync(Guid id);
    }
}