using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Marketing/Events, Module: website_event_meet
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/marketing/EventMeetingRoom")]
    public partial class EventMeetingRoomController : AbpController
    {
        private readonly IEventMeetingRoomAppService _appService;
        public EventMeetingRoomController(IEventMeetingRoomAppService appService) { _appService = appService; }
    }
}