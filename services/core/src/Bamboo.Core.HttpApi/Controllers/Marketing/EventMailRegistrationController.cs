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
    // Category: Marketing/Events, Module: event
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/marketing/EventMailRegistration")]
    public partial class EventMailRegistrationController : AbpController
    {
        private readonly IEventMailRegistrationAppService _appService;
        public EventMailRegistrationController(IEventMailRegistrationAppService appService) { _appService = appService; }
    }
}