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
    public interface IHrLeaveAllocationAppService : IGenericApplicationService<HrLeaveAllocation>
    {
        Task<HrLeaveAllocation> ActivityUpdateAsync(Guid id);
        Task<HrLeaveAllocation> AddFollowerAsync(Guid id, HrLeaveAllocationAddFollowerRequestDto input);
        Task<HrLeaveAllocation> ApproveAsync(Guid id);
        Task<HrLeaveAllocation> MessageSubscribeAsync(Guid id, HrLeaveAllocationMessageSubscribeRequestDto input);
        Task<HrLeaveAllocation> RefuseAsync(Guid id);
        Task<HrLeaveAllocation> SetToConfirmAsync(Guid id);
        Task<HrLeaveAllocation> ValidateAsync(Guid id);
    }
}