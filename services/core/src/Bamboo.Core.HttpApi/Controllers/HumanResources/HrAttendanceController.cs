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
    // Category: Human Resources/Attendances, Module: hr_attendance
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/human-resources/HrAttendance")]
    public partial class HrAttendanceController : AbpController
    {
        private readonly IHrAttendanceAppService _appService;
        public HrAttendanceController(IHrAttendanceAppService appService) { _appService = appService; }
    }
}