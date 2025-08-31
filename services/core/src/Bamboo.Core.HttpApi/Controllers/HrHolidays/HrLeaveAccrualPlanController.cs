using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.HrHolidays
{
    [Route("api/v1/human-resources/HrLeaveAccrualPlan")]
    public partial class HrLeaveAccrualPlanController : AbpControllerBase
    {
        private readonly IHrLeaveAccrualPlanAppService _appService;
        public HrLeaveAccrualPlanController(IHrLeaveAccrualPlanAppService appService) { _appService = appService; }
    }
}