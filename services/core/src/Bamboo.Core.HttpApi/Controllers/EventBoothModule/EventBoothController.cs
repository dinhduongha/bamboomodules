using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.EventBoothModule
{
    [Route("api/v1/marketing/EventBooth")]
    public partial class EventBoothController : AbpControllerBase
    {
        private readonly IEventBoothAppService _appService;
        public EventBoothController(IEventBoothAppService appService) { _appService = appService; }
    }
}