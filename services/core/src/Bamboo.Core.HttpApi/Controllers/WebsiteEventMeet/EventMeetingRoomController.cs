using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteEventMeet
{
    [Route("api/v1/marketing/EventMeetingRoom")]
    public partial class EventMeetingRoomController : AbpControllerBase
    {
        private readonly IEventMeetingRoomAppService _appService;
        public EventMeetingRoomController(IEventMeetingRoomAppService appService) { _appService = appService; }
    }
}