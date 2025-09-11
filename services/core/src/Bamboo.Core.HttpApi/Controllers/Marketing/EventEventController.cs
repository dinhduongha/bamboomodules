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
    // Category: Marketing/Events, Module: event
    [Authorize]
    [Route("api/v1/marketing/EventEvent")]
    public partial class EventEventController : AbpController
    {
        private readonly IEventEventAppService _appService;
        public EventEventController(IEventEventAppService appService) { _appService = appService; }
    }
}