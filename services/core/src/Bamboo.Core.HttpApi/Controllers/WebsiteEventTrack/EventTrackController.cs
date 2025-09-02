using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteEventTrack
{
    [Route("api/v1/marketing/EventTrack")]
    public partial class EventTrackController : AbpControllerBase
    {
        private readonly IEventTrackAppService _appService;
        public EventTrackController(IEventTrackAppService appService) { _appService = appService; }
    }
}