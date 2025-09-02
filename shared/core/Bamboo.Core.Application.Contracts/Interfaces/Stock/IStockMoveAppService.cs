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
    public interface IStockMoveAppService : IGenericApplicationService<StockMove>
    {
        Task<StockMove> AddFromCatalogByproductAsync(Guid id);
        Task<StockMove> AddFromCatalogRawAsync(Guid id);
        Task<StockMove> AddFromCatalogRepairAsync(Guid id);
        Task<StockMove> AssignSerialAsync(Guid id);
        Task<StockMove> CopyDataAsync(Guid id, StockMoveCopyDataRequestDto input);
        Task<StockMove> ExplodeAsync(Guid id);
        Task<StockMove> GenerateLotLineValsAsync(Guid id, StockMoveGenerateLotLineValsRequestDto input);
        Task<StockMove> GetAccountMovesAsync(Guid id);
        Task<StockMove> InitAsync(Guid id);
        Task<StockMove> OpenReferenceAsync(Guid id);
        Task<StockMove> ProductForecastReportAsync(Guid id);
        Task<StockMove> ProductPriceUpdateBeforeDoneAsync(Guid id, StockMoveProductPriceUpdateBeforeDoneRequestDto input);
        Task<StockMove> ShowDetailsAsync(Guid id);
        Task<StockMove> ShowSubcontractDetailsAsync(Guid id);
        Task<StockMove> SplitLotsAsync(Guid id, StockMoveSplitLotsRequestDto input);
    }
}