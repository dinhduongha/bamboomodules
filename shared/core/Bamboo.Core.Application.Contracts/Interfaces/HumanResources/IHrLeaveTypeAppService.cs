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
    public interface IHrLeaveTypeAppService : IGenericAppService<HrLeaveType>
    {
        Task<HrLeaveType> CheckAllocationRequirementEditValidityAsync(Guid[] ids);
        Task<HrLeaveType> CopyDataAsync(HrLeaveTypeCopyDataRequestDto input);
        Task<HrLeaveType> GetAllocationDataAsync(HrLeaveTypeGetAllocationDataRequestDto input);
        Task<HrLeaveType> GetAllocationDataRequestAsync(HrLeaveTypeGetAllocationDataRequestRequestDto input);
        Task<HrLeaveType> HasAccrualAllocationAsync(Guid[] ids);
        Task<HrLeaveType> RequestedDisplayNameAsync(Guid[] ids);
        Task<HrLeaveType> SeeAccrualPlansAsync(Guid[] ids);
        Task<HrLeaveType> SeeDaysAllocatedAsync(Guid[] ids);
        Task<HrLeaveType> SeeGroupLeavesAsync(Guid[] ids);
    }
}