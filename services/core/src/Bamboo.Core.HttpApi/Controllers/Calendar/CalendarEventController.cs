using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Calendar
{
    [Route("api/v1/productivity/CalendarEvent")]
    public partial class CalendarEventController : AbpControllerBase
    {
        private readonly ICalendarEventAppService _appService;
        public CalendarEventController(ICalendarEventAppService appService) { _appService = appService; }
    }
}