using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bamboo.Core.Application.Contracts.Interfaces;
using Volo.Abp.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.EventBoothModule
{
    [Route("api/v1/marketing/EventBooth")]
    public partial class EventBoothController : AbpControllerBase
    {
        private readonly IEventBoothAppService _appService;
        public EventBoothController(IEventBoothAppService appService) { _appService = appService; }
    }
}