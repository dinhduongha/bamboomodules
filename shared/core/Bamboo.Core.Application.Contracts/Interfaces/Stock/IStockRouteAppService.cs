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
    public interface IStockRouteAppService : IGenericApplicationService<StockRoute>
    {
        Task<StockRoute> CopyDataAsync(Guid id, StockRouteCopyDataRequestDto input);
        Task<StockRoute> ToggleActiveAsync(Guid id);
    }
}