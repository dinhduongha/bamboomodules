using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.HrAttendanceModule
{
    [Route("api/v1/human-resources/HrAttendance")]
    public partial class HrAttendanceController : AbpControllerBase
    {
        private readonly IHrAttendanceAppService _appService;
        public HrAttendanceController(IHrAttendanceAppService appService) { _appService = appService; }
    }
}