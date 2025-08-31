using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Calendar
{
    [Route("api/v1/productivity/CalendarFilters")]
    public partial class CalendarFiltersController : AbpControllerBase
    {
        private readonly ICalendarFiltersAppService _appService;
        public CalendarFiltersController(ICalendarFiltersAppService appService) { _appService = appService; }
    }
}