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
    public interface IIrActionsServerAppService : IGenericAppService<IrActServer>
    {
        Task<IrActServer> CopyDataAsync(IrActionsServerCopyDataRequestDto input);
        Task<IrActServer> CreateActionAsync(Guid[] ids);
        Task<IrActServer> HistoryWizardActionAsync(Guid[] ids);
        Task<IrActServer> OpenAutomationAsync(Guid[] ids);
        Task<IrActServer> OpenParentActionAsync(Guid[] ids);
        Task<IrActServer> OpenScheduledActionAsync(Guid[] ids);
        Task<IrActServer> RunAsync(Guid[] ids);
        Task<IrActServer> UnlinkActionAsync(Guid[] ids);
    }
}