using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Event
{
    [Route("api/v1/marketing/EventMailRegistration")]
    public partial class EventMailRegistrationController : AbpControllerBase
    {
        private readonly IEventMailRegistrationAppService _appService;
        public EventMailRegistrationController(IEventMailRegistrationAppService appService) { _appService = appService; }
    }
}