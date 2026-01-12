using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Human Resources/Time Off, Module: hr_holidays
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/human-resources/HrLeaveAllocation")]
    public partial class HrLeaveAllocationController : AbpController
    {
        private readonly IHrLeaveAllocationAppService _appService;
        public HrLeaveAllocationController(IHrLeaveAllocationAppService appService) { _appService = appService; }
    }
}