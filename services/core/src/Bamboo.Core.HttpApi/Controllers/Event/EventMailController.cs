using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Event
{
    [Route("api/v1/marketing/EventMail")]
    public partial class EventMailController : AbpControllerBase
    {
        private readonly IEventMailAppService _appService;
        public EventMailController(IEventMailAppService appService) { _appService = appService; }
    }
}