using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.HrHolidays
{
    [Route("api/v1/human-resources/HrLeave")]
    public partial class HrLeaveController : AbpController
    {
        private readonly IHrLeaveAppService _appService;
        public HrLeaveController(IHrLeaveAppService appService) { _appService = appService; }
    }
}