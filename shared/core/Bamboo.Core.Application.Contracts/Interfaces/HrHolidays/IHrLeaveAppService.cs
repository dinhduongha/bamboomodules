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
    public interface IHrLeaveAppService : IGenericApplicationService<HrLeave>
    {
        Task<HrLeave> ActivityUpdateAsync(Guid id);
        Task<HrLeave> AddFollowerAsync(Guid id, HrLeaveAddFollowerRequestDto input);
        Task<HrLeave> ApproveAsync(Guid id, HrLeaveApproveRequestDto input);
        Task<HrLeave> CancelAsync(Guid id);
        Task<HrLeave> ConfirmAsync(Guid id);
        Task<HrLeave> CopyDataAsync(Guid id, HrLeaveCopyDataRequestDto input);
        Task<HrLeave> DocumentsAsync(Guid id);
        Task<HrLeave> GetUnusualDaysAsync(Guid id, HrLeaveGetUnusualDaysRequestDto input);
        Task<HrLeave> MessageSubscribeAsync(Guid id, HrLeaveMessageSubscribeRequestDto input);
        Task<HrLeave> OpenPendingRequestsAsync(Guid id);
        Task<HrLeave> OpenRecordsAsync(Guid id, HrLeaveOpenRecordsRequestDto input);
        Task<HrLeave> RefuseAsync(Guid id);
        Task<HrLeave> ResetConfirmAsync(Guid id);
        Task<HrLeave> ValidateAsync(Guid id, HrLeaveValidateRequestDto input);
    }
}