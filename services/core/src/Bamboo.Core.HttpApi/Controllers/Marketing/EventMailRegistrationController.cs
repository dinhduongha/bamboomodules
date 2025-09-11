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
    [Route("api/v1/marketing/EventMailRegistration")]
    public partial class EventMailRegistrationController : AbpController
    {
        private readonly IEventMailRegistrationAppService _appService;
        public EventMailRegistrationController(IEventMailRegistrationAppService appService) { _appService = appService; }
    }
}