using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.WebsiteEventMeet
{
    [Route("api/v1/marketing/EventMeetingRoom")]
    public partial class EventMeetingRoomController : AbpControllerBase
    {
        private readonly IEventMeetingRoomAppService _appService;
        public EventMeetingRoomController(IEventMeetingRoomAppService appService) { _appService = appService; }
    }
}