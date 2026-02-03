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
    public interface IHrDepartmentAppService : IGenericApplicationService<HrDepartment>
    {
        Task<HrDepartment> EmployeeFromDepartmentAsync(Guid[] ids);
        Task<HrDepartment> GetChildrenDepartmentIdsAsync(Guid[] ids);
        Task<HrDepartment> GetDepartmentHierarchyAsync(Guid[] ids);
        Task<HrDepartment> GetFormviewActionAsync(HrDepartmentGetFormviewActionRequestDto input);
        Task<HrDepartment> OpenAllocationDepartmentAsync(Guid[] ids);
        Task<HrDepartment> OpenLeaveDepartmentAsync(Guid[] ids);
        Task<HrDepartment> OpenViewChildDepartmentsAsync(Guid[] ids);
        Task<HrDepartment> PlanFromDepartmentAsync(Guid[] ids);
    }
}