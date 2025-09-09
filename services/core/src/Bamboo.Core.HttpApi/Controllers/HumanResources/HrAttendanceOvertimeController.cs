using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.HrAttendanceModule
{
    [Route("api/v1/human-resources/HrAttendanceOvertime")]
    public partial class HrAttendanceOvertimeController : AbpController
    {
        private readonly IHrAttendanceOvertimeAppService _appService;
        public HrAttendanceOvertimeController(IHrAttendanceOvertimeAppService appService) { _appService = appService; }
    }
}