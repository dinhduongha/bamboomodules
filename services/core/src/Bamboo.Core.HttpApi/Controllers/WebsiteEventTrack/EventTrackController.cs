using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteEventTrack
{
    [Route("api/v1/marketing/EventTrack")]
    public partial class EventTrackController : AbpControllerBase
    {
        private readonly IEventTrackAppService _appService;
        public EventTrackController(IEventTrackAppService appService) { _appService = appService; }
    }
}