using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Calendar
{
    [Route("api/v1/productivity/CalendarRecurrence")]
    public partial class CalendarRecurrenceController : AbpControllerBase
    {
        private readonly ICalendarRecurrenceAppService _appService;
        public CalendarRecurrenceController(ICalendarRecurrenceAppService appService) { _appService = appService; }
    }
}