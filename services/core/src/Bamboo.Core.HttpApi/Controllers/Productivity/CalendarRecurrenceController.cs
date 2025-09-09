using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Calendar
{
    [Route("api/v1/productivity/CalendarRecurrence")]
    public partial class CalendarRecurrenceController : AbpController
    {
        private readonly ICalendarRecurrenceAppService _appService;
        public CalendarRecurrenceController(ICalendarRecurrenceAppService appService) { _appService = appService; }
    }
}