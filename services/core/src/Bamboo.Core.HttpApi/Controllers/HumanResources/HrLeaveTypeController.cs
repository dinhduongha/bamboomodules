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
    // Category: Human Resources/Time Off, Module: hr_holidays
    [Authorize]
    [Route("api/v1/human-resources/HrLeaveType")]
    public partial class HrLeaveTypeController : AbpController
    {
        private readonly IHrLeaveTypeAppService _appService;
        public HrLeaveTypeController(IHrLeaveTypeAppService appService) { _appService = appService; }
    }
}