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
    public interface IStockLandedCostAppService : IGenericApplicationService<StockLandedCost>
    {
        Task<StockLandedCost> ButtonCancelAsync(Guid id);
        Task<StockLandedCost> ButtonValidateAsync(Guid id);
        Task<StockLandedCost> ComputeLandedCostAsync(Guid id);
        Task<StockLandedCost> GetValuationLinesAsync(Guid id);
        Task<StockLandedCost> ReconcileLandedCostAsync(Guid id);
        Task<StockLandedCost> ViewStockValuationLayersAsync(Guid id);
    }
}