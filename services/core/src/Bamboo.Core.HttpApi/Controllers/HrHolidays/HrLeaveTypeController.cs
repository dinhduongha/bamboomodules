using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.HrHolidays
{
    [Route("api/v1/human-resources/HrLeaveType")]
    public partial class HrLeaveTypeController : AbpControllerBase
    {
        private readonly IHrLeaveTypeAppService _appService;
        public HrLeaveTypeController(IHrLeaveTypeAppService appService) { _appService = appService; }
    }
}