using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.EventBoothSale
{
    [Route("api/v1/marketing/EventBoothRegistration")]
    public partial class EventBoothRegistrationController : AbpController
    {
        private readonly IEventBoothRegistrationAppService _appService;
        public EventBoothRegistrationController(IEventBoothRegistrationAppService appService) { _appService = appService; }
    }
}