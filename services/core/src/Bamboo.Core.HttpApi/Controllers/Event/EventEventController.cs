using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Event
{
    [Route("api/v1/marketing/EventEvent")]
    public partial class EventEventController : AbpControllerBase
    {
        private readonly IEventEventAppService _appService;
        public EventEventController(IEventEventAppService appService) { _appService = appService; }
    }
}