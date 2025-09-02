using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Event
{
    [Route("api/v1/marketing/EventMailRegistration")]
    public partial class EventMailRegistrationController : AbpControllerBase
    {
        private readonly IEventMailRegistrationAppService _appService;
        public EventMailRegistrationController(IEventMailRegistrationAppService appService) { _appService = appService; }
    }
}