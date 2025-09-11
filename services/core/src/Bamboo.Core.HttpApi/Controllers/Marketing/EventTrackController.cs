using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Marketing, Module: website_event_track
    [Authorize]
    [Route("api/v1/marketing/EventTrack")]
    public partial class EventTrackController : AbpController
    {
        private readonly IEventTrackAppService _appService;
        public EventTrackController(IEventTrackAppService appService) { _appService = appService; }
    }
}