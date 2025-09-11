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
    // Category: Productivity/Calendar, Module: calendar
    [Authorize]
    [Route("api/v1/productivity/CalendarRecurrence")]
    public partial class CalendarRecurrenceController : AbpController
    {
        private readonly ICalendarRecurrenceAppService _appService;
        public CalendarRecurrenceController(ICalendarRecurrenceAppService appService) { _appService = appService; }
    }
}