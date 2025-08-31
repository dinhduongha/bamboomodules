using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Event
{
    [Route("api/v1/marketing/EventEvent")]
    public partial class EventEventController : AbpControllerBase
    {
        private readonly IEventEventAppService _appService;
        public EventEventController(IEventEventAppService appService) { _appService = appService; }
    }
}