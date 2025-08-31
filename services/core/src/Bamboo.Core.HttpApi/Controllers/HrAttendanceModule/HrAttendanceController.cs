using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.HrAttendanceModule
{
    [Route("api/v1/human-resources/HrAttendance")]
    public partial class HrAttendanceController : AbpControllerBase
    {
        private readonly IHrAttendanceAppService _appService;
        public HrAttendanceController(IHrAttendanceAppService appService) { _appService = appService; }
    }
}