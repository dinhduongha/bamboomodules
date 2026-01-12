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
    public interface IMrpWorkorderAppService : IGenericApplicationService<MrpWorkorder>
    {
        Task<MrpWorkorder> ButtonFinishAsync(Guid id);
        Task<MrpWorkorder> ButtonPendingAsync(Guid id);
        Task<MrpWorkorder> ButtonScrapAsync(Guid id);
        Task<MrpWorkorder> ButtonStartAsync(Guid id, MrpWorkorderButtonStartRequestDto input);
        Task<MrpWorkorder> ButtonUnblockAsync(Guid id);
        Task<MrpWorkorder> CancelAsync(Guid id);
        Task<MrpWorkorder> EndAllAsync(Guid id);
        Task<MrpWorkorder> EndPreviousAsync(Guid id, MrpWorkorderEndPreviousRequestDto input);
        Task<MrpWorkorder> GetDurationAsync(Guid id);
        Task<MrpWorkorder> GetWorkingDurationAsync(Guid id);
        Task<MrpWorkorder> MarkAsDoneAsync(Guid id);
        Task<MrpWorkorder> OpenWizardAsync(Guid id);
        Task<MrpWorkorder> ReplanAsync(Guid id);
        Task<MrpWorkorder> SeeMoveScrapAsync(Guid id);
        Task<MrpWorkorder> SetStateAsync(Guid id, MrpWorkorderSetStateRequestDto input);
    }
}