using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Event
{
    [Route("api/v1/marketing/EventMail")]
    public partial class EventMailController : AbpController
    {
        private readonly IEventMailAppService _appService;
        public EventMailController(IEventMailAppService appService) { _appService = appService; }
    }
}