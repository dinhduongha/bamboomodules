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
    public interface IIrModelAccessAppService : IGenericApplicationService<IrModelAccess>
    {
        Task<IrModelAccess> CallCacheClearingMethodsAsync(Guid id);
        Task<IrModelAccess> CheckAsync(Guid id, IrModelAccessCheckRequestDto input);
        Task<IrModelAccess> GroupNamesWithAccessAsync(Guid id, IrModelAccessGroupNamesWithAccessRequestDto input);
    }
}