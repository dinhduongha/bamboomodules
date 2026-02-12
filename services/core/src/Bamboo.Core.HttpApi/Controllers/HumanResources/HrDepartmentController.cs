using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.HttpApi.Controllers
{
    [NonController]
    [Authorize]
    [Route("api/v1/human-resources/HrDepartment")]
    public partial class HrDepartmentController : AbpController
    {
        protected readonly IHrDepartmentAppService _appService;
        public HrDepartmentController(IHrDepartmentAppService appService) { _appService = appService; }
        
        
        [HttpPost]
        [Route("action-employee-from-department")]
        public async Task<IActionResult> EmployeeFromDepartmentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.EmployeeFromDepartmentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-allocation-department")]
        public async Task<IActionResult> OpenAllocationDepartmentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenAllocationDepartmentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-leave-department")]
        public async Task<IActionResult> OpenLeaveDepartmentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenLeaveDepartmentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-open-view-child-departments")]
        public async Task<IActionResult> OpenViewChildDepartmentsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.OpenViewChildDepartmentsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("action-plan-from-department")]
        public async Task<IActionResult> PlanFromDepartmentAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.PlanFromDepartmentAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-children-department-ids")]
        public async Task<IActionResult> GetChildrenDepartmentIdsAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetChildrenDepartmentIdsAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-department-hierarchy")]
        public async Task<IActionResult> GetDepartmentHierarchyAsync([FromBody] Guid[] ids)
        {
            var result = await _appService.GetDepartmentHierarchyAsync(ids);
            return Ok(result);
        }
        
        [HttpPost]
        [Route("get-formview-action")]
        public async Task<IActionResult> GetFormviewActionAsync([FromBody] HrDepartmentGetFormviewActionRequestDto input)
        {
            var result = await _appService.GetFormviewActionAsync(input);
            return Ok(result);
        }
    }
    
}