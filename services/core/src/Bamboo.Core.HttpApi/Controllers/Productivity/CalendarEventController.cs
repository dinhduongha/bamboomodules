using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Calendar
{
    [Route("api/v1/productivity/CalendarEvent")]
    public partial class CalendarEventController : AbpController
    {
        private readonly ICalendarEventAppService _appService;
        public CalendarEventController(ICalendarEventAppService appService) { _appService = appService; }
    }
}