using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.HrHolidays
{
    [Route("api/v1/human-resources/HrLeaveType")]
    public partial class HrLeaveTypeController : AbpControllerBase
    {
        private readonly IHrLeaveTypeAppService _appService;
        public HrLeaveTypeController(IHrLeaveTypeAppService appService) { _appService = appService; }
    }
}