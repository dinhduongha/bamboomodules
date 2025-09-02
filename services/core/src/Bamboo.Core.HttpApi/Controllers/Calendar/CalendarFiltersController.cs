using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Calendar
{
    [Route("api/v1/productivity/CalendarFilters")]
    public partial class CalendarFiltersController : AbpControllerBase
    {
        private readonly ICalendarFiltersAppService _appService;
        public CalendarFiltersController(ICalendarFiltersAppService appService) { _appService = appService; }
    }
}