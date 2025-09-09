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
    public interface IStockLotAppService : IGenericApplicationService<StockLot>
    {
        Task<StockLot> CopyDataAsync(Guid id, StockLotCopyDataRequestDto input);
        Task<StockLot> GenerateLotNamesAsync(Guid id, StockLotGenerateLotNamesRequestDto input);
        Task<StockLot> LotOpenQuantsAsync(Guid id);
        Task<StockLot> LotOpenRepairsAsync(Guid id);
        Task<StockLot> LotOpenTransfersAsync(Guid id);
        Task<StockLot> RevaluationAsync(Guid id);
        Task<StockLot> ViewPoAsync(Guid id);
        Task<StockLot> ViewRoAsync(Guid id);
        Task<StockLot> ViewSoAsync(Guid id);
        Task<StockLot> ViewStockValuationLayersAsync(Guid id);
    }
}