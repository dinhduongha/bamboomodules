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
        Task<MrpWorkorder> ButtonFinishAsync(Guid[] ids);
        Task<MrpWorkorder> ButtonPendingAsync(Guid[] ids);
        Task<MrpWorkorder> ButtonScrapAsync(Guid[] ids);
        Task<MrpWorkorder> ButtonStartAsync(MrpWorkorderButtonStartRequestDto input);
        Task<MrpWorkorder> ButtonUnblockAsync(Guid[] ids);
        Task<MrpWorkorder> CancelAsync(Guid[] ids);
        Task<MrpWorkorder> EndAllAsync(Guid[] ids);
        Task<MrpWorkorder> EndPreviousAsync(MrpWorkorderEndPreviousRequestDto input);
        Task<MrpWorkorder> GetDurationAsync(Guid[] ids);
        Task<MrpWorkorder> GetWorkingDurationAsync(Guid[] ids);
        Task<MrpWorkorder> MarkAsDoneAsync(Guid[] ids);
        Task<MrpWorkorder> OpenWizardAsync(Guid[] ids);
        Task<MrpWorkorder> ReplanAsync(Guid[] ids);
        Task<MrpWorkorder> SeeMoveScrapAsync(Guid[] ids);
        Task<MrpWorkorder> SetStateAsync(MrpWorkorderSetStateRequestDto input);
    }
}