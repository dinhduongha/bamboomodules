using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    public partial class HrDepartmentController
    {
        
        [HttpPost]
        [Route("{id}/action-employee-from-department")]
        public async Task<IActionResult> ActionEmployeeFromDepartmentAsync(Guid id)
        {
            var result = await _appService.EmployeeFromDepartmentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-allocation-department")]
        public async Task<IActionResult> ActionOpenAllocationDepartmentAsync(Guid id)
        {
            var result = await _appService.OpenAllocationDepartmentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-leave-department")]
        public async Task<IActionResult> ActionOpenLeaveDepartmentAsync(Guid id)
        {
            var result = await _appService.OpenLeaveDepartmentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-open-view-child-departments")]
        public async Task<IActionResult> ActionOpenViewChildDepartmentsAsync(Guid id)
        {
            var result = await _appService.OpenViewChildDepartmentsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/action-plan-from-department")]
        public async Task<IActionResult> ActionPlanFromDepartmentAsync(Guid id)
        {
            var result = await _appService.PlanFromDepartmentAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-children-department-ids")]
        public async Task<IActionResult> GetChildrenDepartmentIdsAsync(Guid id)
        {
            var result = await _appService.GetChildrenDepartmentIdsAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-department-hierarchy")]
        public async Task<IActionResult> GetDepartmentHierarchyAsync(Guid id)
        {
            var result = await _appService.GetDepartmentHierarchyAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("{id}/get-formview-action")]
        public async Task<IActionResult> GetFormviewActionAsync(Guid id, [FromBody] HrDepartmentGetFormviewActionRequestDto input)
        {
            var result = await _appService.GetFormviewActionAsync(id, input);
            return Ok(result);
        }
    }
}