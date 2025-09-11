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
    // Category: Marketing/Events, Module: event_booth_sale
    [Authorize]
    [Route("api/v1/marketing/EventBoothRegistration")]
    public partial class EventBoothRegistrationController : AbpController
    {
        private readonly IEventBoothRegistrationAppService _appService;
        public EventBoothRegistrationController(IEventBoothRegistrationAppService appService) { _appService = appService; }
    }
}