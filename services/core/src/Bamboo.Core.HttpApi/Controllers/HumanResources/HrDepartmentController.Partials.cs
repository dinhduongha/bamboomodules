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
        [Route("action-employee-from-department")]
        public async Task<IActionResult> ActionEmployeeFromDepartmentAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.EmployeeFromDepartmentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-allocation-department")]
        public async Task<IActionResult> ActionOpenAllocationDepartmentAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenAllocationDepartmentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-leave-department")]
        public async Task<IActionResult> ActionOpenLeaveDepartmentAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenLeaveDepartmentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-view-child-departments")]
        public async Task<IActionResult> ActionOpenViewChildDepartmentsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.OpenViewChildDepartmentsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-plan-from-department")]
        public async Task<IActionResult> ActionPlanFromDepartmentAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.PlanFromDepartmentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-children-department-ids")]
        public async Task<IActionResult> GetChildrenDepartmentIdsAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetChildrenDepartmentIdsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-department-hierarchy")]
        public async Task<IActionResult> GetDepartmentHierarchyAsync(Guid[] ids)
        {
            // content_action has_extra_params: False
            var result = await _appService.GetDepartmentHierarchyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-formview-action")]
        public async Task<IActionResult> GetFormviewActionAsync(HrDepartmentGetFormviewActionRequestDto input)
        {
            // content_action has_extra_params: True
            var result = await _appService.GetFormviewActionAsync(input);
            return Ok(result);
        }
    }
}