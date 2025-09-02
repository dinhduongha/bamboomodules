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
    public interface IHrLeaveAccrualPlanAppService : IGenericApplicationService<HrLeaveAccrualPlan>
    {
        Task<HrLeaveAccrualPlan> CopyDataAsync(Guid id, HrLeaveAccrualPlanCopyDataRequestDto input);
        Task<HrLeaveAccrualPlan> OpenAccrualPlanEmployeesAsync(Guid id);
    }
}