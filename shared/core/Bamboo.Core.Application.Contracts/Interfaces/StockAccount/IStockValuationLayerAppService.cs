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
    public interface IStockValuationLayerAppService : IGenericApplicationService<StockValuationLayer>
    {
        Task<StockValuationLayer> InitAsync(Guid id);
        Task<StockValuationLayer> OpenJournalEntryAsync(Guid id);
        Task<StockValuationLayer> OpenReferenceAsync(Guid id);
        Task<StockValuationLayer> ValuationAtDateAsync(Guid id);
    }
}