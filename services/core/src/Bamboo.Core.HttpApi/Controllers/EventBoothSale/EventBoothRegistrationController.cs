using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.EventBoothSale
{
    [Route("api/v1/marketing/EventBoothRegistration")]
    public partial class EventBoothRegistrationController : AbpControllerBase
    {
        private readonly IEventBoothRegistrationAppService _appService;
        public EventBoothRegistrationController(IEventBoothRegistrationAppService appService) { _appService = appService; }
    }
}