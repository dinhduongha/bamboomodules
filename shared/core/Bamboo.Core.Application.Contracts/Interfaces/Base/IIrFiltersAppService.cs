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
    public interface IIrFiltersAppService : IGenericApplicationService<IrFilters>
    {
        Task<IrFilters> CopyDataAsync(Guid id, IrFiltersCopyDataRequestDto input);
        Task<IrFilters> CreateFilterAsync(Guid id, IrFiltersCreateFilterRequestDto input);
        Task<IrFilters> GetFiltersAsync(Guid id, IrFiltersGetFiltersRequestDto input);
    }
}