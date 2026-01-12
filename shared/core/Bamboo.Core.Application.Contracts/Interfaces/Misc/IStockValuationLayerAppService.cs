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
    public interface IStockValuationLayerAppService : IGenericApplicationService<StockValuationLayer>
    {
        Task<StockValuationLayer> InitAsync(Guid id);
        Task<StockValuationLayer> OpenJournalEntryAsync(Guid id);
        Task<StockValuationLayer> OpenReferenceAsync(Guid id);
        Task<StockValuationLayer> ValuationAtDateAsync(Guid id);
    }
}