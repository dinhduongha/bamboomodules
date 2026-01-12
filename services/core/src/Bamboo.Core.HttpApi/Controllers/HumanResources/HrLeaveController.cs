using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Human Resources/Time Off, Module: hr_holidays
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/human-resources/HrLeave")]
    public partial class HrLeaveController : AbpController
    {
        private readonly IHrLeaveAppService _appService;
        public HrLeaveController(IHrLeaveAppService appService) { _appService = appService; }
    }
}