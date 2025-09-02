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
    public interface IIrActionsServerAppService : IGenericApplicationService<IrActServer>
    {
        Task<IrActServer> CopyDataAsync(Guid id, IrActionsServerCopyDataRequestDto input);
        Task<IrActServer> CreateActionAsync(Guid id);
        Task<IrActServer> RunAsync(Guid id);
        Task<IrActServer> UnlinkActionAsync(Guid id);
    }
}