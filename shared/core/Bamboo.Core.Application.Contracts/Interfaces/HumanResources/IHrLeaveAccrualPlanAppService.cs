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
    public interface IHrLeaveAccrualPlanAppService : IGenericAppService<HrLeaveAccrualPlan>
    {
        Task<HrLeaveAccrualPlan> CopyDataAsync(HrLeaveAccrualPlanCopyDataRequestDto input);
        Task<HrLeaveAccrualPlan> CreateAccrualPlanLevelAsync(Guid[] ids);
        Task<HrLeaveAccrualPlan> OpenAccrualPlanEmployeesAsync(Guid[] ids);
        Task<HrLeaveAccrualPlan> OpenAccrualPlanLevelAsync(HrLeaveAccrualPlanOpenAccrualPlanLevelRequestDto input);
    }
}