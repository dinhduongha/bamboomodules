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
    public interface IStockLandedCostAppService : IGenericApplicationService<StockLandedCost>
    {
        Task<StockLandedCost> ButtonCancelAsync(Guid id);
        Task<StockLandedCost> ButtonValidateAsync(Guid id);
        Task<StockLandedCost> ComputeLandedCostAsync(Guid id);
        Task<StockLandedCost> GetValuationLinesAsync(Guid id);
    }
}