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
    [Route("api/v1/human-resources/HrLeaveAccrualPlan")]
    public partial class HrLeaveAccrualPlanController : AbpController
    {
        private readonly IHrLeaveAccrualPlanAppService _appService;
        public HrLeaveAccrualPlanController(IHrLeaveAccrualPlanAppService appService) { _appService = appService; }
    }
}