using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Calendar
{
    [Route("api/v1/productivity/CalendarAttendee")]
    public partial class CalendarAttendeeController : AbpControllerBase
    {
        private readonly ICalendarAttendeeAppService _appService;
        public CalendarAttendeeController(ICalendarAttendeeAppService appService) { _appService = appService; }
    }
}