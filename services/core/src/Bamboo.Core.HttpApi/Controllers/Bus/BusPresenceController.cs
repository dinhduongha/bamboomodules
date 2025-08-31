using Bamboo.Core.Models;
using System;
using System.Threading.Tasks;
using Bamboo.Core.Application.Contracts.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace Bamboo.Core.HttpApi.Controllers.Bus
{
    [Route("api/v1/bus/BusPresence")]
    public partial class BusPresenceController : AbpControllerBase
    {
        private readonly IBusPresenceAppService _appService;
        public BusPresenceController(IBusPresenceAppService appService) { _appService = appService; }
    }
}