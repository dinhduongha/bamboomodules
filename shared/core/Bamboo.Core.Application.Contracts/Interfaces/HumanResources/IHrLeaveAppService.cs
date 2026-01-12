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
    public interface IHrLeaveAppService : IGenericApplicationService<HrLeave>
    {
        Task<HrLeave> ActivityUpdateAsync(Guid id);
        Task<HrLeave> AddFollowerAsync(Guid id, HrLeaveAddFollowerRequestDto input);
        Task<HrLeave> ApproveAsync(Guid id, HrLeaveApproveRequestDto input);
        Task<HrLeave> BackToApprovalAsync(Guid id);
        Task<HrLeave> CancelAsync(Guid id);
        Task<HrLeave> CopyDataAsync(Guid id, HrLeaveCopyDataRequestDto input);
        Task<HrLeave> DocumentsAsync(Guid id);
        Task<HrLeave> GetUnusualDaysAsync(Guid id, HrLeaveGetUnusualDaysRequestDto input);
        Task<HrLeave> MessageSubscribeAsync(Guid id, HrLeaveMessageSubscribeRequestDto input);
        Task<HrLeave> OpenPendingRequestsAsync(Guid id);
        Task<HrLeave> RefuseAsync(Guid id);
        Task<HrLeave> ResetConfirmAsync(Guid id);
    }
}