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
    // Category: Marketing/Events, Module: website_event_meet
    [Authorize]
    [Route("api/v1/marketing/EventMeetingRoom")]
    public partial class EventMeetingRoomController : AbpController
    {
        private readonly IEventMeetingRoomAppService _appService;
        public EventMeetingRoomController(IEventMeetingRoomAppService appService) { _appService = appService; }
    }
}