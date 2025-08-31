using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.EventBoothModule
{
    [Route("api/v1/marketing/EventTypeBooth")]
    public partial class EventTypeBoothController : AbpControllerBase
    {
        private readonly IEventTypeBoothAppService _appService;
        public EventTypeBoothController(IEventTypeBoothAppService appService) { _appService = appService; }
    }
}