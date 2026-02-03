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
    public interface IHrLeaveAppService : IGenericAppService<HrLeave>
    {
        Task<HrLeave> ActivityUpdateAsync(Guid[] ids);
        Task<HrLeave> AddFollowerAsync(HrLeaveAddFollowerRequestDto input);
        Task<HrLeave> ApproveAsync(HrLeaveApproveRequestDto input);
        Task<HrLeave> BackToApprovalAsync(Guid[] ids);
        Task<HrLeave> CancelAsync(Guid[] ids);
        Task<HrLeave> CopyDataAsync(HrLeaveCopyDataRequestDto input);
        Task<HrLeave> DocumentsAsync(Guid[] ids);
        Task<HrLeave> GetUnusualDaysAsync(HrLeaveGetUnusualDaysRequestDto input);
        Task<HrLeave> MessageSubscribeAsync(HrLeaveMessageSubscribeRequestDto input);
        Task<HrLeave> OpenPendingRequestsAsync(Guid[] ids);
        Task<HrLeave> RefuseAsync(Guid[] ids);
        Task<HrLeave> ResetConfirmAsync(Guid[] ids);
    }
}