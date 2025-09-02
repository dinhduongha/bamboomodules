using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.HrHolidays
{
    [Route("api/v1/human-resources/HrLeave")]
    public partial class HrLeaveController : AbpControllerBase
    {
        private readonly IHrLeaveAppService _appService;
        public HrLeaveController(IHrLeaveAppService appService) { _appService = appService; }
    }
}