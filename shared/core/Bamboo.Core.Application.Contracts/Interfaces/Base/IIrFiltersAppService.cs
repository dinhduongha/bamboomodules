using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IIrFiltersAppService : IGenericApplicationService<IrFilters>
    {
        Task<IrFilters> CopyDataAsync(Guid id, IrFiltersCopyDataRequestDto input);
        Task<IrFilters> CreateOrReplaceAsync(Guid id, IrFiltersCreateOrReplaceRequestDto input);
        Task<IrFilters> GetFiltersAsync(Guid id, IrFiltersGetFiltersRequestDto input);
    }
}