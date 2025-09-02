using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.HrAttendanceModule
{
    [Route("api/v1/human-resources/HrAttendanceOvertime")]
    public partial class HrAttendanceOvertimeController : AbpControllerBase
    {
        private readonly IHrAttendanceOvertimeAppService _appService;
        public HrAttendanceOvertimeController(IHrAttendanceOvertimeAppService appService) { _appService = appService; }
    }
}