using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.EventBoothModule
{
    [Route("api/v1/marketing/EventTypeBooth")]
    public partial class EventTypeBoothController : AbpControllerBase
    {
        private readonly IEventTypeBoothAppService _appService;
        public EventTypeBoothController(IEventTypeBoothAppService appService) { _appService = appService; }
    }
}