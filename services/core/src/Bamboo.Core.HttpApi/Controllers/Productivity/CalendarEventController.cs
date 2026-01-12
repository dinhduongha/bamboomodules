using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Productivity/Calendar, Module: calendar
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/productivity/CalendarEvent")]
    public partial class CalendarEventController : AbpController
    {
        private readonly ICalendarEventAppService _appService;
        public CalendarEventController(ICalendarEventAppService appService) { _appService = appService; }
    }
}