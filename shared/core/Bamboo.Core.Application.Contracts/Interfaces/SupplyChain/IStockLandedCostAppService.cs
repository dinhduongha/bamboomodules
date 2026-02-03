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
    public interface IStockLandedCostAppService : IGenericAppService<StockLandedCost>
    {
        Task<StockLandedCost> ButtonCancelAsync(Guid[] ids);
        Task<StockLandedCost> ButtonValidateAsync(Guid[] ids);
        Task<StockLandedCost> ComputeLandedCostAsync(Guid[] ids);
        Task<StockLandedCost> GetValuationLinesAsync(Guid[] ids);
    }
}