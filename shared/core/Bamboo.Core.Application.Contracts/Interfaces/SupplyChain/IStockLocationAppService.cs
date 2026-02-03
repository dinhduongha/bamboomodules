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
    public interface IStockLocationAppService : IGenericAppService<StockLocation>
    {
        Task<StockLocation> CopyDataAsync(StockLocationCopyDataRequestDto input);
        Task<StockLocation> IsSubcontractAsync(Guid[] ids);
        Task<StockLocation> ShouldBypassReservationAsync(Guid[] ids);
        Task<StockLocation> ViewEquipmentsRecordsAsync(Guid[] ids);
    }
}