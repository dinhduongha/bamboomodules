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
    // Category: Marketing/Events, Module: event_booth
    [Authorize]
    [Route("api/v1/marketing/EventTypeBooth")]
    public partial class EventTypeBoothController : AbpController
    {
        private readonly IEventTypeBoothAppService _appService;
        public EventTypeBoothController(IEventTypeBoothAppService appService) { _appService = appService; }
    }
}