using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Event
{
    [Route("api/v1/marketing/EventRegistration")]
    public partial class EventRegistrationController : AbpControllerBase
    {
        private readonly IEventRegistrationAppService _appService;
        public EventRegistrationController(IEventRegistrationAppService appService) { _appService = appService; }
    }
}