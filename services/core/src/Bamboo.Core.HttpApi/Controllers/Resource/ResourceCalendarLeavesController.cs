using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Resource
{
    [Route("api/v1/resource/ResourceCalendarLeaves")]
    public partial class ResourceCalendarLeavesController : AbpControllerBase
    {
        private readonly IResourceCalendarLeavesAppService _appService;
        public ResourceCalendarLeavesController(IResourceCalendarLeavesAppService appService) { _appService = appService; }
    }
}