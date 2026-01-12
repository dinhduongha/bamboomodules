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
    public interface IStockMoveAppService : IGenericApplicationService<StockMove>
    {
        Task<StockMove> AddFromCatalogByproductAsync(Guid id);
        Task<StockMove> AddFromCatalogRawAsync(Guid id);
        Task<StockMove> AddFromCatalogRepairAsync(Guid id);
        Task<StockMove> AddPackagesAsync(Guid id);
        Task<StockMove> AdjustValuationAsync(Guid id);
        Task<StockMove> CopyDataAsync(Guid id, StockMoveCopyDataRequestDto input);
        Task<StockMove> ExplodeAsync(Guid id);
        Task<StockMove> GenerateLotLineValsAsync(Guid id, StockMoveGenerateLotLineValsRequestDto input);
        Task<StockMove> OpenReferenceAsync(Guid id);
        Task<StockMove> ProductForecastReportAsync(Guid id);
        Task<StockMove> SearchRemainingQtyAsync(Guid id, StockMoveSearchRemainingQtyRequestDto input);
        Task<StockMove> ShowDetailsAsync(Guid id);
        Task<StockMove> ShowSubcontractDetailsAsync(Guid id, StockMoveShowSubcontractDetailsRequestDto input);
        Task<StockMove> SplitLotsAsync(Guid id, StockMoveSplitLotsRequestDto input);
    }
}