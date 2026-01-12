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
    public interface IStockLocationAppService : IGenericApplicationService<StockLocation>
    {
        Task<StockLocation> CopyDataAsync(Guid id, StockLocationCopyDataRequestDto input);
        Task<StockLocation> IsSubcontractAsync(Guid id);
        Task<StockLocation> ShouldBypassReservationAsync(Guid id);
        Task<StockLocation> ViewEquipmentsRecordsAsync(Guid id);
    }
}