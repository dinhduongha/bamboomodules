using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.EventBoothSale
{
    [Route("api/v1/marketing/EventBoothRegistration")]
    public partial class EventBoothRegistrationController : AbpControllerBase
    {
        private readonly IEventBoothRegistrationAppService _appService;
        public EventBoothRegistrationController(IEventBoothRegistrationAppService appService) { _appService = appService; }
    }
}