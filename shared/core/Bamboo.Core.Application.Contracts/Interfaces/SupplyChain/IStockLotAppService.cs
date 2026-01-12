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
    public interface IStockLotAppService : IGenericApplicationService<StockLot>
    {
        Task<StockLot> CopyDataAsync(Guid id, StockLotCopyDataRequestDto input);
        Task<StockLot> GenerateLotNamesAsync(Guid id, StockLotGenerateLotNamesRequestDto input);
        Task<StockLot> LotOpenQuantsAsync(Guid id);
        Task<StockLot> LotOpenRepairsAsync(Guid id);
        Task<StockLot> LotOpenTransfersAsync(Guid id);
        Task<StockLot> ViewPoAsync(Guid id);
        Task<StockLot> ViewRoAsync(Guid id);
        Task<StockLot> ViewSoAsync(Guid id);
    }
}