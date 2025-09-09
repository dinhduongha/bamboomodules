using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Calendar
{
    [Route("api/v1/productivity/CalendarFilters")]
    public partial class CalendarFiltersController : AbpController
    {
        private readonly ICalendarFiltersAppService _appService;
        public CalendarFiltersController(ICalendarFiltersAppService appService) { _appService = appService; }
    }
}