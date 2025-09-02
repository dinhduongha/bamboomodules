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
    public interface IHrLeaveTypeAppService : IGenericApplicationService<HrLeaveType>
    {
        Task<HrLeaveType> CheckAllocationRequirementEditValidityAsync(Guid id);
        Task<HrLeaveType> CopyDataAsync(Guid id, HrLeaveTypeCopyDataRequestDto input);
        Task<HrLeaveType> GetAllocationDataAsync(Guid id, HrLeaveTypeGetAllocationDataRequestDto input);
        Task<HrLeaveType> GetAllocationDataRequestAsync(Guid id, HrLeaveTypeGetAllocationDataRequestRequestDto input);
        Task<HrLeaveType> HasAccrualAllocationAsync(Guid id);
        Task<HrLeaveType> RequestedDisplayNameAsync(Guid id);
        Task<HrLeaveType> SeeAccrualPlansAsync(Guid id);
        Task<HrLeaveType> SeeDaysAllocatedAsync(Guid id);
        Task<HrLeaveType> SeeGroupLeavesAsync(Guid id);
    }
}