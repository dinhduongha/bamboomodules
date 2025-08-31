using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Event
{
    [Route("api/v1/marketing/EventMail")]
    public partial class EventMailController : AbpControllerBase
    {
        private readonly IEventMailAppService _appService;
        public EventMailController(IEventMailAppService appService) { _appService = appService; }
    }
}