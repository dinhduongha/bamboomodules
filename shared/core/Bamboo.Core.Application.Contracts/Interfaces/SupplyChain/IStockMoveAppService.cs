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
    public interface IStockMoveAppService : IGenericAppService<StockMove>
    {
        Task<StockMove> AddFromCatalogByproductAsync(Guid[] ids);
        Task<StockMove> AddFromCatalogRawAsync(Guid[] ids);
        Task<StockMove> AddFromCatalogRepairAsync(Guid[] ids);
        Task<StockMove> AddPackagesAsync(Guid[] ids);
        Task<StockMove> AdjustValuationAsync(Guid[] ids);
        Task<StockMove> CopyDataAsync(StockMoveCopyDataRequestDto input);
        Task<StockMove> ExplodeAsync(Guid[] ids);
        Task<StockMove> GenerateLotLineValsAsync(StockMoveGenerateLotLineValsRequestDto input);
        Task<StockMove> OpenReferenceAsync(Guid[] ids);
        Task<StockMove> ProductForecastReportAsync(Guid[] ids);
        Task<StockMove> SearchRemainingQtyAsync(StockMoveSearchRemainingQtyRequestDto input);
        Task<StockMove> ShowDetailsAsync(Guid[] ids);
        Task<StockMove> ShowSubcontractDetailsAsync(StockMoveShowSubcontractDetailsRequestDto input);
        Task<StockMove> SplitLotsAsync(StockMoveSplitLotsRequestDto input);
    }
}