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
    public interface IHrDepartmentAppService : IGenericApplicationService<HrDepartment>
    {
        Task<HrDepartment> EmployeeFromDepartmentAsync(Guid id);
        Task<HrDepartment> GetChildrenDepartmentIdsAsync(Guid id);
        Task<HrDepartment> GetDepartmentHierarchyAsync(Guid id);
        Task<HrDepartment> GetFormviewActionAsync(Guid id, HrDepartmentGetFormviewActionRequestDto input);
        Task<HrDepartment> OpenAllocationDepartmentAsync(Guid id);
        Task<HrDepartment> OpenLeaveDepartmentAsync(Guid id);
        Task<HrDepartment> OpenViewChildDepartmentsAsync(Guid id);
        Task<HrDepartment> PlanFromDepartmentAsync(Guid id);
    }
}