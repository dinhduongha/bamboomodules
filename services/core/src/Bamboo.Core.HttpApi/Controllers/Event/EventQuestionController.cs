using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Event
{
    [Route("api/v1/marketing/EventQuestion")]
    public partial class EventQuestionController : AbpControllerBase
    {
        private readonly IEventQuestionAppService _appService;
        public EventQuestionController(IEventQuestionAppService appService) { _appService = appService; }
    }
}