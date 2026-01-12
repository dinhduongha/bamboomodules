using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Marketing/Events, Module: event_booth_sale
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/marketing/EventBoothRegistration")]
    public partial class EventBoothRegistrationController : AbpController
    {
        private readonly IEventBoothRegistrationAppService _appService;
        public EventBoothRegistrationController(IEventBoothRegistrationAppService appService) { _appService = appService; }
    }
}