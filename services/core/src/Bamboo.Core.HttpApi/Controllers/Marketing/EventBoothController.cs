using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Models;
namespace Bamboo.Core.HttpApi.Controllers.EventBoothModule
{
    [Route("api/v1/marketing/EventBooth")]
    public partial class EventBoothController : AbpController
    {
        private readonly IEventBoothAppService _appService;
        public EventBoothController(IEventBoothAppService appService) { _appService = appService; }
    }
}