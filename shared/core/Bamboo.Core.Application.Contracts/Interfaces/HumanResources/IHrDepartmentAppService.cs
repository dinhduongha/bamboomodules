using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
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