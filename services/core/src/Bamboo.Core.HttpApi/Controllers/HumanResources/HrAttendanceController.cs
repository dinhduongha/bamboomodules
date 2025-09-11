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
    [Route("api/v1/human-resources/HrAttendance")]
    public partial class HrAttendanceController : AbpController
    {
        private readonly IHrAttendanceAppService _appService;
        public HrAttendanceController(IHrAttendanceAppService appService) { _appService = appService; }
    }
}