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
    public interface IHrLeaveAllocationAppService : IGenericAppService<HrLeaveAllocation>
    {
        Task<HrLeaveAllocation> ActivityUpdateAsync(Guid[] ids);
        Task<HrLeaveAllocation> AddFollowerAsync(HrLeaveAllocationAddFollowerRequestDto input);
        Task<HrLeaveAllocation> ApproveAsync(Guid[] ids);
        Task<HrLeaveAllocation> MessageSubscribeAsync(HrLeaveAllocationMessageSubscribeRequestDto input);
        Task<HrLeaveAllocation> RefuseAsync(Guid[] ids);
    }
}