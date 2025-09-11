using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Human Resources/Attendances, Module: hr_attendance
    [Authorize]
    [Route("api/v1/human-resources/HrAttendanceOvertime")]
    public partial class HrAttendanceOvertimeController : AbpController
    {
        private readonly IHrAttendanceOvertimeAppService _appService;
        public HrAttendanceOvertimeController(IHrAttendanceOvertimeAppService appService) { _appService = appService; }
    }
}