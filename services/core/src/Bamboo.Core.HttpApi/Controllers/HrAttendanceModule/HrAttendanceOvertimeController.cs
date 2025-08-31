using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.HrAttendanceModule
{
    [Route("api/v1/human-resources/HrAttendanceOvertime")]
    public partial class HrAttendanceOvertimeController : AbpControllerBase
    {
        private readonly IHrAttendanceOvertimeAppService _appService;
        public HrAttendanceOvertimeController(IHrAttendanceOvertimeAppService appService) { _appService = appService; }
    }
}