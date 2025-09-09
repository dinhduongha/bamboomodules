using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.Event
{
    [Route("api/v1/marketing/EventQuestion")]
    public partial class EventQuestionController : AbpController
    {
        private readonly IEventQuestionAppService _appService;
        public EventQuestionController(IEventQuestionAppService appService) { _appService = appService; }
    }
}