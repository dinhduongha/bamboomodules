using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.HrHolidays
{
    [Route("api/v1/human-resources/HrLeaveAccrualPlan")]
    public partial class HrLeaveAccrualPlanController : AbpControllerBase
    {
        private readonly IHrLeaveAccrualPlanAppService _appService;
        public HrLeaveAccrualPlanController(IHrLeaveAccrualPlanAppService appService) { _appService = appService; }
    }
}