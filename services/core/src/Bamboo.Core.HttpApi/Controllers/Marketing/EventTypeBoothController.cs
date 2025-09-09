using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.EventBoothModule
{
    [Route("api/v1/marketing/EventTypeBooth")]
    public partial class EventTypeBoothController : AbpController
    {
        private readonly IEventTypeBoothAppService _appService;
        public EventTypeBoothController(IEventTypeBoothAppService appService) { _appService = appService; }
    }
}