using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Resource
{
    [Route("api/v1/resource/ResourceCalendarAttendance")]
    public partial class ResourceCalendarAttendanceController : AbpControllerBase
    {
        private readonly IResourceCalendarAttendanceAppService _appService;
        public ResourceCalendarAttendanceController(IResourceCalendarAttendanceAppService appService) { _appService = appService; }
    }
}