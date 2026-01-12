using Volo.Abp.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces;
namespace Bamboo.Core.HttpApi.Controllers
{
    // Category: Marketing/Events, Module: event
    // Interface only, not yet implemented service layer
    [NonController]
    [Authorize]
    [Route("api/v1/marketing/EventQuestionAnswer")]
    public partial class EventQuestionAnswerController : AbpController
    {
        private readonly IEventQuestionAnswerAppService _appService;
        public EventQuestionAnswerController(IEventQuestionAnswerAppService appService) { _appService = appService; }
    }
}