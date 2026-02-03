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
        Task<StockLot> CopyDataAsync(StockLotCopyDataRequestDto input);
        Task<StockLot> GenerateLotNamesAsync(StockLotGenerateLotNamesRequestDto input);
        Task<StockLot> LotOpenQuantsAsync(Guid[] ids);
        Task<StockLot> LotOpenRepairsAsync(Guid[] ids);
        Task<StockLot> LotOpenTransfersAsync(Guid[] ids);
        Task<StockLot> ViewPoAsync(Guid[] ids);
        Task<StockLot> ViewRoAsync(Guid[] ids);
        Task<StockLot> ViewSoAsync(Guid[] ids);
    }
}