using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.HrHolidays
{
    [Route("api/v1/human-resources/HrLeaveAllocation")]
    public partial class HrLeaveAllocationController : AbpControllerBase
    {
        private readonly IHrLeaveAllocationAppService _appService;
        public HrLeaveAllocationController(IHrLeaveAllocationAppService appService) { _appService = appService; }
    }
}