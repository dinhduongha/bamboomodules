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
    public interface IIrActionsServerAppService : IGenericApplicationService<IrActServer>
    {
        Task<IrActServer> CopyDataAsync(Guid id, IrActionsServerCopyDataRequestDto input);
        Task<IrActServer> CreateActionAsync(Guid id);
        Task<IrActServer> HistoryWizardActionAsync(Guid id);
        Task<IrActServer> OpenAutomationAsync(Guid id);
        Task<IrActServer> OpenParentActionAsync(Guid id);
        Task<IrActServer> OpenScheduledActionAsync(Guid id);
        Task<IrActServer> RunAsync(Guid id);
        Task<IrActServer> UnlinkActionAsync(Guid id);
    }
}