using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Resource
{
    [Route("api/v1/resource/ResourceCalendar")]
    public partial class ResourceCalendarController : AbpController
    {
        private readonly IResourceCalendarAppService _appService;
        public ResourceCalendarController(IResourceCalendarAppService appService) { _appService = appService; }
    }
}