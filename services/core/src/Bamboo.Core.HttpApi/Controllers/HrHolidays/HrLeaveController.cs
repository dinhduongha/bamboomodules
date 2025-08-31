using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.HrHolidays
{
    [Route("api/v1/human-resources/HrLeave")]
    public partial class HrLeaveController : AbpControllerBase
    {
        private readonly IHrLeaveAppService _appService;
        public HrLeaveController(IHrLeaveAppService appService) { _appService = appService; }
    }
}