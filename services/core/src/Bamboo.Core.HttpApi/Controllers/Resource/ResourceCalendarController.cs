using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Resource
{
    [Route("api/v1/resource/ResourceCalendar")]
    public partial class ResourceCalendarController : AbpControllerBase
    {
        private readonly IResourceCalendarAppService _appService;
        public ResourceCalendarController(IResourceCalendarAppService appService) { _appService = appService; }
    }
}