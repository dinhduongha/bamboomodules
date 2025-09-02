using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Resource
{
    [Route("api/v1/resource/ResourceCalendar")]
    public partial class ResourceCalendarController : AbpControllerBase
    {
        private readonly IResourceCalendarAppService _appService;
        public ResourceCalendarController(IResourceCalendarAppService appService) { _appService = appService; }
    }
}